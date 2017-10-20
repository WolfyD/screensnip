using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class f_Canvas : Form
	{
		public Size bounds { get; set; }
		public Bitmap bmp { get; set; }
		public Bitmap edge;
		public Bitmap retImg { get; set; }
		public int mode { get; set; }
		public Image Image { get; set; }

		private Rectangle rcSelect = new Rectangle();
		private Point pntStart;
		private Rectangle cut = new Rectangle(-1, -1, -1, -1);
		private List<Point> cut_points = new List<Point>();

		bool mdown = false;
		Color bgc = new Color();
		int transparency = 100;

		Color magicSelectColor = new Color();
		Point magicSelectPoint = new Point(-1, -1);
		List<Point> magicSelectPixels = new List<Point>();
		List<Point> magicUnSelectPixels = new List<Point>();
		Bitmap brect = new Bitmap(100, 100);

		public f_Canvas()
		{
			InitializeComponent();

			Load += F_Canvas_Load;
		}

		private void F_Canvas_Load(object sender, EventArgs e)
		{
			Location = new Point(0, 0);
			Size = bounds;

			BackgroundImage = bmp;
			if(mode == 4)
			{
				//edge = bmp.filter(true);
			    //BackgroundImage = edge;
			}

			bgc = Properties.Settings.Default.s_CanvasColor;
			transparency = 255 / (100 / (int)(Properties.Settings.Default.s_CanvasTransparency * 100));
		}

		public int distance(Point p1, Point p2)
		{
			int ret = 0;

			int x = (int)Math.Pow((p2.X - p1.X), 2.0d);
			int y = (int)Math.Pow((p2.Y - p1.Y), 2.0d);

			ret = (int)Math.Sqrt((x + y));

			return ret;
		}

		public int colorDistance(Color c1, Color c2)
		{
			int ret = 0;

			ret = (c1.R + c1.G + c1.B) - (c2.R + c2.G + c2.B);

			return ret;
		}

		public static Image Snip()
		{
			var rc = Screen.PrimaryScreen.Bounds;
			using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
			{
				using (Graphics gr = Graphics.FromImage(bmp))
					gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
				using (var snipper = new f_Canvas() { bounds = new Size(100, 100), bmp = new Bitmap(1, 1) })
				{
					if (snipper.ShowDialog() == DialogResult.OK)
					{
						return snipper.Image;
					}
				}
				return null;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			// Start the snip on mouse down
			if (e.Button != MouseButtons.Left) {  return; }
			if (mode == 0)
			{
				pntStart = e.Location;
				rcSelect = new Rectangle(e.Location, new Size(0, 0));
				this.Invalidate();
			}
			else if (mode == 1 || mode == 2)
			{
				cut_points.Add(e.Location);

				foreach (Point p in cut_points)
				{
					if (p.X < cut.X || cut.X == -1) { cut.X = p.X; }
					if (p.Y < cut.Y || cut.Y == -1) { cut.Y = p.Y; }
					if (p.X > cut.X + cut.Width) { cut.Width = p.X - cut.X; }
					if (p.Y > cut.Y + cut.Height) { cut.Height = p.Y - cut.Y; }
				}
				mdown = true;
			}
			else if (mode == 4)
			{
				//TODO: MAGIC
				cut_points.Add(e.Location);

				foreach (Point p in cut_points)
				{
					if (p.X < cut.X || cut.X == -1) { cut.X = p.X; }
					if (p.Y < cut.Y || cut.Y == -1) { cut.Y = p.Y; }
					if (p.X > cut.X + cut.Width) { cut.Width = p.X - cut.X; }
					if (p.Y > cut.Y + cut.Height) { cut.Height = p.Y - cut.Y; }
				}
				mdown = true;
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			// Modify the selection on mouse move
			if (mode == 0)
			{
				if (e.Button != MouseButtons.Left) return;
				int x1 = Math.Min(e.X, pntStart.X);
				int y1 = Math.Min(e.Y, pntStart.Y);
				int x2 = Math.Max(e.X, pntStart.X);
				int y2 = Math.Max(e.Y, pntStart.Y);
				rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
				this.Invalidate();
			}
			else if (mode == 1)
			{

			}
			else if (mode == 2)
			{
				if (mdown)
				{
					cut_points.Add(e.Location);

					int minx = cut_points.Min(x => x.X);
					int maxx = cut_points.Max(x => x.X);
					int miny = cut_points.Min(y => y.Y);
					int maxy = cut_points.Max(y => y.Y);

					cut.X = minx;
					cut.Y = miny;
					cut.Width = maxx - minx;
					cut.Height = maxy - miny;
				}

			}
			else if (mode == 4)
			{
				if (mdown)
				{
					Point pnt = e.Location;

					List<Point> pnts = new List<Point>();

					brect = new Bitmap(75,75);
					using(Graphics g = Graphics.FromImage(brect))
					{
						g.DrawImage(bmp, new Rectangle(0, 0, brect.Width, brect.Height), new Rectangle(new Point(pnt.X - brect.Width / 2, pnt.Y - brect.Height / 2), brect.Size), GraphicsUnit.Pixel);
					}
					brect = brect.filter(true);

					//BitmapData bd = brect.LockBits(new Rectangle(0, 0, 100, 100), ImageLockMode.ReadOnly, PixelFormat.Canonical);

					Dictionary<Point, Color> dict = new Dictionary<Point, Color>();

					int left = pnt.X - (brect.Width / 2);
					int top = pnt.Y - (brect.Height / 2);

					Point originalPoint = new Point(brect.Width / 2, brect.Height / 2);
					Color originalColor = brect.GetPixel(brect.Width / 2, brect.Height / 2);

					Point newPoint = new Point(-1, -1);
					dict = getPixelValues(brect, originalColor);
					
					int currentDist = 0;
					int mindist = 999999;
					foreach(KeyValuePair<Point,Color> kp in dict)
					{
						int dist = distance(originalPoint, kp.Key);
						int cdist = colorDistance(kp.Value, originalColor);

						dist = (int)Math.Pow(dist,1.5);

						

						int maxdist = cdist - dist;

						if(currentDist < maxdist || (currentDist == maxdist && dist < mindist))
						{
							newPoint = new Point(left + kp.Key.X, (top + kp.Key.Y));
							currentDist = maxdist;
							//Console.WriteLine(kp.Key.X.ToString().PadLeft(2,'0') + "," + kp.Key.Y.ToString().PadLeft(2, '0') + ": " + dist + " | " + cdist);
						}

						//sConsole.WriteLine(maxdist);

						if (dist < mindist) { mindist = dist; }
					}

					if(newPoint.X >= 0 && newPoint.Y >= 0) { pnt = newPoint;  }

					cut_points.Add(pnt);

					int minx = cut_points.Min(x => x.X);
					int maxx = cut_points.Max(x => x.X);
					int miny = cut_points.Min(y => y.Y);
					int maxy = cut_points.Max(y => y.Y);

					cut.X = minx;
					cut.Y = miny;
					cut.Width = maxx - minx;
					cut.Height = maxy - miny;
				}

			}

			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			// Complete the snip on mouse-up
			if (mode == 0)
			{
				if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
				retImg = new Bitmap(rcSelect.Width, rcSelect.Height);
				using (Graphics gr = Graphics.FromImage(retImg))
				{
					gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, retImg.Width, retImg.Height),
						rcSelect, GraphicsUnit.Pixel);
				}


				DialogResult = DialogResult.OK;
			}
			else if (mode == 1)
			{
				//Window
			}
			else if (mode == 2)
			{
				mdown = false;
                Bitmap b = new Bitmap(cut.Width, cut.Height);
                using(Graphics g = Graphics.FromImage(b))
                {
					g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, cut.Width, cut.Height), cut, GraphicsUnit.Pixel);
                    //g.CopyFromScreen(cut.Location, new Point(0, 0), cut.Size);
                }

				//b.Save(@"c:\REPO\test1.bmp");
                Bitmap bb = (Bitmap)getPixels(b);
                //bb.Save(@"c:\REPO\test2.bmp");

                retImg = bb;
                DialogResult = DialogResult.OK;
            }
			else if (mode == 3)
			{
				mdown = false;
			}
			else if (mode == 4)
			{
				mdown = false;
				Bitmap b = new Bitmap(cut.Width > 0 ? cut.Width : 1, cut.Height > 0 ? cut.Height : 1);
				using (Graphics g = Graphics.FromImage(b))
				{
					g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, cut.Width, cut.Height), cut, GraphicsUnit.Pixel);
					//g.CopyFromScreen(cut.Location, new Point(0, 0), cut.Size);
				}

				//b.Save(@"c:\REPO\test1.bmp");
				//Console.WriteLine("COUNT: " + cut_points.Count);
				Bitmap bb = (Bitmap)getPixels(b);
				//bb.Save(@"c:\REPO\test2.bmp");

				f_EditSelection fed = new f_EditSelection();
				fed.CutImage = bb;
				fed.FullImage = (Bitmap)BackgroundImage;
				fed.points = cut_points;
				fed.left = cut.Left;
				fed.top = cut.Top;
				fed.ShowDialog();

				retImg = bb;
				DialogResult = DialogResult.OK;
			}


		}
		protected override void OnPaint(PaintEventArgs e)
		{
            //RECTANGLE SELECTION
            if (mode == 0)
            {
                using (Brush br = new SolidBrush(Color.FromArgb(transparency, bgc)))
                {
                    int x1 = rcSelect.X; int x2 = rcSelect.X + rcSelect.Width;
                    int y1 = rcSelect.Y; int y2 = rcSelect.Y + rcSelect.Height;
                    e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, this.Height));
                    e.Graphics.FillRectangle(br, new Rectangle(x2, 0, this.Width - x2, this.Height));
                    e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
                    e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
                }
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    e.Graphics.DrawRectangle(pen, rcSelect);
                }
            }
			//WINDOW SELECTION
            else if (mode == 1)
            {
				//TODO: [CANVAS] make window selection
            }
			//FREEHAND
            else if (mode == 2)
            {
                using (Brush br = new SolidBrush(Color.FromArgb(transparency, bgc)))
                {
                    e.Graphics.FillRectangle(br, new Rectangle(0, 0, Width, Height));
                }
				
                try
                {
                    List<int> ppprem = new List<int>();
                    for (int i = 0; i < cut_points.Count - 1; i++)
                    {
                        if (cut_points[i].X == cut_points[i + 1].X && cut_points[i].Y == cut_points[i + 1].Y)
                        {
                            ppprem.Add(i);
                        }
                    }

                    foreach (int i in ppprem)
                    {
						cut_points.Remove(cut_points[i]);
                    }
                }
                catch { }

                Point[] ppp = cut_points.ToArray();

				using (Pen _pen = new Pen(Brushes.Blue))
				{

					for (int i = 0; i < ppp.Length; i++)
					{
						int ii = i + 1;
						if(ii == ppp.Length)
						{ ii = 0; }

						Point[] lines = new Point[6] {
							new Point(ppp[i].X + 1, ppp[i].Y),
							new Point(ppp[ii].X + 1, ppp[ii].Y),
							ppp[ii],
							ppp[i],
							new Point(ppp[i].X, ppp[i].Y + 1),
							new Point(ppp[ii].X, ppp[ii].Y + 1)
						};

						e.Graphics.DrawLines(_pen, lines);
					}
				}
                
                e.Graphics.DrawRectangle(Pens.Black, cut);
				
			}
			//FREEHAND WITH LINES
			else if (mode == 3)
			{
				//TODO: [CANVAS] make line selection
			}
			//MAGIC WAND
			else if (mode == 4)
			{
				//TODO: [CANVAS] make Magic selection
				/*
				using (Brush br = new SolidBrush(Color.FromArgb(transparency, bgc)))
				{
					e.Graphics.FillRectangle(br, new Rectangle(0, 0, Width, Height));
				}
				*/
				try
				{
					List<int> ppprem = new List<int>();
					for (int i = 0; i < cut_points.Count - 1; i++)
					{
						if (cut_points[i].X == cut_points[i + 1].X && cut_points[i].Y == cut_points[i + 1].Y)
						{
							ppprem.Add(i);
						}
					}

					foreach (int i in ppprem)
					{
						cut_points.Remove(cut_points[i]);
					}
				}
				catch { }

				Point[] ppp = cut_points.ToArray();

				using (Pen _pen = new Pen(Brushes.Blue))
				{

					for (int i = 0; i < ppp.Length; i++)
					{
						int ii = i + 1;
						if (ii == ppp.Length)
						{ ii = 0; }

						Point[] lines = new Point[6] {
							new Point(ppp[i].X + 1, ppp[i].Y),
							new Point(ppp[ii].X + 1, ppp[ii].Y),
							ppp[ii],
							ppp[i],
							new Point(ppp[i].X, ppp[i].Y + 1),
							new Point(ppp[ii].X, ppp[ii].Y + 1)
						};

						e.Graphics.DrawLines(_pen, lines);
					}
				}

				e.Graphics.DrawRectangle(Pens.Black, cut);

			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Allow canceling the snip with the Escape key
			if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
			return base.ProcessCmdKey(ref msg, keyData);
		}

        #region Raycasting, not used

        /*RayCasting
		public bool raycast(Point p)
		{
			int k, j = cut_points.Count - 1;
			bool oddNodes = false; //to check whether number of intersections is odd
			for (k = 0; k < cut_points.Count; k++)
			{
				//fetch adjucent points of the polygon
				PointF polyK = cut_points[k];
				PointF polyJ = cut_points[j];

				//check the intersections
				if (((polyK.Y > p.Y) != (polyJ.Y > p.Y)) &&
				 (p.X < (polyJ.X - polyK.X) * (p.Y - polyK.Y) / (polyJ.Y - polyK.Y) + polyK.X))
					oddNodes = !oddNodes; //switch between odd and even
				j = k;
			}

			//if odd number of intersections
			if (oddNodes)
			{
				//mouse point is inside the polygon
				return true;
			}
			else //if even number of intersections
			{
				//mouse point is outside the polygon so deselect the polygon
				return false;
			}
		}
		*/

        /*PointInPoly
		bool pinp(List<Loc> ll, Point p)
		{
			Loc l = new Loc(p.X, p.Y);
			return IsPointInPolygon(ll, l);
		}

		bool IsPointInPolygon(List<Loc> poly, Loc point)
		{
			int i, j;
			bool c = false;
			for (i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
			{
				if ((((poly[i].Lt <= point.Lt) && (point.Lt < poly[j].Lt))
						|| ((poly[j].Lt <= point.Lt) && (point.Lt < poly[i].Lt)))
						&& (point.Lg < (poly[j].Lg - poly[i].Lg) * (point.Lt - poly[i].Lt)
							/ (poly[j].Lt - poly[i].Lt) + poly[i].Lg))
				{
					c = !c;
				}
			}

			return c;
		}
		*/

        #endregion

		//Creates array from list of points, adds first point to end of list
        public Point[] generatePointArray(List<Point> pnts)
		{
			List<Point> lst = new List<Point>();
			foreach (Point p in pnts)
			{
				Point pp = new Point(p.X, p.Y);
				lst.Add(pp);
			}

			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			try { lst.Add(lst[0]); } catch { }

			try
			{
				List<int> ppprem = new List<int>();
				for (int i = 0; i < lst.Count - 1; i++)
				{
					if (lst[i].X == lst[i + 1].X && lst[i].Y == lst[i + 1].Y)
					{
						ppprem.Add(i);
					}
				}

				foreach (int i in ppprem)
				{
					lst.Remove(lst[i]);
				}
			}
			catch { }
			
			return lst.ToArray();
		}

		//UNSAFE CODE! Returns proper non-rectangular images
		public unsafe Image getPixels(Bitmap _image)
		{
			Bitmap b = new Bitmap(_image);
			Bitmap bb = new Bitmap(b.Width, b.Height, PixelFormat.Format32bppArgb);
			Point[] ppp = generatePointArray(cut_points);
			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = (byte)Image.GetPixelFormatSize(bData.PixelFormat);
			int PixelSize = 4;

			for (int y = 0; y < bb.Height; y++)
			{
				byte* row = (byte*)bData.Scan0 + (y * bData.Stride);

				for (int x = 0; x < bb.Width; x++)
				{
					if (c_WindingFunctions.wn_PnPoly(new Point(cut.Left + x, cut.Top + y), ppp, ppp.Length - 1) == 0)
					{
						row[x * PixelSize] = 0;         //Blue  0-255
						row[x * PixelSize + 1] = 0;   //Green 0-255
						row[x * PixelSize + 2] = 0;     //Red   0-255
						row[x * PixelSize + 3] = 0;    //Alpha 0-255
					}
				}
			}

			b.UnlockBits(bData);

			return b;
		}

		public unsafe Dictionary<Point,Color> getPixelValues(Bitmap _image, Color c)
		{
			Dictionary<Point, Color> dict = new Dictionary<Point, Color>();
			Bitmap b = new Bitmap(_image);
			Bitmap bb = new Bitmap(b.Width, b.Height, PixelFormat.Format32bppArgb);
			Point[] ppp = generatePointArray(cut_points);
			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = (byte)Image.GetPixelFormatSize(bData.PixelFormat);
			int PixelSize = 4;

			int cc = c.R + c.G + c.B;

			for (int y = 0; y < bb.Height; y++)
			{
				byte* row = (byte*)bData.Scan0 + (y * bData.Stride);

				for (int x = 0; x < bb.Width; x++)
				{
					int px = row[x * PixelSize] + row[x * PixelSize + 1] + row[x * PixelSize + 2];
					if (px > cc) { dict.Add(new Point(x, y), Color.FromArgb(row[x * PixelSize], row[x * PixelSize + 1], row[x * PixelSize + 2])); }
				}
			}

			b.UnlockBits(bData);

			return dict;
		}

		//END UNSAFE CODE

		private void f_Canvas_MouseClick(object sender, MouseEventArgs e)
		{
			if (mode == 4)
			{
				
				
			}
		}

		List<Point> tmpPoints = new List<Point>();

		public void pixelCheckColor(Point p, Color c)
		{
			if(c == magicSelectColor) { magicSelectPixels.Add(p); }
			else { magicUnSelectPixels.Add(p); }
		}

		public Point[] pixelHadValidNeighburs(Point p)
		{
			List<Point> ret = new List<Point>();

			Point[] pp = new Point[]
			{
				new Point(p.X, p.Y - 1),
				new Point(p.X, p.Y + 1),
				new Point(p.X - 1, p.Y),
				new Point(p.X + 1, p.Y)
			};

			foreach(Point ppp in pp)
			{
				if(!magicSelectPixels.Contains(ppp) &&
					!magicUnSelectPixels.Contains(ppp))
				{
					ret.Add(ppp);
				}
			}

			if(ret.Count > 0)
			{
				return ret.ToArray();
			}
			else
			{
				return null;
			}
		}

		//UNSAFE CODE
		
	}



	

}


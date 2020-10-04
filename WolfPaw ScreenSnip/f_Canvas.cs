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

namespace SharpSnip
{
	public partial class f_Canvas : Form
	{
		public Size bounds { get; set; }
		public Bitmap bmp { get; set; }
		public Bitmap edge;
		public Bitmap retImg { get; set; }
		public int mode { get; set; }
		public Image Image { get; set; }
		public bool save_editable_backup { get; set; }
		public string randID { get; set; }

		private Rectangle rcSelect = new Rectangle();
		private Point pntStart;
		private Rectangle cut = new Rectangle(-1, -1, -1, -1);
		private List<Point> cut_points = new List<Point>();

		bool mdown = false;
		Color bgc = new Color();
		int transparency = 100;
		
		Point magicSelectPoint = new Point(-1, -1);
		List<Point> magicSelectPixels = new List<Point>();
		List<Point> magicUnSelectPixels = new List<Point>();
		Bitmap brect = new Bitmap(100, 100);

		public bool shiftDown = false;
		public bool ctrlDown = false;
		public bool altDown = false;

		public bool useInch = false;
		public bool usePixels = false;
		public bool giveCrosshairs = true;
		public bool drawPositionData = true;
		public bool drawRulerBackground = true;

		int vertical = 0;
		int horizontal = 0;
		string type = "";
		Bitmap rulerX = null;
		Bitmap rulerY = null;

		int imgCounter = 0;

		public f_Canvas()
		{
			InitializeComponent();

			Load += F_Canvas_Load;
		}

		private void F_Canvas_Load(object sender, EventArgs e)
		{
			Location = new Point(0, Screen.AllScreens.Min(x => x.Bounds.Y));
			Size = bounds;

			if(mode == -1) { mode = 0; }

			BackgroundImage = bmp;
			if(mode == 4)
			{
				edge = bmp.filter(true);
			    BackgroundImage = edge;
			}

			int i = Properties.Settings.Default.s_DPIType;

			usePixels = false;
			useInch = false;

			if (i == 1)
			{
				useInch = true;
			}
			else if(i == 2)
			{
				usePixels = true;
			}

			giveCrosshairs = Properties.Settings.Default.s_DrawCrosshairs;
			drawPositionData = Properties.Settings.Default.s_DrawPosiData;
			//drawRulerBackground = Properties.Settings.Default.s_DrawRulerBackground;

			bgc = Properties.Settings.Default.s_CanvasColor;

			float transp = Properties.Settings.Default.s_CanvasTransparency;
			transparency = (int)(255 / (100 / ( transp * 100)));

			if (useInch)
			{
				type = "In. ";
				getDPI(out horizontal, out vertical);
			}
			else if (!usePixels)
			{
				type = "Cm. ";
				getDPCM(out horizontal, out vertical);
			}
			else
			{
				type = "Px. ";
				horizontal = 100;
				vertical = 100;
			}

			TopMost = true;
			BringToFront();
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

				int wid = x2 - x1;
				int hei = y2 - y1;

				if (ctrlDown)
				{
					hei = wid;
				}

				rcSelect = new Rectangle(x1, y1, wid, hei);
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

					cut = c_Unsafe.getRect(cut_points);
				}

			}
			else if (mode == 4)
			{
				if (mdown)
				{
					Point pnt = e.Location;

					List<Point> pnts = new List<Point>();

					brect = new Bitmap(50,50);
					using(Graphics g = Graphics.FromImage(brect))
					{
						g.DrawImage(bmp, new Rectangle(0, 0, brect.Width, brect.Height), new Rectangle(new Point(pnt.X - brect.Width / 2, pnt.Y - brect.Height / 2), brect.Size), GraphicsUnit.Pixel);
					}
					brect = brect.filter(true);
					//brect.Save("D:\\test\\img_" + imgCounter.ToString().PadLeft(3, '0') + ".bmp");
					//imgCounter++;
					//brect = brect.Laplacian5x5OfGaussian5x5Filter1();
					//brect.Save("D:\\img2.bmp");

					//BitmapData bd = brect.LockBits(new Rectangle(0, 0, 100, 100), ImageLockMode.ReadOnly, PixelFormat.Canonical);

					Dictionary<Point, Color> dict = new Dictionary<Point, Color>();

					int left = pnt.X - (brect.Width / 2);
					int top = pnt.Y - (brect.Height / 2);

					Point originalPoint = new Point(brect.Width / 2, brect.Height / 2);
					Color originalColor = brect.GetPixel(brect.Width / 2, brect.Height / 2);

					Point newPoint = new Point(-1, -1);
					dict = c_Unsafe.getPixelValues(brect, originalColor,cut_points);
					
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

					GC.Collect();
				}

			}

			this.Invalidate();
		}

		public string genRandomId()
		{
			return Guid.NewGuid().ToString();

			//long i1 = DateTime.Now.ToFileTimeUtc();
			//long i2 = (long)new Random((int)Math.Sqrt(i1) + 333).Next();
			//
			//string i3 = i1 + "--" + i2;
			//
			//System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
			//string i4 = "";
			//int i = 0;
			//foreach(Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(i3)))
			//{
			//	if(i > 10) { break; }
			//	i4 += b.ToString("X2");
			//	i++;
			//}
			//
			//i4 = i4 + "_" + DateTime.Now.ToFileTime();
			//this.Hide();
			//return i4;
		}

		public void saveScreenCap(string randomID, List<Point> pnts)
		{
			string pointstr = "";
			
			foreach(Point p in pnts) { pointstr += p.X + ":" + p.Y + "|"; }
			pointstr = pointstr.Trim('|');

			string err;
			c_DatabaseHandler.insertImageToBackups(c_DatabaseHandler.ConnectToDB("editable_backup.db", out err), c_Converter.ConvertToHex((Bitmap)BackgroundImage), randomID, pointstr);
			randID = randomID;
		}

		//TODO: MOUSEUP
		protected override void OnMouseUp(MouseEventArgs e)
		{
			// Complete the snip on mouse-up
			//Rectangle
			if (mode == 0)
			{
				if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
				retImg = new Bitmap(rcSelect.Width, rcSelect.Height);
				using (Graphics gr = Graphics.FromImage(retImg))
				{
					gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, retImg.Width, retImg.Height),
						rcSelect, GraphicsUnit.Pixel);
				}

				var pp = new List<Point> {
					new Point(rcSelect.X,rcSelect.Y),
					new Point(rcSelect.X + rcSelect.Width,rcSelect.Y),
					new Point(rcSelect.X + rcSelect.Width,rcSelect.Y + rcSelect.Height),
					new Point(rcSelect.X ,rcSelect.Y + rcSelect.Height),

				};

				if (save_editable_backup) { saveScreenCap(genRandomId(), pp);  }
				DialogResult = DialogResult.OK;
			}
			//Window detection
			else if (mode == 1)
			{
				//Window
			}
			//Freehand
			else if (mode == 2)
			{
				mdown = false;
                Bitmap b = new Bitmap(cut.Width, cut.Height);
                using(Graphics g = Graphics.FromImage(b))
                {
					g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, cut.Width, cut.Height), cut, GraphicsUnit.Pixel);
                }

				Bitmap bb = (Bitmap)c_Unsafe.getPixels(b, cut_points, cut);

                retImg = bb;
				if (save_editable_backup) { saveScreenCap(genRandomId(), cut_points); }
				DialogResult = DialogResult.OK;
            }
			//Point selector
			else if (mode == 3)
			{
				mdown = false;
			}
			//Magic
			else if (mode == 4)
			{
				mdown = false;
				Bitmap b = new Bitmap(cut.Width > 0 ? cut.Width : 1, cut.Height > 0 ? cut.Height : 1);
				using (Graphics g = Graphics.FromImage(b))
				{
					g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, cut.Width, cut.Height), cut, GraphicsUnit.Pixel);
				}

				Bitmap bb = (Bitmap)c_Unsafe.getPixels(b, cut_points, cut);

				
				if (shiftDown)
				{
					Hide();
					f_EditSelection fed = new f_EditSelection
					{
						CutImage = bb,
						FullImage = (Bitmap)BackgroundImage,
						points = cut_points,
						left = cut.Left,
						top = cut.Top,
						cut = cut
					};
					fed.ShowDialog();
					bb = fed.CutImage;
				}
				/**/

				retImg = bb;
				if (save_editable_backup) { saveScreenCap(genRandomId(), cut_points); }
				DialogResult = DialogResult.OK;
			}


		}

		public void generateRulers(int wid, int hei)
		{
			if (rulerX == null)
			{
				rulerX = new Bitmap(Width, 20);
				using(Graphics g = Graphics.FromImage(rulerX))
				{
					if (drawRulerBackground)
						g.FillRectangle(Brushes.White, new Rectangle(0, 0, Width, 21));
					for (int i = 0; i < wid; i++)
					{
						g.DrawLine(Pens.Black, new Point(i * horizontal, 0), new Point(i * horizontal, 20));
					}
				}
			}

			if(rulerY == null)
			{
				rulerY = new Bitmap(20, Height);
				using (Graphics g = Graphics.FromImage(rulerY))
				{
					if (drawRulerBackground)
						g.FillRectangle(Brushes.White, new Rectangle(0, 0, 21, Height));
					for (int i = 0; i < hei; i++)
					{
						g.DrawLine(Pens.Black, new Point(0, i * vertical), new Point(20, i * vertical));
					}
				}
			}
		}

		public void dpiToInt(out int x, out int y)
		{
			int i = Properties.Settings.Default.s_UseMonitorForDpi;
			string s = Properties.Settings.Default.s_DPI[i];
			string[] ss = s.Split('|');

			if (ss.Length == 4)
			{
				int.TryParse(ss[2], out x);
				int.TryParse(ss[3], out y);
			}
			else
			{
				x = 0; y = 0;
			}
		}

		public void getDPI(out int x, out int y)
		{
			dpiToInt(out x, out y);
		}

		public void getDPCM(out int x, out int y)
		{
			int ix = 0;
			int iy = 0;

			dpiToInt(out ix, out iy);

			x = (int)(ix * 0.393700787);
			y = (int)(iy * 0.393700787);
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


			if (altDown || Properties.Settings.Default.s_AlwaysHaveRuler)
			{
				int wid = bmp.Width / horizontal;
				int hei = bmp.Height / vertical;

				if(rulerX == null || rulerY == null) { generateRulers(wid, hei); }
				e.Graphics.DrawImage(rulerX, new Point(0, 0));
				e.Graphics.DrawImage(rulerY, new Point(0, 0));


				e.Graphics.DrawLine(Pens.Red, new Point(Cursor.Position.X, 0), new Point(Cursor.Position.X, 10));
				e.Graphics.DrawLine(Pens.Red, new Point(0, Cursor.Position.Y), new Point(10, Cursor.Position.Y));

				if (giveCrosshairs)
				{
					e.Graphics.DrawLine(Pens.Red, new Point(Cursor.Position.X, 0), new Point(Cursor.Position.X, Cursor.Position.Y - 10));
					e.Graphics.DrawLine(Pens.Red, new Point(Cursor.Position.X, Cursor.Position.Y + 10), new Point(Cursor.Position.X, bmp.Height));

					e.Graphics.DrawLine(Pens.Red, new Point(0, Cursor.Position.Y), new Point(Cursor.Position.X - 10, Cursor.Position.Y));
					e.Graphics.DrawLine(Pens.Red, new Point(Cursor.Position.X + 10, Cursor.Position.Y), new Point(bmp.Width, Cursor.Position.Y));
				}

				if (drawPositionData)
				{
					string s = "Position:\r\n" + type + ": " + (Cursor.Position.X / horizontal) + " x " + (Cursor.Position.Y / vertical);
					Size sz = TextRenderer.MeasureText(s, this.Font);
					e.Graphics.FillRectangle(Brushes.White, new Rectangle(Cursor.Position.X + 10, Cursor.Position.Y + 10, sz.Width, sz.Height));
					e.Graphics.DrawString(s, this.Font, Brushes.Black, new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10));
				}
			}
			GC.Collect();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Allow canceling the snip with the Escape key
			if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
			{
				shiftDown = true;
			}else if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey)
			{
				ctrlDown = true;
			}
			else if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu)
			{
				altDown = true;
			}

			Invalidate();
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey)
			{
				shiftDown = false;
			}
			else if (e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey)
			{
				ctrlDown = false;
			}
			else if (e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu)
			{
				altDown = false;
			}
			Invalidate();
		}

		private void f_Canvas_MouseClick(object sender, MouseEventArgs e)
		{
			if (mode == 4)
			{
				//TODO
				
			}
		}
		
		
	}



	

}


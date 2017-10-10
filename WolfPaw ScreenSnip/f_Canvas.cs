using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
		public Bitmap retImg { get; set; }
		public int mode { get; set; }

		private Rectangle cut = new Rectangle(-1, -1, -1, -1);

		private List<Point> cut_points = new List<Point>();
		bool mdown = false;


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

		public Image Image { get; set; }

		private Rectangle rcSelect = new Rectangle();
		private Point pntStart;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			// Start the snip on mouse down
			if (e.Button != MouseButtons.Left) { doit();  return; }
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

					foreach (Point p in cut_points)
					{
						if (p.X < cut.X || cut.X == -1) { cut.X = p.X; }
						if (p.Y < cut.Y || cut.Y == -1) { cut.Y = p.Y; }
						if (p.X > cut.X + cut.Width) { cut.Width = p.X - cut.X; }
						if (p.Y > cut.Y + cut.Height) { cut.Height = p.Y - cut.Y; }
					}
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
			}
			else if (mode == 3)
			{
				mdown = false;
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
            // Draw the current selection
            if (mode == 0)
            {
                using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
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
            else if (mode == 1)
            {

            }
            else if (mode == 2)
            {
                using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
                {
                    e.Graphics.FillRectangle(br, new Rectangle(0, 0, Width, Height));
                }



                //Freehand


                Pen _pen = new Pen(Brushes.Blue);

                List<Point> lst = new List<Point>();
                foreach (Point p in cut_points)
                {
                    Point pp = new Point(p.X, p.Y);
                    lst.Add(pp);
                }

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

                Point[] ppp = lst.ToArray();



                /*
                 * int ii = (c_WindingFunctions.wn_PnPoly(Cursor.Position, ppp, ppp.Length - 1));

				if (ii != 0)
				{
					_pen = new Pen(Brushes.Red);
				}
				for (int i = 0; i < cut_points.Count; i++)
				{
					if (i < cut_points.Count - 1)
					{

						e.Graphics.DrawLine(_pen, cut_points[i], cut_points[i + 1]);
						e.Graphics.DrawLine(_pen, new Point(cut_points[i].X + 1, cut_points[i].Y), new Point(cut_points[i + 1].X + 1, cut_points[i + 1].Y));
						e.Graphics.DrawLine(_pen, new Point(cut_points[i].X, cut_points[i].Y + 1), new Point(cut_points[i + 1].X, cut_points[i + 1].Y + 1));
					}
					else
					{
						e.Graphics.DrawLine(_pen, cut_points[i], cut_points[0]);
						e.Graphics.DrawLine(_pen, new Point(cut_points[i].X + 1, cut_points[i].Y), new Point(cut_points[0].X + 1, cut_points[0].Y));
						e.Graphics.DrawLine(_pen, new Point(cut_points[i].X, cut_points[i].Y + 1), new Point(cut_points[0].X, cut_points[0].Y + 1));
					}
				}
				/*--*/


                int _i = 0;
                foreach(Point p in ppp)
                {
                    Console.WriteLine((_i++).ToString().PadLeft(2, '0') + ": " + p.X + ":" + p.Y);
                }

                for (int i = 0; i < ppp.Length; i++)
                {
                    if (ppp.Length > i + 1)
                    {
                        if (ppp[i].Y > ppp[i + 1].Y) { _pen = new Pen(Brushes.Red); }else
                        {
                            _pen = new Pen(Brushes.Green);
                        }
                    }
                    else
                    {
                        if (ppp[i].Y > ppp[0].Y) { _pen = new Pen(Brushes.Red); }
                        else
                        {
                            _pen = new Pen(Brushes.Green);
                        }
                    }
                    if (i < ppp.Length - 1)
                    {
                        if(i == 0) { e.Graphics.FillEllipse(Brushes.Yellow, ppp[i].X, ppp[i].Y, 8, 8); }
                        else { e.Graphics.FillEllipse(Brushes.Pink, ppp[i].X, ppp[i].Y, 5, 5); }

                        if (i == 0)
                        {
                            e.Graphics.DrawLine(Pens.Orange, ppp[i], ppp[i + 1]);
                            e.Graphics.DrawLine(Pens.Orange, new Point(ppp[i].X + 1, ppp[i].Y), new Point(ppp[i + 1].X + 1, ppp[i + 1].Y));
                            e.Graphics.DrawLine(Pens.Orange, new Point(ppp[i].X, ppp[i].Y + 1), new Point(ppp[i + 1].X, ppp[i + 1].Y + 1));

                            e.Graphics.DrawLine(Pens.Orange, ppp[i].X, ppp[i].Y, ppp[i].X - 500, ppp[i].Y);
                        }
                        else if (i == ppp.Length - 2)
                        {
                            e.Graphics.DrawLine(Pens.Blue, ppp[i], ppp[i + 1]);
                            e.Graphics.DrawLine(Pens.Blue, new Point(ppp[i].X + 1, ppp[i].Y), new Point(ppp[i + 1].X + 1, ppp[i + 1].Y));
                            e.Graphics.DrawLine(Pens.Blue, new Point(ppp[i].X, ppp[i].Y + 1), new Point(ppp[i + 1].X, ppp[i + 1].Y + 1));

                            e.Graphics.DrawLine(Pens.Blue, ppp[i].X, ppp[i].Y, ppp[i].X - 500, ppp[i].Y);
                        }
                        else
                        {
                            e.Graphics.DrawLine(_pen, ppp[i], ppp[i + 1]);
                            e.Graphics.DrawLine(_pen, new Point(ppp[i].X + 1, ppp[i].Y), new Point(ppp[i + 1].X + 1, ppp[i + 1].Y));
                            e.Graphics.DrawLine(_pen, new Point(ppp[i].X, ppp[i].Y + 1), new Point(ppp[i + 1].X, ppp[i + 1].Y + 1));
                        }
                    }
                }
                
                e.Graphics.DrawRectangle(Pens.Black, cut);

				

			}
			else if (mode == 3)
			{

			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Allow canceling the snip with the Escape key
			if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
			return base.ProcessCmdKey(ref msg, keyData);
		}


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

		public void doit()
		{
            try
            {
                //e.Graphics.DrawClosedCurve(Pens.Blue,cut_points.ToArray());
                //e.Graphics.FillClosedCurve(Brushes.Transparent, cut_points.ToArray());

                using (Graphics g = Graphics.FromHwnd(this.Handle))
                    for (int x = 0; x < cut.Width; x++)
                    {
                        for (int y = 0; y < cut.Height; y++)
                        {
                            //-----

                            List<Point> lst = new List<Point>();
                            foreach (Point p in cut_points)
                            {
                                Point pp = new Point(p.X, p.Y);
                                lst.Add(pp);
                            }

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

                            Point[] ppp = lst.ToArray();

                            //-----

                            Point _pp = new Point(cut.Left + x, cut.Top + y);
                            if (c_WindingFunctions.wn_PnPoly(_pp, ppp, ppp.Length - 1) != 0)
                            {
                                g.FillEllipse(Brushes.Pink, _pp.X, _pp.Y, 3, 3);
                            }
                        }
                    }
            }
            catch { }
		}


	}

	public class Loc
	{
		private double lt;
		private double lg;

		public double Lg
		{
			get { return lg; }
			set { lg = value; }
		}

		public double Lt
		{
			get { return lt; }
			set { lt = value; }
		}

		public Loc(double lt, double lg)
		{
			this.lt = lt;
			this.lg = lg;
		}
	}

}


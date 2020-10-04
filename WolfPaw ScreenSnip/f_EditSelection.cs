using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSnip
{
	public partial class f_EditSelection : Form
	{
		public Bitmap FullImage { get; set; }
		public Bitmap CutImage { get; set; }
		public List<Point> points { get; set; }
		public List<Point> pnts2 = new List<Point>();
		public c_PointStorage ps = new c_PointStorage();
		public Rectangle cut { get; set; }
		public int left { get; set; }
		public int top { get; set; }

		public bool mdown = false;
		public bool mouseOver = false;
		public Point? mouseOverPoint = null;
		public Point? selectedPoint = null;
		public Point? draggedPoint = null;
		public List<Point> selectedPoints = null;
		public Point[] draggedPoints = null;
		public Rectangle selectionRectangle = new Rectangle(-1, -1, 0, 0);
		public Point pntStart = new Point(0, 0);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		public f_EditSelection()
		{
			InitializeComponent();

			Load += F_EditSelection_Load;
		}

		private void F_EditSelection_Load(object sender, EventArgs e)
		{
			
			foreach(Point p in points)
			{
				pnts2.Add(new Point(p.X - left, p.Y - top));
			}
			ps.setPoints(pnts2);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawImage(CutImage, new PointF(0, 0));

			foreach(Point p in pnts2)
			{
				Point pp = new Point(p.X , p.Y );

				if (pp == selectedPoint)
				{
					e.Graphics.FillEllipse(Brushes.Red, new RectangleF(pp.X - 4, pp.Y - 4, 8, 8));
					e.Graphics.DrawEllipse(Pens.Red, new RectangleF(pp.X - 6, pp.Y - 6, 12, 12));
				}
				else if (selectedPoints != null && selectedPoints.Contains(pp))
				{
					e.Graphics.FillEllipse(Brushes.Orange, new RectangleF(pp.X - 4, pp.Y - 4, 8, 8));
				}
				else if(pp == mouseOverPoint)
				{
					e.Graphics.FillEllipse(Brushes.Red, new RectangleF(pp.X - 4, pp.Y - 4, 8, 8));
				}
				else
				{
					e.Graphics.DrawEllipse(Pens.Gray, new RectangleF(pp.X - 2, pp.Y - 2, 4, 4));
				}

				if(selectionRectangle.Size != new Size(0, 0))
				{
					e.Graphics.DrawRectangle(Pens.Gray, selectionRectangle);
				}

			}

			for (int i = 0; i < pnts2.Count; i++)
			{
				Point p2 = new Point();
				if (i + 1 == pnts2.Count)
				{
					p2 = pnts2[0];
				}
				else
				{
					p2 = pnts2[i + 1];
				}

				e.Graphics.DrawLine(Pens.Blue, pnts2[i], p2);
			}

		}

		public void getNewImage()
		{
			if(pnts2.Count > 2)
			{
				List<Point> pnts3 = new List<Point>();
				foreach (Point ppp in pnts2)
				{
					pnts3.Add(new Point(ppp.X + left, ppp.Y + top));
				}
				Rectangle cut2 = c_Unsafe.getRect(pnts3);

				Bitmap bmp = new Bitmap(cut2.Width, cut2.Height);

				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(this.FullImage, new Rectangle(0, 0, cut2.Width, cut2.Height), cut2, GraphicsUnit.Pixel);
				}

				CutImage = (Bitmap)c_Unsafe.getPixels(bmp, pnts3, cut2);
				Invalidate();
			}
		}

		public bool mouseIsOverAPoint(Point curp)
		{
			foreach (Point p in pnts2)
			{
				Point pp = new Point((p.X ), (p.Y ));
				Rectangle r = new Rectangle(pp.X - 4, pp.Y - 4, 8, 8);
				if (r.Contains(curp)) { return true; }
			}
			return false;
		}

		public Point? moseOverWhichPoint(Point curp)
		{
			Point? ret = null;

			foreach(Point p in pnts2)
			{
				Point pp = new Point((p.X ), (p.Y ));
				Rectangle r = new Rectangle(pp.X - 4, pp.Y - 4, 8, 8);
				if (r.Contains(curp)) { ret = pp; break; }
			}

			return ret;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (mdown)
			{
				if(selectedPoint != null && selectedPoints != null && selectedPoints.Count > 0 && selectedPoints.Contains((Point)selectedPoint))
				{
					Point p = new Point(e.X , e.Y );
					Point pp = (Point)selectedPoint;
					selectedPoints = ps.movePointsInRelation(pp, p, selectedPoints.ToArray());
					selectedPoint = p;

					getNewImage();
				}
				else if(selectedPoint != null)
				{
					Point p = new Point(e.X , e.Y );
					Point pp = new Point(((Point)selectedPoint).X, ((Point)selectedPoint).Y);
					ps.movePoint(pp, p);
					selectedPoint = new Point(e.X, e.Y);
				}
				else
				{
					if(selectedPoints == null) { selectedPoints = new List<Point>(); }

					int x1 = Math.Min(e.X, pntStart.X);
					int y1 = Math.Min(e.Y, pntStart.Y);
					int x2 = Math.Max(e.X, pntStart.X);
					int y2 = Math.Max(e.Y, pntStart.Y);

					int wid = x2 - x1;
					int hei = y2 - y1;

					selectionRectangle = new Rectangle(x1, y1, wid, hei);

					foreach(Point p in pnts2)
					{
						Point pp = new Point(p.X , p.Y );
						if (selectionRectangle.Contains(pp))
						{
							selectedPoints.Add(pp);
						}
						else
						{
							if (selectedPoints.Contains(pp))
							{
								selectedPoints.Remove(pp);
							}
						}
					}
				}
			}
			else
			{
				if (mouseIsOverAPoint(e.Location))
				{
					mouseOver = true;
					mouseOverPoint = moseOverWhichPoint(e.Location);
				}
				else
				{
					mouseOver = false;
				}
			}

			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			mdown = true;
			pntStart = e.Location;

			if (mouseOver)
			{
				if(selectedPoints != null && selectedPoints.Count > 0)
				{
					if (!selectedPoints.Contains((Point)mouseOverPoint))
					{
						selectedPoints = null;
					}
					else
					{
						draggedPoints = selectedPoints.ToArray();
					}
				}
				else
				{
					draggedPoints = null;
				}

				selectedPoint = mouseOverPoint;
				Invalidate();
			}
			else
			{
				selectionRectangle = new Rectangle(e.X, e.Y, 0, 0);
				selectedPoint = null;
				selectedPoints = null;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			mdown = false;
			selectedPoint = null;
			selectionRectangle = new Rectangle(-1, -1, 0, 0);
		}

		private void f_EditSelection_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				if(selectedPoints != null && selectedPoints.Count > 0)
				{
					ps.removePoints(selectedPoints.ToArray());
				}
				else if(selectedPoint != null && pnts2.Contains((Point)selectedPoint))
				{
					ps.removePoint((Point)selectedPoint);
				}

				getNewImage();
			}
		}
	}
}

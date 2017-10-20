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
	public partial class f_EditSelection : Form
	{
		public Bitmap FullImage { get; set; }
		public Bitmap CutImage { get; set; }
		public List<Point> points { get; set; }
		public c_PointStorage ps = new c_PointStorage();
		public int left { get; set; }
		public int top { get; set; }

		public bool mdown = false;
		public c_Point mdownPoint = null;
		c_Point selected = null;

		public f_EditSelection()
		{
			InitializeComponent();

			Load += F_EditSelection_Load;
		}

		private void F_EditSelection_Load(object sender, EventArgs e)
		{
			foreach (Point pp in points)
			{
				ps.add(new c_Point() { p = pp });
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawImage(CutImage, new PointF(0, 0));

			foreach (c_Point cp in ps.cPoints())
			{
				Pen _pen = Pens.Blue;
				c_Point p2 = new c_Point();

				if (c_WindingFunctions.isLeft(new Point(cp.X - left, cp.Y - top), new Point(p2.X - left, p2.Y - top), Cursor.Position) == 0)
				{
					_pen = Pens.Red;
				}

				if (ps.getIndex(cp) < ps.cPoints().Count - 1)
				{
					p2 = ps.getPointAfter(cp);
				}
				else
				{
					p2 = ps.cPoints()[0];
				}


				e.Graphics.DrawLine(_pen, new Point(cp.X - left, cp.Y - top), new Point(p2.X - left, p2.Y - top));

				if (cp == selected)
				{
					e.Graphics.FillEllipse(Brushes.Red, new RectangleF(new Point(cp.X - left - 4, cp.Y - top - 4), new Size(9, 9)));
				}
				else
				{
					e.Graphics.DrawEllipse(Pens.Red, new RectangleF(new Point(cp.X - left - 2, cp.Y - top - 2), new Size(5, 5)));
				}
				e.Graphics.FillRectangle(Brushes.LightGray, new RectangleF(new Point(10, Height - 200), new Size(100, 100)));
				try
				{
					e.Graphics.DrawString("Points: " + ps.cPoints().Count + "\r\nP1: " + selected.X + "-" + selected.Y + "\r\nP2: " + ps.getPointAfter(selected).X + "-" + ps.getPointAfter(selected).Y + "\r\nCursor: " + PointToClient(Cursor.Position).X + "-" + PointToClient(Cursor.Position).Y, this.Font, Brushes.Black, new Point(10, Height - 200));
				}
				catch
				{

				}
			}
		}

		public bool mouseIsOverAPoint(Point curp)
		{
			Rectangle r = new Rectangle(curp.X - 2, curp.Y - 2, 4, 4);
			foreach (c_Point p in ps.cPoints())
			{
				if (r.Contains(new Point(p.X - left, p.Y - top)))
				{
					return true;
				}
			}
			return false;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			Rectangle r = new Rectangle(e.X - 2, e.Y - 2, 4, 4);

			selected = null;

			foreach(c_Point p in ps.cPoints())
			{
				if (r.Contains(new Point(p.X - left, p.Y - top)))
				{
					selected = p;
					Invalidate();
					break;
				}
			}

			if (mdown)
			{
				if (mdownPoint != null)
				{
					mdownPoint.setPoint(new Point(e.X + left, e.Y + top));
					Invalidate();
				}
				else
				{

				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (mouseIsOverAPoint(e.Location))
			{
				if(selected != null)
				{
					mdownPoint = selected;
				}
				else
				{
					mdownPoint = null;
				}
			}else
			{
				mdownPoint = null;
			}

			mdown = true;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			mdown = false;
			mdownPoint = null;
		}



	}
}

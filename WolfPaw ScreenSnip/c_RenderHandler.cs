using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	public class c_RenderHandler
	{
		List<c_ImageHolder> Limages = new List<c_ImageHolder>();

		public c_RenderHandler(List<c_ImageHolder> Li)
		{
			Limages = Li;
		}

		public bool pointInPosition(Point p, Rectangle r)
		{
			if (p.X >= r.X && p.X <= r.X + r.Width && p.Y >= r.Y && p.Y <= r.Y + r.Height)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool pointOverAny(Point p, out c_ImageHolder overImg)
		{
			overImg = null;
			Limages.Sort(new intComparerDesc());
			foreach (c_ImageHolder c in Limages)
			{
				if (pointInPosition(p, c.bounds()))
				{
					overImg = c;
					return true;
				}
			}

			return false;
		}

		public Bitmap renderButtons(Point p, c_ImageHolder c)
		{
			Point newp = new Point(p.X - c.Left, p.Y - c.Top);

			Bitmap ret = new Bitmap(c.Width, 20);

			using (Graphics g = Graphics.FromImage(ret))
			{
				foreach (btn b in c._buttons.btns)
				{
					if (b.visible)
					{
						if (b.anchor == btn.anchors.left)
						{
							if (c.isOverButton(newp, b))
							{
								g.DrawImage(b.image2, new Point(b.pos * 22, 0));
							}
							else
							{
								g.DrawImage(b.image1, new Point(b.pos * 22, 0));
							}

							g.DrawRectangle(Pens.Black, new Rectangle(b.pos * 22, 0, 20, 20));
						}
						else
						{
							if (c.isOverButton(newp, b))
							{
								g.DrawImage(b.image2, new Point(c.Width - (((b.pos + 1) * 20) + (b.pos * 2)), 0));
							}
							else
							{
								g.DrawImage(b.image1, new Point(c.Width - (((b.pos + 1) * 20) + (b.pos * 2)), 0));
							}

							g.DrawRectangle(Pens.Black, new Rectangle(c.Width - (((b.pos + 1) * 20) + (b.pos * 2)), 0, 20, 20));
						}
					}

					
				}

				return ret;
			}
		}
	}
}

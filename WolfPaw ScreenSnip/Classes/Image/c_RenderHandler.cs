using System.Collections.Generic;
using System.Drawing;

namespace SharpSnip
{
	public class c_RenderHandler
	{
		public int panelHeight = 20;

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

			Bitmap ret = new Bitmap(c.Width, panelHeight);

			using (Graphics g = Graphics.FromImage(ret))
			{
				foreach (CustomPanelButton b in c._buttons.btns)
				{
					if (b.visible)
					{
						if (b.Anchor == CustomPanelButton.Anchors.left)
						{
							if (c.isOverButton(newp, b))
							{
								g.DrawImage(b.Image2, new Point(b.Pos * b.Size + (b.Pos > 1 ? b.Pos + 1 : 0) - b.PadRight + (b.Pos > 0 ? (b.Pos * 2) : 0), b.PadTop));
							}
							else
							{
								g.DrawImage(b.Image1, new Point(b.Pos * b.Size + (b.Pos > 1 ? b.Pos + 1 : 0) - b.PadRight + (b.Pos > 0 ? (b.Pos * 2) : 0), b.PadTop));
							}

							g.DrawRectangle(Pens.Black, new Rectangle(b.Pos * c.buttonSize + (b.Pos > 0 ? (b.Pos * 2) : 0), 0, c.buttonSize, c.buttonSize));
						}
						else
						{
							if (c.isOverButton(newp, b))
							{
								g.DrawImage(b.Image2, new Point(c.Width - (((b.Pos + 1) * b.Size + 7) - b.PadRight + (b.Pos * 2)), b.PadTop));
							}
							else
							{
								g.DrawImage(b.Image1, new Point(c.Width - (((b.Pos + 1) * b.Size + 7) - b.PadRight + (b.Pos * 2)), b.PadTop));
							}

							g.DrawRectangle(Pens.Black, new Rectangle(c.Width - (((b.Pos + 1) * c.buttonSize) + (b.Pos * 2)), 0, c.buttonSize, c.buttonSize));
						}
					}

					
				}

				return ret;
			}
		}
	}
}

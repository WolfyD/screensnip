using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	static class c_ImgGen
	{
		public static Bitmap createImage(Rectangle rec, Dictionary<int, uc_CutoutHolder> cutouts)
		{
			return createImage(rec, cutouts, false);
		}

		public static Bitmap createImage(Rectangle rec, Dictionary<int, uc_CutoutHolder> cutouts, bool drawTBG)
		{
			int border = 0;

			if (Properties.Settings.Default.s_hasBorder)
			{
				border = Properties.Settings.Default.s_borderWidth;
			}

			Bitmap bm = new Bitmap(rec.Width + (border * 2), rec.Height + (border * 2));

			using (Graphics g = Graphics.FromImage(bm))
			{
				c_returnGraphicSettings cg = new c_returnGraphicSettings();

				g.SmoothingMode = cg.getSM();
				g.InterpolationMode = cg.getIM();
				g.PixelOffsetMode = cg.getPOM();

				g.Clear(Color.Transparent);
				
				if (Properties.Settings.Default.s_hasBgColor)
				{ g.Clear(Properties.Settings.Default.s_bgColor); } else { g.Clear(Color.Transparent); }

				if (drawTBG)
				{
					int x = 0;
					int y = 0;
					while (y < bm.Height)
					{
						while (x < bm.Width)
						{
							g.DrawImageUnscaled(Properties.Resources.transparentBG, new Point(x, y));
							x += Properties.Resources.transparentBG.Width;
						}

						y += Properties.Resources.transparentBG.Height;
						x = 0;
					}
				}

				foreach (KeyValuePair<int, uc_CutoutHolder> kvp in cutouts)
				{
					uc_CutoutHolder k = kvp.Value;
					g.DrawImage(k.BMP, new Rectangle(k.Left - rec.Left + border, k.Top - rec.Top + border, k.Width, k.Height), new Rectangle(0, 0, k.BMP.Width, k.BMP.Height), GraphicsUnit.Pixel);
				}

				if (Properties.Settings.Default.s_hasBorder)
				{
					Brush b = new SolidBrush(Properties.Settings.Default.s_borderColor);

					g.FillRectangle(b, new RectangleF(0, 0, bm.Width, border));
					g.FillRectangle(b, new RectangleF(0, bm.Height - border, bm.Width, border));
					g.FillRectangle(b, new RectangleF(0, 0, border, bm.Height));
					g.FillRectangle(b, new RectangleF(bm.Width - border, 0, border, bm.Height));
				}
			}

			return bm;
		}

		public static Bitmap createPng(f_Screen fs, Dictionary<int, uc_CutoutHolder> cutouts) { return createPng(fs, cutouts, false); }

		public static Bitmap createPng(f_Screen fs, Dictionary<int, uc_CutoutHolder> cutouts, bool drawTBG)
		{
			if (fs != null)
			{
				fillDict(fs,cutouts);

				int left = 999999;
				int top = 999999;

				int right = 0;
				int bottom = 0;

				foreach (var v in cutouts)
				{
					var k = v.Value;
					if (k.Left < left) { left = k.Left; }
					if (k.Top < top) { top = k.Top; }
					if (k.Right > right) { right = k.Right; }
					if (k.Bottom > bottom) { bottom = k.Bottom; }
				}
				
				int height = bottom - top;
				int width = right - left;

				Rectangle picrec = new Rectangle(left, top, width, height);

				Bitmap _b = createImage(picrec, cutouts, drawTBG);

				return _b;
			}
			else { return null; }
		}

		public static void fillDict(f_Screen fs,Dictionary<int, uc_CutoutHolder> cutouts)
		{
			cutouts.Clear();
			foreach (var v in fs.Controls)
			{
				if (v != null && v is uc_CutoutHolder)
				{
					int i = fs.Controls.GetChildIndex(((uc_CutoutHolder)v));
					if (!cutouts.ContainsKey(i))
					{
						cutouts.Add(i, ((uc_CutoutHolder)v));
					}
				}
			}

			//TODO:This SORTS cutouts
			cutouts = cutouts.OrderByDescending(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
		}

	}
}

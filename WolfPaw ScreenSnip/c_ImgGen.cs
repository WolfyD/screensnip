using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WolfPaw_ScreenSnip
{
	static class c_ImgGen
	{

		//DrawTBG => Draw with Transparent Background checkered pattern
		public static Bitmap createImage(System.Drawing.Rectangle rec, List<c_ImageHolder> cutouts, bool drawTBG)
		{
			int border = 0;

			if (Properties.Settings.Default.s_hasBorder)
			{
				border = Properties.Settings.Default.s_borderWidth;
			}

			Bitmap bm = null;

			try
			{
				bm = new Bitmap(rec.Width + (border * 2), rec.Height + (border * 2));

				using (Graphics g = Graphics.FromImage(bm))
				{
					c_returnGraphicSettings cg = new c_returnGraphicSettings();

					g.SmoothingMode = cg.getSM();
					g.InterpolationMode = cg.getIM();
					g.PixelOffsetMode = cg.getPOM();

					//g.Clear(Color.Transparent);

					if (Properties.Settings.Default.s_hasBgColor) { g.Clear(Properties.Settings.Default.s_bgColor); }
					else { g.Clear(Color.Transparent); }

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

					foreach (c_ImageHolder c in cutouts)
					{
						c_ImageHolder k = c;
						g.DrawImage(k.Image, new System.Drawing.Rectangle(k.Left - rec.Left + border, k.Top - rec.Top + border, k.Width, k.Height), new System.Drawing.Rectangle(0, 0, k.Image.Width, k.Image.Height), GraphicsUnit.Pixel);
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
			}
			catch
			{

			}

			return bm;
		}

		public static Bitmap createPng(f_Screen fs, List<c_ImageHolder> cutouts, Object[] drawings) { return createPng(fs, cutouts, drawings, false); }

		public static Bitmap createPng(f_Screen fs, List<c_ImageHolder> cutouts, Object[] drawings, bool drawTBG)
		{
			if (fs != null)
			{
				int left = int.MaxValue;
				int top = int.MaxValue;

				int right = 0;
				int bottom = 0;

				foreach (var v in cutouts)
				{
					//var k = v.Value;
					if (v.Left < left) { left = v.Left; }
					if (v.Top < top) { top = v.Top; }
					if (v.Left + v.Width > right) { right = v.Left + v.Width; }
					if (v.Top + v.Height > bottom) { bottom = v.Top + v.Height; }
				}

				int height = bottom - top;
				int width = right - left;

				var picrec = new System.Drawing.Rectangle(left, top, width, height);

				Bitmap _b = createImage(picrec, cutouts, drawTBG);
				
				return _b;
			}
			else { return null; }
		}




		
	}


}

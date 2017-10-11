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

		public static Bitmap createImage(System.Drawing.Rectangle rec, Dictionary<int, uc_CutoutHolder> cutouts)
		{
			return createImage(rec, cutouts, false);
		}

		public static Bitmap createImage(System.Drawing.Rectangle rec, Dictionary<int, uc_CutoutHolder> cutouts, bool drawTBG)
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

					g.Clear(Color.Transparent);

					if (Properties.Settings.Default.s_hasBgColor)
					{ g.Clear(Properties.Settings.Default.s_bgColor); }
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

					foreach (KeyValuePair<int, uc_CutoutHolder> kvp in cutouts)
					{
						uc_CutoutHolder k = kvp.Value;
						g.DrawImage(k.BMP, new System.Drawing.Rectangle(k.Left - rec.Left + border, k.Top - rec.Top + border, k.Width, k.Height), new System.Drawing.Rectangle(0, 0, k.BMP.Width, k.BMP.Height), GraphicsUnit.Pixel);
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

		public static Bitmap createPng(f_Screen fs, Dictionary<int, uc_CutoutHolder> cutouts, Object[] drawings) { return createPng(fs, cutouts, drawings, false); }

		public static Bitmap createPng(f_Screen fs, Dictionary<int, uc_CutoutHolder> cutouts, Object[] drawings, bool drawTBG)
		{
			if (fs != null)
			{
				fillDict(fs,out cutouts);

				int left = int.MaxValue;
				int top = int.MaxValue;

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

				var picrec = new System.Drawing.Rectangle(left, top, width, height);

				Bitmap _b = createImage(picrec, cutouts, drawTBG);

				//TODO: Redo this. drawnpoints instead of lines
				//TODO: New object type instead of Bitmaps
				if (drawings != null && drawings.Length == 2)
				{
					List<c_DrawnPoints> lines = drawings[0] as List<c_DrawnPoints>;
					//List<Bitmap> shapes = drawings[1] as List<Bitmap>;

					if(lines.Count > 0)

					try
					{
						using (Graphics g = Graphics.FromImage(_b))
						{

							for (int i = 0; i < lines.Count - 2; i++)
							{
								c_DrawnPoints l = lines[i];
								c_DrawnPoints l2 = lines[i + 1];

								Point p1 = new Point(l.X, l.Y);
								Point p2 = new Point(l2.X, l2.Y);

								g.DrawLine(Pens.Black, p1, p2);
							}
							/*
							foreach (Bitmap b in shapes)
							{
								g.DrawImage(b, new PointF(0, 0));
							}
							*/
						}
					}
					catch
					{

					}

				}

				return _b;
			}
			else { return null; }
		}

		public static void fillDict(f_Screen fs,out Dictionary<int, uc_CutoutHolder> cutouts)
		{
			cutouts = new Dictionary<int, uc_CutoutHolder>();
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

		public static Dictionary<int, uc_CutoutHolder> returnCutouts(f_Screen fs)
		{
			Dictionary<int, uc_CutoutHolder> c = new Dictionary<int, uc_CutoutHolder>();
			foreach (var v in fs.Controls)
			{
				if (v != null && v is uc_CutoutHolder)
				{
					int i = fs.Controls.GetChildIndex(((uc_CutoutHolder)v));
					if (!c.ContainsKey(i))
					{
						c.Add(i, ((uc_CutoutHolder)v));
					}
				}
			}
			return c;
		}

	}


}

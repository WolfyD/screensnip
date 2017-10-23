using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	static class c_Unsafe
	{
		//Creates array from list of points, adds first point to end of list
		public static Point[] generatePointArray(List<Point> pnts)
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
		public static unsafe Image getPixels(Bitmap _image, List<Point> cut_points, Rectangle cut)
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

		public static unsafe Dictionary<Point, Color> getPixelValues(Bitmap _image, Color c, List<Point> cut_points)
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


		public static Rectangle getRect(List<Point> cut_points)
		{
			Rectangle cut = new Rectangle(0, 0, 0, 0);

			int minx = cut_points.Min(x => x.X);
			int maxx = cut_points.Max(x => x.X);
			int miny = cut_points.Min(y => y.Y);
			int maxy = cut_points.Max(y => y.Y);

			cut.X = minx;
			cut.Y = miny;
			cut.Width = maxx - minx;
			cut.Height = maxy - miny;

			return cut;
		}

	}
}

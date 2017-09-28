using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	static class c_Converter
	{
		public static string ConvertToHex(Bitmap img)
		{
			StringBuilder sb = new StringBuilder();
			ImageConverter _imageConverter = new ImageConverter();
			byte[] xByte = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));
			foreach (byte b in xByte)
			{
				sb.Append(b.ToString("X2"));
			}

			return sb.ToString();
		}

		public static Bitmap ConvertToImg(string hex)
		{
			if (hex.Length % 2 != 0) { return null; }

			byte[] bb = new byte[hex.Length / 2];
			int ii = 0;
			for (int i = 0; i < hex.Length; i += 2)
			{
				bb[ii] = byte.Parse(hex[i] + "" + hex[i + 1], System.Globalization.NumberStyles.HexNumber);
				ii++;
			}

			Bitmap bmp;
			using (var ms = new MemoryStream(bb))
			{
				bmp = new Bitmap(ms);
			}

			return bmp;
		}
	}
}

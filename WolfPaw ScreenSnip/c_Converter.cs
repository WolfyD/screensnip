using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpSnip
{

	static class c_Converter
	{
		public static int MimeSampleSize = 512;
		public static string DefaultMimeType = "UNKNOWN";

		[DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
		private extern static uint FindMimeFromData(
			uint pBC,
			[MarshalAs(UnmanagedType.LPStr)] string pwzUrl,
			[MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
			uint cbSize,
			[MarshalAs(UnmanagedType.LPStr)] string pwzMimeProposed,
			uint dwMimeFlags,
			out uint ppwzMimeOut,
			uint dwReserverd
		);

		private static string GetMimeFromBytes(byte[] data)
		{
			try
			{
				uint mimeType = 0;
				FindMimeFromData(0, null, data, (uint)MimeSampleSize, null, 0, out mimeType, 0);

				var mimePointer = new IntPtr(mimeType);
				var mime = Marshal.PtrToStringUni(mimePointer);
				Marshal.FreeCoTaskMem(mimePointer);

				return mime ?? DefaultMimeType;
			}
			catch
			{
				return DefaultMimeType;
			}
		}

		public static string fileToMime(string fn)
		{
			DirectoryInfo di = new DirectoryInfo(fn);
			string mime = "Directory";
			if (!di.Exists)
			{
				mime = GetMimeFromBytes(File.ReadAllBytes(fn));
			}

			return mime;
		}

		public static Bitmap fileToImage(string fn)
		{
			Bitmap retb = null;
			byte[] b = File.ReadAllBytes(fn);

			using (MemoryStream ms = new MemoryStream(b))
			{
				retb = new Bitmap(ms);
			}
			return retb;
		}

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

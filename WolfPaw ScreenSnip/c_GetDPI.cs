using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpSnip
{
	public static class c_GetDPI
	{
		public static void GetDpi(this System.Windows.Forms.Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
		{
			var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
			var mon = MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
			GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
		}
		
		[DllImport("User32.dll")]
		private static extern IntPtr MonitorFromPoint([In]System.Drawing.Point pt, [In]uint dwFlags);
		[DllImport("Shcore.dll")]
		private static extern IntPtr GetDpiForMonitor([In]IntPtr hmonitor, [In]DpiType dpiType, [Out]out uint dpiX, [Out]out uint dpiY);
	}

	public enum DpiType
	{
		Effective = 0,
		Angular = 1,
		Raw = 2,
	}
}

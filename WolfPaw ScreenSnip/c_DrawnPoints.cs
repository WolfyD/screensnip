using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	public class c_DrawnPoints
	{
		public int width { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public Color color { get; set; }

		public c_DrawnPoints(int _wid, int x, int y, Color col)
		{
			width = _wid;
			X = x;
			Y = y;
			color = col;
		}
	}
}

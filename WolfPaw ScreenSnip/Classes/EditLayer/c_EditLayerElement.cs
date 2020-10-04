using System;
using System.Collections.Generic;
using System.Drawing;

namespace SharpSnip
{
    public class c_EditLayerElement
	{
		public elementTypes type { get; set; }
		public Point _Position { get; set; }
		public Size _Size { get; set; }
		public int _ToolSize { get; set; }
		public Font _Font { get; set; }
		public Bitmap _Drawing { get; set; }
		public String _Text { get; set; }
		public List<Point> _Points { get; set; }
		public Point _ArrowP1 { get; set; }
		public Point _ArrowP2 { get; set; }
		public bool _Selected { get; set; }

		public Rectangle getBounds()
		{
			return new Rectangle(_Position, _Size);
		}
	}
	
}



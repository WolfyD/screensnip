﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSnip
{
    public class c_EditLayer
	{
		//TODO: Finish Edit Layer

		public List<c_EditLayerElement> elements = new List<c_EditLayerElement>();

		public bool mouseOverElement(Point p)
		{
			foreach(c_EditLayerElement ee in elements)
			{
				if (ee.getBounds().Contains(p))
				{
					return true;
				}
			}

			return false;
		}

		public c_EditLayerElement getElementUnderMouse(Point p)
		{
			foreach (c_EditLayerElement ee in elements)
			{
				if (ee.getBounds().Contains(p))
				{
					return ee;
				}
			}
			return null;
		}

		/// <summary>
		/// Add Drawing to EditLayer
		/// </summary>
		public void addElement(Bitmap _Drawing, Point _Position, Size _Size)
		{
			c_EditLayerElement e = new c_EditLayerElement();
			e.type = elementTypes.drawing;
			e._Drawing = _Drawing;
			e._Position = _Position;
			e._Size = _Size;
			elements.Add(e);
		}

		/// <summary>
		/// Add arrow to EditLayer
		/// </summary>
		public void addElement(Point _ArrowP1, Point _ArrowP2, int _ToolSize)
		{
			c_EditLayerElement e = new c_EditLayerElement();
			e.type = elementTypes.arrow;
			e._ArrowP1 = _ArrowP1;
			e._ArrowP2 = _ArrowP2;
			e._ToolSize = _ToolSize;
			elements.Add(e);
		}

		/// <summary>
		/// Add Textbox to EditLayer
		/// </summary>
		public void addElement(Point _Position, Size _Size,Font _Font)
		{
			c_EditLayerElement e = new c_EditLayerElement();
			e.type = elementTypes.textbox;
			e._Position = _Position;
			e._Size = _Size;
			e._Font = _Font;
			elements.Add(e);
		}

	}
	
}



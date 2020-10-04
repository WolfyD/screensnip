using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSnip
{
	public partial class uc_TrackBar : UserControl
	{
		public enum style
		{
			emptyCircle,
			fullCircle,
			emptyAndFullCircle
		}

		private double min = 0;
		public double Min { get { return min; } set { min = value; } }
		private double max = 10;
		public double Max { get { return max; } set { max = value; } }
		private double val = 5;
		public double Val { get { return val; } set { val = value; setValue(); } }
		private style stl;
		[DisplayName("HandleStyle"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Misc")]
		public style Style { get { return stl; } set { stl = value; Invalidate(); } }
		private Color col;
		public Color HandleColor { get { return col; } set { col = value; } }
		int Hmid = 0;
		int width = 0;
		double percent = 0;
		double point = 0;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		public uc_TrackBar()
		{
			InitializeComponent();
			OnValueChange += Uc_TrackBar_OnValueChange;
			Load += Uc_TrackBar_Load;
		}

		private void Uc_TrackBar_Load(object sender, EventArgs e)
		{
			setValues();
		}

		public void setValues()
		{
			width = Width;
			Hmid = Height / 2;
		}

		public void calculatePoint()
		{
			calculatePercent();
			point = (((Width - 15) * 1.0d) / 100) * percent;
		}

		public void calculatePercent()
		{
			percent = (100 / (max - min)) * (val - min);
		}

		public void setValue()
		{
			Invalidate();
		}

		public void getPointByClick(int x)
		{
			point = x - 5;
			percent = (100 * 1.0f) / (width * 1.0f) * point;

			double _val = max / 100 * percent;

			if (_val >= min && _val <= max) {
				val = _val;
				setValue();
				OnValueChange(this, new ValueEventArgs(val));
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			calculatePoint();

			Pen colorPen = new Pen(col);
			Brush colorBrush = new SolidBrush(col);

			e.Graphics.DrawLine(Pens.Black, new Point(5, Hmid), new Point(width - 10, Hmid));
			if (stl == style.emptyCircle)
			{
				e.Graphics.DrawEllipse(colorPen, new RectangleF(new PointF((float)point, Hmid - 5), new SizeF(10, 10)));
			}
			else if (stl == style.fullCircle)
			{
				e.Graphics.FillEllipse(colorBrush, new RectangleF(new PointF((float)point, Hmid - 5), new SizeF(10, 10)));
			}
			else if (stl == style.emptyAndFullCircle)
			{
				e.Graphics.DrawEllipse(colorPen, new RectangleF(new PointF((float)point - 2, Hmid - 7), new SizeF(14, 14)));
				e.Graphics.FillEllipse(colorBrush, new RectangleF(new PointF((float)point, Hmid - 5), new SizeF(10, 10)));
			}
		}

		public bool mdown = false;

		private void uc_TrackBar_MouseDown(object sender, MouseEventArgs e)
		{
			mdown = true;
			getPointByClick(e.X);
		}

		private void uc_TrackBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (mdown)
			{
				getPointByClick(e.X);
			}
		}

		private void uc_TrackBar_MouseUp(object sender, MouseEventArgs e)
		{
			mdown = false;
		}

		private void Uc_TrackBar_OnValueChange(object sender, EventArgs e)
		{
			
		}
		

		public event ValueChanged OnValueChange;
		public delegate void ValueChanged(object sender, ValueEventArgs e);
	}

	public class ValueEventArgs : EventArgs
	{
		public double Val { get; private set; }

		public ValueEventArgs(double val)
		{
			Val = val;
		}
	}

}

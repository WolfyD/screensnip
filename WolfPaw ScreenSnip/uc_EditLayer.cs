using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class uc_EditLayer : UserControl
	{
		public bool mdown = false;
		public f_Screen parent { get; set; }
		public Point curpos = new Point(-1, -1);
		public Point mpos = new Point(-1, -1);
		Bitmap bmp = null;
		Bitmap old = null;
		private int Tool;
		public int toolSize = 1;
		public int tool
		{
			get { return Tool; }
			set { Tool = value; setTool(Tool); }
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000020;  // Turn on WS_EX_TRANSPARENT
				return cp;
			}
		}

		public uc_EditLayer()
		{
			InitializeComponent();
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.Opaque, true);
			this.BackColor = Color.Transparent;
			Load += Uc_EditLayer_Load;
		}

		private void Uc_EditLayer_Load(object sender, EventArgs e)
		{
			handleNewBitmap();
		}

		public void handleNewBitmap()
		{
			if(bmp == null)
			{
				bmp = new Bitmap(Width, Height);
			}
			else
			{
				old = bmp;
				bmp = new Bitmap(Width, Height);
				using(Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(old, new Point(0, 0));
				}

				Invalidate();
			}
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			if (this.Parent != null)
			{
				Parent.Invalidate(this.Bounds, true);
			}
			base.OnBackColorChanged(e);
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			this.Invalidate();
			base.OnParentBackColorChanged(e);
		}

		private void uc_EditLayer_MouseDown(object sender, MouseEventArgs e)
		{
			mdown = true;
			curpos = e.Location;
		}

		private void uc_EditLayer_MouseUp(object sender, MouseEventArgs e)
		{
			mdown = false;
		}

		public void callGraphics()
		{
			OnPaint(new PaintEventArgs(CreateGraphics(), Bounds));
		}

		SolidBrush sb = new SolidBrush(Color.FromArgb(1, Color.Yellow));

		private void uc_EditLayer_MouseMove(object sender, MouseEventArgs e)
		{
			mpos = e.Location;

			if (mdown)
			{
				/*
				using(Graphics g = Graphics.FromImage(bmp))
				{
					if (Tool == 1)
					{
						g.DrawLine(Pens.Black, curpos, e.Location);
						
					}
					else if (Tool == 2)
					{
						g.FillRectangle(sb, new Rectangle(curpos.X, curpos.Y - 4, e.X - curpos.X, 20));
					}
					else if (Tool == 3)
					{

					}
				}

				curpos = e.Location;
				callGraphics();
				*/
			}

			
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			try { e.Graphics.DrawImage(bmp, 0, 0); } catch { }
		}

		public void setTool(int _t)
		{
			
		}

		private void uc_EditLayer_SizeChanged(object sender, EventArgs e)
		{
			handleNewBitmap();
		}
	}
}

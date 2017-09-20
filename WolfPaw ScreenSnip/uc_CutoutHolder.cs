using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WolfPaw_ScreenSnip
{
    public partial class uc_CutoutHolder : UserControl
    {
        Bitmap bmp = null;
        public Bitmap BMP { get { return bmp; } set { bmp = value; setimg(bmp); } }

        private Bitmap img = null;
        private bool redraw = false;

        private bool resize = false;
        private bool overresize = false;
        private bool move = false;
        private Point movexy = new Point(0, 0);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		public uc_CutoutHolder()
        {
            InitializeComponent();

            this.MouseEnter += Uc_CutoutHolder_MouseEnter;
            this.MouseLeave += Uc_CutoutHolder_MouseLeave;
            this.MouseMove += Uc_CutoutHolder_MouseMove;
            this.MouseDown += Uc_CutoutHolder_MouseDown;
            this.MouseUp += Uc_CutoutHolder_MouseUp;

            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseUp += Panel1_MouseUp;
            panel1.MouseMove += Panel1_MouseMove;
			panel1.MouseEnter += Panel1_MouseEnter;
			panel1.MouseLeave += Panel1_MouseLeave;

			Load += Uc_CutoutHolder_Load;
        }

        private void Uc_CutoutHolder_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            resize = false;
        }

        private void Uc_CutoutHolder_MouseDown(object sender, MouseEventArgs e)
        {
            BringToFront();

            if (!overresize)
            {
                move = true;
                movexy = e.Location;
            }else
            {
                resize = true;
            }
        }

        private void Uc_CutoutHolder_Load(object sender, EventArgs e)
		{
			BringToFront();
		}

		private void Panel1_MouseLeave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
            Width += 2;
            Height += 2;
			panel1.Height = 0;
		}

		private void Panel1_MouseEnter(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
            Width -= 2;
            Height -= 2;
        }

		private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Point p = new Point(0, 0);
                p.X = Left + e.X;
                p.Y = Top + e.Y;

                Left = p.X - movexy.X;
                Top = p.Y - movexy.Y;
            }
        }
        

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            movexy = e.Location;
        }

        private void Uc_CutoutHolder_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Point p = new Point(0, 0);
                p.X = Left + e.X;
                p.Y = Top + e.Y;

                Left = p.X - movexy.X;
                Top = p.Y - movexy.Y;
            }else if (resize)
            {
                Width = e.X;
                Height = e.Y;
                Invalidate();
            }

            if (e.Y < 20)
            {
                panel1.Height = 20;
			}

            if(e.X >= Width - 10 && e.Y >= Height - 10)
            {
                Cursor = Cursors.SizeNWSE;
                overresize = true;
            }
            else
            {
                Cursor = Cursors.Default;
                overresize = false;
            }
        }

        private void Uc_CutoutHolder_MouseLeave(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
        }

        private void Uc_CutoutHolder_MouseEnter(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void setimg(Bitmap i)
        {
            img = i;
            redraw = true;
        }
		
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (redraw)
            {
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
					c_returnGraphicSettings cg = new c_returnGraphicSettings();

					g.SmoothingMode = cg.getSM();
					g.InterpolationMode = cg.getIM();
					g.PixelOffsetMode = cg.getPOM();

					Rectangle r = this.Bounds;
                    r.Y = panel1.Height;

                    Rectangle rr = new Rectangle(0, 0, r.Width, r.Height);

                    g.DrawImage(img, rr);
                }
            }
        }

        private void uc_CutoutHolder_SizeChanged(object sender, EventArgs e)
        {
            panel1.Width = Width;
        }

        private void pb_btn_Delete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

		private void uc_CutoutHolder_LocationChanged(object sender, EventArgs e)
		{
			Parent.Invalidate();
		}
	}
}

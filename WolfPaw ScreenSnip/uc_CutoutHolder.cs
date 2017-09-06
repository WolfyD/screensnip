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
    public partial class uc_CutoutHolder : UserControl
    {
        Bitmap bmp = null;
        public Bitmap BMP { get { return bmp; } set { bmp = value; setimg(bmp); } }

        private Bitmap img = null;
        private bool redraw = false;

        private bool resize = false;
        private bool move = false;
        private Point movexy = new Point(0, 0);

        public uc_CutoutHolder()
        {
            InitializeComponent();

            this.MouseEnter += Uc_CutoutHolder_MouseEnter;
            this.MouseLeave += Uc_CutoutHolder_MouseLeave;
            this.MouseMove += Uc_CutoutHolder_MouseMove;

            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseUp += Panel1_MouseUp;
            panel1.MouseMove += Panel1_MouseMove;
			panel1.MouseEnter += Panel1_MouseEnter;
			panel1.MouseLeave += Panel1_MouseLeave;

			Load += Uc_CutoutHolder_Load;
        }

		private void Uc_CutoutHolder_Load(object sender, EventArgs e)
		{
			BringToFront();
		}

		private void Panel1_MouseLeave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
			panel1.Height = 0;
		}

		private void Panel1_MouseEnter(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}

		private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
				Point p = new Point(0,0);
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
			BringToFront();
			move = true;
            movexy = e.Location;
        }

        private void Uc_CutoutHolder_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Y < 20)
            {
                panel1.Height = 20;
			}

            if(e.X >= Width - 10 && e.Y >= Height - 10)
            {
                Cursor = Cursors.SizeNWSE;
            }else
            {
                Cursor = Cursors.Default;
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

		private void pb_BringToFront_Click(object sender, EventArgs e)
		{
			
		}
	}
}

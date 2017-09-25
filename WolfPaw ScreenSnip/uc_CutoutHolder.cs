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
using System.Drawing.Imaging;

namespace WolfPaw_ScreenSnip
{
    public partial class uc_CutoutHolder : UserControl
    {
        Bitmap bmp = null;
		Bitmap bmpBackup = null;
        public Bitmap BMP { get { return bmp; } set { bmp = value; bmpBackup = value; setimg(bmp); } }

        private Bitmap img = null;
        private bool redraw = false;

        private bool resize = false;
        private bool overresize = false;
        private bool move = false;
        private Point movexy = new Point(0, 0);
		private bool overCorner = false;

        private bool keepAspectRatio = false;
        
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
            Width += 2;
            Height += 2;
			panel1.Height = 0;
			BorderStyle = BorderStyle.None;
		}

		private void Panel1_MouseEnter(object sender, EventArgs e)
		{
            Width -= 2;
            Height -= 2;
			BorderStyle = BorderStyle.FixedSingle;
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
            System.Windows.Input.Key lc = System.Windows.Input.Key.LeftCtrl;
            System.Windows.Input.Key rc = System.Windows.Input.Key.RightCtrl;

            if (System.Windows.Input.Keyboard.IsKeyDown(lc) || 
                System.Windows.Input.Keyboard.IsKeyDown(rc))
            {
                keepAspectRatio = true;
            }else
            {
                keepAspectRatio = false;
            }

            if (move)
            {
                Point p = new Point(0, 0);
                p.X = Left + e.X;
                p.Y = Top + e.Y;

                Left = p.X - movexy.X;
                Top = p.Y - movexy.Y;
            }
			else if (resize && Height >= 24)
            {
                if (keepAspectRatio)
                {
					//TODO:KEEP ASPECT RATIO
					Height = e.Y;
					Width = getRatio(bmp.Width, bmp.Height, e.Y);
				}
                else
                {
                    Width = e.X;
                    Height = e.Y;
                }

                Invalidate();
            }

			if(Height < 24) { Height = 24; }

            if (e.Y < 20)
            {
                panel1.Height = 20;
			}

            if(e.X >= Width - 20 && e.Y >= Height - 20)
            {
				overCorner = true;
                if (keepAspectRatio)
                {
                    Cursor = Cursors.SizeAll;
                }
                else
                {
                    Cursor = Cursors.SizeNWSE;
                }
                overresize = true;
            }
            else
            {
                Cursor = Cursors.Default;
                overresize = false;
            }
        }

		public int getRatio(int ow, int oh, int height)
		{
			int ret = 0;

			double ratio = (ow * 1.0) / (oh * 1.0);
			double wid = ratio * height;

			ret = (int)Math.Floor(wid);

			return ret;
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

					if(BorderStyle == BorderStyle.FixedSingle)
					{

						g.DrawLine(Pens.Black, new Point(Width - 20, Height), new Point(Width, Height - 20));
						g.DrawLine(Pens.Black, new Point(Width - 19, Height), new Point(Width, Height - 19));
						g.DrawLine(Pens.Black, new Point(Width - 17, Height), new Point(Width, Height - 17));
						g.DrawLine(Pens.Black, new Point(Width - 16, Height), new Point(Width, Height - 16));
						g.DrawLine(Pens.Black, new Point(Width - 14, Height), new Point(Width, Height - 14));
						g.DrawLine(Pens.Black, new Point(Width - 13, Height), new Point(Width, Height - 13));
						g.DrawLine(Pens.Black, new Point(Width - 11, Height), new Point(Width, Height - 11));
						g.DrawLine(Pens.Black, new Point(Width - 10, Height), new Point(Width, Height - 10));
						g.DrawLine(Pens.Black, new Point(Width - 8, Height), new Point(Width, Height - 8));
						g.DrawLine(Pens.Black, new Point(Width - 7, Height), new Point(Width, Height - 7));
						g.DrawLine(Pens.Black, new Point(Width - 5, Height), new Point(Width, Height - 5));
						g.DrawLine(Pens.Black, new Point(Width - 4, Height), new Point(Width, Height - 4));
						g.DrawLine(Pens.Black, new Point(Width - 2, Height), new Point(Width, Height - 2));
						g.DrawLine(Pens.Black, new Point(Width - 1, Height), new Point(Width, Height - 1));
					}
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

		private void pb_btn_Delete_MouseLeave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
			Width += 2;
			Height += 2;
			panel1.Height = 0;
		}

		private void pb_btn_OriginalSize_Click(object sender, EventArgs e)
		{
			Width = bmp.Width;
			Height = bmp.Height;
		}

		public int getIndex()
		{
			return ParentForm.Controls.GetChildIndex(this);
		}

		private void pb_btn_UP_Click(object sender, EventArgs e)
		{
			int ci = getIndex();
			ParentForm.Controls.SetChildIndex(this, ci - 1);
			ParentForm.Refresh();
		}

		private void pb_btn_DOWN_Click(object sender, EventArgs e)
		{
			int ci = getIndex();
			ParentForm.Controls.SetChildIndex(this, ci + 1);
			ParentForm.Refresh();
		}

		private void pb_btn_Transparent_Click(object sender, EventArgs e)
		{
			f_TCP ft = new f_TCP();
			ft.bmp = bmp;
			ft.TopMost = true;
			ft.ShowDialog();
			if (ft.OK)
			{
				int r = ft.TC.R;
				int g = ft.TC.G;
				int b = ft.TC.B;
				int t = ft.T;

				for (int y = 0; y < bmp.Height; y++)
				{
					for (int x = 0; x < bmp.Width; x++)
					{
						Color c = bmp.GetPixel(x, y);
						if ((c.R > r - t && c.R < r + t) && 
							(c.G > g - t && c.G < g + t) && 
							(c.B > b - t && c.B < b + t))
						{
							bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
						}
					}
				}
				
				BMP.MakeTransparent(Color.FromArgb(0, 0, 0, 0));
			}
		}

		public Bitmap getImage()
		{
			Bitmap __bmp = new Bitmap(Width, Height);
			using (Graphics g = Graphics.FromImage(__bmp))
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

			return __bmp;
		}

		private void pb_btn_Copy_Click(object sender, EventArgs e)
		{
			Clipboard.SetImage(getImage());
		}

		private void pb_btn_Save_Click(object sender, EventArgs e)
		{
			Bitmap _b = getImage();
			string savename = "ScreenSnip_";

			if (true || Properties.Settings.Default.s_SaveHasDateTime)
			{
				string date = "";
				DateTime n = DateTime.Now;
				date = n.Year + "." + n.Month.ToString().PadLeft(2, '0') + "." + n.Day.ToString().PadLeft(2, '0') + "_" + n.Hour.ToString().PadLeft(2, '0') + "." + n.Minute.ToString().PadLeft(2, '0') + "." + n.Second.ToString().PadLeft(2, '0');
				savename += date;
			}
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Portable Network Graphics Image (PNG)|*.png|" +
							"Bitmap Image (BMP)|*.bmp|" +
							"Joint Photographic Experts Group Image (JPEG)|*.jpg;*.jpeg|" +
							"Graphics Interchange Format Image (GIF)|*.gif|" +
							"Tagged Image File Format Image (TIFF)|*.tif;*.tiff|" +
							"Windows Metafile Image (WMF)|*.wmf";

			sfd.FilterIndex = Properties.Settings.Default.s_lastSaveFormat;

			sfd.FileName = savename;

			if (sfd.ShowDialog() == DialogResult.OK)
			{

				ImageFormat _if = ImageFormat.Png;

				switch (sfd.FileName.Substring(sfd.FileName.LastIndexOf(".") + 1).ToLower())
				{
					case "png":
						_if = ImageFormat.Png;
						Properties.Settings.Default.s_lastSaveFormat = 0;
						break;

					case "bmp":
						_if = ImageFormat.Bmp;
						Properties.Settings.Default.s_lastSaveFormat = 1;
						break;

					case "jpg":
						_if = ImageFormat.Jpeg;
						Properties.Settings.Default.s_lastSaveFormat = 2;
						break;

					case "jpeg":
						_if = ImageFormat.Jpeg;
						Properties.Settings.Default.s_lastSaveFormat = 2;
						break;

					case "gif":
						_if = ImageFormat.Gif;
						Properties.Settings.Default.s_lastSaveFormat = 3;
						break;

					case "tif":
						_if = ImageFormat.Tiff;
						Properties.Settings.Default.s_lastSaveFormat = 4;
						break;

					case "tiff":
						_if = ImageFormat.Tiff;
						Properties.Settings.Default.s_lastSaveFormat = 4;
						break;

					case "wmf":
						_if = ImageFormat.Wmf;
						Properties.Settings.Default.s_lastSaveFormat = 5;
						break;

					default:
						_if = ImageFormat.Png;
						Properties.Settings.Default.s_lastSaveFormat = 0;
						break;
				}

				_b.Save(sfd.FileName, _if);

			}
		}

        private void uc_CutoutHolder_KeyDown(object sender, KeyEventArgs e)
        {
			if (overCorner)
			{
				if (e.KeyCode == Keys.LControlKey || 
					e.KeyCode == Keys.RControlKey || 
					e.KeyCode == Keys.ControlKey)
				{
					Cursor = Cursors.SizeAll;
				}
				else
				{
					Cursor = Cursors.SizeNWSE;
				}
			}
			
        }

        private void uc_CutoutHolder_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

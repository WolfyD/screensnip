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
		private bool moveLR = false;
		private bool moveUD = false;

		public bool moveMode = false;

		public int cmsSetup = 0;

		
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
			} else
			{
				resize = true;
			}
		}

		private void Uc_CutoutHolder_Load(object sender, EventArgs e)
		{
			//BackgroundImage = bmp;
			BringToFront();
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		private void Panel1_MouseLeave(object sender, EventArgs e)
		{
			panel1.Height = 0;
			BorderStyle = BorderStyle.None;
		}

		private void Panel1_MouseEnter(object sender, EventArgs e)
		{
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

				//TODO: Transparency
				//BackColor = Color.FromArgb(100, Color.White);
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
			System.Windows.Input.Key _ls = System.Windows.Input.Key.LeftShift;
			System.Windows.Input.Key _rs = System.Windows.Input.Key.RightShift;
			System.Windows.Input.Key _la = System.Windows.Input.Key.LeftAlt;
			System.Windows.Input.Key _ra = System.Windows.Input.Key.RightAlt;


			//Keep Aspect Ratio
			if (System.Windows.Input.Keyboard.IsKeyDown(lc) ||
				System.Windows.Input.Keyboard.IsKeyDown(rc))
			{
				keepAspectRatio = true;
			}
			else
			{
				keepAspectRatio = false;
			}

			//Move ←→
			if (System.Windows.Input.Keyboard.IsKeyDown(_ls) ||
				System.Windows.Input.Keyboard.IsKeyDown(_rs))
			{
				moveLR = true;
			}
			else
			{
				moveLR = false;
			}

			//Move↑↓
			if (System.Windows.Input.Keyboard.IsKeyDown(_la) ||
				System.Windows.Input.Keyboard.IsKeyDown(_ra))
			{
				moveUD = true;
			}
			else
			{
				moveUD = false;
			}

			if (move)
			{
				Point p = new Point(0, 0);
				p.X = Left + e.X;
				p.Y = Top + e.Y;

				if (moveUD)
				{
					Top = p.Y - movexy.Y;
				}
				else if (moveLR)
				{
					Left = p.X - movexy.X;
				}
				else
				{
					Left = p.X - movexy.X;
					Top = p.Y - movexy.Y;
				}


			}
			else if (resize && Height >= 24)
			{
				if (keepAspectRatio)
				{
					Height = e.Y;
					Width = getRatio(bmp.Width, bmp.Height, e.Y);
				}
				else if (moveLR)
				{
					Width = e.X;
				}
				else if (moveUD)
				{
					Height = e.Y;
				}
				else
				{
					Width = e.X;
					Height = e.Y;
				}

				//handlePanelButtons();

				ParentForm.Refresh();
				Invalidate();
			}

			if (Height < 24)
			{
				Height = 24;
			}
			if (Width < 24)
			{
				Width = 24;
			}

			if (e.Y < 20)
			{
				panel1.Height = 20;
			}

			if (e.X >= Width - 20 && e.Y >= Height - 20)
			{
				overCorner = true;
				if (keepAspectRatio)
				{
					Cursor = Cursors.SizeAll;
				}
				else if (moveLR)
				{
					Cursor = Cursors.SizeWE;
				}
				else if (moveUD)
				{
					Cursor = Cursors.SizeNS;
				}
				else
				{
					Cursor = Cursors.SizeNWSE;
				}
				overresize = true;
			}
			else
			{
				if (moveLR)
				{
					Cursor = Cursors.SizeWE;
				}
				else if (moveUD)
				{
					Cursor = Cursors.SizeNS;
				}
				else
				{
					Cursor = Cursors.Default;
				}
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

					if (BorderStyle == BorderStyle.FixedSingle)
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

					if (moveMode)
					{
						//g.DrawRectangle(Pens.Black, new Rectangle(1, 1, Width + 2, Height - 2));
						//g.DrawRectangle(Pens.Red, new Rectangle(2, 2, Width - 4, Height - 4));

					}

				}
			}
		}

		private void uc_CutoutHolder_SizeChanged(object sender, EventArgs e)
		{
			panel1.Width = Width;
			handlePanelButtons();
		}

		public void clickMovementMode()
		{
			btn_PrecisionMovement_Click(null, null);
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
				if (keepAspectRatio)
				{
					Cursor = Cursors.SizeAll;
				}
				else if (moveUD)
				{
					Cursor = Cursors.SizeNS;
				}
				else if (moveLR)
				{
					Cursor = Cursors.SizeWE;
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

		private void pb_btn_OriginalSize_MouseEnter(object sender, EventArgs e)
		{
			((FontAwesome.Sharp.IconButton)sender).IconColor = Color.White;
		}

		private void pb_btn_OriginalSize_MouseLeave(object sender, EventArgs e)
		{
			((FontAwesome.Sharp.IconButton)sender).IconColor = Color.Black;
		}

		private void btn_FitSize_Click(object sender, EventArgs e)
		{
			if (Width > Height)
			{
				int hm = 15;
				Width = ParentForm.Width - hm;
				Height = getRatio(bmp.Height, bmp.Width, ParentForm.Width - hm);
			}
			else
			{
				int hm = 65;
				Height = ParentForm.Height - hm;
				Width = getRatio(bmp.Width, bmp.Height, ParentForm.Height - hm);
			}
		}

		private void btn_PrecisionMovement_Click(object sender, EventArgs e)
		{
			var c = c_ImgGen.returnCutouts(ParentForm as f_Screen);
			foreach (var v in c.Values)
			{
				if (v != this)
				{
					v.moveMode = false;
					v.btn_PrecisionMovement.IconColor = Color.Black;
					v.Refresh();
				}

			}

			moveMode = !moveMode;
			if (moveMode)
			{
				((f_Screen)ParentForm).showSBS();
			}
			else
			{
				((f_Screen)ParentForm).hideSBS();
			}


			btn_PrecisionMovement.IconColor = moveMode ? Color.Red : Color.Black;
			ParentForm.Refresh();
		}

		private void pb_btn_OriginalSize_MouseEnter_1(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}

		private void pb_btn_OriginalSize_MouseLeave_1(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
		}

		private void uc_CutoutHolder_MouseEnter_1(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}

		private void uc_CutoutHolder_MouseLeave_1(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
		}

		private void btn_PrecisionMovement_MouseEnter(object sender, EventArgs e)
		{
			btn_PrecisionMovement.IconColor = Color.White;
		}

		private void btn_PrecisionMovement_MouseLeave(object sender, EventArgs e)
		{
			btn_PrecisionMovement.IconColor = moveMode ? Color.Red : Color.Black;
		}

		private void pb_btn_OriginalSize_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
				e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				e.IsInputKey = true;
			}
		}

		private void pb_btn_OriginalSize_KeyDown(object sender, KeyEventArgs e)
		{
			//((f_Screen)ParentForm).f_Screen_KeyDown(null, null);
		}

		public void setupCMS()
		{
			

			switch (cmsSetup)
			{
				case 1:
					foreach (ToolStripMenuItem c in cms_Panel.Items) { c.Visible = false; }
					cms_btn_LayerDown.Visible = true;
					cms_btn_LayerUp.Visible = true;
					cms_btn_Fit.Visible = true;
					break;

				case 2:
					foreach (ToolStripMenuItem c in cms_Panel.Items) { c.Visible = false; }
					cms_btn_LayerDown.Visible = true;
					cms_btn_LayerUp.Visible = true;
					cms_btn_Fit.Visible = true;
					cms_btn_PresiceMovementMode.Visible = true;
					cms_btn_Save.Visible = true;
					cms_btn_Copy.Visible = true;
					break;

				case 3:
					foreach (ToolStripMenuItem c in cms_Panel.Items) { c.Visible = true; }
					break;


				default:
					break;
			}
		}

		public void setupPanel()
		{
			switch (cmsSetup)
			{
				case 0:
					btn_CMS.Hide();
					btn_OriginalSize.Show();
					btn_FitSize.Show();
					btn_Up.Show();
					btn_Down.Show();
					btn_PrecisionMovement.Show();
					btn_Save.Show();
					btn_Copy.Show();
					btn_Delete.Show();
					break;

				case 1:
					btn_CMS.Show();
					btn_CMS.Left = btn_PrecisionMovement.Left - btn_CMS.Width - 5;

					btn_OriginalSize.Show();
					btn_PrecisionMovement.Show();
					btn_Save.Show();
					btn_Copy.Show();
					btn_Delete.Show();

					btn_FitSize.Hide();
					btn_Up.Hide();
					btn_Down.Hide();
					break;

				case 2:
					btn_CMS.Show();
					btn_CMS.Left = btn_Delete.Left - btn_CMS.Width - 5;

					btn_OriginalSize.Show();
					btn_Delete.Show();

					btn_FitSize.Hide();
					btn_Up.Hide();
					btn_Down.Hide();

					btn_PrecisionMovement.Hide();
					btn_Save.Hide();
					btn_Copy.Hide();
					break;

				case 3:
					btn_CMS.Show();
					btn_CMS.Left = Width - btn_CMS.Width;

					btn_OriginalSize.Hide();
					btn_Delete.Hide();

					btn_FitSize.Hide();
					btn_Up.Hide();
					btn_Down.Hide();

					btn_PrecisionMovement.Hide();
					btn_Save.Hide();
					btn_Copy.Hide();
					break;


				default:
					break;
			}
		}

		public void handlePanelButtons()
		{
			if (panel1.Width < 65)
			{
				cmsSetup = 3;
			}
			else if (panel1.Width < 135)
			{
				cmsSetup = 2;
			}
			else if (panel1.Width < 175)
			{
				cmsSetup = 1;
			}
			else
			{
				cmsSetup = 0;
			}

			setupPanel();
			setupCMS();
		}

		private void t_Hide_Tick(object sender, EventArgs e)
		{
			if(this.GetChildAtPoint(PointToClient(Cursor.Position)) != panel1 && !cms_Panel.Visible)
			{
				panel1.Height = 0;
			}
		}

		private void btn_CMS_Click(object sender, EventArgs e)
		{
			cms_Panel.Show(this, PointToClient(PointToScreen(btn_CMS.Location)), ToolStripDropDownDirection.AboveRight);
		}

		private void uc_CutoutHolder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			
		}
	}
}

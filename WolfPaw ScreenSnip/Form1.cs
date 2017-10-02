using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using System.Data.SQLite;

namespace WolfPaw_ScreenSnip
{
    public partial class Form1 : Form
    {
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

        //TODO: Add save to DB

		f_Screen fs = null;
		f_SettingPanel tools = null;
		Dictionary<int, uc_CutoutHolder> cutouts = new Dictionary<int, uc_CutoutHolder>();

		private bool highHandle = false;
		public bool clearRequireAuth = false;

       

        public Form1()
        {
            InitializeComponent();

			Left = 0;
			Top = 0;

            Load += Form1_Load;
			
        }

		public void loadSettings()
		{
			//Set handle size
			highHandle = Properties.Settings.Default.s_HighHandle;
			if (highHandle){Height = 65;}
			else{Height = 50;}
			Form1_Activated(null, null);

			//Set clear
			clearRequireAuth = Properties.Settings.Default.s_ClearRequireAuth;

			//TODO: rest of settings

		}

        public void setIcons(string btn, Button b, Control parent)
        {
            IconButton ib = new IconButton();
            ib.Parent = parent;
            ib.Size = new Size(40, 40);
			ib.IconSize = 40;

			switch (btn)
            {
                case "new":
                    ib.Icon = IconChar.Scissors;
                    break;

                case "clear":
                    ib.Icon = IconChar.TrashO;
                    break;

                case "preview":
                    ib.Icon = IconChar.PictureO;
                    break;

                case "copy":
                    ib.Icon = IconChar.FilesO;
                    break;

                case "save":
                    ib.Icon = IconChar.FloppyO;
                    break;

                case "print":
                    ib.Icon = IconChar.Print;
                    break;

                case "mail":
                    ib.Icon = IconChar.EnvelopeO;
                    break;

                case "settings":
                    ib.Icon = IconChar.Cogs;
                    break;

                case "tools":
                    ib.Icon = IconChar.Wrench;
                    break;

				case "db":
					ib.Icon = IconChar.Database;
					ib.IconSize = 36;
					break;

				case "db1":
					ib.Icon = IconChar.FolderOpenO;
					break;

				case "exit":
                    ib.Icon = IconChar.WindowClose;
                    break;
                    
                default:
                    break;
            }

            b.Hide();
            ib.Left = b.Left;
            ib.Top = b.Top;
            ib.ImageAlign = ContentAlignment.MiddleCenter;
            ib.Padding = new Padding(2, 4, 0, 0);
            ib.Anchor = b.Anchor;
            ib.Tag = b;
            ib.Click += Ib_Click;
        }

        public void cleanButtons()
        {
            setIcons("new", brn_New,this);
            setIcons("clear", btn_Clear, this);
            setIcons("preview", btn_Preview, this);
            setIcons("copy", btn_Copy, this);
            setIcons("save", btn_Save, this);
			setIcons("db", btn_SaveToDB, this);
			setIcons("db1", btn_DatabaseLoad, this);
			setIcons("print", btn_Print, this);
            setIcons("mail", btn_AttachToEmail, this);
            setIcons("settings", btn_Options, this);
            setIcons("tools", btn_Settings, this);
            setIcons("exit", btn_Exit, this);
        }

        private void Ib_Click(object sender, EventArgs e)
        {
            IconButton ib = sender as IconButton;
            if(ib != null && ib.Tag != null && ib.Tag is Button)
            {
                string i = ((Button)ib.Tag).Tag.ToString();

                switch (i)
                {
                    case "0":
                        brn_New_Click(null, null);
                        break;

                    case "1":
                        btn_Clear_Click(null, null);
                        break;

                    case "2":
                        btn_Preview_Click(null, null);
                        break;

                    case "3":
                        btn_Copy_Click(null, null);
                        break;

                    case "4":
                        btn_Save_Click(null, null);
                        break;

                    case "5":
                        btn_Print_Click(null, null);
                        break;

                    case "6":
                        btn_AttachToEmail_Click(null, null);
                        break;

                    case "7":
                        btn_Options_Click(null, null);
                        break;

                    case "8":
                        btn_Settings_Click(null, null);
                        break;

                    case "9":
                        btn_Exit_Click(null, null);
                        break;

					case "10":
						btn_SaveToDB_Click(null, null);
						break;

					case "11":
						btn_DatabaseLoad_Click(null, null);
						break;

					default:
                        break;


                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

			Height = Properties.Settings.Default.s_HandleSize + Properties.Settings.Default.s_ButtonSize;
			Width = btn_Exit.Right;

            if (Properties.Settings.Default.s_UseCleanButtons)
            {
                cleanButtons();
            }
            

            TopMost = true;
            Icon = Properties.Resources.scissors;

			this.Activated += Form1_Activated;
			this.Deactivate += Form1_Deactivate;
        }

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			if (highHandle)
			{
				this.BackgroundImage = Properties.Resources.handle2_tall;
			}
			else
			{
				this.BackgroundImage = Properties.Resources.handle2;
			}
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (highHandle)
			{
				this.BackgroundImage = Properties.Resources.handle_tall;
			}
			else
			{
				this.BackgroundImage = Properties.Resources.handle;
			}
		}

		private void btn_Exit_Click(object sender, EventArgs e)
        {
			//TODO:EXIT

			try
			{
				Application.Exit();
			}
			catch
			{
				try
				{
					Application.Exit();
				}
				catch
				{

				}
			}
        }

		public Size getScreenSize()
		{
			Size s = new Size(-1,-1);

			foreach(Screen ss in Screen.AllScreens)
			{
				s.Width += ss.Bounds.Width;
				s.Height += ss.Bounds.Height;
			}

			return s;
		}

		public Bitmap captureScreen()
		{
			Hide();
			if(fs != null) { fs.Hide(); }
            if(tools != null) { tools.Hide(); }

            Thread.Sleep(Properties.Settings.Default.s_BaseDelay);

			if (Properties.Settings.Default.s_hasDelay)
			{
				Thread.Sleep(Properties.Settings.Default.s_delayLength);
			}

			Size s = getScreenSize();

			Bitmap c = new Bitmap(s.Width, s.Height);

			using (Graphics g = Graphics.FromImage(c))
			{
				g.CopyFromScreen(new Point(0, 0), new Point(0, 0), s);
			}

			return c;
		}

		public Bitmap showCaptureArea(Size s, Bitmap b)
		{
			f_Canvas fc = new f_Canvas();
			fc.bounds = s;
			fc.bmp = b;
			fc.ShowDialog();
			return fc.retImg;
		}

		public Bitmap doCutting()
		{
			Bitmap bmp = null;

			bmp = showCaptureArea(getScreenSize(), captureScreen());
			
			Show();
			if(fs != null && !fs.IsDisposed) { fs.Show(); }
            if (tools != null && !tools.IsDisposed) { tools.Show(); }

            return bmp;
		}

        private void brn_New_Click(object sender, EventArgs e)
        {
			Bitmap bmp = doCutting();
			int i = 0;

			var x = Application.OpenForms;
			foreach(Form f in x)
			{
				if(f is f_Screen)
				{
					i++;
					break;
				}
			}

			if (i == 0)
			{
				fs = new f_Screen();
				fs.parent = this;
				fs.Show();
				tools = new f_SettingPanel();
				tools.parent = fs;
				fs.child = tools;
				tools.Show();
			}

			if(fs != null)
			{
				fs.addImage(bmp);
			}
        }

		private void btn_Copy_Click(object sender, EventArgs e)
		{
			copyImage();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			saveImage();
		}
		
		public void copyImage()
		{
			try
			{
				Bitmap _b = c_ImgGen.createPng(fs,cutouts);
				Clipboard.SetImage(_b);
			}
			catch
			{

			}
		}

		public void saveImage()
		{
			Bitmap _b = c_ImgGen.createPng(fs,cutouts);
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

			if(sfd.ShowDialog() == DialogResult.OK)
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
		
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void Form1_LocationChanged(object sender, EventArgs e)
		{
			int fsw = 0;
			int fsh = 0;

			foreach (Screen s in Screen.AllScreens)
			{
				fsw += s.WorkingArea.Width;
				if(fsh < s.WorkingArea.Height)
				{
					fsh = s.WorkingArea.Height;
				}
			}

			if(Left < 0) { Left = 0; }
			if(Top < 0) { Top = 0; }
			if(Right > fsw) { Left = fsw - Width;  }
			if(Bottom > fsh) { Top = fsh - Height; }
		}

		private void btn_Settings_Click(object sender, EventArgs e)
		{
			bool open = false;
			foreach (var v in Application.OpenForms)
			{
				if (v is f_SettingPanel)
				{
					open = true;
					break;
				}
			}

			if (tools != null && open)
			{
				tools.Dispose();
			}
			else
			{
				if(fs != null)
				{
					tools = new f_SettingPanel();
					tools.parent = fs;
					fs.child = tools;
					tools.Show();
				}
			}
		}

		private void btn_Preview_Click(object sender, EventArgs e)
		{
			f_Preview fp = new f_Preview();
			fp.fs = fs;
			fp.cutouts = cutouts;
			fp.ShowDialog();
			fp.TopMost = true;
		}

		private void btn_Print_Click(object sender, EventArgs e)
		{
			PageSettings ps = new PageSettings();
			ps.Margins = new Margins(100, 10, 10, 10);
			printDocument1.DefaultPageSettings = ps;

			f_PrintSetup fps = new f_PrintSetup();
			fps.pd = printDocument1;
			fps.ps = ps;
			fps.cutouts = cutouts;
			fps.fs = fs;
			fps.ShowDialog();

			/*
			pageSetupDialog1.PageSettings = ps;
			pageSetupDialog1.ShowDialog();
			printPreviewDialog1.Document = printDocument1;
			printDocument1.DefaultPageSettings = ps;
			printPreviewDialog1.ShowDialog();
			*/
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				e.Graphics.DrawImage(c_ImgGen.createPng(fs, cutouts), new Point(10, 10));
				c_returnGraphicSettings cg = new c_returnGraphicSettings();

				e.Graphics.SmoothingMode = cg.getSM();
				e.Graphics.InterpolationMode = cg.getIM();
				e.Graphics.PixelOffsetMode = cg.getPOM();
				printPreviewDialog1.Document = printDocument1;
			}
			catch
			{

			}
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			if (!clearRequireAuth || MessageBox.Show("You are about to clear your cutouts.\r\nAre you sure you wish to continue?\r\n\r\nTo continue click Yes!","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (fs != null && !fs.IsDisposed)
				{
					List<uc_CutoutHolder> v = new List<uc_CutoutHolder>();
					foreach (Control c in fs.Controls)
					{
						if (c != null && c is uc_CutoutHolder)
						{
							v.Add(c as uc_CutoutHolder);
						}
					}

					foreach (var vv in v)
					{
						vv.Dispose();
					}
				}
			}
		}

		private void btn_Options_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_HighHandle = !highHandle;
			loadSettings();
		}

		public void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control)
			{
				if (e.KeyCode == Keys.N)
				{
					brn_New_Click(null, null);
				}
				else if (e.KeyCode == Keys.C)
				{
					btn_Copy_Click(null, null);
				}
				else if (e.KeyCode == Keys.S)
				{
					btn_Save_Click(null, null);
				}
				else if (e.KeyCode == Keys.X || e.KeyCode == Keys.Delete)
				{
					btn_Clear_Click(null, null);
				}

			}
			else if (e.Modifiers == (Keys.Control | Keys.Shift))
			{
				if (e.KeyCode == Keys.P)
				{
					btn_Preview_Click(null, null);
				}
			}
		}

        private void btn_AttachToEmail_Click(object sender, EventArgs e)
        {

        }

        private void btn_SaveToDB_Click(object sender, EventArgs e)
        {
			if (fs != null && !fs.IsDisposed)
			{
				f_SaveToDB fsd = new f_SaveToDB();
				fsd.img = c_ImgGen.createPng(fs, cutouts);
				fsd.ShowDialog();
			}
        }

		private void btn_DatabaseLoad_Click(object sender, EventArgs e)
		{
			f_LoadImageDB flid = new f_LoadImageDB();
			flid.ShowDialog();
		}

		private void btn_Minimize_MouseEnter(object sender, EventArgs e)
		{
			btn_Minimize.Image = Properties.Resources.minimize_white;
		}

		private void btn_Minimize_MouseLeave(object sender, EventArgs e)
		{
			btn_Minimize.Image = Properties.Resources.minimize_black;
		}

		private void btn_Minimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void btn_Rollup_Click(object sender, EventArgs e)
		{
			if(Height == 20)
			{
				Height = 60;
                btn_Rollup.Image = Properties.Resources.rollup_white;
            }
			else
			{
				Height = 20;
                btn_Rollup.Image = Properties.Resources.rolldown_white;
            }
		}

		private void btn_Rollup_MouseEnter(object sender, EventArgs e)
		{
			if(Height == 20)
			{
				btn_Rollup.Image = Properties.Resources.rolldown_white;
			}
			else
			{
				btn_Rollup.Image = Properties.Resources.rollup_white;
			}
		}

		private void btn_Rollup_MouseLeave(object sender, EventArgs e)
		{
			if (Height == 20)
			{
				btn_Rollup.Image = Properties.Resources.rolldown_black;
			}
			else
			{
				btn_Rollup.Image = Properties.Resources.rollup_black;
			}
		}

		private void btn_Question_Click(object sender, EventArgs e)
		{
			//TODO: Help
		}

		private void btn_Question_MouseEnter(object sender, EventArgs e)
		{
			btn_Question.Image = Properties.Resources.questionmark_white;
		}

		private void btn_Question_MouseLeave(object sender, EventArgs e)
		{
			btn_Question.Image = Properties.Resources.questionmark_black;
		}

		private void btn_Screen_Click(object sender, EventArgs e)
		{
			if(fs != null && !fs.IsDisposed)
			{
				fs.WindowState = FormWindowState.Normal;
				fs.BringToFront();
				fs.Focus();
				fs.Show();

			}
			else
			{
				fs = new f_Screen();
				fs.parent = this;
				fs.Show();
			}
		}
	}
}

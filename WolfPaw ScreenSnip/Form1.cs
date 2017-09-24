using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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


		f_Screen fs = null;
		f_SettingPanel tools = null;
		Dictionary<int, uc_CutoutHolder> cutouts = new Dictionary<int, uc_CutoutHolder>();

		public Form1()
        {
            InitializeComponent();

			Left = 0;
			Top = 0;

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Icon = Properties.Resources.scissors;

			this.Activated += Form1_Activated;
			this.Deactivate += Form1_Deactivate;
        }

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.BackgroundImage = Properties.Resources.handle2;
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			this.BackgroundImage = Properties.Resources.handle;
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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Portable Network Graphics Image (PNG)|*.png|" +
							"Bitmap Image (BMP)|*.bmp|" +
							"Joint Photographic Experts Group Image (JPEG)|*.jpg;*.jpeg|" +
							"Graphics Interchange Format Image (GIF)|*.gif|" +
							"Tagged Image File Format Image (TIFF)|*.tif;*.tiff|" +
							"Windows Metafile Image (WMF)|*.wmf";

			sfd.FilterIndex = Properties.Settings.Default.s_lastSaveFormat;

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
			fp.Show();
			fp.TopMost = true;
		}
	}
}

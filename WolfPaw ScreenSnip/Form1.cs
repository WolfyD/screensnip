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

		public Bitmap createPng()
		{
			if (fs != null)
			{
				fillDict();

				int left = 999999;
				int top = 999999;

				int right = 0;
				int bottom = 0;

				foreach (var v in cutouts)
				{
					var k = v.Value;
					if (k.Left < left) { left = k.Left; }
					if (k.Top < top) { top = k.Top; }
					if (k.Right > right) { right = k.Right; }
					if (k.Bottom > bottom) { bottom = k.Bottom; }
				}



				int height = bottom - top;
				int width = right - left;

				Rectangle picrec = new Rectangle(left, top, width, height);

				Bitmap _b = createImage(picrec);

				return _b;
			}
			else { return null; }
		}

		public void copyImage()
		{
			try
			{
				Bitmap _b = createPng();
				Clipboard.SetImage(_b);
			}
			catch
			{

			}
		}

		public void saveImage()
		{
			Bitmap _b = createPng();
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

		public Bitmap createImage(Rectangle rec)
		{
			int border = 0;

			if (Properties.Settings.Default.s_hasBorder)
			{
				border = Properties.Settings.Default.s_borderWidth;
			}

			Bitmap bm = new Bitmap(rec.Width + (border * 2), rec.Height + (border * 2));

			using (Graphics g = Graphics.FromImage(bm))
			{
				c_returnGraphicSettings cg = new c_returnGraphicSettings();

				g.SmoothingMode = cg.getSM();
				g.InterpolationMode = cg.getIM();
				g.PixelOffsetMode = cg.getPOM();

				g.Clear(Color.Transparent);

				if (Properties.Settings.Default.s_hasBgColor)
				{
					g.Clear(Properties.Settings.Default.s_bgColor);
				}
				else
				{
					g.Clear(Color.Transparent);
				}

				foreach (KeyValuePair<int, uc_CutoutHolder> kvp in cutouts)
				{
					uc_CutoutHolder k = kvp.Value;
					g.DrawImage(k.BMP, new Rectangle(k.Left - rec.Left + border, k.Top - rec.Top + border, k.Width,k.Height), new Rectangle(0,0,k.BMP.Width,k.BMP.Height), GraphicsUnit.Pixel);
				}

				if (Properties.Settings.Default.s_hasBorder)
				{
					Brush b = new SolidBrush(Properties.Settings.Default.s_borderColor);

					g.FillRectangle(b, new RectangleF(0, 0, bm.Width, border));
					g.FillRectangle(b, new RectangleF(0, bm.Height - border, bm.Width,border));
					g.FillRectangle(b, new RectangleF(0, 0, border, bm.Height));
					g.FillRectangle(b, new RectangleF(bm.Width - border, 0, border, bm.Height));
				}
			}

			

			return bm;
		}

		public void fillDict()
		{
			cutouts.Clear();
			foreach (var v in fs.Controls)
			{
				if (v != null && v is uc_CutoutHolder)
				{
					int i = fs.Controls.GetChildIndex(((uc_CutoutHolder)v));
					if (!cutouts.ContainsKey(i))
					{
						cutouts.Add(i, ((uc_CutoutHolder)v));
					}
				}
			}

			//TODO SORT cutouts
			cutouts = cutouts.OrderByDescending(r => r.Key).ToDictionary(r => r.Key, r => r.Value);
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			List<uc_CutoutHolder> lst = new List<uc_CutoutHolder>();

			if (fs != null)
			{
				foreach (var v in fs.Controls)
				{
					if (v is uc_CutoutHolder)
					{
						lst.Add((uc_CutoutHolder)v);
					}
				}
			}

			if (lst.Count > 0)
			{
				if (MessageBox.Show("You are about to remove all of your cutouts.\r\nAre you sure you wish to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < lst.Count; i++)
					{
						lst[i].Dispose();
					}
				}
			}
		}

		private void btn_AttachToEmail_Click(object sender, EventArgs e)
		{

		}
	}
}

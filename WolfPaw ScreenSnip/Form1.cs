using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.IO;
using System.Runtime.InteropServices;

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

		public List<IconButton> ibList = new List<IconButton>();
		public c_returnGraphicSettings cr = new c_returnGraphicSettings();
		public c_KeyboardHook ck = new c_KeyboardHook();

		public f_Screen fs = null;
		public f_SettingPanel tools = null;
		
		public bool clearRequireAuth = false;
		
		public bool hidden = false;

		public bool CTRLDOWN = false;
		public bool SHIFTDOWN = false;

		public bool EditableMode = false;
		public bool canSaveEditImages = false;
		public bool justLoggedIn = true;
		public string lastCutoutId = "";


		#region MAPI

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public class MapiMessage
		{
			public int reserved;
			public string subject;
			public string noteText;
			public string messageType;
			public string dateReceived;
			public string conversationID;
			public int flags;
			public IntPtr originator;
			public int recipCount;
			public IntPtr recips;
			public int fileCount;
			public IntPtr files;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public class MapiFileDesc
		{
			public int reserved;
			public int flags;
			public int position;
			public string path;
			public string name;
			public IntPtr type;
		}

		[DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
		public static extern uint MAPISendMail(IntPtr lhSession, IntPtr ulUIParam,MapiMessage lpMessage, uint flFlags, uint ulReserved);

		#endregion

		public Form1()
        {
            InitializeComponent();

			Left = 0;
			Top = 0;

            Load += Form1_Load;
			
        }

        #region MAIL

        public void getMailClient()
		{
			object mailClient = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\Mail", "", "none");
			Console.WriteLine(mailClient.ToString());


			if (mailClient.ToString().ToLower().Contains("outlook"))
			{
				//Thread t = new Thread(ThreadStart => SendMail(@"C:\Users\radicsm\Desktop\xxx\test.jpg"));
				//Thread t = new Thread(new ThreadStart(startSend));
				//t.Start();
				startSend();
			}
			else { startSend(); }
		}

		public void startSend()
		{
			SendMail(@"C:\Users\radicsm\Desktop\xxx\test.jpg");
		}

		public int SendMail(string fileName)
		{
			MapiMessage msg = new MapiMessage();
			msg.subject = "Hello World!";
			msg.noteText = "See attached file for details";
			msg.files = GetAttachments(fileName, out msg.fileCount);

			int result = (int)MAPISendMail(new IntPtr(0), new IntPtr(0), msg, 0x00000001 | 0x00000008, 0);
			if (result > 1 || result < 0)
				throw new System.InvalidOperationException();
			return result;
		}

		IntPtr GetAttachments(string fileName, out int fileCount)
		{
			int size = Marshal.SizeOf(typeof(MapiFileDesc));
			IntPtr intPtr = Marshal.AllocHGlobal(size);

			MapiFileDesc mapiFileDesc = new MapiFileDesc();
			//An integer used to indicate where in the message text to render the attachment.
			mapiFileDesc.position = -1;
			int ptr = (int)intPtr;

			mapiFileDesc.name = Path.GetFileName(fileName);
			mapiFileDesc.path = fileName;
			Marshal.StructureToPtr(mapiFileDesc, (IntPtr)ptr, false);
			ptr += size;

			fileCount = 1;
			return intPtr;
		}

		#endregion

		public void loadSettings()
		{
			Form1_Activated(null, null);
			
			clearRequireAuth = Properties.Settings.Default.s_ClearRequireAuth;
			
			if(Properties.Settings.Default.s_DPI.Count == 0)
			{
				getDPIValues();
			}

			toolTip1.Active = Properties.Settings.Default.s_ShowTooltipOnMouseOver;

			EditableMode = Properties.Settings.Default.s_KeepEditImage;

			String editDBFileName = "editable_backup.db";

			if (justLoggedIn && File.Exists(editDBFileName))
			{
				File.Delete(editDBFileName);
			}

			if (EditableMode)
			{
				if (!File.Exists(editDBFileName))
				{
					File.Create(editDBFileName).Close();
					string err = "";
					c_DatabaseHandler.generateEditTable(c_DatabaseHandler.ConnectToDB(editDBFileName, out err));
					if(err != "")
					{
						MessageBox.Show("There was an error while creating the backup database.\r\nThe following Error was recieved:\r\n\r\n" + err, "Error creating table", MessageBoxButtons.OK, MessageBoxIcon.Error);
						canSaveEditImages = false;
					}
					else
					{
						canSaveEditImages = true;
					}
				}
			}
			else
			{
				if (File.Exists(editDBFileName))
				{ 
					//TODO: Fix issue when it can't delete
					File.Delete(editDBFileName);
					canSaveEditImages = false;
				}
			}

			MaximumSize = Size;

			justLoggedIn = false;
		}

		public void getDPIValues()
		{
			Properties.Settings.Default.s_DPI.Clear();
			List<Screen> sa = Screen.AllScreens.ToList<Screen>();
			int i = 0;
			foreach(Screen s in sa)
			{

				i = sa.IndexOf(s);
                c_GetDPI.GetDpi(s, DpiType.Raw, out uint px, out uint py);

                Properties.Settings.Default.s_DPI.Add(string.Format("{0}|{1}|{2}|{3}", i, s.DeviceName, px, py));
				Properties.Settings.Default.Save();
				//MessageBox.Show(Properties.Settings.Default.s_DPI[0]);
			}
		}

        public void setIcons(string btn, Button b, Control parent)
        {
			IconButton ib = new IconButton
			{
				Parent = parent,
				Size = new Size(40, 40),
				IconSize = 40
			};

			switch (btn)
            {
                case "new":
                    ib.IconChar = IconChar.Cut;
					ib.Name = "new";
                    break;

                case "clear":
                    ib.IconChar = IconChar.Trash;
					ib.Name = "clear";
					break;

                case "preview":
                    ib.IconChar = IconChar.Image;
					ib.Name = "preview";
					break;

                case "copy":
                    ib.IconChar = IconChar.Clone;
					ib.Name = "copy";
					break;

                case "save":
                    ib.IconChar = IconChar.Save;
					ib.Name = "save";
					break;

                case "print":
                    ib.IconChar = IconChar.Print;
					ib.Name = "print";
					break;

                case "mail":
                    ib.IconChar = IconChar.Envelope;
					ib.Name = "mail";
					break;

                case "settings":
                    ib.IconChar = IconChar.Cogs;
					ib.Name = "settings";
					break;

                case "tools":
                    ib.IconChar = IconChar.Wrench;
					ib.Name = "tools";
					break;

				case "db":
					ib.IconChar = IconChar.Database;
					ib.Name = "db";
					ib.IconSize = 36;
					break;

				case "db1":
					ib.IconChar = IconChar.FolderOpen;
					ib.Name = "db1";
					break;

				case "exit":
                    ib.IconChar = IconChar.WindowClose;
					ib.Name = "exit";
					break;
                    
                default:
                    break;
            }

            b.Hide();
			
            ib.Left = b.Left;
            ib.Top = b.Top;
            ib.ImageAlign = ContentAlignment.MiddleCenter;
            ib.Padding = new Padding(0, 4, 6, 0);
            ib.Anchor = b.Anchor;
            ib.Tag = b;
			toolTip1.SetToolTip(ib, toolTip1.GetToolTip(b));
			ib.Enabled = b.Enabled;
            ib.Click += Ib_Click;

			ibList.Add(ib);

		}

		public void cleanButtons()
        {
            //setIcons("new", brn_New,this);
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
			if (ib is IconButton && ib.Tag != null && ib.Tag is Button)
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

			uc_ButtonSelector1.parent = this;

            TopMost = true;
            Icon = Properties.Resources.scissors;

			this.Activated += Form1_Activated;
			this.Deactivate += Form1_Deactivate;

			ck.KeyPressDetected += Ck_KeyPressDetected;
			ck.KeyReleaseDetected += Ck_KeyReleaseDetected;

			if (Properties.Settings.Default.s_RememberLastPosition)
			{
				Location = Properties.Settings.Default.s_LastPosition;
			}
			
			loadSettings();
        }

		private void Ck_KeyReleaseDetected(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.LControlKey ||
				e.KeyCode == Keys.RControlKey ||
				e.KeyCode == Keys.Control)
			{
				CTRLDOWN = false;
			}
			else if (e.KeyCode == Keys.LShiftKey ||
				e.KeyCode == Keys.RShiftKey ||
				e.KeyCode == Keys.Shift)
			{
				SHIFTDOWN = false;
			}
		}

		public void enableButtons(bool enabled)
		{
			if (enabled)
			{
				btn_Preview.Enabled = true;
				btn_Copy.Enabled = true;
				btn_Save.Enabled = true;
				btn_SaveToDB.Enabled = true;
				btn_Print.Enabled = true;
				btn_AttachToEmail.Enabled = true;
			}
			else
			{
				btn_Preview.Enabled = false;
				btn_Copy.Enabled = false;
				btn_Save.Enabled = false;
				btn_SaveToDB.Enabled = false;
				btn_Print.Enabled = false;
				btn_AttachToEmail.Enabled = false;
			}
			enableNewButtons();
		}

		public void enableNewButtons()
		{
			foreach(IconButton ib in ibList)
			{
				ib.Enabled = (ib.Tag as Button).Enabled;

				ib.IconColor = ib.Enabled ? Color.Black : Color.FromArgb(255, 250, 100, 100);
			}
		}

		private void Ck_KeyPressDetected(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.PrintScreen && Properties.Settings.Default.s_handlePrintScreen)
			{
				Size sz = getScreenSize();
				Bitmap b = new Bitmap(sz.Width, sz.Height);
				using (Graphics g = Graphics.FromImage(b))
				{
					g.InterpolationMode = cr.getIM();
					g.SmoothingMode = cr.getSM();
					g.PixelOffsetMode = cr.getPOM();

					g.CopyFromScreen(new Point(0, 0), new Point(0, 0), b.Size);
				}

				if (fs == null || fs.IsDisposed)
				{
					btn_Screen_Click(null, null);
				}

				try
				{
					fs.addImage(b, new Point(0, 0), "");
				}
				catch { }

				//OnKeyDown(new KeyEventArgs(Keys.V | Keys.Control));
				if (fs != null && !fs.IsDisposed)
				{
					fs.BringToFront();
				}

				try
				{
					Clipboard.SetImage(b);
				}
				catch
				{

				}
			}
			else if (e.KeyCode == Keys.Control ||
						e.KeyCode == Keys.LControlKey ||
						e.KeyCode == Keys.RControlKey)
			{
				CTRLDOWN = true;
			}
			else if (e.KeyCode == Keys.Shift ||
						e.KeyCode == Keys.LShiftKey ||
						e.KeyCode == Keys.ShiftKey ||
						e.KeyCode == Keys.RShiftKey)
			{
				SHIFTDOWN = true;
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F1 && CTRLDOWN && SHIFTDOWN)
			{
				brn_New_Click("Rect2", null);
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F1 && CTRLDOWN && !SHIFTDOWN)
			{
				brn_New_Click("Rect", null);
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F2 && CTRLDOWN && !SHIFTDOWN)
			{
				//brn_New_Click("Window", null);
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F3 && CTRLDOWN && !SHIFTDOWN)
			{
				brn_New_Click("Freehand", null);
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F4 && CTRLDOWN && !SHIFTDOWN)
			{
				//brn_New_Click("Lines", null);
			}
			else if (Properties.Settings.Default.s_HandleShortcuts && e.KeyCode == Keys.F5 && CTRLDOWN && !SHIFTDOWN)
			{
				brn_New_Click("Magic", null);
			}

			
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
			Size s = new Size();

			Screen[] scr = Screen.AllScreens;

			int scr_top = scr.Min(x => x.Bounds.Y);
			int scr_bottom = scr.Max(x => x.Bounds.Bottom);
			int scr_left = scr.Min(x => x.Bounds.Left);
			int scr_right = scr.Max(x => x.Bounds.Right);

			/*
			foreach (Screen ss in Screen.AllScreens)
            {
                s.Width += ss.Bounds.Width;
                if (ss.Bounds.Bottom > s.Height) { s.Height = ss.Bounds.Height; }
			}
			*/

			s = new Size(scr_right - scr_left, scr_bottom - scr_top);

			return s;
		}

		public bool QshowPreview()
		{
			return Properties.Settings.Default.s_ShowPreview && Properties.Settings.Default.s_LastPreviewMode == 0;
		}

		public Bitmap captureScreen()
		{
			Hide();
			if(fs != null) { fs.Hide(); }
            if(tools != null) { tools.Hide(); }
			if (fs != null && fs.pw != null && QshowPreview()) { fs.pw.Hide(); }

			Thread.Sleep(Properties.Settings.Default.s_BaseDelay);

			if (Properties.Settings.Default.s_hasDelay)
			{
				Thread.Sleep(Properties.Settings.Default.s_delayLength);
			}

			Size s = getScreenSize();

			Bitmap c = new Bitmap(s.Width, s.Height);

			Screen[] sss = Screen.AllScreens;
			using (Graphics g = Graphics.FromImage(c))
			{
				g.CopyFromScreen(new Point(sss.Min(x=>x.Bounds.X), sss.Min(x => x.Bounds.Y)), new Point(0, 0), s);
			}

			return c;
		}

		public Bitmap showCaptureArea(Size s, Bitmap b, int mode)
		{
			f_Canvas fc = new f_Canvas
			{
				bounds = s,
				bmp = b,
				mode = mode,
				save_editable_backup = canSaveEditImages && EditableMode
			};
			fc.ShowDialog();

			if(canSaveEditImages && EditableMode) { lastCutoutId = fc.randID; }

			return fc.retImg;
		}

		public Bitmap doCutting(int mode)
		{
			Bitmap bmp = null;

			bmp = showCaptureArea(getScreenSize(), captureScreen(), mode);
			
			if(!hidden)
			{
				Show();
			}
			if(fs != null && !fs.IsDisposed) { fs.Show(); }
			if (tools != null && !tools.IsDisposed) { tools.Show(); }
			if (fs != null && fs.pw != null && !fs.pw.IsDisposed && QshowPreview()) { fs.pw.Show(); }

			return bmp;
		}

        public void brn_New_Click(object sender, EventArgs e)
        {
			if (e == null && sender != null && sender is string)
			{
				switch (sender as string)
				{
					case "Rect":
						handleCutouts(0);
						break;
					case "Rect2":
						handleCutouts(-1);
						break;
					case "Window":
						handleCutouts(1);
						break;
					case "Freehand":
						handleCutouts(2);
						break;
					case "Lines":
						handleCutouts(3);
						break;
					case "Magic":
						handleCutouts(4);
						break;
				}
			}
			else
			{
				handleCutouts(0);
			}
		}

		public void handleCutouts(int mode)
		{
			Bitmap bmp = doCutting(mode);

			if (mode == -1)
			{
				if(bmp != null)
				{
					Clipboard.SetImage(bmp);
				}
			}
			else
			{

				int i = 0;

				var x = Application.OpenForms;
				foreach (Form f in x)
				{
					if (f is f_Screen)
					{
						i++;
						break;
					}
				}

				if (i == 0)
				{
					fs = new f_Screen
					{
						parent = this
					};
					fs.Show();
					fs.Refresh();
					if (Properties.Settings.Default.s_ToolbarPanel == 0)
					{
						tools = new f_SettingPanel
						{
							parent = fs
						};
						fs.child = tools;
						tools.Show();
					}
				}

				if (fs != null)
				{
					fs.addImage(bmp, lastCutoutId);
					lastCutoutId = "";
				}
			}
		}

		private void btn_Copy_Click(object sender, EventArgs e)
		{
			copyImage();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			string sv = "";
			if(sender != null && sender.ToString() == "quicksave") { sv = "quick"; }
			saveImage(sv);
		}
		
		public void copyImage()
		{
			try
			{
				Bitmap _b = c_ImgGen.createPng(fs,fs.Limages, new object[] { fs.getDrawnPoints(), null });
				Clipboard.SetImage(_b);
			}
			catch
			{

			}
		}

		public void saveImage(string svMode)
		{
			if (fs != null && fs.Limages != null && fs.Limages.Count > 0)
			{
				Bitmap _b = c_ImgGen.createPng(fs, fs.Limages, new object[] { fs.getDrawnPoints(), null });
				string savename = "ScreenSnip_";

				if (svMode == "quick" && Properties.Settings.Default.s_QuickSaveDir != "" && Directory.Exists(Properties.Settings.Default.s_QuickSaveDir))
				{
					ImageFormat _if = ImageFormat.Png;
					string dts = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();
					dts = dts.Replace(".", "").Replace(" ", "").Replace(":", "");

					_b.Save(Properties.Settings.Default.s_QuickSaveDir + "\\screensnip_" + dts + ".png", _if);
				}
				else
				{
					if(svMode == "quick") { MessageBox.Show("It seems that you either have no quicksave directory set up,\r\nor the directory you have set up is unavailable.\r\n\r\nPlease check your quicksave settings in the options,\r\nunder the `General Settings` point!", "Quicksave not available!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }

					if (true || Properties.Settings.Default.s_SaveHasDateTime)
					{
						string date = "";
						DateTime n = DateTime.Now;
						date = n.Year + "." + n.Month.ToString().PadLeft(2, '0') + "." + n.Day.ToString().PadLeft(2, '0') + "_" + n.Hour.ToString().PadLeft(2, '0') + "." + n.Minute.ToString().PadLeft(2, '0') + "." + n.Second.ToString().PadLeft(2, '0');
						savename += date;
					}
					SaveFileDialog sfd = new SaveFileDialog
					{
						Filter = "Portable Network Graphics Image (PNG)|*.png|" +
									"Bitmap Image (BMP)|*.bmp|" +
									"Joint Photographic Experts Group Image (JPEG)|*.jpg;*.jpeg|" +
									"Graphics Interchange Format Image (GIF)|*.gif|" +
									"Tagged Image File Format Image (TIFF)|*.tif;*.tiff|" +
									"Windows Metafile Image (WMF)|*.wmf",

						FilterIndex = Properties.Settings.Default.s_lastSaveFormat,

						FileName = savename
					};

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
			Screen[] ss = Screen.AllScreens;
			
			if(Left < ss.Min(x=>x.Bounds.X)) { Left = ss.Min(x => x.Bounds.X); }
			if(Top < ss.Min(x => x.Bounds.Y)) { Top = ss.Min(x => x.Bounds.Y); }
			if(Right > ss.Max(x => x.Bounds.Right)) { Left = ss.Max(x => x.Bounds.Right) - Width;  }
			if(Bottom > ss.Max(x => x.Bounds.Bottom)) { Top = ss.Max(x => x.Bounds.Bottom) - Height; }
		}

		private void btn_Settings_Click(object sender, EventArgs e)
		{
			int panel = Properties.Settings.Default.s_ToolbarPanel;

			if (panel == 0)
			{
				if (tools != null && !tools.IsDisposed)
				{
					try
					{
						tools.Close();
					}
					catch
					{

					}
				}
				else if (fs != null && !fs.IsDisposed)
				{
					tools = new f_SettingPanel
					{
						parent = fs
					};
					fs.child = tools;
					tools.Show();
				}
			}
			else if (panel == 1)
			{
				if(fs != null && !fs.IsDisposed)
				{
					fs.togglePanel();
				}
			}
			else if (panel == 2)
			{
				if (fs != null && !fs.IsDisposed)
				{
					fs.toggleToolbar();
				}
			}
			
		}

		private void btn_Preview_Click(object sender, EventArgs e)
		{
			if (fs != null && fs.Limages != null && fs.Limages.Count > 0)
			{
				f_Preview fp = new f_Preview
				{
					fs = fs,
					cutouts = fs.Limages
				};
				fp.ShowDialog();
				fp.TopMost = true;
			}
		}

		private void btn_Print_Click(object sender, EventArgs e)
		{
			PageSettings ps = new PageSettings
			{
				Margins = new Margins(100, 10, 10, 10)
			};
			printDocument1.DefaultPageSettings = ps;

			f_PrintSetup fps = new f_PrintSetup
			{
				pd = printDocument1,
				ps = ps,
				fs = fs
			};
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
				e.Graphics.DrawImage(c_ImgGen.createPng(fs, fs.Limages, new object[] { fs.getDrawnPoints(), null }), new Point(10, 10));
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
					while(fs.Limages.Count > 0)
					{
						try
						{
							fs.Limages[0].Dispose();
							fs.Limages.RemoveAt(0);
						}
						catch
						{
							break;
						}
					}
					enableButtons(false);
					GC.Collect();
				}
			}
		}

		private void btn_Options_Click(object sender, EventArgs e)
		{
			f_Settings _fs = new f_Settings();
			_fs.ShowDialog();
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
                else if (e.KeyCode == Keys.V || e.KeyCode == Keys.Insert)
                {
                    try
                    {
                        btn_Screen_Click(null, null);
                        fs.paste();
                    }
                    catch
                    {

                    }
                }

            }
			else if (e.Modifiers == (Keys.Control | Keys.Shift))
			{
				if (e.KeyCode == Keys.P)
				{
					btn_Preview_Click(null, null);
				}
				else if (e.KeyCode == Keys.S)
				{
					btn_Save_Click("quicksave", null);
				}
			}
		}

        private void btn_AttachToEmail_Click(object sender, EventArgs e)
        {
			getMailClient();
        }

        private void btn_SaveToDB_Click(object sender, EventArgs e)
        {
			if (fs != null && !fs.IsDisposed)
			{
				f_SaveToDB fsd = new f_SaveToDB
				{
					img = c_ImgGen.createPng(fs, fs.Limages, new object[] { fs.getDrawnPoints(), null })
				};
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
            if (!Properties.Settings.Default.s_MoveToTools)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
				hidden = true;
                Bitmap b = Properties.Resources.scissors1;
                for(int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        Color c = b.GetPixel(x, y);
                        if (c.R + c.G + c.B < 300)
                        {
                            b.SetPixel(x, y, Color.FromArgb(c.A, Color.Pink));
                        }
                    }
                }
                ni_Notify.Icon = System.Drawing.Icon.FromHandle(b.GetHicon());
				ni_Notify.Visible = true;
                Hide();
            }
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
			f_Settings _fs = new f_Settings();
			_fs.Show();
			_fs.openHelp();
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
			}
			else
			{
				fs = new f_Screen
				{
					parent = this
				};
			}

			fs.Show();
			if (Properties.Settings.Default.s_ToolbarPanel == 0)
			{
				if (tools == null || tools.IsDisposed) { tools = new f_SettingPanel(); }
				fs.child = tools;
				tools.parent = fs;
				tools.Show();
			}
		}

		#region NotifyIcon

		private void btn_CMS_Exit_Click(object sender, EventArgs e)
		{
			btn_Exit_Click(null, null);
		}

		private void btn_CMS_MainWindow_Click(object sender, EventArgs e)
		{
			this.Show();
			hidden = false;
			ni_Notify.Visible = false;
		}

		private void ni_Notify_DoubleClick(object sender, EventArgs e)
		{
			btn_CMS_MainWindow_Click(null, null);
		}

		private void btn_CMS_ShowScreen_Click(object sender, EventArgs e)
		{
			btn_Screen_Click(null, null);
		}

		private void btn_CMS_Options_Click(object sender, EventArgs e)
		{
			btn_Settings_Click(null, null);
		}

		private void btn_CMS_Email_Click(object sender, EventArgs e)
		{
			btn_AttachToEmail_Click(null, null);
		}

		private void btn_CMS_Print_Click(object sender, EventArgs e)
		{
			btn_Print_Click(null, null);
		}

		private void btn_CMS_BrowseDB_Click(object sender, EventArgs e)
		{
			btn_DatabaseLoad_Click(null, null);
		}

		private void btn_CMS_SaveToDB_Click(object sender, EventArgs e)
		{
			btn_SaveToDB_Click(null, null);
		}

		private void btn_CMS_Copy_Click(object sender, EventArgs e)
		{
			btn_Copy_Click(null, null);
		}

		private void btn_CMS_Save_Click(object sender, EventArgs e)
		{
			btn_Save_Click(null, null);
		}

		private void btn_CMS_Preview_Click(object sender, EventArgs e)
		{
			btn_Preview_Click(null, null);
		}

		private void btn_CMS_Rectangle_Click(object sender, EventArgs e)
		{
			handleCutouts(0);
		}

		private void btn_CMS_Window_Click(object sender, EventArgs e)
		{
			handleCutouts(1);
		}

		private void btn_CMS_Freehand_Click(object sender, EventArgs e)
		{
			handleCutouts(2);
		}

		private void btn_CMS_Line_Click(object sender, EventArgs e)
		{
			handleCutouts(3);
		}

		private void btn_CMS_Magic_Click(object sender, EventArgs e)
		{
			handleCutouts(4);
		}

		#endregion

	}
}

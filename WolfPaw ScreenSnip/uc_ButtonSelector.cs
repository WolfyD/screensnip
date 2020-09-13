using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace WolfPaw_ScreenSnip
{
	public partial class uc_ButtonSelector : UserControl
	{
		private int buttonSize = 50;
		private DropDownFunction function;
		[Browsable(true)]
		public DropDownFunction Function
		{
            get { return function; }
            set { function = value; }
		}

		public Form1 parent { get; set; }

		public bool cmsIsClosed = true;

		public int ButtonSize
		{
			get { return buttonSize; }
			set
			{
				buttonSize = value;
				setButtonSize(buttonSize);
			}
		}
		
		public uc_ButtonSelector()
		{
			InitializeComponent();

			Load += Uc_ButtonSelector_Load;
		}

		Bitmap bmp = null;

		private void Uc_ButtonSelector_Load(object sender, EventArgs e)
		{
			cms_Buttons.AutoClose = false;
			btn_DropDown.Padding = new Padding(0, 0, 5, 0);

			cms_Buttons.ShowCheckMargin = false;
			cms_Buttons.ShowImageMargin = false;

			if (function == DropDownFunction.Cutout)
			{
				ToolStripItem tsiRec = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Rectangle", Image = IconChar.Cut.ToBitmap(buttonSize, Color.Black), Tag = 0 };
				tsiRec.Click += ItemClick;
				ToolStripItem tsiWindow = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Window", Image = IconChar.WindowMaximize.ToBitmap(buttonSize, Color.Black), Tag = 1 };
				tsiWindow.Click += ItemClick;
				ToolStripItem tsiFreehand = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Freehand", Image = IconChar.PenSquare.ToBitmap(buttonSize, Color.Black), Tag = 2 };
				tsiFreehand.Click += ItemClick;
				ToolStripItem tsiPoint = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Line", Image = IconChar.Star.ToBitmap(buttonSize, Color.Black), Tag = 3 };
				tsiPoint.Click += ItemClick;
				ToolStripItem tsiMagic = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Magic", Image = IconChar.Magic.ToBitmap(buttonSize, Color.Black), Tag = 4 };
				tsiMagic.Click += ItemClick;

				cms_Buttons.Items.Add(tsiRec);
				cms_Buttons.Items.Add(tsiWindow);
				cms_Buttons.Items.Add(tsiFreehand);
				cms_Buttons.Items.Add(tsiPoint);
				cms_Buttons.Items.Add(tsiMagic);

				cms_Buttons.Width = Width;
				cms_Buttons.Height = cms_Buttons.Items.Count * (buttonSize + 1);

				cms_Buttons.Closed += Cms_Buttons_Closed;

				switch (Properties.Settings.Default.s_lastTool)
				{
					case 0:
						bmp = (Bitmap)tsiRec.Image;
						break;

					case 1:
						bmp = (Bitmap)tsiWindow.Image;
						break;

					case 2:
						bmp = (Bitmap)tsiFreehand.Image;
						break;

					case 3:
						bmp = (Bitmap)tsiPoint.Image;
						break;

					case 4:
						bmp = (Bitmap)tsiMagic.Image;
						break;

					default:
						bmp = (Bitmap)tsiRec.Image;
						break;

				}
			}
			else if (function == DropDownFunction.DataManagement)
			{
				Bitmap save = Properties.Resources.database_down;
				save.Save("D:\\save_test.bmp");
				Bitmap load = Properties.Resources.database_up;
				ToolStripItem tsiDBSave = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Save to DB", Image = save, Tag = 0 };
				tsiDBSave.Click += ItemClick;
				ToolStripItem tsiDBLoad = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Load from DB", Image = load, Tag = 1 };
				tsiDBLoad.Click += ItemClick;
				ToolStripItem tsiFreehand = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Freehand", Image = IconChar.PenSquare.ToBitmap(buttonSize, Color.Black), Tag = 2 };
				tsiFreehand.Click += ItemClick;
				ToolStripItem tsiPoint = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Line", Image = IconChar.Star.ToBitmap(buttonSize, Color.Black), Tag = 3 };
				tsiPoint.Click += ItemClick;
				ToolStripItem tsiMagic = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Magic", Image = IconChar.Magic.ToBitmap(buttonSize, Color.Black), Tag = 4 };
				tsiMagic.Click += ItemClick;

				cms_Buttons.Items.Add(tsiDBSave);
				cms_Buttons.Items.Add(tsiDBLoad);
				cms_Buttons.Items.Add(tsiFreehand);
				cms_Buttons.Items.Add(tsiPoint);
				cms_Buttons.Items.Add(tsiMagic);

				cms_Buttons.Width = Width;
				cms_Buttons.Height = cms_Buttons.Items.Count * (buttonSize + 1);

				cms_Buttons.Closed += Cms_Buttons_Closed;

				switch (Properties.Settings.Default.s_lastTool)
				{
					case 0:
						bmp = (Bitmap)tsiDBSave.Image;
						break;

					case 1:
						bmp = (Bitmap)tsiDBLoad.Image;
						break;

					case 2:
						bmp = (Bitmap)tsiFreehand.Image;
						break;

					case 3:
						bmp = (Bitmap)tsiPoint.Image;
						break;

					case 4:
						bmp = (Bitmap)tsiMagic.Image;
						break;

					default:
						bmp = (Bitmap)tsiDBSave.Image;
						break;

				}
			}

			btn_Button.BackgroundImage = bmp;
		}

		private void Cms_Buttons_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			cmsIsClosed = true;
		}

		private void ItemClick(object sender, EventArgs e)
		{
			//TODO:
			var item = sender as ToolStripMenuItem;
			Properties.Settings.Default.s_lastTool = Convert.ToInt32(item.Tag.ToString());
			Properties.Settings.Default.Save();
			btn_Button.BackgroundImage = item.Image;
			DropDownClose();
			btn_Button_Click(null, null);
		}

		public void setButtonSize(int btns)
		{
			btn_Button.Size = new Size(buttonSize, buttonSize);
			btn_DropDown.Left = btn_Button.Width - 2;
			btn_DropDown.Height = buttonSize;
			this.Height = buttonSize;
			this.Width = btn_DropDown.Right;
		}

		public void DropDownOpen()
		{
			cms_Buttons.Show(this, new Point(0, buttonSize));
		}

		public void DropDownClose()
		{
			cms_Buttons.Close();
		}

		public bool IsDropDownOpen()
		{
			return !cmsIsClosed;
		}

		private void btn_Button_Click(object sender, EventArgs e)
		{
			parent.handleCutouts(Properties.Settings.Default.s_lastTool);
		}

        private void btn_DropDown_MouseDown(object sender, MouseEventArgs e)
        {
			cmsIsClosed = !IsDropDownOpen();
		}

        private void btn_DropDown_MouseUp(object sender, MouseEventArgs e)
        {
			if (!cmsIsClosed)
			{
				cmsIsClosed = true;
				DropDownClose();
			}
			else
			{
				cmsIsClosed = false;
				DropDownOpen();
			}
		}
    }

	public enum DropDownFunction
    {
		Cutout,
		DataManagement,
		Share,
		Other
    }

    public partial class myTSMI : ToolStripMenuItem
	{
		public string myText = "";

		public myTSMI()
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawImage(this.Image, new PointF(Width / 2 - this.Image.Width / 2 - 5, 0));
		}
	}
}

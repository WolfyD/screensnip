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

		private void Uc_ButtonSelector_Load(object sender, EventArgs e)
		{
			cms_Buttons.ShowCheckMargin = false;
			cms_Buttons.ShowImageMargin = false;

			ToolStripItem tsiRec = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false,  myText = "Rectangle", Image = IconChar.Scissors.ToBitmap(buttonSize, Color.Black), Tag = 0 };
			tsiRec.Click += itemClick;
			ToolStripItem tsiWindow = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Window", Image = IconChar.WindowMaximize.ToBitmap(buttonSize, Color.Black), Tag = 1 };
			tsiWindow.Click += itemClick;
			ToolStripItem tsiFreehand = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Freehand", Image = IconChar.PencilSquareO.ToBitmap(buttonSize, Color.Black), Tag = 2 };
			tsiFreehand.Click += itemClick;
			ToolStripItem tsiPoint = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Line", Image = IconChar.StarO.ToBitmap(buttonSize, Color.Black), Tag = 3 };
			tsiPoint.Click += itemClick;
			ToolStripItem tsiMagic = new myTSMI() { Width = this.Width, Height = buttonSize, AutoSize = false, myText = "Magic", Image = IconChar.Magic.ToBitmap(buttonSize, Color.Black), Tag = 4 };
			tsiMagic.Click += itemClick;

			cms_Buttons.Items.Add(tsiRec);
			cms_Buttons.Items.Add(tsiWindow);
			cms_Buttons.Items.Add(tsiFreehand);
			cms_Buttons.Items.Add(tsiPoint);
			cms_Buttons.Items.Add(tsiMagic);

			cms_Buttons.Width = Width;
			cms_Buttons.Height = cms_Buttons.Items.Count * (buttonSize + 1);

			cms_Buttons.Closed += Cms_Buttons_Closed;

			Bitmap bmp = null;

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

			btn_Button.BackgroundImage = bmp;
		}

		private void Cms_Buttons_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			cmsIsClosed = true;
		}

		private void itemClick(object sender, EventArgs e)
		{
			//TODO:
			var item = sender as ToolStripMenuItem;
			//MessageBox.Show(item.Tag.ToString());
			Properties.Settings.Default.s_lastTool = Convert.ToInt32(item.Tag.ToString());
			Properties.Settings.Default.Save();
			btn_Button.BackgroundImage = item.Image;
			dropDownClose();
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

		public void dropDownOpen()
		{
			cms_Buttons.Show(this, new Point(0, buttonSize));
		}

		public void dropDownClose()
		{
			cms_Buttons.Hide();
		}

		public bool checkDropDown()
		{
			return !cmsIsClosed;
		}

		private void btn_DropDown_Click(object sender, EventArgs e)
		{
			if (checkDropDown())
			{
				dropDownClose();
			}
			else
			{
				cmsIsClosed = false;
				dropDownOpen();
			}
		}

		private void btn_Button_Click(object sender, EventArgs e)
		{
			parent.handleCutouts(Properties.Settings.Default.s_lastTool);
		}
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

			e.Graphics.DrawImage(this.Image, new PointF(Width / 2 - this.Image.Width / 2, 0));
		}
	}
}

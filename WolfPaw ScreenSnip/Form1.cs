using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
    public partial class Form1 : Form
    {
		f_Screen fs = null;


		public Form1()
        {
            InitializeComponent();

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

            Application.Exit();
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
			}

			if(fs != null)
			{
				fs.addImage(bmp);
			}
        }
    }
}

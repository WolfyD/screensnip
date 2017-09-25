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
    public partial class f_Screen : Form
    {
		public f_SettingPanel child = null;
		public Form1 parent = null;

		public f_Screen()
        {
            InitializeComponent();

            Load += F_Screen_Load;
        }



		private void F_Screen_Load(object sender, EventArgs e)
        {
            
        }

        public void addImage(Bitmap img)
        {
			if (img != null)
			{
				var box = new uc_CutoutHolder();
				box.Parent = this;

				box.Width = img.Width;
				box.Height = img.Height;

				box.BMP = img;
			}
        }

		private void f_Screen_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(child != null) { child.Close(); }
			parent.Activate();
		}

		public void f_Screen_KeyDown(object sender, KeyEventArgs e)
		{
			parent.Form1_KeyDown(sender, e);
		}
	}
}

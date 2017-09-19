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
    }
}

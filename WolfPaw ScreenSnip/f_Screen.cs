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
            Bitmap b = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(100, 100));
            }
            addImage(b);
        }

        public void addImage(Bitmap img)
        {
            var box = new uc_CutoutHolder();
            box.Parent = this;
            
            box.BMP = img;
        }
    }
}

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
	public partial class f_TCP : Form
	{
		public Bitmap bmp = null;
		private Bitmap bmp2 = null;
		public bool OK = false;
		public Color TC = Color.White;
		public int T = 0;

		public f_TCP()
		{
			InitializeComponent();

			Load += F_TCP_Load;
		}

		private void F_TCP_Load(object sender, EventArgs e)
		{
			bmp2 = bmp;
			pb_Pic.Image = bmp;
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			OK = true;
			TC = p_Color.BackColor;
			T = (int)num_Tolerance.Value;
			this.Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}

		private void p_Color_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if(cd.ShowDialog() == DialogResult.OK)
			{
				p_Color.BackColor = cd.Color;
			}
		}

		private void pb_Pic_MouseDown(object sender, MouseEventArgs e)
		{
			Bitmap b = new Bitmap(pb_Pic.DisplayRectangle.Width, pb_Pic.DisplayRectangle.Height);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.CopyFromScreen(new Point(pb_Pic.DisplayRectangle.X, pb_Pic.DisplayRectangle.Y),new Point(0,0), new Size(pb_Pic.DisplayRectangle.Width, pb_Pic.DisplayRectangle.Height));
			}
			p_Color.BackColor = b.GetPixel(e.X,e.Y);
		}
	}
}

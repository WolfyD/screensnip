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
	public partial class f_Preview : Form
	{
		public f_Screen fs = null;
		//public Dictionary<int, uc_CutoutHolder> cutouts = null;
		public List<c_ImageHolder> cutouts = null;
		bool trender = true;
		bool hbg = false;
		bool hbd = false;

		public f_Preview()
		{
			InitializeComponent();
			Load += F_Preview_Load;
		}

		private void F_Preview_Load(object sender, EventArgs e)
		{
			if (fs != null && !fs.IsDisposed)
			{
				if (fs.child != null && !fs.child.IsDisposed)
				{ fs.child.Hide(); }
			}

			hbg = Properties.Settings.Default.s_hasBgColor;
			hbd = Properties.Settings.Default.s_hasBorder;

			if (fs != null && cutouts != null)
			{
				try
				{
					generateImage();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}

			
		}

		public void generateImage()
		{
			Bitmap _b = c_ImgGen.createPng(fs, cutouts, new object[] { fs.getDrawnPoints(), null }, trender);
			pb_Pic.Image = _b;


			lbl_Info.Text = "Size: " + _b.Width + "x" + _b.Height + "px | # of layers: " + fs.Limages.Count;
			//_b.Dispose();
		}

		private void btn_ED_TransparencyRender_Click(object sender, EventArgs e)
		{
			trender = !trender;
			generateImage();
		}

		private void btn_ED_Border_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_hasBorder = !Properties.Settings.Default.s_hasBorder;
			generateImage();
		}

		private void btn_ED_Background_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_hasBgColor = !Properties.Settings.Default.s_hasBgColor;
			generateImage();
		}

        private void f_Preview_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (fs != null && !fs.IsDisposed)
			{
				if (fs.child != null && !fs.child.IsDisposed) { fs.child.Show(); }
			}
			Properties.Settings.Default.s_hasBgColor = hbg;
			Properties.Settings.Default.s_hasBorder = hbd;
		}
	}
}

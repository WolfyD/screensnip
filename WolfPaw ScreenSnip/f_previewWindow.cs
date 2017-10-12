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
	public partial class f_previewWindow : Form
	{
		public f_previewWindow()
		{
			InitializeComponent();

		}

		Image i = null;

		public void refreshImage(f_Screen fs)
		{
			pb_PreviewPicture.Image = c_ImgGen.createPng(fs, fs.Limages, new object[] { fs.getDrawnPoints(), null });
			GC.Collect(1);
		}
	}
}

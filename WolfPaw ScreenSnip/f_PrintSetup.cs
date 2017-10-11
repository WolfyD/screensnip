using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class f_PrintSetup : Form
	{
		public PrintDocument pd { get; set; }
		public PageSettings ps { get; set; }
		public f_Screen fs { get; set; }
		public Dictionary<int,uc_CutoutHolder> cutouts { get; set; }

		public f_PrintSetup()
		{
			InitializeComponent();

			Load += F_PrintSetup_Load;
		}

		private void F_PrintSetup_Load(object sender, EventArgs e)
		{
			foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = printer;
				lvi.ImageIndex = 1;
				lv_ListView.Items.Add(lvi);
			}

			ch_Printers.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

			if (ch_Printers.Width < lv_ListView.Width)
			{
				ch_Printers.Width = lv_ListView.Width;
			}

			if (pd != null && ps != null)
			{
				pd.DefaultPageSettings = ps;
				ppc_Preview.Document = pd;

				//pd.PrintPage += Pd_PrintPage;
			}
		}

		private void Pd_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				e.Graphics.DrawImage(c_ImgGen.createPng(fs, cutouts, new object[] { fs.getDrawnPoints(), null }), new Point(100, 10));
				c_returnGraphicSettings cg = new c_returnGraphicSettings();

				e.Graphics.SmoothingMode = cg.getSM();
				e.Graphics.InterpolationMode = cg.getIM();
				e.Graphics.PixelOffsetMode = cg.getPOM();
				pd_PrintDialog.Document = pd;
			}
			catch
			{

			}
		}

		private void num_Margin_Top_ValueChanged(object sender, EventArgs e)
		{
			
		}
	}
}

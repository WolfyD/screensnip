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
	public partial class f_SettingPanel : Form
	{
		public Form parent = null;

		public f_SettingPanel()
		{
			InitializeComponent();

			Load += F_SettingPanel_Load;
		}

		private void F_SettingPanel_Load(object sender, EventArgs e)
		{
			if (parent != null)
			{
				Left = parent.Right - Width - 8;
				Top = parent.Top + 31;
			}

			if (Properties.Settings.Default.s_hasBgColor) { r_BgColor.Checked = true; p_BgColor.BackColor = Properties.Settings.Default.s_bgColor; } else { r_BgTransparent.Checked = true; p_BgColor.Enabled = false; }
			if (Properties.Settings.Default.s_hasBorder) { cb_Border.Checked = true; p_Border.BackColor = Properties.Settings.Default.s_borderColor; num_Border.Value = Properties.Settings.Default.s_borderWidth; } else { num_Border.Enabled = false; p_Border.Enabled = false; }
		}

		private void cb_Transparent_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void f_SettingPanel_MouseLeave(object sender, EventArgs e)
		{
			if (cb_Transparent.Checked)
			{
				this.Opacity = 1 - (double)(num_Transparency.Value / 100);
			}
		}

		private void f_SettingPanel_MouseEnter(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}

		private void r_BgTransparent_CheckedChanged(object sender, EventArgs e)
		{
			if (r_BgTransparent.Checked) { p_BgColor.Enabled = false; p_BgColor.BorderStyle = BorderStyle.None; Properties.Settings.Default.s_hasBgColor = false; }
			else { p_BgColor.Enabled = true; p_BgColor.BorderStyle = BorderStyle.FixedSingle; Properties.Settings.Default.s_hasBgColor = true; }
			Properties.Settings.Default.Save();
		}

		private void cb_Border_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_Border.Checked) { p_Border.Enabled = true; num_Border.Enabled = true; p_Border.BorderStyle = BorderStyle.None; Properties.Settings.Default.s_hasBorder = true; }
			else { p_Border.Enabled = false; num_Border.Enabled = false;  p_Border.BorderStyle = BorderStyle.FixedSingle; Properties.Settings.Default.s_hasBorder = false; }
			Properties.Settings.Default.Save();
		}
	}
}

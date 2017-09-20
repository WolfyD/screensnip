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
		public Point pos = new Point(-1, -1);
		public bool posChange = true;


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

				pos = new Point(Left - parent.Left, Top - parent.Top);
				parent.LocationChanged += Parent_LocationChanged;
			}

			lbl_Demo.Font = Properties.Settings.Default.s_font;
			lbl_Demo.Left = ((Width - 16) / 2) - (lbl_Demo.Width / 2);

			if (Properties.Settings.Default.s_hasBgColor) { r_BgColor.Checked = true; p_BgColor.BackColor = Properties.Settings.Default.s_bgColor; } else { r_BgTransparent.Checked = true; p_BgColor.Tag = 0; }
			if (Properties.Settings.Default.s_hasBorder) { cb_Border.Checked = true; p_Border.BackColor = Properties.Settings.Default.s_borderColor; num_Border.Value = Properties.Settings.Default.s_borderWidth; } else { num_Border.Enabled = false; p_Border.Tag = 0; }
		}

		private void Parent_LocationChanged(object sender, EventArgs e)
		{
			if (cb_Follow.Checked)
			{
				posChange = false;
				Left = pos.X + parent.Left;
				Top = pos.Y + parent.Top;
				posChange = true;
			}
		}
		

		private void f_SettingPanel_MouseEnter(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}

		private void r_BgTransparent_CheckedChanged(object sender, EventArgs e)
		{
			if (r_BgTransparent.Checked) { p_BgColor.Tag = 0; p_BgColor.BorderStyle = BorderStyle.None; Properties.Settings.Default.s_hasBgColor = false;}
			else { p_BgColor.Tag = 1; p_BgColor.BorderStyle = BorderStyle.FixedSingle; Properties.Settings.Default.s_hasBgColor = true;}
			Properties.Settings.Default.Save();
		}

		private void cb_Border_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_Border.Checked) { p_Border.Tag = 1; num_Border.Enabled = true; p_Border.BorderStyle = BorderStyle.FixedSingle; Properties.Settings.Default.s_hasBorder = true; }
			else { p_Border.Tag = 0; num_Border.Enabled = false;  p_Border.BorderStyle = BorderStyle.None; Properties.Settings.Default.s_hasBorder = false;}
			Properties.Settings.Default.Save();
		}

		private void f_SettingPanel_LocationChanged(object sender, EventArgs e)
		{
			if (posChange)
			{
				pos = new Point(Left - parent.Left, Top - parent.Top);
			}
		}

		private void p_BgColor_Click(object sender, EventArgs e)
		{
			if(p_BgColor.Tag.ToString() != "0")
			{
				ColorDialog cd = new ColorDialog();
				cd.Color = p_BgColor.BackColor;
				if (cd.ShowDialog() == DialogResult.OK)
				{
					p_BgColor.BackColor = cd.Color;
					Properties.Settings.Default.s_bgColor = cd.Color;
					Properties.Settings.Default.Save();
				}
			}
		}

		private void p_Border_Click(object sender, EventArgs e)
		{
			if(p_Border.Tag.ToString() != "0")
			{
				ColorDialog cd = new ColorDialog();
				cd.Color = p_Border.BackColor;
				if (cd.ShowDialog() == DialogResult.OK)
				{
					p_Border.BackColor = cd.Color;
					Properties.Settings.Default.s_borderColor = cd.Color;
					Properties.Settings.Default.Save();
				}
			}
		}

		private void p_BgColor_MouseEnter(object sender, EventArgs e)
		{
			if(p_BgColor.Tag.ToString() == "0")
			{
				p_BgColor.Cursor = Cursors.No;
			}
			else
			{
				p_BgColor.Cursor = Cursors.Default;
			}
		}

		private void p_Border_MouseEnter(object sender, EventArgs e)
		{
			if (p_Border.Tag.ToString() == "0")
			{
				p_Border.Cursor = Cursors.No;
			}
			else
			{
				p_Border.Cursor = Cursors.Default;
			}
		}

		private void num_Border_ValueChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_borderWidth = (int)num_Border.Value;
			Properties.Settings.Default.Save();
		}

		private void btn_Font_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			fd.Font = Properties.Settings.Default.s_font;
			if(fd.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.s_font = fd.Font;

				lbl_Demo.Font = Properties.Settings.Default.s_font;
				lbl_Demo.Left = ((Width - 16) / 2) - (lbl_Demo.Width / 2);

				Properties.Settings.Default.Save();
			}

			
		}
	}
}

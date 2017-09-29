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
	public partial class f_SearchBy : Form
	{
		public bool OK { get; set; }
		public System.Data.SQLite.SQLiteConnection sqlc { get; set; }
		public List<c_Object> loc { get; set; }

		public f_SearchBy()
		{
			InitializeComponent();

            Load += F_SearchBy_Load;
		}

        private void F_SearchBy_Load(object sender, EventArgs e)
        {
			/*
            btn_Search.Top = Height - (btn_Search.Height + 39 + 10);
            btn_Cancel.Top = btn_Search.Top;
			*/
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loc = null;

			if (rb_Title.Checked)
			{
				loc = c_DatabaseHandler.getImagesByTitle(sqlc, tb_Title.Text, cb_Title.Checked);
				if (loc != null && loc.Count > 0)
				{
					OK = true;
					this.Close();
				}
			}
			else if (rb_Description.Checked)
			{
				loc = c_DatabaseHandler.getImagesByDescription(sqlc, tb_Description.Text, cb_Description.Checked);
				if (loc != null && loc.Count > 0)
				{
					OK = true;
					this.Close();
				}
			}
			else if (rb_Tags.Checked)
			{
				if (tb_Tags.Tag == null)
				{
					if (tb_Tags.Text != "") { tb_Tags.Tag = tb_Tags.Text.Split(';'); }
					else
					{
						return;
					}
				}

				loc = c_DatabaseHandler.getImagesByTags(sqlc, tb_Tags.Tag as String[]);
				if (loc != null && loc.Count > 0)
				{
					OK = true;
					this.Close();
				}
			}
			else if (rb_All.Checked)
			{
				loc = c_DatabaseHandler.getImagesAll(sqlc);
				if (loc != null && loc.Count > 0)
				{
					OK = true;
					this.Close();
				}
			}

			if (loc == null)
			{
				MessageBox.Show("There was an error while handling your request. \r\nPlease reopen this window an try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if(loc.Count == 0)
			{
				MessageBox.Show("No results were found for your search. \r\nPlease try again with different settings.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

        private void tb_Title_Click(object sender, EventArgs e)
        {
            rb_Title.Checked = true;
        }

        private void tb_Description_Click(object sender, EventArgs e)
        {
            rb_Description.Checked = true;
        }

        private void tb_Tags_Click(object sender, EventArgs e)
        {
            rb_Tags.Checked = true;
        }

        private void tb_Date_Click(object sender, EventArgs e)
        {
            rb_Date.Checked = true;
        }

		private void btn_EditTags_Click(object sender, EventArgs e)
		{
			f_TagEditor ftag = new f_TagEditor();
			ftag.openTags = tb_Tags.Text;
			ftag.ShowDialog();
			tb_Tags.Text = ftag.closeTags;
			tb_Tags.Tag = ftag.tagarray;
		}
	}
}

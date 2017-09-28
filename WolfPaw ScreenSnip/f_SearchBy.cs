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
			else if (rb_Tags.Checked)
			{
				loc = c_DatabaseHandler.getImagesByTags(sqlc, tb_Tags.Tag as String[]);
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
			else
			{
				MessageBox.Show("No results were found for your search. \r\nPlease try again with different settings.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}

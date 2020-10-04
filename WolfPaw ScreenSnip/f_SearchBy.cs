using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSnip
{
	public partial class f_SearchBy : Form
	{
		public bool OK { get; set; }
		public System.Data.SQLite.SQLiteConnection sqlc { get; set; }
		public List<c_Object> loc { get; set; }

        string date1 = "0000/00/00";
        string date2 = "0000/00/00";

		public f_SearchBy()
		{
			InitializeComponent();

            Load += F_SearchBy_Load;
		}

        private void F_SearchBy_Load(object sender, EventArgs e)
        {
			string[] tables = getTableNames();
			cb_Tables.Items.Clear();
			cb_Tables.Items.AddRange(tables);
			cb_Tables.SelectedIndex = 0;
		}

		public string[] getTableNames()
		{
			return c_DatabaseHandler.getTableNamesFromDB(sqlc);
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
				loc = c_DatabaseHandler.getImagesByTitle(sqlc, tb_Title.Text, cb_Title.Checked, cb_Tables.Text);
				if (loc != null && loc.Count > 0)
				{
					OK = true;
					this.Close();
				}
			}
			else if (rb_Description.Checked)
			{
				loc = c_DatabaseHandler.getImagesByDescription(sqlc, tb_Description.Text, cb_Description.Checked, cb_Tables.Text);
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

                loc = c_DatabaseHandler.getImagesByTags(sqlc, tb_Tags.Tag as String[], cb_Tables.Text);
                if (loc != null && loc.Count > 0)
                {
                    OK = true;
                    this.Close();
                }
            }
            else if (rb_Date.Checked)
            {
                loc = c_DatabaseHandler.getImagesByDate(sqlc, tb_Date.Text, cb_Tables.Text);
                if (loc != null && loc.Count > 0)
                {
                    OK = true;
                    this.Close();
                }
            }
            else if (rb_All.Checked)
			{
				loc = c_DatabaseHandler.getImagesAll(sqlc, cb_Tables.Text);
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

        private void btn_date_Close_Click(object sender, EventArgs e)
        {
            tb_Date.Text = lbl_Dates.Text;
            p_date.Hide();
            btn_Search.Enabled = true;
        }

        public string gettoday()
        {
            DateTime d = DateTime.Now;
            return d.Year + "/" + d.Month.ToString().PadLeft(2, '0') + "/" + d.Day.ToString().PadLeft(2, '0');
        }

        public void updateDateText()
        {
            string d1 = date1 == "0000/00/00" ? gettoday() : date1;
            string d2 = date2 == "0000/00/00" ? gettoday() : date2;

            lbl_Dates.Text = d1 + "|" + d2; 
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = dtp_from.Value;
            date1 = d.Year + "/" + d.Month.ToString().PadLeft(2, '0') + "/" + d.Day.ToString().PadLeft(2, '0');
            updateDateText();
        }

        private void dtp_to_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = dtp_to.Value;
            date2 = d.Year + "/" + d.Month.ToString().PadLeft(2,'0') + "/" + d.Day.ToString().PadLeft(2, '0');
            updateDateText();
        }

        private void btn_EditDate_Click(object sender, EventArgs e)
        {
            rb_Date.Checked = true;
            btn_Search.Enabled = false;
            p_date.Show();
            p_date.Dock = DockStyle.Fill;
        }
    }
}

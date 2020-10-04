using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSnip
{
    public partial class f_SaveToDB : Form
    {
		public Bitmap img { get; set; }
		String dbfilename = "";
		String dbFile = "";

        public f_SaveToDB()
        {
            InitializeComponent();
			Load += F_SaveToDB_Load;
        }

		private void F_SaveToDB_Load(object sender, EventArgs e)
		{
			pb_Pic.Image = img;
			refreshLog();
			load();
		}

		public void refreshLog()
		{
			cb_Tags.Items.Clear();
			foreach(string s in Properties.tagLog.Default.LOG)
			{
				cb_Tags.Items.Add(s);
			}
		}

		public void load()
		{
			dbFile = Properties.Settings.Default.s_DBFileLocation.Replace("%this%", Environment.CurrentDirectory);
			dbfilename = Properties.Settings.Default.s_DBFileLocation.Replace("%this%", ".");
			lbl_DBFile.Text = dbfilename;
			if (!File.Exists(dbFile))
			{
				File.Create(dbFile).Close();
				string err = "";
				System.Data.SQLite.SQLiteConnection sqlc = c_DatabaseHandler.ConnectToDB(dbFile, out err);
				if (err == "")
				{
					c_DatabaseHandler.generateTable(sqlc);
				}
				else
				{
					MessageBox.Show(err);
				}
			}
			
			string[] tables = getTableNames();
			cb_Tables.Items.Clear();
			cb_Tables.Items.AddRange(tables);
			cb_Tables.SelectedIndex = 0;
		}

		public string[] getTableNames()
		{
			string err2 = "";
			return c_DatabaseHandler.getTableNamesFromDB(c_DatabaseHandler.ConnectToDB(dbFile, out err2));
		}

		private void btn_DB_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "SQLite Files|*.sqlite|DB Files|*.db|SQL Files|*.sql";
			sfd.FileName = dbFile;
			if(sfd.ShowDialog() == DialogResult.OK)
			{
				dbFile = sfd.FileName;
				Properties.Settings.Default.s_DBFileLocation = dbFile;
				Properties.Settings.Default.Save();
				load();
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public string getDate()
		{
			string d = "";
			DateTime n = DateTime.Now;

			d = n.Year + "" + n.Month.ToString().PadLeft(2,'0') + "" + n.Day.ToString().PadLeft(2, '0');

			return d;
		}

		public string getTags()
		{
			string t = "";

			foreach(ListViewItem lvi in lv_Tags.Items)
			{
				t += lvi.Text + ";";
			}

			t = t.Trim(' ', ';');

			return t;
		}
		
		private void btn_Save_Click(object sender, EventArgs e)
		{
			String hex = c_Converter.ConvertToHex(img);
			string err = "";
			System.Data.SQLite.SQLiteConnection sqlc = c_DatabaseHandler.ConnectToDB(dbFile, out err);
			if(err == "")
			{
				c_DatabaseHandler.insertImage(sqlc, cb_Tables.Text, tb_Title.Text, tb_Description.Text, hex, getTags(), getDate());
				this.Close();
			}
			else
			{
				MessageBox.Show(err);
			}
			//pb_Pic.Image = c_Converter.ConvertToImg(hex);
		}

		public void resetBGC()
		{
			foreach(ListViewItem lvi in lv_Tags.Items)
			{
				int i = lvi.Index;
				lvi.BackColor = i % 2 == 0 ? Color.LightYellow : Color.LightBlue;
			}
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			if(cb_Tags.Text != "" && !getTags().ToLower().Split(';').Contains(cb_Tags.Text.ToLower()))
			{
				if (!Properties.tagLog.Default.LOG.Contains(cb_Tags.Text))
				{
					Properties.tagLog.Default.LOG.Add(cb_Tags.Text);
					Properties.tagLog.Default.Save();
					refreshLog();
				}
				ListViewItem lvi = new ListViewItem();
				lvi.Text = cb_Tags.Text;
				lvi.BackColor = lv_Tags.Items.Count % 2 == 0 ? Color.LightYellow : Color.AliceBlue;
				lv_Tags.Items.Add(lvi);
			}
		}

		private void cb_Tags_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) { btn_Add_Click(null, null); }
		}

		public ListViewItem getFocus()
		{
			if (lv_Tags.FocusedItem != null)
			{
				return lv_Tags.FocusedItem;
			}
			else { return null; }
		}


#region	buttons
		private void btn_Delete_Click(object sender, EventArgs e)
		{
			var v = getFocus();
			if(v != null)
			{
				lv_Tags.Items.Remove((v as ListViewItem));
			}
			resetBGC();
		}

		private void btn_Up_Click(object sender, EventArgs e)
		{
			var v = getFocus();
			if (v != null)
			{
				//(v as ListViewItem)
				int i = (v as ListViewItem).Index;
				if(i > 0)
				{
					v.Remove();
					lv_Tags.Items.Insert(i - 1, v);
					lv_Tags.FocusedItem = v;
				}
			}
			resetBGC();
		}

		private void btn_Down_Click(object sender, EventArgs e)
		{
			var v = getFocus();
			if (v != null)
			{
				//(v as ListViewItem)
				int i = (v as ListViewItem).Index;
				if (i < lv_Tags.Items.Count - 1)
				{
					v.Remove();
					lv_Tags.Items.Insert(i + 1, v);
					lv_Tags.FocusedItem = v;
				}
			}
			resetBGC();
		}

		private void btn_Top_Click(object sender, EventArgs e)
		{
			var v = getFocus();
			if (v != null)
			{
				//(v as ListViewItem)
				int i = (v as ListViewItem).Index;
				if (i > 0)
				{
					v.Remove();
					lv_Tags.Items.Insert(0, v);
					lv_Tags.FocusedItem = v;
				}
			}
			resetBGC();
		}

		private void btn_Bottom_Click(object sender, EventArgs e)
		{
			var v = getFocus();
			if (v != null)
			{
				//(v as ListViewItem)
				int i = (v as ListViewItem).Index;
				if (i < lv_Tags.Items.Count - 1)
				{
					v.Remove();
					lv_Tags.Items.Insert(lv_Tags.Items.Count, v);
					lv_Tags.FocusedItem = v;
				}
			}
			resetBGC();
		}

		private void btn_AddTable_Click(object sender, EventArgs e)
		{
			p_CreateTable.Visible = true;
			populateTableList();
		}

		#endregion

		public void populateTableList()
		{
			string[] tbls = getTableNames();
			lv_Tables.Items.Clear();

			foreach(String s in tbls)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = s;
				lvi.BackColor = lv_Tables.Items.Count % 2 == 0 ? Color.LightBlue : Color.LightYellow;
				lv_Tables.Items.Add(lvi);
			}
		}

		private void btn_CreateNewTable_Click(object sender, EventArgs e)
		{
			string err2 = "";
			var conn = c_DatabaseHandler.ConnectToDB(dbFile, out err2);
			if (!c_DatabaseHandler.getTableNamesFromDB(conn).Contains(tb_NewTableName.Text))
			{
				c_DatabaseHandler.generateAdditionalTable(conn, tb_NewTableName.Text);
				tb_NewTableName.Text = "";
				lv_Tables.Items.Clear();
				p_CreateTable.Hide();
				load();
			}
			else
			{
				MessageBox.Show("It seems a table with the name " + tb_NewTableName.Text + " already exists.\r\n\r\nPlease select a different name!", "Table name already exists!");
			}
		}

		private void btn_CloseTableCreator_Click(object sender, EventArgs e)
		{
			tb_NewTableName.Text = "";
			lv_Tables.Items.Clear();
			p_CreateTable.Hide();
			load();
		}
	}
}

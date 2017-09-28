using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class f_LoadImageDB : Form
	{
		SQLiteConnection sqlc = null;
		List<c_Object> loc = null;

		public f_LoadImageDB()
		{
			InitializeComponent();

			Load += F_LoadImageDB_Load;
		}

		private void F_LoadImageDB_Load(object sender, EventArgs e)
		{
			string err = "";
			string dbFile = Properties.Settings.Default.s_DBFileLocation.Replace("%this%", Environment.CurrentDirectory);

			if (File.Exists(dbFile))
			{
				sqlc = c_DatabaseHandler.ConnectToDB(dbFile, out err);
				if(err == "")
				{
					f_SearchBy fsb = new f_SearchBy();
					fsb.sqlc = sqlc;
					fsb.ShowDialog();
					if (fsb.OK)
					{
						loc = fsb.loc;
					}
				}
				else
				{
					MessageBox.Show(err, "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			f_SearchBy fsb = new f_SearchBy();
			fsb.sqlc = sqlc;
			fsb.ShowDialog();
			if (fsb.OK)
			{
				loc = fsb.loc;
				pb_Img.Image = loc[0].getImage();
				lbl_Title.Text = loc[0].getTitle();
				lbl_Desc.Text = loc[0].getDescription();
			}
		}
	}
}

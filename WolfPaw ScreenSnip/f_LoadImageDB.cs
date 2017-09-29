using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
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

        int currentIndex = 0;

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
                    /*
					f_SearchBy fsb = new f_SearchBy();
					fsb.sqlc = sqlc;
					fsb.ShowDialog();
					if (fsb.OK)
					{
						loc = fsb.loc;
					}
                    */
                    btn_Search.Enabled = true;
				}
				else
				{
					MessageBox.Show(err, "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        public void setImg(int i)
        {
            try
            {
                pb_Img.Image = loc[i].getImage();

				//h_Hist.setImage(@"C:\Users\WolfyD\Desktop\rb\1.jpg");
				Bitmap bmp = pb_Img.Image as Bitmap;
				h_Hist.showCatchExceptions = true;
				h_Hist.setImage(bmp);
				h_Hist.getHistogram();
				

				lbl_Title.Text = loc[i].getTitle();
                lbl_Desc.Text = loc[i].getDescription();
                //btn_Tags.Tag = loc[i].getTags();

                lv_Tags.Items.Clear();
                foreach(string s in loc[i].getTags())
                {
                    lv_Tags.Items.Add(s);
                }

                if (i == 0)
                {
                    btn_Prev.Enabled = false;
                }
                else
                {
                    btn_Prev.Enabled = true;
                }

                if (i == loc.Count - 1)
                {
                    btn_Next.Enabled = false;
                }
                else
                {
                    btn_Next.Enabled = true;
                }

				

                lbl_numOfNum.Text = (i + 1) + " of " + loc.Count;
            }
            catch { }
        }

		private void btn_Search_Click(object sender, EventArgs e)
		{
			f_SearchBy fsb = new f_SearchBy();
			fsb.sqlc = sqlc;
			fsb.ShowDialog();
			if (fsb.OK)
			{
				loc = fsb.loc;
				if(loc.Count > 0) { setImg(0); btn_Copy.Enabled = true; btn_Save.Enabled = true; }
			}
		}

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if(currentIndex < loc.Count - 1)
            {
                currentIndex++;
                setImg(currentIndex);
            }
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                setImg(currentIndex);
            }
        }

        private void btn_Tags_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed)
            {
                splitContainer2.Panel2Collapsed = false;
            }
            else
            {
                splitContainer2.Panel2Collapsed = true;
            }
        }

        private void btn_Data_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage((Bitmap)pb_Img.Image);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Bitmap _b = pb_Img.Image as Bitmap;
            string savename = "ScreenSnip_";

            if (true || Properties.Settings.Default.s_SaveHasDateTime)
            {
                string date = "";
                DateTime n = DateTime.Now;
                date = n.Year + "." + n.Month.ToString().PadLeft(2, '0') + "." + n.Day.ToString().PadLeft(2, '0') + "_" + n.Hour.ToString().PadLeft(2, '0') + "." + n.Minute.ToString().PadLeft(2, '0') + "." + n.Second.ToString().PadLeft(2, '0');
                savename += date;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter =    "Portable Network Graphics Image (PNG)|*.png|" +
                            "Bitmap Image (BMP)|*.bmp|" +
                            "Joint Photographic Experts Group Image (JPEG)|*.jpg;*.jpeg|" +
                            "Graphics Interchange Format Image (GIF)|*.gif|" +
                            "Tagged Image File Format Image (TIFF)|*.tif;*.tiff|" +
                            "Windows Metafile Image (WMF)|*.wmf";

            sfd.FilterIndex = Properties.Settings.Default.s_lastSaveFormat;

            sfd.FileName = savename;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ImageFormat _if = ImageFormat.Png;

                switch (sfd.FileName.Substring(sfd.FileName.LastIndexOf(".") + 1).ToLower())
                {
                    case "png":
                        _if = ImageFormat.Png;
                        Properties.Settings.Default.s_lastSaveFormat = 0;
                        break;

                    case "bmp":
                        _if = ImageFormat.Bmp;
                        Properties.Settings.Default.s_lastSaveFormat = 1;
                        break;

                    case "jpg":
                        _if = ImageFormat.Jpeg;
                        Properties.Settings.Default.s_lastSaveFormat = 2;
                        break;

                    case "jpeg":
                        _if = ImageFormat.Jpeg;
                        Properties.Settings.Default.s_lastSaveFormat = 2;
                        break;

                    case "gif":
                        _if = ImageFormat.Gif;
                        Properties.Settings.Default.s_lastSaveFormat = 3;
                        break;

                    case "tif":
                        _if = ImageFormat.Tiff;
                        Properties.Settings.Default.s_lastSaveFormat = 4;
                        break;

                    case "tiff":
                        _if = ImageFormat.Tiff;
                        Properties.Settings.Default.s_lastSaveFormat = 4;
                        break;

                    case "wmf":
                        _if = ImageFormat.Wmf;
                        Properties.Settings.Default.s_lastSaveFormat = 5;
                        break;

                    default:
                        _if = ImageFormat.Png;
                        Properties.Settings.Default.s_lastSaveFormat = 0;
                        break;
                }

                _b.Save(sfd.FileName, _if);

            }
        }
    }
}

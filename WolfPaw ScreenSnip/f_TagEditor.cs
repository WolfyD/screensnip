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
	public partial class f_TagEditor : Form
	{
		public string openTags { get; set; }
		public string closeTags { get; set; }
		public string[] tagarray { get; set; }

		public f_TagEditor()
		{
			InitializeComponent();

			Load += F_TagEditor_Load;
		}

		private void F_TagEditor_Load(object sender, EventArgs e)
		{
			if(openTags != "")
			{
				foreach(String s in openTags.Split(';'))
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = s;
					lv_Tags.Items.Add(lvi);
					resetBGC();
				}
			}
			lv_Tags.ContextMenuStrip = cms_Tags;
			foreach(string s in Properties.tagLog.Default.LOG)
			{
				cb_Tag.Items.Add(s);
			}
		}

		private void btn_RemoveTag_Click(object sender, EventArgs e)
		{
			if(lv_Tags.FocusedItem != null)
			{
				lv_Tags.FocusedItem.Remove();
				resetBGC();
			}
		}

		private void btn_ClearAllTags_Click(object sender, EventArgs e)
		{
			lv_Tags.Items.Clear();
		}

		public void resetBGC()
		{
			foreach (ListViewItem lvi in lv_Tags.Items)
			{
				int i = lvi.Index;
				lvi.BackColor = i % 2 == 0 ? Color.LightYellow : Color.LightBlue;
			}
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			List<string> lst = new List<string>();
			foreach(ListViewItem v in lv_Tags.Items) { lst.Add(v.Text.ToLower()); }
			if(cb_Tag.Text != "" && !lst.Contains(cb_Tag.Text.ToLower()))
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = cb_Tag.Text;
				lv_Tags.Items.Add(lvi);
				resetBGC();
			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void f_TagEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach(ListViewItem lvi in lv_Tags.Items)
			{
				closeTags += lvi.Text + ";";
			}

			try
			{
				closeTags = closeTags.Trim(';');
				tagarray = closeTags.Split(';');
			}
			catch
			{

			}

		}
	}
}

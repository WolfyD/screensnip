namespace SharpSnip
{
	partial class f_PrintSetup
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_PrintSetup));
			this.ppc_Preview = new System.Windows.Forms.PrintPreviewControl();
			this.psd_PageSetup = new System.Windows.Forms.PageSetupDialog();
			this.pd_PrintDialog = new System.Windows.Forms.PrintDialog();
			this.ppd_Preview = new System.Windows.Forms.PrintPreviewDialog();
			this.lv_ListView = new System.Windows.Forms.ListView();
			this.ch_Printers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.il_Images = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.num_Margin_Top = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.num_Margin_Top)).BeginInit();
			this.SuspendLayout();
			// 
			// ppc_Preview
			// 
			this.ppc_Preview.Location = new System.Drawing.Point(12, 12);
			this.ppc_Preview.Name = "ppc_Preview";
			this.ppc_Preview.Size = new System.Drawing.Size(397, 429);
			this.ppc_Preview.TabIndex = 0;
			// 
			// psd_PageSetup
			// 
			this.psd_PageSetup.EnableMetric = true;
			this.psd_PageSetup.ShowHelp = true;
			// 
			// pd_PrintDialog
			// 
			this.pd_PrintDialog.AllowCurrentPage = true;
			this.pd_PrintDialog.AllowSelection = true;
			this.pd_PrintDialog.AllowSomePages = true;
			this.pd_PrintDialog.ShowHelp = true;
			this.pd_PrintDialog.UseEXDialog = true;
			// 
			// ppd_Preview
			// 
			this.ppd_Preview.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.ppd_Preview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.ppd_Preview.ClientSize = new System.Drawing.Size(400, 300);
			this.ppd_Preview.Enabled = true;
			this.ppd_Preview.Icon = ((System.Drawing.Icon)(resources.GetObject("ppd_Preview.Icon")));
			this.ppd_Preview.Name = "ppd_Preview";
			this.ppd_Preview.Visible = false;
			// 
			// lv_ListView
			// 
			this.lv_ListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.lv_ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Printers});
			this.lv_ListView.FullRowSelect = true;
			this.lv_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv_ListView.HideSelection = false;
			this.lv_ListView.LargeImageList = this.il_Images;
			this.lv_ListView.Location = new System.Drawing.Point(415, 12);
			this.lv_ListView.MultiSelect = false;
			this.lv_ListView.Name = "lv_ListView";
			this.lv_ListView.Size = new System.Drawing.Size(260, 160);
			this.lv_ListView.SmallImageList = this.il_Images;
			this.lv_ListView.TabIndex = 1;
			this.lv_ListView.UseCompatibleStateImageBehavior = false;
			this.lv_ListView.View = System.Windows.Forms.View.Details;
			// 
			// ch_Printers
			// 
			this.ch_Printers.Text = "Printers";
			this.ch_Printers.Width = 235;
			// 
			// il_Images
			// 
			this.il_Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_Images.ImageStream")));
			this.il_Images.TransparentColor = System.Drawing.Color.Transparent;
			this.il_Images.Images.SetKeyName(0, "printer_32.gif");
			this.il_Images.Images.SetKeyName(1, "printer_16_2.gif");
			this.il_Images.Images.SetKeyName(2, "printer_16.png");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(415, 194);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Margin: ";
			// 
			// num_Margin_Top
			// 
			this.num_Margin_Top.Location = new System.Drawing.Point(466, 192);
			this.num_Margin_Top.Name = "num_Margin_Top";
			this.num_Margin_Top.Size = new System.Drawing.Size(120, 20);
			this.num_Margin_Top.TabIndex = 3;
			this.num_Margin_Top.ValueChanged += new System.EventHandler(this.num_Margin_Top_ValueChanged);
			// 
			// f_PrintSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 616);
			this.Controls.Add(this.num_Margin_Top);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lv_ListView);
			this.Controls.Add(this.ppc_Preview);
			this.Name = "f_PrintSetup";
			this.Text = "f_PrintSetup";
			((System.ComponentModel.ISupportInitialize)(this.num_Margin_Top)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PrintPreviewControl ppc_Preview;
		private System.Windows.Forms.PageSetupDialog psd_PageSetup;
		private System.Windows.Forms.PrintDialog pd_PrintDialog;
		private System.Windows.Forms.PrintPreviewDialog ppd_Preview;
		private System.Windows.Forms.ListView lv_ListView;
		private System.Windows.Forms.ColumnHeader ch_Printers;
		private System.Windows.Forms.ImageList il_Images;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown num_Margin_Top;
	}
}
namespace WolfPaw_ScreenSnip
{
	partial class f_LoadImageDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_LoadImageDB));
            this.btn_Prev = new FontAwesome.Sharp.IconButton();
            this.btn_Next = new FontAwesome.Sharp.IconButton();
            this.btn_Search = new FontAwesome.Sharp.IconButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Data = new FontAwesome.Sharp.IconButton();
            this.pb_Img = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.h_Hist = new histogram_dll.UserControl1();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Tags = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_Tags = new System.Windows.Forms.ListView();
            this.ch_Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_numOfNum = new System.Windows.Forms.Label();
            this.btn_Copy = new FontAwesome.Sharp.IconButton();
            this.btn_Save = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Prev
            // 
            this.btn_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Prev.Enabled = false;
            this.btn_Prev.Icon = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btn_Prev.IconColor = System.Drawing.Color.Black;
            this.btn_Prev.IconSize = 28;
            this.btn_Prev.Image = ((System.Drawing.Image)(resources.GetObject("btn_Prev.Image")));
            this.btn_Prev.Location = new System.Drawing.Point(826, 550);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(30, 30);
            this.btn_Prev.TabIndex = 1;
            this.btn_Prev.TabStop = false;
            this.btn_Prev.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            this.btn_Prev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Prev.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Next.Enabled = false;
            this.btn_Next.Icon = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btn_Next.IconColor = System.Drawing.Color.Black;
            this.btn_Next.IconSize = 28;
            this.btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("btn_Next.Image")));
            this.btn_Next.Location = new System.Drawing.Point(861, 550);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(30, 30);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.TabStop = false;
            this.btn_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            this.btn_Next.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Next.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Search.Enabled = false;
            this.btn_Search.Icon = FontAwesome.Sharp.IconChar.Search;
            this.btn_Search.IconColor = System.Drawing.Color.Black;
            this.btn_Search.IconSize = 18;
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.Location = new System.Drawing.Point(12, 553);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            this.btn_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Search.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Data);
            this.splitContainer1.Panel1.Controls.Add(this.pb_Img);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(902, 547);
            this.splitContainer1.SplitterDistance = 632;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 4;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.splitContainer1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // btn_Data
            // 
            this.btn_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Data.BackColor = System.Drawing.Color.Black;
            this.btn_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Data.Icon = FontAwesome.Sharp.IconChar.Bars;
            this.btn_Data.IconColor = System.Drawing.Color.White;
            this.btn_Data.IconSize = 28;
            this.btn_Data.Image = ((System.Drawing.Image)(resources.GetObject("btn_Data.Image")));
            this.btn_Data.Location = new System.Drawing.Point(609, 0);
            this.btn_Data.Name = "btn_Data";
            this.btn_Data.Size = new System.Drawing.Size(24, 24);
            this.btn_Data.TabIndex = 2;
            this.btn_Data.TabStop = false;
            this.btn_Data.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Data.UseVisualStyleBackColor = false;
            this.btn_Data.Click += new System.EventHandler(this.btn_Data_Click);
            this.btn_Data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Data.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // pb_Img
            // 
            this.pb_Img.BackColor = System.Drawing.Color.Black;
            this.pb_Img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Img.Location = new System.Drawing.Point(0, 0);
            this.pb_Img.Name = "pb_Img";
            this.pb_Img.Size = new System.Drawing.Size(632, 547);
            this.pb_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Img.TabIndex = 0;
            this.pb_Img.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.h_Hist);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Desc);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Title);
            this.splitContainer2.Panel1.Controls.Add(this.btn_Tags);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lv_Tags);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(260, 547);
            this.splitContainer2.SplitterDistance = 421;
            this.splitContainer2.TabIndex = 0;
            // 
            // h_Hist
            // 
            this.h_Hist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.h_Hist.backgroundColor = System.Drawing.Color.Transparent;
            this.h_Hist.borderColor = System.Drawing.Color.White;
            this.h_Hist.Color_a = System.Drawing.Color.Black;
            this.h_Hist.Color_b = System.Drawing.Color.Blue;
            this.h_Hist.Color_g = System.Drawing.Color.Green;
            this.h_Hist.Color_r = System.Drawing.Color.Red;
            this.h_Hist.hideButtons = false;
            this.h_Hist.Location = new System.Drawing.Point(0, 0);
            this.h_Hist.Name = "h_Hist";
            this.h_Hist.showLegends = false;
            this.h_Hist.Size = new System.Drawing.Size(257, 439);
            this.h_Hist.startOn = 0;
            this.h_Hist.TabIndex = 14;
            this.h_Hist.TabStop = false;
            this.h_Hist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.h_Hist.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Desc.Location = new System.Drawing.Point(77, 471);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(178, 76);
            this.lbl_Desc.TabIndex = 12;
            this.lbl_Desc.Text = "Description";
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Title.Location = new System.Drawing.Point(76, 442);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(36, 20);
            this.lbl_Title.TabIndex = 11;
            this.lbl_Title.Text = "Title";
            // 
            // btn_Tags
            // 
            this.btn_Tags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Tags.Icon = FontAwesome.Sharp.IconChar.Eye;
            this.btn_Tags.IconColor = System.Drawing.Color.Black;
            this.btn_Tags.IconSize = 18;
            this.btn_Tags.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tags.Image")));
            this.btn_Tags.Location = new System.Drawing.Point(4, 524);
            this.btn_Tags.Name = "btn_Tags";
            this.btn_Tags.Size = new System.Drawing.Size(63, 23);
            this.btn_Tags.TabIndex = 10;
            this.btn_Tags.TabStop = false;
            this.btn_Tags.Text = "Tags";
            this.btn_Tags.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Tags.UseVisualStyleBackColor = true;
            this.btn_Tags.Click += new System.EventHandler(this.btn_Tags_Click);
            this.btn_Tags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Tags.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Description: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title: ";
            // 
            // lv_Tags
            // 
            this.lv_Tags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Tags});
            this.lv_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Tags.Location = new System.Drawing.Point(0, 0);
            this.lv_Tags.Name = "lv_Tags";
            this.lv_Tags.Size = new System.Drawing.Size(150, 46);
            this.lv_Tags.TabIndex = 0;
            this.lv_Tags.UseCompatibleStateImageBehavior = false;
            this.lv_Tags.View = System.Windows.Forms.View.List;
            // 
            // ch_Tags
            // 
            this.ch_Tags.Text = "Tags";
            this.ch_Tags.Width = 283;
            // 
            // lbl_numOfNum
            // 
            this.lbl_numOfNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_numOfNum.Location = new System.Drawing.Point(680, 553);
            this.lbl_numOfNum.Name = "lbl_numOfNum";
            this.lbl_numOfNum.Size = new System.Drawing.Size(140, 23);
            this.lbl_numOfNum.TabIndex = 5;
            this.lbl_numOfNum.Text = "0 of 0";
            this.lbl_numOfNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Copy.Enabled = false;
            this.btn_Copy.Icon = FontAwesome.Sharp.IconChar.Clipboard;
            this.btn_Copy.IconColor = System.Drawing.Color.Black;
            this.btn_Copy.IconSize = 18;
            this.btn_Copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_Copy.Image")));
            this.btn_Copy.Location = new System.Drawing.Point(115, 553);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(67, 23);
            this.btn_Copy.TabIndex = 6;
            this.btn_Copy.TabStop = false;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            this.btn_Copy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Copy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Save.Enabled = false;
            this.btn_Save.Icon = FontAwesome.Sharp.IconChar.FloppyO;
            this.btn_Save.IconColor = System.Drawing.Color.Black;
            this.btn_Save.IconSize = 18;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(188, 553);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(67, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.TabStop = false;
            this.btn_Save.Text = "Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            this.btn_Save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.btn_Save.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            // 
            // f_LoadImageDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 581);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lbl_numOfNum);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Prev);
            this.Name = "f_LoadImageDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load image from Database";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_LoadImageDB_KeyDown_1);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.f_LoadImageDB_PreviewKeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private FontAwesome.Sharp.IconButton btn_Prev;
		private FontAwesome.Sharp.IconButton btn_Next;
		private FontAwesome.Sharp.IconButton btn_Search;
		private System.Windows.Forms.SplitContainer splitContainer1;
		//private histogram_dll.UserControl1 uc_Histogram;
		private System.Windows.Forms.PictureBox pb_Img;
        private System.Windows.Forms.Label lbl_numOfNum;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Label lbl_Title;
        private FontAwesome.Sharp.IconButton btn_Tags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_Tags;
        private System.Windows.Forms.ColumnHeader ch_Tags;
        private FontAwesome.Sharp.IconButton btn_Copy;
        private FontAwesome.Sharp.IconButton btn_Save;
        private FontAwesome.Sharp.IconButton btn_Data;
		private histogram_dll.UserControl1 h_Hist;
	}
}
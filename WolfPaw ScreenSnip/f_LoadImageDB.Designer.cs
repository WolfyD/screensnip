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
			this.lbl_Desc = new System.Windows.Forms.Label();
			this.lbl_Title = new System.Windows.Forms.Label();
			this.iconButton1 = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.uc_Histogram = new histogram_dll.UserControl1();
			this.pb_Img = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_Img)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_Prev
			// 
			this.btn_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Prev.Icon = FontAwesome.Sharp.IconChar.ArrowLeft;
			this.btn_Prev.IconColor = System.Drawing.Color.Black;
			this.btn_Prev.IconSize = 28;
			this.btn_Prev.Image = ((System.Drawing.Image)(resources.GetObject("btn_Prev.Image")));
			this.btn_Prev.Location = new System.Drawing.Point(826, 550);
			this.btn_Prev.Name = "btn_Prev";
			this.btn_Prev.Size = new System.Drawing.Size(30, 30);
			this.btn_Prev.TabIndex = 1;
			this.btn_Prev.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_Prev.UseVisualStyleBackColor = true;
			// 
			// btn_Next
			// 
			this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Next.Icon = FontAwesome.Sharp.IconChar.ArrowRight;
			this.btn_Next.IconColor = System.Drawing.Color.Black;
			this.btn_Next.IconSize = 28;
			this.btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("btn_Next.Image")));
			this.btn_Next.Location = new System.Drawing.Point(861, 550);
			this.btn_Next.Name = "btn_Next";
			this.btn_Next.Size = new System.Drawing.Size(30, 30);
			this.btn_Next.TabIndex = 2;
			this.btn_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_Next.UseVisualStyleBackColor = true;
			// 
			// btn_Search
			// 
			this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Search.Icon = FontAwesome.Sharp.IconChar.Search;
			this.btn_Search.IconColor = System.Drawing.Color.Black;
			this.btn_Search.IconSize = 18;
			this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
			this.btn_Search.Location = new System.Drawing.Point(12, 553);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(75, 23);
			this.btn_Search.TabIndex = 3;
			this.btn_Search.Text = "Search";
			this.btn_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_Search.UseVisualStyleBackColor = true;
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
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
			this.splitContainer1.Panel1.Controls.Add(this.pb_Img);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lbl_Desc);
			this.splitContainer1.Panel2.Controls.Add(this.lbl_Title);
			this.splitContainer1.Panel2.Controls.Add(this.iconButton1);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.uc_Histogram);
			this.splitContainer1.Size = new System.Drawing.Size(902, 547);
			this.splitContainer1.SplitterDistance = 609;
			this.splitContainer1.TabIndex = 4;
			// 
			// lbl_Desc
			// 
			this.lbl_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_Desc.Location = new System.Drawing.Point(79, 466);
			this.lbl_Desc.Name = "lbl_Desc";
			this.lbl_Desc.Size = new System.Drawing.Size(207, 76);
			this.lbl_Desc.TabIndex = 6;
			this.lbl_Desc.Text = "Description";
			// 
			// lbl_Title
			// 
			this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbl_Title.AutoSize = true;
			this.lbl_Title.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Title.Location = new System.Drawing.Point(78, 437);
			this.lbl_Title.Name = "lbl_Title";
			this.lbl_Title.Size = new System.Drawing.Size(36, 20);
			this.lbl_Title.TabIndex = 5;
			this.lbl_Title.Text = "Title";
			// 
			// iconButton1
			// 
			this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.iconButton1.Icon = FontAwesome.Sharp.IconChar.Eye;
			this.iconButton1.IconColor = System.Drawing.Color.Black;
			this.iconButton1.IconSize = 18;
			this.iconButton1.Image = ((System.Drawing.Image)(resources.GetObject("iconButton1.Image")));
			this.iconButton1.Location = new System.Drawing.Point(6, 519);
			this.iconButton1.Name = "iconButton1";
			this.iconButton1.Size = new System.Drawing.Size(63, 23);
			this.iconButton1.TabIndex = 4;
			this.iconButton1.Text = "Tags";
			this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.iconButton1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 466);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description: ";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 442);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title: ";
			// 
			// uc_Histogram
			// 
			this.uc_Histogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uc_Histogram.backgroundColor = System.Drawing.Color.White;
			this.uc_Histogram.borderColor = System.Drawing.Color.White;
			this.uc_Histogram.Color_a = System.Drawing.Color.Black;
			this.uc_Histogram.Color_b = System.Drawing.Color.Blue;
			this.uc_Histogram.Color_g = System.Drawing.Color.Green;
			this.uc_Histogram.Color_r = System.Drawing.Color.Red;
			this.uc_Histogram.hideButtons = false;
			this.uc_Histogram.Location = new System.Drawing.Point(3, 3);
			this.uc_Histogram.Name = "uc_Histogram";
			this.uc_Histogram.showLegends = false;
			this.uc_Histogram.Size = new System.Drawing.Size(283, 428);
			this.uc_Histogram.startOn = 0;
			this.uc_Histogram.TabIndex = 0;
			// 
			// pb_Img
			// 
			this.pb_Img.BackColor = System.Drawing.Color.Black;
			this.pb_Img.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb_Img.Location = new System.Drawing.Point(0, 0);
			this.pb_Img.Name = "pb_Img";
			this.pb_Img.Size = new System.Drawing.Size(609, 547);
			this.pb_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_Img.TabIndex = 0;
			this.pb_Img.TabStop = false;
			// 
			// f_LoadImageDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 581);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btn_Search);
			this.Controls.Add(this.btn_Next);
			this.Controls.Add(this.btn_Prev);
			this.Name = "f_LoadImageDB";
			this.Text = "Load image from Database";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_Img)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private FontAwesome.Sharp.IconButton btn_Prev;
		private FontAwesome.Sharp.IconButton btn_Next;
		private FontAwesome.Sharp.IconButton btn_Search;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label lbl_Desc;
		private System.Windows.Forms.Label lbl_Title;
		private FontAwesome.Sharp.IconButton iconButton1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private histogram_dll.UserControl1 uc_Histogram;
		private System.Windows.Forms.PictureBox pb_Img;
	}
}
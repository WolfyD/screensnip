namespace WolfPaw_ScreenSnip
{
	partial class f_SearchBy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_SearchBy));
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rb_Title = new System.Windows.Forms.RadioButton();
            this.rb_Description = new System.Windows.Forms.RadioButton();
            this.rb_Tags = new System.Windows.Forms.RadioButton();
            this.rb_Date = new System.Windows.Forms.RadioButton();
            this.rb_All = new System.Windows.Forms.RadioButton();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.tb_Tags = new System.Windows.Forms.TextBox();
            this.tb_Date = new System.Windows.Forms.TextBox();
            this.cb_Title = new System.Windows.Forms.CheckBox();
            this.cb_Description = new System.Windows.Forms.CheckBox();
            this.btn_EditTags = new FontAwesome.Sharp.IconButton();
            this.btn_EditDate = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.Location = new System.Drawing.Point(12, 127);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(179, 23);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(197, 127);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rb_Title
            // 
            this.rb_Title.AutoSize = true;
            this.rb_Title.Location = new System.Drawing.Point(12, 12);
            this.rb_Title.Name = "rb_Title";
            this.rb_Title.Size = new System.Drawing.Size(45, 17);
            this.rb_Title.TabIndex = 2;
            this.rb_Title.TabStop = true;
            this.rb_Title.Text = "Title";
            this.rb_Title.UseVisualStyleBackColor = true;
            // 
            // rb_Description
            // 
            this.rb_Description.AutoSize = true;
            this.rb_Description.Location = new System.Drawing.Point(12, 35);
            this.rb_Description.Name = "rb_Description";
            this.rb_Description.Size = new System.Drawing.Size(78, 17);
            this.rb_Description.TabIndex = 3;
            this.rb_Description.TabStop = true;
            this.rb_Description.Text = "Description";
            this.rb_Description.UseVisualStyleBackColor = true;
            // 
            // rb_Tags
            // 
            this.rb_Tags.AutoSize = true;
            this.rb_Tags.Location = new System.Drawing.Point(12, 58);
            this.rb_Tags.Name = "rb_Tags";
            this.rb_Tags.Size = new System.Drawing.Size(49, 17);
            this.rb_Tags.TabIndex = 4;
            this.rb_Tags.TabStop = true;
            this.rb_Tags.Text = "Tags";
            this.rb_Tags.UseVisualStyleBackColor = true;
            // 
            // rb_Date
            // 
            this.rb_Date.AutoSize = true;
            this.rb_Date.Location = new System.Drawing.Point(12, 81);
            this.rb_Date.Name = "rb_Date";
            this.rb_Date.Size = new System.Drawing.Size(48, 17);
            this.rb_Date.TabIndex = 5;
            this.rb_Date.TabStop = true;
            this.rb_Date.Text = "Date";
            this.rb_Date.UseVisualStyleBackColor = true;
            // 
            // rb_All
            // 
            this.rb_All.AutoSize = true;
            this.rb_All.Location = new System.Drawing.Point(12, 104);
            this.rb_All.Name = "rb_All";
            this.rb_All.Size = new System.Drawing.Size(36, 17);
            this.rb_All.TabIndex = 6;
            this.rb_All.TabStop = true;
            this.rb_All.Text = "All";
            this.rb_All.UseVisualStyleBackColor = true;
            // 
            // tb_Title
            // 
            this.tb_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Title.Location = new System.Drawing.Point(106, 11);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(125, 20);
            this.tb_Title.TabIndex = 7;
            this.tb_Title.Click += new System.EventHandler(this.tb_Title_Click);
            // 
            // tb_Description
            // 
            this.tb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Description.Location = new System.Drawing.Point(106, 34);
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(125, 20);
            this.tb_Description.TabIndex = 8;
            this.tb_Description.Click += new System.EventHandler(this.tb_Description_Click);
            // 
            // tb_Tags
            // 
            this.tb_Tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Tags.Location = new System.Drawing.Point(106, 57);
            this.tb_Tags.Name = "tb_Tags";
            this.tb_Tags.Size = new System.Drawing.Size(125, 20);
            this.tb_Tags.TabIndex = 9;
            this.tb_Tags.Click += new System.EventHandler(this.tb_Tags_Click);
            // 
            // tb_Date
            // 
            this.tb_Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Date.Location = new System.Drawing.Point(106, 80);
            this.tb_Date.Name = "tb_Date";
            this.tb_Date.Size = new System.Drawing.Size(125, 20);
            this.tb_Date.TabIndex = 10;
            this.tb_Date.Click += new System.EventHandler(this.tb_Date_Click);
            // 
            // cb_Title
            // 
            this.cb_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Title.AutoSize = true;
            this.cb_Title.Checked = true;
            this.cb_Title.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Title.Location = new System.Drawing.Point(237, 13);
            this.cb_Title.Name = "cb_Title";
            this.cb_Title.Size = new System.Drawing.Size(46, 17);
            this.cb_Title.TabIndex = 11;
            this.cb_Title.Text = "Like";
            this.cb_Title.UseVisualStyleBackColor = true;
            // 
            // cb_Description
            // 
            this.cb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Description.AutoSize = true;
            this.cb_Description.Checked = true;
            this.cb_Description.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Description.Location = new System.Drawing.Point(237, 36);
            this.cb_Description.Name = "cb_Description";
            this.cb_Description.Size = new System.Drawing.Size(46, 17);
            this.cb_Description.TabIndex = 12;
            this.cb_Description.Text = "Like";
            this.cb_Description.UseVisualStyleBackColor = true;
            // 
            // btn_EditTags
            // 
            this.btn_EditTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditTags.FlatAppearance.BorderSize = 0;
            this.btn_EditTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditTags.Icon = FontAwesome.Sharp.IconChar.Eye;
            this.btn_EditTags.IconColor = System.Drawing.Color.Black;
            this.btn_EditTags.IconSize = 22;
            this.btn_EditTags.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditTags.Image")));
            this.btn_EditTags.Location = new System.Drawing.Point(237, 55);
            this.btn_EditTags.Name = "btn_EditTags";
            this.btn_EditTags.Size = new System.Drawing.Size(31, 23);
            this.btn_EditTags.TabIndex = 13;
            this.btn_EditTags.UseVisualStyleBackColor = true;
            // 
            // btn_EditDate
            // 
            this.btn_EditDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditDate.FlatAppearance.BorderSize = 0;
            this.btn_EditDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditDate.Icon = FontAwesome.Sharp.IconChar.CalendarO;
            this.btn_EditDate.IconColor = System.Drawing.Color.Black;
            this.btn_EditDate.IconSize = 22;
            this.btn_EditDate.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditDate.Image")));
            this.btn_EditDate.Location = new System.Drawing.Point(237, 78);
            this.btn_EditDate.Name = "btn_EditDate";
            this.btn_EditDate.Size = new System.Drawing.Size(31, 23);
            this.btn_EditDate.TabIndex = 14;
            this.btn_EditDate.UseVisualStyleBackColor = true;
            // 
            // f_SearchBy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.ControlBox = false;
            this.Controls.Add(this.btn_EditDate);
            this.Controls.Add(this.btn_EditTags);
            this.Controls.Add(this.cb_Description);
            this.Controls.Add(this.cb_Title);
            this.Controls.Add(this.tb_Date);
            this.Controls.Add(this.tb_Tags);
            this.Controls.Add(this.tb_Description);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.rb_All);
            this.Controls.Add(this.rb_Date);
            this.Controls.Add(this.rb_Tags);
            this.Controls.Add(this.rb_Description);
            this.Controls.Add(this.rb_Title);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 199);
            this.MinimumSize = new System.Drawing.Size(300, 199);
            this.Name = "f_SearchBy";
            this.Text = "Search By";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.RadioButton rb_Title;
		private System.Windows.Forms.RadioButton rb_Description;
		private System.Windows.Forms.RadioButton rb_Tags;
		private System.Windows.Forms.RadioButton rb_Date;
		private System.Windows.Forms.RadioButton rb_All;
		private System.Windows.Forms.TextBox tb_Title;
		private System.Windows.Forms.TextBox tb_Description;
		private System.Windows.Forms.TextBox tb_Tags;
		private System.Windows.Forms.TextBox tb_Date;
		private System.Windows.Forms.CheckBox cb_Title;
		private System.Windows.Forms.CheckBox cb_Description;
		private FontAwesome.Sharp.IconButton btn_EditTags;
		private FontAwesome.Sharp.IconButton btn_EditDate;
	}
}
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.p_date = new System.Windows.Forms.Panel();
			this.btn_date_Close = new FontAwesome.Sharp.IconButton();
			this.lbl_Dates = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp_to = new System.Windows.Forms.DateTimePicker();
			this.dtp_from = new System.Windows.Forms.DateTimePicker();
			this.btn_Help = new FontAwesome.Sharp.IconButton();
			this.label4 = new System.Windows.Forms.Label();
			this.cb_Tables = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.p_date.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Search
			// 
			this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Search.Location = new System.Drawing.Point(3, 3);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(193, 23);
			this.btn_Search.TabIndex = 0;
			this.btn_Search.Text = "Search";
			this.btn_Search.UseVisualStyleBackColor = true;
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.Location = new System.Drawing.Point(220, 3);
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
			this.btn_EditTags.Click += new System.EventHandler(this.btn_EditTags_Click);
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
			this.btn_EditDate.Click += new System.EventHandler(this.btn_EditDate_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btn_Search);
			this.panel1.Controls.Add(this.btn_Cancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 152);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(298, 29);
			this.panel1.TabIndex = 15;
			// 
			// p_date
			// 
			this.p_date.Controls.Add(this.btn_date_Close);
			this.p_date.Controls.Add(this.lbl_Dates);
			this.p_date.Controls.Add(this.label3);
			this.p_date.Controls.Add(this.label2);
			this.p_date.Controls.Add(this.label1);
			this.p_date.Controls.Add(this.dtp_to);
			this.p_date.Controls.Add(this.dtp_from);
			this.p_date.Location = new System.Drawing.Point(0, 0);
			this.p_date.Name = "p_date";
			this.p_date.Size = new System.Drawing.Size(40, 10);
			this.p_date.TabIndex = 16;
			this.p_date.Visible = false;
			// 
			// btn_date_Close
			// 
			this.btn_date_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_date_Close.Icon = FontAwesome.Sharp.IconChar.Check;
			this.btn_date_Close.IconColor = System.Drawing.Color.Black;
			this.btn_date_Close.IconSize = 28;
			this.btn_date_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_date_Close.Image")));
			this.btn_date_Close.Location = new System.Drawing.Point(84, 92);
			this.btn_date_Close.Name = "btn_date_Close";
			this.btn_date_Close.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
			this.btn_date_Close.Size = new System.Drawing.Size(131, 29);
			this.btn_date_Close.TabIndex = 7;
			this.btn_date_Close.Text = "Close";
			this.btn_date_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_date_Close.UseVisualStyleBackColor = true;
			this.btn_date_Close.Click += new System.EventHandler(this.btn_date_Close_Click);
			// 
			// lbl_Dates
			// 
			this.lbl_Dates.AutoSize = true;
			this.lbl_Dates.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Dates.Location = new System.Drawing.Point(101, 62);
			this.lbl_Dates.Name = "lbl_Dates";
			this.lbl_Dates.Size = new System.Drawing.Size(176, 18);
			this.lbl_Dates.TabIndex = 6;
			this.lbl_Dates.Text = "0000/00/00|0000/00/00";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Selected Dates: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "To: ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "From: ";
			// 
			// dtp_to
			// 
			this.dtp_to.Location = new System.Drawing.Point(51, 35);
			this.dtp_to.Name = "dtp_to";
			this.dtp_to.Size = new System.Drawing.Size(235, 20);
			this.dtp_to.TabIndex = 1;
			this.dtp_to.ValueChanged += new System.EventHandler(this.dtp_to_ValueChanged);
			// 
			// dtp_from
			// 
			this.dtp_from.Location = new System.Drawing.Point(51, 8);
			this.dtp_from.Name = "dtp_from";
			this.dtp_from.Size = new System.Drawing.Size(235, 20);
			this.dtp_from.TabIndex = 0;
			this.dtp_from.ValueChanged += new System.EventHandler(this.dtp_from_ValueChanged);
			// 
			// btn_Help
			// 
			this.btn_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Help.Icon = FontAwesome.Sharp.IconChar.QuestionCircle;
			this.btn_Help.IconColor = System.Drawing.Color.Black;
			this.btn_Help.IconSize = 21;
			this.btn_Help.Image = ((System.Drawing.Image)(resources.GetObject("btn_Help.Image")));
			this.btn_Help.Location = new System.Drawing.Point(275, 128);
			this.btn_Help.Name = "btn_Help";
			this.btn_Help.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
			this.btn_Help.Size = new System.Drawing.Size(23, 23);
			this.btn_Help.TabIndex = 17;
			this.btn_Help.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Table: ";
			// 
			// cb_Tables
			// 
			this.cb_Tables.FormattingEnabled = true;
			this.cb_Tables.Location = new System.Drawing.Point(106, 128);
			this.cb_Tables.Name = "cb_Tables";
			this.cb_Tables.Size = new System.Drawing.Size(125, 21);
			this.cb_Tables.TabIndex = 19;
			// 
			// f_SearchBy
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(298, 181);
			this.ControlBox = false;
			this.Controls.Add(this.cb_Tables);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btn_Help);
			this.Controls.Add(this.p_date);
			this.Controls.Add(this.panel1);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1000, 220);
			this.MinimumSize = new System.Drawing.Size(300, 220);
			this.Name = "f_SearchBy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search By";
			this.panel1.ResumeLayout(false);
			this.p_date.ResumeLayout(false);
			this.p_date.PerformLayout();
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
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel p_date;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label lbl_Dates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btn_date_Close;
        private FontAwesome.Sharp.IconButton btn_Help;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cb_Tables;
	}
}
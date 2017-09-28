namespace WolfPaw_ScreenSnip
{
    partial class f_SaveToDB
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_SaveToDB));
			this.pb_Pic = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_Title = new System.Windows.Forms.TextBox();
			this.tb_Description = new System.Windows.Forms.TextBox();
			this.cb_Tags = new System.Windows.Forms.ComboBox();
			this.btn_Add = new System.Windows.Forms.Button();
			this.lv_Tags = new System.Windows.Forms.ListView();
			this.ch_Tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_Top = new FontAwesome.Sharp.IconButton();
			this.btn_Up = new FontAwesome.Sharp.IconButton();
			this.btn_Delete = new FontAwesome.Sharp.IconButton();
			this.btn_Down = new FontAwesome.Sharp.IconButton();
			this.btn_Bottom = new FontAwesome.Sharp.IconButton();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_DB = new FontAwesome.Sharp.IconButton();
			this.lbl_DBFile = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_Pic
			// 
			this.pb_Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb_Pic.Location = new System.Drawing.Point(375, 6);
			this.pb_Pic.Name = "pb_Pic";
			this.pb_Pic.Size = new System.Drawing.Size(203, 176);
			this.pb_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_Pic.TabIndex = 0;
			this.pb_Pic.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(372, 187);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Resolution:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Image Title: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Description: ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Tags: ";
			// 
			// tb_Title
			// 
			this.tb_Title.Location = new System.Drawing.Point(86, 6);
			this.tb_Title.Name = "tb_Title";
			this.tb_Title.Size = new System.Drawing.Size(268, 20);
			this.tb_Title.TabIndex = 5;
			// 
			// tb_Description
			// 
			this.tb_Description.Location = new System.Drawing.Point(86, 36);
			this.tb_Description.Name = "tb_Description";
			this.tb_Description.Size = new System.Drawing.Size(268, 20);
			this.tb_Description.TabIndex = 6;
			// 
			// cb_Tags
			// 
			this.cb_Tags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cb_Tags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cb_Tags.FormattingEnabled = true;
			this.cb_Tags.Location = new System.Drawing.Point(86, 66);
			this.cb_Tags.Name = "cb_Tags";
			this.cb_Tags.Size = new System.Drawing.Size(185, 21);
			this.cb_Tags.TabIndex = 7;
			this.cb_Tags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_Tags_KeyDown);
			// 
			// btn_Add
			// 
			this.btn_Add.Location = new System.Drawing.Point(279, 66);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 21);
			this.btn_Add.TabIndex = 8;
			this.btn_Add.Text = "ADD";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// lv_Tags
			// 
			this.lv_Tags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Tag});
			this.lv_Tags.FullRowSelect = true;
			this.lv_Tags.GridLines = true;
			this.lv_Tags.HideSelection = false;
			this.lv_Tags.Location = new System.Drawing.Point(86, 94);
			this.lv_Tags.MultiSelect = false;
			this.lv_Tags.Name = "lv_Tags";
			this.lv_Tags.ShowGroups = false;
			this.lv_Tags.Size = new System.Drawing.Size(240, 110);
			this.lv_Tags.TabIndex = 9;
			this.lv_Tags.UseCompatibleStateImageBehavior = false;
			this.lv_Tags.View = System.Windows.Forms.View.Details;
			// 
			// ch_Tag
			// 
			this.ch_Tag.Text = "Tag";
			this.ch_Tag.Width = 236;
			// 
			// btn_Top
			// 
			this.btn_Top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_Top.FlatAppearance.BorderSize = 0;
			this.btn_Top.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Top.Icon = FontAwesome.Sharp.IconChar.AngleDoubleUp;
			this.btn_Top.IconColor = System.Drawing.Color.Black;
			this.btn_Top.IconSize = 22;
			this.btn_Top.Image = ((System.Drawing.Image)(resources.GetObject("btn_Top.Image")));
			this.btn_Top.Location = new System.Drawing.Point(332, 94);
			this.btn_Top.Name = "btn_Top";
			this.btn_Top.Size = new System.Drawing.Size(22, 22);
			this.btn_Top.TabIndex = 15;
			this.btn_Top.UseVisualStyleBackColor = true;
			this.btn_Top.Click += new System.EventHandler(this.btn_Top_Click);
			// 
			// btn_Up
			// 
			this.btn_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_Up.FlatAppearance.BorderSize = 0;
			this.btn_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Up.Icon = FontAwesome.Sharp.IconChar.AngleUp;
			this.btn_Up.IconColor = System.Drawing.Color.Black;
			this.btn_Up.IconSize = 22;
			this.btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up.Image")));
			this.btn_Up.Location = new System.Drawing.Point(332, 116);
			this.btn_Up.Name = "btn_Up";
			this.btn_Up.Size = new System.Drawing.Size(22, 22);
			this.btn_Up.TabIndex = 16;
			this.btn_Up.UseVisualStyleBackColor = true;
			this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
			// 
			// btn_Delete
			// 
			this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_Delete.FlatAppearance.BorderSize = 0;
			this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Delete.ForeColor = System.Drawing.Color.Red;
			this.btn_Delete.Icon = FontAwesome.Sharp.IconChar.Ban;
			this.btn_Delete.IconColor = System.Drawing.Color.Red;
			this.btn_Delete.IconSize = 22;
			this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
			this.btn_Delete.Location = new System.Drawing.Point(332, 138);
			this.btn_Delete.Name = "btn_Delete";
			this.btn_Delete.Size = new System.Drawing.Size(22, 22);
			this.btn_Delete.TabIndex = 17;
			this.btn_Delete.UseVisualStyleBackColor = true;
			this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
			// 
			// btn_Down
			// 
			this.btn_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_Down.FlatAppearance.BorderSize = 0;
			this.btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Down.Icon = FontAwesome.Sharp.IconChar.AngleDown;
			this.btn_Down.IconColor = System.Drawing.Color.Black;
			this.btn_Down.IconSize = 22;
			this.btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down.Image")));
			this.btn_Down.Location = new System.Drawing.Point(332, 160);
			this.btn_Down.Name = "btn_Down";
			this.btn_Down.Size = new System.Drawing.Size(22, 22);
			this.btn_Down.TabIndex = 18;
			this.btn_Down.UseVisualStyleBackColor = true;
			this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
			// 
			// btn_Bottom
			// 
			this.btn_Bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_Bottom.FlatAppearance.BorderSize = 0;
			this.btn_Bottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Bottom.Icon = FontAwesome.Sharp.IconChar.AngleDoubleDown;
			this.btn_Bottom.IconColor = System.Drawing.Color.Black;
			this.btn_Bottom.IconSize = 22;
			this.btn_Bottom.Image = ((System.Drawing.Image)(resources.GetObject("btn_Bottom.Image")));
			this.btn_Bottom.Location = new System.Drawing.Point(332, 182);
			this.btn_Bottom.Name = "btn_Bottom";
			this.btn_Bottom.Size = new System.Drawing.Size(22, 22);
			this.btn_Bottom.TabIndex = 19;
			this.btn_Bottom.UseVisualStyleBackColor = true;
			this.btn_Bottom.Click += new System.EventHandler(this.btn_Bottom_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(375, 218);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(96, 23);
			this.btn_Cancel.TabIndex = 20;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(482, 218);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(96, 23);
			this.btn_Save.TabIndex = 21;
			this.btn_Save.Text = "Save";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_DB
			// 
			this.btn_DB.Icon = FontAwesome.Sharp.IconChar.Database;
			this.btn_DB.IconColor = System.Drawing.Color.DimGray;
			this.btn_DB.IconSize = 20;
			this.btn_DB.Image = ((System.Drawing.Image)(resources.GetObject("btn_DB.Image")));
			this.btn_DB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_DB.Location = new System.Drawing.Point(9, 211);
			this.btn_DB.Name = "btn_DB";
			this.btn_DB.Size = new System.Drawing.Size(69, 30);
			this.btn_DB.TabIndex = 22;
			this.btn_DB.Text = "DB File";
			this.btn_DB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_DB.UseVisualStyleBackColor = true;
			this.btn_DB.Click += new System.EventHandler(this.btn_DB_Click);
			// 
			// lbl_DBFile
			// 
			this.lbl_DBFile.AutoEllipsis = true;
			this.lbl_DBFile.Location = new System.Drawing.Point(83, 219);
			this.lbl_DBFile.Name = "lbl_DBFile";
			this.lbl_DBFile.Size = new System.Drawing.Size(243, 15);
			this.lbl_DBFile.TabIndex = 23;
			this.lbl_DBFile.Text = "C:\\DBFile.sqlite";
			this.lbl_DBFile.UseCompatibleTextRendering = true;
			// 
			// f_SaveToDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(585, 248);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.lbl_DBFile);
			this.Controls.Add(this.btn_DB);
			this.Controls.Add(this.btn_Bottom);
			this.Controls.Add(this.btn_Down);
			this.Controls.Add(this.btn_Delete);
			this.Controls.Add(this.btn_Up);
			this.Controls.Add(this.btn_Top);
			this.Controls.Add(this.lv_Tags);
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.cb_Tags);
			this.Controls.Add(this.tb_Description);
			this.Controls.Add(this.tb_Title);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pb_Pic);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_SaveToDB";
			this.Text = "Save image to DB";
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Pic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.ComboBox cb_Tags;
        private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.ListView lv_Tags;
		private System.Windows.Forms.ColumnHeader ch_Tag;
		private FontAwesome.Sharp.IconButton btn_Top;
		private FontAwesome.Sharp.IconButton btn_Up;
		private FontAwesome.Sharp.IconButton btn_Delete;
		private FontAwesome.Sharp.IconButton btn_Down;
		private FontAwesome.Sharp.IconButton btn_Bottom;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Save;
		private FontAwesome.Sharp.IconButton btn_DB;
		private System.Windows.Forms.Label lbl_DBFile;
	}
}
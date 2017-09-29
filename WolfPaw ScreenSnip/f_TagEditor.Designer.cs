namespace WolfPaw_ScreenSnip
{
	partial class f_TagEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_TagEditor));
			this.lv_Tags = new System.Windows.Forms.ListView();
			this.btn_Close = new FontAwesome.Sharp.IconButton();
			this.cb_Tag = new System.Windows.Forms.ComboBox();
			this.btn_Add = new FontAwesome.Sharp.IconButton();
			this.ch_Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cms_Tags = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.btn_RemoveTag = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_ClearAllTags = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_Tags.SuspendLayout();
			this.SuspendLayout();
			// 
			// lv_Tags
			// 
			this.lv_Tags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Tags});
			this.lv_Tags.FullRowSelect = true;
			this.lv_Tags.GridLines = true;
			this.lv_Tags.Location = new System.Drawing.Point(1, 39);
			this.lv_Tags.Name = "lv_Tags";
			this.lv_Tags.Size = new System.Drawing.Size(169, 103);
			this.lv_Tags.TabIndex = 0;
			this.lv_Tags.UseCompatibleStateImageBehavior = false;
			this.lv_Tags.View = System.Windows.Forms.View.Details;
			// 
			// btn_Close
			// 
			this.btn_Close.Icon = FontAwesome.Sharp.IconChar.Times;
			this.btn_Close.IconColor = System.Drawing.Color.Black;
			this.btn_Close.IconSize = 16;
			this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
			this.btn_Close.Location = new System.Drawing.Point(171, 119);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(68, 23);
			this.btn_Close.TabIndex = 1;
			this.btn_Close.Text = "Close";
			this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// cb_Tag
			// 
			this.cb_Tag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cb_Tag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cb_Tag.FormattingEnabled = true;
			this.cb_Tag.Location = new System.Drawing.Point(1, 12);
			this.cb_Tag.Name = "cb_Tag";
			this.cb_Tag.Size = new System.Drawing.Size(107, 21);
			this.cb_Tag.TabIndex = 2;
			// 
			// btn_Add
			// 
			this.btn_Add.Icon = FontAwesome.Sharp.IconChar.Plus;
			this.btn_Add.IconColor = System.Drawing.Color.Black;
			this.btn_Add.IconSize = 16;
			this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
			this.btn_Add.Location = new System.Drawing.Point(114, 12);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(56, 21);
			this.btn_Add.TabIndex = 3;
			this.btn_Add.Text = "Add";
			this.btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// ch_Tags
			// 
			this.ch_Tags.Text = "Tags";
			this.ch_Tags.Width = 163;
			// 
			// cms_Tags
			// 
			this.cms_Tags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_RemoveTag,
            this.btn_ClearAllTags});
			this.cms_Tags.Name = "cms_Tags";
			this.cms_Tags.Size = new System.Drawing.Size(145, 48);
			// 
			// btn_RemoveTag
			// 
			this.btn_RemoveTag.Name = "btn_RemoveTag";
			this.btn_RemoveTag.Size = new System.Drawing.Size(144, 22);
			this.btn_RemoveTag.Text = "Remove Tag";
			this.btn_RemoveTag.Click += new System.EventHandler(this.btn_RemoveTag_Click);
			// 
			// btn_ClearAllTags
			// 
			this.btn_ClearAllTags.Name = "btn_ClearAllTags";
			this.btn_ClearAllTags.Size = new System.Drawing.Size(144, 22);
			this.btn_ClearAllTags.Text = "Clear all Tags";
			this.btn_ClearAllTags.Click += new System.EventHandler(this.btn_ClearAllTags_Click);
			// 
			// f_TagEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 143);
			this.ControlBox = false;
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.cb_Tag);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.lv_Tags);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f_TagEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tag Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_TagEditor_FormClosing);
			this.cms_Tags.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lv_Tags;
		private FontAwesome.Sharp.IconButton btn_Close;
		private System.Windows.Forms.ComboBox cb_Tag;
		private FontAwesome.Sharp.IconButton btn_Add;
		private System.Windows.Forms.ColumnHeader ch_Tags;
		private System.Windows.Forms.ContextMenuStrip cms_Tags;
		private System.Windows.Forms.ToolStripMenuItem btn_RemoveTag;
		private System.Windows.Forms.ToolStripMenuItem btn_ClearAllTags;
	}
}
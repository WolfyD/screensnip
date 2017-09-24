namespace WolfPaw_ScreenSnip
{
    partial class uc_CutoutHolder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.pb_btn_Copy = new System.Windows.Forms.PictureBox();
			this.pb_btn_Save = new System.Windows.Forms.PictureBox();
			this.pb_btn_Transparent = new System.Windows.Forms.PictureBox();
			this.pb_btn_DOWN = new System.Windows.Forms.PictureBox();
			this.pb_btn_UP = new System.Windows.Forms.PictureBox();
			this.pb_btn_OriginalSize = new System.Windows.Forms.PictureBox();
			this.pb_btn_Delete = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Copy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Save)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Transparent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_DOWN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_UP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_OriginalSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Delete)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.pb_btn_Copy);
			this.panel1.Controls.Add(this.pb_btn_Save);
			this.panel1.Controls.Add(this.pb_btn_Delete);
			this.panel1.Controls.Add(this.pb_btn_Transparent);
			this.panel1.Controls.Add(this.pb_btn_DOWN);
			this.panel1.Controls.Add(this.pb_btn_UP);
			this.panel1.Controls.Add(this.pb_btn_OriginalSize);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 20);
			this.panel1.TabIndex = 0;
			// 
			// pb_btn_Copy
			// 
			this.pb_btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_btn_Copy.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.clipboard_20;
			this.pb_btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_Copy.Location = new System.Drawing.Point(123, 0);
			this.pb_btn_Copy.Name = "pb_btn_Copy";
			this.pb_btn_Copy.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_Copy.TabIndex = 6;
			this.pb_btn_Copy.TabStop = false;
			this.pb_btn_Copy.Click += new System.EventHandler(this.pb_btn_Copy_Click);
			this.pb_btn_Copy.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_Copy.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// pb_btn_Save
			// 
			this.pb_btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_btn_Save.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.save_20;
			this.pb_btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_Save.Location = new System.Drawing.Point(103, 0);
			this.pb_btn_Save.Name = "pb_btn_Save";
			this.pb_btn_Save.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_Save.TabIndex = 5;
			this.pb_btn_Save.TabStop = false;
			this.pb_btn_Save.Click += new System.EventHandler(this.pb_btn_Save_Click);
			this.pb_btn_Save.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_Save.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// pb_btn_Transparent
			// 
			this.pb_btn_Transparent.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.down;
			this.pb_btn_Transparent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_Transparent.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_Transparent.Enabled = false;
			this.pb_btn_Transparent.Location = new System.Drawing.Point(69, 0);
			this.pb_btn_Transparent.Name = "pb_btn_Transparent";
			this.pb_btn_Transparent.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_Transparent.TabIndex = 4;
			this.pb_btn_Transparent.TabStop = false;
			this.pb_btn_Transparent.Visible = false;
			this.pb_btn_Transparent.Click += new System.EventHandler(this.pb_btn_Transparent_Click);
			// 
			// pb_btn_DOWN
			// 
			this.pb_btn_DOWN.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.down;
			this.pb_btn_DOWN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_DOWN.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_DOWN.Location = new System.Drawing.Point(43, 0);
			this.pb_btn_DOWN.Name = "pb_btn_DOWN";
			this.pb_btn_DOWN.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_DOWN.TabIndex = 3;
			this.pb_btn_DOWN.TabStop = false;
			this.pb_btn_DOWN.Click += new System.EventHandler(this.pb_btn_DOWN_Click);
			this.pb_btn_DOWN.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_DOWN.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// pb_btn_UP
			// 
			this.pb_btn_UP.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.up;
			this.pb_btn_UP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_UP.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_UP.Location = new System.Drawing.Point(23, 0);
			this.pb_btn_UP.Name = "pb_btn_UP";
			this.pb_btn_UP.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_UP.TabIndex = 2;
			this.pb_btn_UP.TabStop = false;
			this.pb_btn_UP.Click += new System.EventHandler(this.pb_btn_UP_Click);
			this.pb_btn_UP.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_UP.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// pb_btn_OriginalSize
			// 
			this.pb_btn_OriginalSize.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.full_screen;
			this.pb_btn_OriginalSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_OriginalSize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_OriginalSize.Location = new System.Drawing.Point(0, 0);
			this.pb_btn_OriginalSize.Name = "pb_btn_OriginalSize";
			this.pb_btn_OriginalSize.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_OriginalSize.TabIndex = 1;
			this.pb_btn_OriginalSize.TabStop = false;
			this.pb_btn_OriginalSize.Click += new System.EventHandler(this.pb_btn_OriginalSize_Click);
			this.pb_btn_OriginalSize.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_OriginalSize.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// pb_btn_Delete
			// 
			this.pb_btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_btn_Delete.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.trashcan;
			this.pb_btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_btn_Delete.Location = new System.Drawing.Point(149, 0);
			this.pb_btn_Delete.Name = "pb_btn_Delete";
			this.pb_btn_Delete.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_Delete.TabIndex = 0;
			this.pb_btn_Delete.TabStop = false;
			this.pb_btn_Delete.Click += new System.EventHandler(this.pb_btn_Delete_Click);
			this.pb_btn_Delete.MouseEnter += new System.EventHandler(this.Panel1_MouseEnter);
			this.pb_btn_Delete.MouseLeave += new System.EventHandler(this.pb_btn_Delete_MouseLeave);
			// 
			// uc_CutoutHolder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Name = "uc_CutoutHolder";
			this.Size = new System.Drawing.Size(169, 155);
			this.LocationChanged += new System.EventHandler(this.uc_CutoutHolder_LocationChanged);
			this.SizeChanged += new System.EventHandler(this.uc_CutoutHolder_SizeChanged);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Copy)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Save)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Transparent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_DOWN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_UP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_OriginalSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Delete)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pb_btn_Delete;
		private System.Windows.Forms.PictureBox pb_btn_OriginalSize;
		private System.Windows.Forms.PictureBox pb_btn_DOWN;
		private System.Windows.Forms.PictureBox pb_btn_UP;
		private System.Windows.Forms.PictureBox pb_btn_Transparent;
		private System.Windows.Forms.PictureBox pb_btn_Copy;
		private System.Windows.Forms.PictureBox pb_btn_Save;
	}
}

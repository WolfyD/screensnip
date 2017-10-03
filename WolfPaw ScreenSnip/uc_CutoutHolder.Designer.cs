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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_CutoutHolder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_btn_Transparent = new System.Windows.Forms.PictureBox();
            this.btn_FitSize = new FontAwesome.Sharp.IconButton();
            this.pb_btn_OriginalSize = new FontAwesome.Sharp.IconButton();
            this.btn_Delete = new FontAwesome.Sharp.IconButton();
            this.btn_Copy = new FontAwesome.Sharp.IconButton();
            this.btn_Save = new FontAwesome.Sharp.IconButton();
            this.btn_Up = new FontAwesome.Sharp.IconButton();
            this.btn_Down = new FontAwesome.Sharp.IconButton();
            this.tt_Tip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_btn_Transparent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_Up);
            this.panel1.Controls.Add(this.btn_Down);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_Copy);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.pb_btn_OriginalSize);
            this.panel1.Controls.Add(this.btn_FitSize);
            this.panel1.Controls.Add(this.pb_btn_Transparent);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 20);
            this.panel1.TabIndex = 0;
            // 
            // pb_btn_Transparent
            // 
            this.pb_btn_Transparent.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.down;
            this.pb_btn_Transparent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_btn_Transparent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_btn_Transparent.Enabled = false;
            this.pb_btn_Transparent.Location = new System.Drawing.Point(93, 0);
            this.pb_btn_Transparent.Name = "pb_btn_Transparent";
            this.pb_btn_Transparent.Size = new System.Drawing.Size(20, 20);
            this.pb_btn_Transparent.TabIndex = 4;
            this.pb_btn_Transparent.TabStop = false;
            this.pb_btn_Transparent.Visible = false;
            this.pb_btn_Transparent.Click += new System.EventHandler(this.pb_btn_Transparent_Click);
            // 
            // btn_FitSize
            // 
            this.btn_FitSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FitSize.Icon = FontAwesome.Sharp.IconChar.Arrows;
            this.btn_FitSize.IconColor = System.Drawing.Color.Black;
            this.btn_FitSize.IconSize = 20;
            this.btn_FitSize.Image = ((System.Drawing.Image)(resources.GetObject("btn_FitSize.Image")));
            this.btn_FitSize.Location = new System.Drawing.Point(20, 0);
            this.btn_FitSize.Name = "btn_FitSize";
            this.btn_FitSize.Size = new System.Drawing.Size(20, 20);
            this.btn_FitSize.TabIndex = 7;
            this.btn_FitSize.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_FitSize, "Fit in screen\r\n(Resizes cutout so that it fits inside the screen)");
            this.btn_FitSize.UseVisualStyleBackColor = true;
            this.btn_FitSize.Click += new System.EventHandler(this.btn_FitSize_Click);
            this.btn_FitSize.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_FitSize.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // pb_btn_OriginalSize
            // 
            this.pb_btn_OriginalSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pb_btn_OriginalSize.Icon = FontAwesome.Sharp.IconChar.ArrowsAlt;
            this.pb_btn_OriginalSize.IconColor = System.Drawing.Color.Black;
            this.pb_btn_OriginalSize.IconSize = 20;
            this.pb_btn_OriginalSize.Image = ((System.Drawing.Image)(resources.GetObject("pb_btn_OriginalSize.Image")));
            this.pb_btn_OriginalSize.Location = new System.Drawing.Point(0, 0);
            this.pb_btn_OriginalSize.Name = "pb_btn_OriginalSize";
            this.pb_btn_OriginalSize.Size = new System.Drawing.Size(20, 20);
            this.pb_btn_OriginalSize.TabIndex = 8;
            this.pb_btn_OriginalSize.TabStop = false;
            this.tt_Tip.SetToolTip(this.pb_btn_OriginalSize, "Original Size\r\n(Return Cutout to it\'s original size)");
            this.pb_btn_OriginalSize.UseVisualStyleBackColor = true;
            this.pb_btn_OriginalSize.Click += new System.EventHandler(this.pb_btn_OriginalSize_Click);
            this.pb_btn_OriginalSize.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.pb_btn_OriginalSize.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Icon = FontAwesome.Sharp.IconChar.Trash;
            this.btn_Delete.IconColor = System.Drawing.Color.Black;
            this.btn_Delete.IconSize = 22;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.Location = new System.Drawing.Point(168, 0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btn_Delete.Size = new System.Drawing.Size(20, 20);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_Delete, "Delete\r\n(Removes this cutout from the screen)");
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.pb_btn_Delete_Click);
            this.btn_Delete.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_Delete.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // btn_Copy
            // 
            this.btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Copy.Icon = FontAwesome.Sharp.IconChar.FilesO;
            this.btn_Copy.IconColor = System.Drawing.Color.Black;
            this.btn_Copy.IconSize = 22;
            this.btn_Copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_Copy.Image")));
            this.btn_Copy.Location = new System.Drawing.Point(147, 0);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btn_Copy.Size = new System.Drawing.Size(20, 20);
            this.btn_Copy.TabIndex = 10;
            this.btn_Copy.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_Copy, "Copy\r\n(Copies this cutout as a self contained image)\r\n");
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.pb_btn_Copy_Click);
            this.btn_Copy.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_Copy.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Icon = FontAwesome.Sharp.IconChar.FloppyO;
            this.btn_Save.IconColor = System.Drawing.Color.Black;
            this.btn_Save.IconSize = 22;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(126, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btn_Save.Size = new System.Drawing.Size(20, 20);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_Save, "Save\r\n(Saves this cutout as a self contained image)");
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.pb_btn_Save_Click);
            this.btn_Save.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_Save.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // btn_Up
            // 
            this.btn_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Up.Icon = FontAwesome.Sharp.IconChar.ArrowCircleOUp;
            this.btn_Up.IconColor = System.Drawing.Color.Black;
            this.btn_Up.IconSize = 20;
            this.btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up.Image")));
            this.btn_Up.Location = new System.Drawing.Point(43, 0);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(20, 20);
            this.btn_Up.TabIndex = 13;
            this.btn_Up.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_Up, "Layer Up\r\n(Raises the cutout up one layer)");
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.pb_btn_UP_Click);
            this.btn_Up.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_Up.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
            // 
            // btn_Down
            // 
            this.btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Down.Icon = FontAwesome.Sharp.IconChar.ArrowCircleODown;
            this.btn_Down.IconColor = System.Drawing.Color.Black;
            this.btn_Down.IconSize = 20;
            this.btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down.Image")));
            this.btn_Down.Location = new System.Drawing.Point(63, 0);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(20, 20);
            this.btn_Down.TabIndex = 12;
            this.btn_Down.TabStop = false;
            this.tt_Tip.SetToolTip(this.btn_Down, "Layer Down\r\n(Loweres the cutout down one layer)\r\n");
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.pb_btn_DOWN_Click);
            this.btn_Down.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter);
            this.btn_Down.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave);
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
            this.Size = new System.Drawing.Size(187, 155);
            this.LocationChanged += new System.EventHandler(this.uc_CutoutHolder_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.uc_CutoutHolder_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uc_CutoutHolder_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uc_CutoutHolder_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_btn_Transparent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pb_btn_Transparent;
        private FontAwesome.Sharp.IconButton pb_btn_OriginalSize;
        private FontAwesome.Sharp.IconButton btn_FitSize;
        private FontAwesome.Sharp.IconButton btn_Save;
        private FontAwesome.Sharp.IconButton btn_Copy;
        private FontAwesome.Sharp.IconButton btn_Delete;
        private FontAwesome.Sharp.IconButton btn_Up;
        private FontAwesome.Sharp.IconButton btn_Down;
        private System.Windows.Forms.ToolTip tt_Tip;
    }
}

namespace WolfPaw_ScreenSnip
{
    partial class uc_CutoutHolder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

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
			this.btn_CMS = new FontAwesome.Sharp.IconButton();
			this.btn_Delete = new FontAwesome.Sharp.IconButton();
			this.btn_OriginalSize = new FontAwesome.Sharp.IconButton();
			this.btn_PrecisionMovement = new FontAwesome.Sharp.IconButton();
			this.btn_Save = new FontAwesome.Sharp.IconButton();
			this.btn_Copy = new FontAwesome.Sharp.IconButton();
			this.btn_Up = new FontAwesome.Sharp.IconButton();
			this.btn_Down = new FontAwesome.Sharp.IconButton();
			this.btn_FitSize = new FontAwesome.Sharp.IconButton();
			this.tt_Tip = new System.Windows.Forms.ToolTip(this.components);
			this.cms_Panel = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cms_btn_Resize = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_Fit = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_LayerUp = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_LayerDown = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_PresiceMovementMode = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_btn_Delete = new System.Windows.Forms.ToolStripMenuItem();
			this.t_Hide = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.cms_Panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.btn_CMS);
			this.panel1.Controls.Add(this.btn_Delete);
			this.panel1.Controls.Add(this.btn_OriginalSize);
			this.panel1.Controls.Add(this.btn_PrecisionMovement);
			this.panel1.Controls.Add(this.btn_Save);
			this.panel1.Controls.Add(this.btn_Copy);
			this.panel1.Controls.Add(this.btn_Up);
			this.panel1.Controls.Add(this.btn_Down);
			this.panel1.Controls.Add(this.btn_FitSize);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 20);
			this.panel1.TabIndex = 0;
			// 
			// btn_CMS
			// 
			this.btn_CMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_CMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_CMS.Icon = FontAwesome.Sharp.IconChar.CaretUp;
			this.btn_CMS.IconColor = System.Drawing.Color.Black;
			this.btn_CMS.IconSize = 20;
			this.btn_CMS.Image = ((System.Drawing.Image)(resources.GetObject("btn_CMS.Image")));
			this.btn_CMS.Location = new System.Drawing.Point(90, 0);
			this.btn_CMS.Name = "btn_CMS";
			this.btn_CMS.Size = new System.Drawing.Size(20, 20);
			this.btn_CMS.TabIndex = 15;
			this.btn_CMS.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_CMS, "Layer Down\r\n(Loweres the cutout down one layer)\r\n");
			this.btn_CMS.UseVisualStyleBackColor = true;
			this.btn_CMS.Visible = false;
			this.btn_CMS.Click += new System.EventHandler(this.btn_CMS_Click);
			// 
			// btn_Delete
			// 
			this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Delete.Icon = FontAwesome.Sharp.IconChar.Trash;
			this.btn_Delete.IconColor = System.Drawing.Color.Black;
			this.btn_Delete.IconSize = 22;
			this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
			this.btn_Delete.Location = new System.Drawing.Point(180, 0);
			this.btn_Delete.Name = "btn_Delete";
			this.btn_Delete.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.btn_Delete.Size = new System.Drawing.Size(20, 20);
			this.btn_Delete.TabIndex = 9;
			this.btn_Delete.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_Delete, "Delete\r\n(Removes this cutout from the screen)");
			this.btn_Delete.UseVisualStyleBackColor = true;
			this.btn_Delete.Click += new System.EventHandler(this.pb_btn_Delete_Click);
			this.btn_Delete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_Delete.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_Delete.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_Delete.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
			// 
			// btn_OriginalSize
			// 
			this.btn_OriginalSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_OriginalSize.Icon = FontAwesome.Sharp.IconChar.ArrowsAlt;
			this.btn_OriginalSize.IconColor = System.Drawing.Color.Black;
			this.btn_OriginalSize.IconSize = 20;
			this.btn_OriginalSize.Image = ((System.Drawing.Image)(resources.GetObject("btn_OriginalSize.Image")));
			this.btn_OriginalSize.Location = new System.Drawing.Point(0, 0);
			this.btn_OriginalSize.Name = "btn_OriginalSize";
			this.btn_OriginalSize.Size = new System.Drawing.Size(20, 20);
			this.btn_OriginalSize.TabIndex = 8;
			this.btn_OriginalSize.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_OriginalSize, "Original Size\r\n(Return Cutout to it\'s original size)");
			this.btn_OriginalSize.UseVisualStyleBackColor = true;
			this.btn_OriginalSize.Click += new System.EventHandler(this.pb_btn_OriginalSize_Click);
			this.btn_OriginalSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_OriginalSize.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_OriginalSize.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_OriginalSize.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
			// 
			// btn_PrecisionMovement
			// 
			this.btn_PrecisionMovement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_PrecisionMovement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_PrecisionMovement.Icon = FontAwesome.Sharp.IconChar.CaretSquareORight;
			this.btn_PrecisionMovement.IconColor = System.Drawing.Color.Black;
			this.btn_PrecisionMovement.IconSize = 20;
			this.btn_PrecisionMovement.Image = ((System.Drawing.Image)(resources.GetObject("btn_PrecisionMovement.Image")));
			this.btn_PrecisionMovement.Location = new System.Drawing.Point(113, 0);
			this.btn_PrecisionMovement.Name = "btn_PrecisionMovement";
			this.btn_PrecisionMovement.Size = new System.Drawing.Size(20, 20);
			this.btn_PrecisionMovement.TabIndex = 14;
			this.btn_PrecisionMovement.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_PrecisionMovement, "Precision movement\r\n(Selects the cutout for precise movement mode)\r\n");
			this.btn_PrecisionMovement.UseVisualStyleBackColor = true;
			this.btn_PrecisionMovement.Click += new System.EventHandler(this.btn_PrecisionMovement_Click);
			this.btn_PrecisionMovement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_PrecisionMovement.MouseEnter += new System.EventHandler(this.btn_PrecisionMovement_MouseEnter);
			this.btn_PrecisionMovement.MouseLeave += new System.EventHandler(this.btn_PrecisionMovement_MouseLeave);
			this.btn_PrecisionMovement.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
			// 
			// btn_Save
			// 
			this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Save.Icon = FontAwesome.Sharp.IconChar.FloppyO;
			this.btn_Save.IconColor = System.Drawing.Color.Black;
			this.btn_Save.IconSize = 22;
			this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
			this.btn_Save.Location = new System.Drawing.Point(138, 0);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.btn_Save.Size = new System.Drawing.Size(20, 20);
			this.btn_Save.TabIndex = 11;
			this.btn_Save.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_Save, "Save\r\n(Saves this cutout as a self contained image)");
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.pb_btn_Save_Click);
			this.btn_Save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_Save.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_Save.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_Save.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
			// 
			// btn_Copy
			// 
			this.btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Copy.Icon = FontAwesome.Sharp.IconChar.FilesO;
			this.btn_Copy.IconColor = System.Drawing.Color.Black;
			this.btn_Copy.IconSize = 22;
			this.btn_Copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_Copy.Image")));
			this.btn_Copy.Location = new System.Drawing.Point(159, 0);
			this.btn_Copy.Name = "btn_Copy";
			this.btn_Copy.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.btn_Copy.Size = new System.Drawing.Size(20, 20);
			this.btn_Copy.TabIndex = 10;
			this.btn_Copy.TabStop = false;
			this.tt_Tip.SetToolTip(this.btn_Copy, "Copy\r\n(Copies this cutout as a self contained image)\r\n");
			this.btn_Copy.UseVisualStyleBackColor = true;
			this.btn_Copy.Click += new System.EventHandler(this.pb_btn_Copy_Click);
			this.btn_Copy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_Copy.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_Copy.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_Copy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
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
			this.btn_Up.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_Up.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_Up.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_Up.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
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
			this.btn_Down.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_Down.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_Down.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_Down.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
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
			this.btn_FitSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pb_btn_OriginalSize_KeyDown);
			this.btn_FitSize.MouseEnter += new System.EventHandler(this.pb_btn_OriginalSize_MouseEnter_1);
			this.btn_FitSize.MouseLeave += new System.EventHandler(this.pb_btn_OriginalSize_MouseLeave_1);
			this.btn_FitSize.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_btn_OriginalSize_PreviewKeyDown);
			// 
			// cms_Panel
			// 
			this.cms_Panel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_btn_Resize,
            this.cms_btn_Fit,
            this.cms_btn_LayerUp,
            this.cms_btn_LayerDown,
            this.cms_btn_PresiceMovementMode,
            this.cms_btn_Save,
            this.cms_btn_Copy,
            this.cms_btn_Delete});
			this.cms_Panel.Name = "cms_Panel";
			this.cms_Panel.Size = new System.Drawing.Size(207, 180);
			// 
			// cms_btn_Resize
			// 
			this.cms_btn_Resize.Image = global::WolfPaw_ScreenSnip.Properties.Resources.full_screen;
			this.cms_btn_Resize.Name = "cms_btn_Resize";
			this.cms_btn_Resize.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_Resize.Text = "Resize";
			this.cms_btn_Resize.Click += new System.EventHandler(this.pb_btn_OriginalSize_Click);
			// 
			// cms_btn_Fit
			// 
			this.cms_btn_Fit.Name = "cms_btn_Fit";
			this.cms_btn_Fit.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_Fit.Text = "Fit";
			this.cms_btn_Fit.Click += new System.EventHandler(this.btn_FitSize_Click);
			// 
			// cms_btn_LayerUp
			// 
			this.cms_btn_LayerUp.Image = global::WolfPaw_ScreenSnip.Properties.Resources.up;
			this.cms_btn_LayerUp.Name = "cms_btn_LayerUp";
			this.cms_btn_LayerUp.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_LayerUp.Text = "Layer Up";
			this.cms_btn_LayerUp.Click += new System.EventHandler(this.pb_btn_UP_Click);
			// 
			// cms_btn_LayerDown
			// 
			this.cms_btn_LayerDown.Image = global::WolfPaw_ScreenSnip.Properties.Resources.down;
			this.cms_btn_LayerDown.Name = "cms_btn_LayerDown";
			this.cms_btn_LayerDown.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_LayerDown.Text = "Layer Down";
			this.cms_btn_LayerDown.Click += new System.EventHandler(this.pb_btn_DOWN_Click);
			// 
			// cms_btn_PresiceMovementMode
			// 
			this.cms_btn_PresiceMovementMode.Name = "cms_btn_PresiceMovementMode";
			this.cms_btn_PresiceMovementMode.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_PresiceMovementMode.Text = "Precise Movement Mode";
			this.cms_btn_PresiceMovementMode.Click += new System.EventHandler(this.btn_PrecisionMovement_Click);
			// 
			// cms_btn_Save
			// 
			this.cms_btn_Save.Image = global::WolfPaw_ScreenSnip.Properties.Resources.save_20;
			this.cms_btn_Save.Name = "cms_btn_Save";
			this.cms_btn_Save.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_Save.Text = "Save";
			this.cms_btn_Save.Click += new System.EventHandler(this.pb_btn_Save_Click);
			// 
			// cms_btn_Copy
			// 
			this.cms_btn_Copy.Image = global::WolfPaw_ScreenSnip.Properties.Resources.clipboard_20;
			this.cms_btn_Copy.Name = "cms_btn_Copy";
			this.cms_btn_Copy.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_Copy.Text = "Copy";
			this.cms_btn_Copy.Click += new System.EventHandler(this.pb_btn_Copy_Click);
			// 
			// cms_btn_Delete
			// 
			this.cms_btn_Delete.Image = global::WolfPaw_ScreenSnip.Properties.Resources.trashcan;
			this.cms_btn_Delete.Name = "cms_btn_Delete";
			this.cms_btn_Delete.Size = new System.Drawing.Size(206, 22);
			this.cms_btn_Delete.Text = "Delete";
			this.cms_btn_Delete.Click += new System.EventHandler(this.pb_btn_Delete_Click);
			// 
			// t_Hide
			// 
			this.t_Hide.Enabled = true;
			this.t_Hide.Interval = 1000;
			this.t_Hide.Tick += new System.EventHandler(this.t_Hide_Tick);
			// 
			// uc_CutoutHolder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Name = "uc_CutoutHolder";
			this.Size = new System.Drawing.Size(200, 211);
			this.LocationChanged += new System.EventHandler(this.uc_CutoutHolder_LocationChanged);
			this.SizeChanged += new System.EventHandler(this.uc_CutoutHolder_SizeChanged);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uc_CutoutHolder_KeyDown);
			this.MouseEnter += new System.EventHandler(this.uc_CutoutHolder_MouseEnter_1);
			this.MouseLeave += new System.EventHandler(this.uc_CutoutHolder_MouseLeave_1);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uc_CutoutHolder_PreviewKeyDown);
			this.panel1.ResumeLayout(false);
			this.cms_Panel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_OriginalSize;
        private FontAwesome.Sharp.IconButton btn_FitSize;
        private FontAwesome.Sharp.IconButton btn_Save;
        private FontAwesome.Sharp.IconButton btn_Copy;
        private FontAwesome.Sharp.IconButton btn_Delete;
        private FontAwesome.Sharp.IconButton btn_Up;
        private FontAwesome.Sharp.IconButton btn_Down;
        private System.Windows.Forms.ToolTip tt_Tip;
		private FontAwesome.Sharp.IconButton btn_PrecisionMovement;
		private System.Windows.Forms.ContextMenuStrip cms_Panel;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_Resize;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_Fit;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_LayerUp;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_LayerDown;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_PresiceMovementMode;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_Save;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_Copy;
		private System.Windows.Forms.ToolStripMenuItem cms_btn_Delete;
		private FontAwesome.Sharp.IconButton btn_CMS;
		private System.Windows.Forms.Timer t_Hide;
	}
}

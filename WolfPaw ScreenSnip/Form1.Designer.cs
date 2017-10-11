namespace WolfPaw_ScreenSnip
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btn_Copy = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_AttachToEmail = new System.Windows.Forms.Button();
			this.btn_Clear = new System.Windows.Forms.Button();
			this.btn_Exit = new System.Windows.Forms.Button();
			this.btn_Options = new System.Windows.Forms.Button();
			this.btn_Settings = new System.Windows.Forms.Button();
			this.btn_Print = new System.Windows.Forms.Button();
			this.btn_Preview = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.btn_SaveToDB = new System.Windows.Forms.Button();
			this.btn_DatabaseLoad = new System.Windows.Forms.Button();
			this.btn_Screen = new System.Windows.Forms.Button();
			this.btn_Minimize = new System.Windows.Forms.PictureBox();
			this.btn_Rollup = new System.Windows.Forms.PictureBox();
			this.btn_Question = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ni_Notify = new System.Windows.Forms.NotifyIcon(this.components);
			this.uc_ButtonSelector1 = new WolfPaw_ScreenSnip.uc_ButtonSelector();
			((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_Rollup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_Question)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_Copy
			// 
			this.btn_Copy.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.clipboard;
			this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Copy.Location = new System.Drawing.Point(191, 20);
			this.btn_Copy.Name = "btn_Copy";
			this.btn_Copy.Size = new System.Drawing.Size(40, 40);
			this.btn_Copy.TabIndex = 1;
			this.btn_Copy.Tag = "3";
			this.btn_Copy.UseVisualStyleBackColor = true;
			this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.save;
			this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Save.Location = new System.Drawing.Point(232, 20);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(40, 40);
			this.btn_Save.TabIndex = 2;
			this.btn_Save.Tag = "4";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_AttachToEmail
			// 
			this.btn_AttachToEmail.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.attach;
			this.btn_AttachToEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AttachToEmail.Location = new System.Drawing.Point(396, 20);
			this.btn_AttachToEmail.Name = "btn_AttachToEmail";
			this.btn_AttachToEmail.Size = new System.Drawing.Size(40, 40);
			this.btn_AttachToEmail.TabIndex = 3;
			this.btn_AttachToEmail.Tag = "6";
			this.btn_AttachToEmail.UseVisualStyleBackColor = true;
			this.btn_AttachToEmail.Click += new System.EventHandler(this.btn_AttachToEmail_Click);
			// 
			// btn_Clear
			// 
			this.btn_Clear.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.shredder;
			this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Clear.Location = new System.Drawing.Point(99, 20);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.Size = new System.Drawing.Size(40, 40);
			this.btn_Clear.TabIndex = 4;
			this.btn_Clear.Tag = "1";
			this.btn_Clear.UseVisualStyleBackColor = true;
			this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
			// 
			// btn_Exit
			// 
			this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Exit.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.exit;
			this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Exit.Location = new System.Drawing.Point(537, 20);
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(40, 40);
			this.btn_Exit.TabIndex = 6;
			this.btn_Exit.Tag = "9";
			this.btn_Exit.UseVisualStyleBackColor = true;
			this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
			// 
			// btn_Options
			// 
			this.btn_Options.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.gear;
			this.btn_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Options.Location = new System.Drawing.Point(447, 20);
			this.btn_Options.Name = "btn_Options";
			this.btn_Options.Size = new System.Drawing.Size(40, 40);
			this.btn_Options.TabIndex = 7;
			this.btn_Options.Tag = "7";
			this.btn_Options.UseVisualStyleBackColor = true;
			this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
			// 
			// btn_Settings
			// 
			this.btn_Settings.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.screw;
			this.btn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Settings.Location = new System.Drawing.Point(488, 20);
			this.btn_Settings.Name = "btn_Settings";
			this.btn_Settings.Size = new System.Drawing.Size(40, 40);
			this.btn_Settings.TabIndex = 8;
			this.btn_Settings.Tag = "8";
			this.btn_Settings.UseVisualStyleBackColor = true;
			this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
			// 
			// btn_Print
			// 
			this.btn_Print.BackColor = System.Drawing.SystemColors.ControlDark;
			this.btn_Print.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.print;
			this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Print.Enabled = false;
			this.btn_Print.Location = new System.Drawing.Point(355, 20);
			this.btn_Print.Name = "btn_Print";
			this.btn_Print.Size = new System.Drawing.Size(40, 40);
			this.btn_Print.TabIndex = 9;
			this.btn_Print.Tag = "5";
			this.btn_Print.UseVisualStyleBackColor = false;
			this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
			// 
			// btn_Preview
			// 
			this.btn_Preview.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.preview;
			this.btn_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Preview.Location = new System.Drawing.Point(150, 20);
			this.btn_Preview.Name = "btn_Preview";
			this.btn_Preview.Size = new System.Drawing.Size(40, 40);
			this.btn_Preview.TabIndex = 10;
			this.btn_Preview.Tag = "2";
			this.btn_Preview.UseVisualStyleBackColor = true;
			this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.UseAntiAlias = true;
			this.printPreviewDialog1.Visible = false;
			// 
			// btn_SaveToDB
			// 
			this.btn_SaveToDB.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.db;
			this.btn_SaveToDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_SaveToDB.Location = new System.Drawing.Point(273, 20);
			this.btn_SaveToDB.Name = "btn_SaveToDB";
			this.btn_SaveToDB.Size = new System.Drawing.Size(40, 40);
			this.btn_SaveToDB.TabIndex = 11;
			this.btn_SaveToDB.Tag = "10";
			this.btn_SaveToDB.UseVisualStyleBackColor = true;
			this.btn_SaveToDB.Click += new System.EventHandler(this.btn_SaveToDB_Click);
			// 
			// btn_DatabaseLoad
			// 
			this.btn_DatabaseLoad.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.dbl;
			this.btn_DatabaseLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_DatabaseLoad.Location = new System.Drawing.Point(314, 20);
			this.btn_DatabaseLoad.Name = "btn_DatabaseLoad";
			this.btn_DatabaseLoad.Size = new System.Drawing.Size(40, 40);
			this.btn_DatabaseLoad.TabIndex = 12;
			this.btn_DatabaseLoad.Tag = "11";
			this.btn_DatabaseLoad.UseVisualStyleBackColor = true;
			this.btn_DatabaseLoad.Click += new System.EventHandler(this.btn_DatabaseLoad_Click);
			// 
			// btn_Screen
			// 
			this.btn_Screen.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.screen;
			this.btn_Screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Screen.Location = new System.Drawing.Point(58, 20);
			this.btn_Screen.Name = "btn_Screen";
			this.btn_Screen.Size = new System.Drawing.Size(40, 40);
			this.btn_Screen.TabIndex = 4;
			this.btn_Screen.Tag = "12";
			this.btn_Screen.UseVisualStyleBackColor = true;
			this.btn_Screen.Click += new System.EventHandler(this.btn_Screen_Click);
			// 
			// btn_Minimize
			// 
			this.btn_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Minimize.BackColor = System.Drawing.Color.Transparent;
			this.btn_Minimize.Image = global::WolfPaw_ScreenSnip.Properties.Resources.minimize_black;
			this.btn_Minimize.Location = new System.Drawing.Point(555, -2);
			this.btn_Minimize.Name = "btn_Minimize";
			this.btn_Minimize.Size = new System.Drawing.Size(20, 22);
			this.btn_Minimize.TabIndex = 13;
			this.btn_Minimize.TabStop = false;
			this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
			this.btn_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
			this.btn_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
			// 
			// btn_Rollup
			// 
			this.btn_Rollup.BackColor = System.Drawing.Color.Transparent;
			this.btn_Rollup.Image = global::WolfPaw_ScreenSnip.Properties.Resources.rollup_black;
			this.btn_Rollup.Location = new System.Drawing.Point(0, 0);
			this.btn_Rollup.Name = "btn_Rollup";
			this.btn_Rollup.Size = new System.Drawing.Size(20, 20);
			this.btn_Rollup.TabIndex = 14;
			this.btn_Rollup.TabStop = false;
			this.btn_Rollup.Click += new System.EventHandler(this.btn_Rollup_Click);
			this.btn_Rollup.MouseEnter += new System.EventHandler(this.btn_Rollup_MouseEnter);
			this.btn_Rollup.MouseLeave += new System.EventHandler(this.btn_Rollup_MouseLeave);
			// 
			// btn_Question
			// 
			this.btn_Question.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Question.BackColor = System.Drawing.Color.Transparent;
			this.btn_Question.Image = global::WolfPaw_ScreenSnip.Properties.Resources.questionmark_black;
			this.btn_Question.Location = new System.Drawing.Point(534, 0);
			this.btn_Question.Name = "btn_Question";
			this.btn_Question.Size = new System.Drawing.Size(20, 20);
			this.btn_Question.TabIndex = 15;
			this.btn_Question.TabStop = false;
			this.btn_Question.Click += new System.EventHandler(this.btn_Question_Click);
			this.btn_Question.MouseEnter += new System.EventHandler(this.btn_Question_MouseEnter);
			this.btn_Question.MouseLeave += new System.EventHandler(this.btn_Question_MouseLeave);
			// 
			// ni_Notify
			// 
			this.ni_Notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.ni_Notify.BalloonTipText = "WolfPaw Screen Snip is still running";
			this.ni_Notify.BalloonTipTitle = "WolfPaw Screen Snip";
			this.ni_Notify.Text = "WolfPaw Screen Snip";
			this.ni_Notify.Visible = true;
			// 
			// uc_ButtonSelector1
			// 
			this.uc_ButtonSelector1.ButtonSize = 40;
			this.uc_ButtonSelector1.Location = new System.Drawing.Point(0, 20);
			this.uc_ButtonSelector1.Name = "uc_ButtonSelector1";
			this.uc_ButtonSelector1.Size = new System.Drawing.Size(55, 40);
			this.uc_ButtonSelector1.TabIndex = 16;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.handle;
			this.ClientSize = new System.Drawing.Size(577, 60);
			this.ControlBox = false;
			this.Controls.Add(this.uc_ButtonSelector1);
			this.Controls.Add(this.btn_Question);
			this.Controls.Add(this.btn_Rollup);
			this.Controls.Add(this.btn_Minimize);
			this.Controls.Add(this.btn_DatabaseLoad);
			this.Controls.Add(this.btn_SaveToDB);
			this.Controls.Add(this.btn_Preview);
			this.Controls.Add(this.btn_Print);
			this.Controls.Add(this.btn_Settings);
			this.Controls.Add(this.btn_Options);
			this.Controls.Add(this.btn_Exit);
			this.Controls.Add(this.btn_Screen);
			this.Controls.Add(this.btn_Clear);
			this.Controls.Add(this.btn_AttachToEmail);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.btn_Copy);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Snip";
			this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_Rollup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_Question)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_AttachToEmail;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Options;
		private System.Windows.Forms.Button btn_Settings;
		private System.Windows.Forms.Button btn_Print;
		private System.Windows.Forms.Button btn_Preview;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btn_SaveToDB;
		private System.Windows.Forms.Button btn_DatabaseLoad;
		private System.Windows.Forms.Button btn_Screen;
		private System.Windows.Forms.PictureBox btn_Minimize;
		private System.Windows.Forms.PictureBox btn_Rollup;
		private System.Windows.Forms.PictureBox btn_Question;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon ni_Notify;
		private uc_ButtonSelector uc_ButtonSelector1;
	}
}


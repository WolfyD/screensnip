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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.brn_New = new System.Windows.Forms.Button();
			this.btn_Copy = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_AttachToEmail = new System.Windows.Forms.Button();
			this.btn_Clear = new System.Windows.Forms.Button();
			this.btn_Exit = new System.Windows.Forms.Button();
			this.btn_Options = new System.Windows.Forms.Button();
			this.btn_Settings = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// brn_New
			// 
			this.brn_New.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brn_New.BackgroundImage")));
			this.brn_New.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.brn_New.Location = new System.Drawing.Point(0, 0);
			this.brn_New.Name = "brn_New";
			this.brn_New.Size = new System.Drawing.Size(40, 40);
			this.brn_New.TabIndex = 0;
			this.brn_New.UseVisualStyleBackColor = true;
			this.brn_New.Click += new System.EventHandler(this.brn_New_Click);
			// 
			// btn_Copy
			// 
			this.btn_Copy.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.clipboard;
			this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Copy.Location = new System.Drawing.Point(88, 0);
			this.btn_Copy.Name = "btn_Copy";
			this.btn_Copy.Size = new System.Drawing.Size(40, 40);
			this.btn_Copy.TabIndex = 1;
			this.btn_Copy.UseVisualStyleBackColor = true;
			this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.save;
			this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Save.Location = new System.Drawing.Point(129, 0);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(40, 40);
			this.btn_Save.TabIndex = 2;
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_AttachToEmail
			// 
			this.btn_AttachToEmail.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.attach;
			this.btn_AttachToEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AttachToEmail.Location = new System.Drawing.Point(170, 0);
			this.btn_AttachToEmail.Name = "btn_AttachToEmail";
			this.btn_AttachToEmail.Size = new System.Drawing.Size(40, 40);
			this.btn_AttachToEmail.TabIndex = 3;
			this.btn_AttachToEmail.UseVisualStyleBackColor = true;
			this.btn_AttachToEmail.Click += new System.EventHandler(this.btn_AttachToEmail_Click);
			// 
			// btn_Clear
			// 
			this.btn_Clear.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.shredder;
			this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Clear.Location = new System.Drawing.Point(42, 0);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.Size = new System.Drawing.Size(40, 40);
			this.btn_Clear.TabIndex = 4;
			this.btn_Clear.UseVisualStyleBackColor = true;
			this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
			// 
			// btn_Exit
			// 
			this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Exit.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.exit;
			this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Exit.Location = new System.Drawing.Point(311, 0);
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(40, 40);
			this.btn_Exit.TabIndex = 6;
			this.btn_Exit.UseVisualStyleBackColor = true;
			this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
			// 
			// btn_Options
			// 
			this.btn_Options.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.gear;
			this.btn_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Options.Location = new System.Drawing.Point(216, 0);
			this.btn_Options.Name = "btn_Options";
			this.btn_Options.Size = new System.Drawing.Size(40, 40);
			this.btn_Options.TabIndex = 7;
			this.btn_Options.UseVisualStyleBackColor = true;
			// 
			// btn_Settings
			// 
			this.btn_Settings.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.gear;
			this.btn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_Settings.Location = new System.Drawing.Point(257, 0);
			this.btn_Settings.Name = "btn_Settings";
			this.btn_Settings.Size = new System.Drawing.Size(40, 40);
			this.btn_Settings.TabIndex = 8;
			this.btn_Settings.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 40);
			this.ControlBox = false;
			this.Controls.Add(this.btn_Settings);
			this.Controls.Add(this.btn_Options);
			this.Controls.Add(this.btn_Exit);
			this.Controls.Add(this.btn_Clear);
			this.Controls.Add(this.btn_AttachToEmail);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.btn_Copy);
			this.Controls.Add(this.brn_New);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Snip";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button brn_New;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_AttachToEmail;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Options;
		private System.Windows.Forms.Button btn_Settings;
	}
}


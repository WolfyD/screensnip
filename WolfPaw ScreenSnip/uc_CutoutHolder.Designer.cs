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
			this.pb_btn_Delete = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Delete)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.pb_btn_Delete);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 20);
			this.panel1.TabIndex = 0;
			// 
			// pb_btn_Delete
			// 
			this.pb_btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_btn_Delete.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.trashcan;
			this.pb_btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_btn_Delete.Location = new System.Drawing.Point(149, 0);
			this.pb_btn_Delete.Name = "pb_btn_Delete";
			this.pb_btn_Delete.Size = new System.Drawing.Size(20, 20);
			this.pb_btn_Delete.TabIndex = 0;
			this.pb_btn_Delete.TabStop = false;
			this.pb_btn_Delete.Click += new System.EventHandler(this.pb_btn_Delete_Click);
			// 
			// uc_CutoutHolder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Name = "uc_CutoutHolder";
			this.Size = new System.Drawing.Size(169, 155);
			this.SizeChanged += new System.EventHandler(this.uc_CutoutHolder_SizeChanged);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_btn_Delete)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pb_btn_Delete;
	}
}

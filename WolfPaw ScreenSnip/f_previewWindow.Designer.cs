namespace WolfPaw_ScreenSnip
{
	partial class f_previewWindow
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
			this.pb_PreviewPicture = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pb_PreviewPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_PreviewPicture
			// 
			this.pb_PreviewPicture.BackColor = System.Drawing.Color.Black;
			this.pb_PreviewPicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb_PreviewPicture.Location = new System.Drawing.Point(0, 0);
			this.pb_PreviewPicture.Name = "pb_PreviewPicture";
			this.pb_PreviewPicture.Size = new System.Drawing.Size(184, 161);
			this.pb_PreviewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_PreviewPicture.TabIndex = 0;
			this.pb_PreviewPicture.TabStop = false;
			// 
			// f_previewWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(184, 161);
			this.Controls.Add(this.pb_PreviewPicture);
			this.Name = "f_previewWindow";
			this.Text = "Preview";
			((System.ComponentModel.ISupportInitialize)(this.pb_PreviewPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_PreviewPicture;
	}
}
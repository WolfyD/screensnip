namespace SharpSnip
{
	partial class uc_TextBox
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
			this.tb_TextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tb_TextBox
			// 
			this.tb_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_TextBox.Location = new System.Drawing.Point(3, 3);
			this.tb_TextBox.Multiline = true;
			this.tb_TextBox.Name = "tb_TextBox";
			this.tb_TextBox.Size = new System.Drawing.Size(204, 73);
			this.tb_TextBox.TabIndex = 0;
			// 
			// uc_TextBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tb_TextBox);
			this.Name = "uc_TextBox";
			this.Size = new System.Drawing.Size(210, 79);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_TextBox;
	}
}

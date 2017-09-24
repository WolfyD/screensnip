namespace WolfPaw_ScreenSnip
{
	partial class f_TCP
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
			this.pb_Pic = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_Color = new System.Windows.Forms.Label();
			this.num_Tolerance = new System.Windows.Forms.NumericUpDown();
			this.p_Color = new System.Windows.Forms.Panel();
			this.btn_OK = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Tolerance)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_Pic
			// 
			this.pb_Pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_Pic.Location = new System.Drawing.Point(0, 0);
			this.pb_Pic.Name = "pb_Pic";
			this.pb_Pic.Size = new System.Drawing.Size(313, 190);
			this.pb_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_Pic.TabIndex = 0;
			this.pb_Pic.TabStop = false;
			this.pb_Pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Pic_MouseDown);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 197);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Color:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 219);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tolerance:";
			// 
			// lbl_Color
			// 
			this.lbl_Color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbl_Color.AutoSize = true;
			this.lbl_Color.Location = new System.Drawing.Point(60, 197);
			this.lbl_Color.Name = "lbl_Color";
			this.lbl_Color.Size = new System.Drawing.Size(124, 13);
			this.lbl_Color.TabIndex = 3;
			this.lbl_Color.Text = "#FFFFFF | 255, 255, 255";
			// 
			// num_Tolerance
			// 
			this.num_Tolerance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.num_Tolerance.Location = new System.Drawing.Point(60, 215);
			this.num_Tolerance.Name = "num_Tolerance";
			this.num_Tolerance.Size = new System.Drawing.Size(52, 20);
			this.num_Tolerance.TabIndex = 5;
			// 
			// p_Color
			// 
			this.p_Color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.p_Color.BackColor = System.Drawing.Color.White;
			this.p_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.p_Color.Location = new System.Drawing.Point(191, 196);
			this.p_Color.Name = "p_Color";
			this.p_Color.Size = new System.Drawing.Size(40, 40);
			this.p_Color.TabIndex = 6;
			this.p_Color.Click += new System.EventHandler(this.p_Color_Click);
			// 
			// btn_OK
			// 
			this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_OK.Location = new System.Drawing.Point(238, 193);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(75, 23);
			this.btn_OK.TabIndex = 7;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(238, 217);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 8;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// f_TCP
			// 
			this.AcceptButton = this.btn_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(313, 240);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.p_Color);
			this.Controls.Add(this.num_Tolerance);
			this.Controls.Add(this.lbl_Color);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pb_Pic);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f_TCP";
			this.Text = "Transparent Color Picker";
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Tolerance)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_Pic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbl_Color;
		private System.Windows.Forms.NumericUpDown num_Tolerance;
		private System.Windows.Forms.Panel p_Color;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Button btn_Cancel;
	}
}
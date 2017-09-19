namespace WolfPaw_ScreenSnip
{
	partial class f_SettingPanel
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
			this.label1 = new System.Windows.Forms.Label();
			this.r_BgTransparent = new System.Windows.Forms.RadioButton();
			this.r_BgColor = new System.Windows.Forms.RadioButton();
			this.p_BgColor = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_Border = new System.Windows.Forms.CheckBox();
			this.num_Border = new System.Windows.Forms.NumericUpDown();
			this.p_Border = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_Pen = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cb_Transparent = new System.Windows.Forms.CheckBox();
			this.num_Transparency = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.num_Border)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Transparency)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Background:";
			// 
			// r_BgTransparent
			// 
			this.r_BgTransparent.AutoSize = true;
			this.r_BgTransparent.Checked = true;
			this.r_BgTransparent.Location = new System.Drawing.Point(86, 7);
			this.r_BgTransparent.Name = "r_BgTransparent";
			this.r_BgTransparent.Size = new System.Drawing.Size(82, 17);
			this.r_BgTransparent.TabIndex = 1;
			this.r_BgTransparent.TabStop = true;
			this.r_BgTransparent.Text = "Transparent";
			this.r_BgTransparent.UseVisualStyleBackColor = true;
			this.r_BgTransparent.CheckedChanged += new System.EventHandler(this.r_BgTransparent_CheckedChanged);
			// 
			// r_BgColor
			// 
			this.r_BgColor.AutoSize = true;
			this.r_BgColor.Location = new System.Drawing.Point(86, 30);
			this.r_BgColor.Name = "r_BgColor";
			this.r_BgColor.Size = new System.Drawing.Size(49, 17);
			this.r_BgColor.TabIndex = 2;
			this.r_BgColor.Text = "Color";
			this.r_BgColor.UseVisualStyleBackColor = true;
			// 
			// p_BgColor
			// 
			this.p_BgColor.BackColor = System.Drawing.Color.White;
			this.p_BgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_BgColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.p_BgColor.Location = new System.Drawing.Point(137, 28);
			this.p_BgColor.Name = "p_BgColor";
			this.p_BgColor.Size = new System.Drawing.Size(20, 20);
			this.p_BgColor.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Border: ";
			// 
			// cb_Border
			// 
			this.cb_Border.AutoSize = true;
			this.cb_Border.Location = new System.Drawing.Point(62, 64);
			this.cb_Border.Name = "cb_Border";
			this.cb_Border.Size = new System.Drawing.Size(15, 14);
			this.cb_Border.TabIndex = 5;
			this.cb_Border.UseVisualStyleBackColor = true;
			this.cb_Border.CheckedChanged += new System.EventHandler(this.cb_Border_CheckedChanged);
			// 
			// num_Border
			// 
			this.num_Border.Location = new System.Drawing.Point(86, 61);
			this.num_Border.Name = "num_Border";
			this.num_Border.Size = new System.Drawing.Size(45, 20);
			this.num_Border.TabIndex = 6;
			this.num_Border.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// p_Border
			// 
			this.p_Border.BackColor = System.Drawing.Color.Black;
			this.p_Border.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Border.Cursor = System.Windows.Forms.Cursors.Hand;
			this.p_Border.Location = new System.Drawing.Point(137, 61);
			this.p_Border.Name = "p_Border";
			this.p_Border.Size = new System.Drawing.Size(20, 20);
			this.p_Border.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Tool: ";
			// 
			// btn_Pen
			// 
			this.btn_Pen.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btn_Pen.FlatAppearance.BorderSize = 3;
			this.btn_Pen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Pen.Location = new System.Drawing.Point(60, 101);
			this.btn_Pen.Name = "btn_Pen";
			this.btn_Pen.Size = new System.Drawing.Size(20, 20);
			this.btn_Pen.TabIndex = 8;
			this.btn_Pen.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.button1.FlatAppearance.BorderSize = 3;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(86, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 20);
			this.button1.TabIndex = 9;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.button2.FlatAppearance.BorderSize = 3;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(112, 101);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(20, 20);
			this.button2.TabIndex = 10;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.button3.FlatAppearance.BorderSize = 3;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Location = new System.Drawing.Point(60, 127);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(20, 20);
			this.button3.TabIndex = 11;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.button4.FlatAppearance.BorderSize = 3;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Location = new System.Drawing.Point(86, 127);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(20, 20);
			this.button4.TabIndex = 12;
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.button5.FlatAppearance.BorderSize = 3;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button5.Location = new System.Drawing.Point(112, 127);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(20, 20);
			this.button5.TabIndex = 13;
			this.button5.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(59, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Color: ";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panel1.Location = new System.Drawing.Point(102, 155);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(20, 20);
			this.panel1.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(59, 183);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Size: ";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(102, 179);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(45, 20);
			this.numericUpDown1.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 222);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Font: ";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(60, 217);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(53, 23);
			this.button6.TabIndex = 18;
			this.button6.Text = "Change";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 302);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Transparent: ";
			// 
			// cb_Transparent
			// 
			this.cb_Transparent.AutoSize = true;
			this.cb_Transparent.Location = new System.Drawing.Point(77, 302);
			this.cb_Transparent.Name = "cb_Transparent";
			this.cb_Transparent.Size = new System.Drawing.Size(15, 14);
			this.cb_Transparent.TabIndex = 20;
			this.cb_Transparent.UseVisualStyleBackColor = true;
			this.cb_Transparent.CheckedChanged += new System.EventHandler(this.cb_Transparent_CheckedChanged);
			// 
			// num_Transparency
			// 
			this.num_Transparency.Location = new System.Drawing.Point(102, 300);
			this.num_Transparency.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.num_Transparency.Name = "num_Transparency";
			this.num_Transparency.Size = new System.Drawing.Size(45, 20);
			this.num_Transparency.TabIndex = 21;
			this.num_Transparency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(153, 302);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(15, 13);
			this.label8.TabIndex = 22;
			this.label8.Text = "%";
			// 
			// f_SettingPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(173, 324);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.num_Transparency);
			this.Controls.Add(this.cb_Transparent);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_Pen);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.p_Border);
			this.Controls.Add(this.num_Border);
			this.Controls.Add(this.cb_Border);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.p_BgColor);
			this.Controls.Add(this.r_BgColor);
			this.Controls.Add(this.r_BgTransparent);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_SettingPanel";
			this.Opacity = 0.9D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Settings";
			this.MouseEnter += new System.EventHandler(this.f_SettingPanel_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.f_SettingPanel_MouseLeave);
			((System.ComponentModel.ISupportInitialize)(this.num_Border)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_Transparency)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton r_BgTransparent;
		private System.Windows.Forms.RadioButton r_BgColor;
		private System.Windows.Forms.Panel p_BgColor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cb_Border;
		private System.Windows.Forms.NumericUpDown num_Border;
		private System.Windows.Forms.Panel p_Border;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_Pen;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox cb_Transparent;
		private System.Windows.Forms.NumericUpDown num_Transparency;
		private System.Windows.Forms.Label label8;
	}
}
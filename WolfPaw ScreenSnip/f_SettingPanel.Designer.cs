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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_SettingPanel));
			this.label1 = new System.Windows.Forms.Label();
			this.r_BgTransparent = new System.Windows.Forms.RadioButton();
			this.r_BgColor = new System.Windows.Forms.RadioButton();
			this.p_BgColor = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_Border = new System.Windows.Forms.CheckBox();
			this.num_Border = new System.Windows.Forms.NumericUpDown();
			this.p_Border = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.btn_Font = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cb_Follow = new System.Windows.Forms.CheckBox();
			this.lbl_Demo = new System.Windows.Forms.Label();
			this.btn_Pen = new FontAwesome.Sharp.IconButton();
			this.btn_Marker = new FontAwesome.Sharp.IconButton();
			this.btn_Line = new FontAwesome.Sharp.IconButton();
			this.btn_Square = new FontAwesome.Sharp.IconButton();
			this.btn_Oval = new FontAwesome.Sharp.IconButton();
			this.btn_Text = new FontAwesome.Sharp.IconButton();
			this.btn_Eraser = new FontAwesome.Sharp.IconButton();
			this.btn_Dock = new FontAwesome.Sharp.IconButton();
			((System.ComponentModel.ISupportInitialize)(this.num_Border)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
			this.p_BgColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.p_BgColor.Location = new System.Drawing.Point(137, 28);
			this.p_BgColor.Name = "p_BgColor";
			this.p_BgColor.Size = new System.Drawing.Size(20, 20);
			this.p_BgColor.TabIndex = 3;
			this.p_BgColor.Tag = "0";
			this.p_BgColor.Click += new System.EventHandler(this.p_BgColor_Click);
			this.p_BgColor.MouseEnter += new System.EventHandler(this.p_BgColor_MouseEnter);
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
			this.num_Border.ValueChanged += new System.EventHandler(this.num_Border_ValueChanged);
			// 
			// p_Border
			// 
			this.p_Border.BackColor = System.Drawing.Color.Black;
			this.p_Border.Cursor = System.Windows.Forms.Cursors.Hand;
			this.p_Border.Location = new System.Drawing.Point(137, 61);
			this.p_Border.Name = "p_Border";
			this.p_Border.Size = new System.Drawing.Size(20, 20);
			this.p_Border.TabIndex = 4;
			this.p_Border.Tag = "0";
			this.p_Border.Click += new System.EventHandler(this.p_Border_Click);
			this.p_Border.MouseEnter += new System.EventHandler(this.p_Border_MouseEnter);
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
			// btn_Font
			// 
			this.btn_Font.Location = new System.Drawing.Point(60, 217);
			this.btn_Font.Name = "btn_Font";
			this.btn_Font.Size = new System.Drawing.Size(53, 23);
			this.btn_Font.TabIndex = 18;
			this.btn_Font.Text = "Change";
			this.btn_Font.UseVisualStyleBackColor = true;
			this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(1, 308);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Follow Parent: ";
			// 
			// cb_Follow
			// 
			this.cb_Follow.AutoSize = true;
			this.cb_Follow.Checked = true;
			this.cb_Follow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_Follow.Location = new System.Drawing.Point(77, 307);
			this.cb_Follow.Name = "cb_Follow";
			this.cb_Follow.Size = new System.Drawing.Size(15, 14);
			this.cb_Follow.TabIndex = 20;
			this.cb_Follow.UseVisualStyleBackColor = true;
			// 
			// lbl_Demo
			// 
			this.lbl_Demo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lbl_Demo.AutoSize = true;
			this.lbl_Demo.Location = new System.Drawing.Point(45, 260);
			this.lbl_Demo.Name = "lbl_Demo";
			this.lbl_Demo.Size = new System.Drawing.Size(81, 13);
			this.lbl_Demo.TabIndex = 22;
			this.lbl_Demo.Text = "DEMO AaBbCc";
			this.lbl_Demo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_Pen
			// 
			this.btn_Pen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Pen.Icon = FontAwesome.Sharp.IconChar.Pencil;
			this.btn_Pen.IconColor = System.Drawing.Color.Black;
			this.btn_Pen.IconSize = 20;
			this.btn_Pen.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pen.Image")));
			this.btn_Pen.Location = new System.Drawing.Point(60, 101);
			this.btn_Pen.Name = "btn_Pen";
			this.btn_Pen.Size = new System.Drawing.Size(20, 20);
			this.btn_Pen.TabIndex = 24;
			this.btn_Pen.UseVisualStyleBackColor = true;
			// 
			// btn_Marker
			// 
			this.btn_Marker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Marker.Icon = FontAwesome.Sharp.IconChar.PencilSquare;
			this.btn_Marker.IconColor = System.Drawing.Color.Black;
			this.btn_Marker.IconSize = 22;
			this.btn_Marker.Image = ((System.Drawing.Image)(resources.GetObject("btn_Marker.Image")));
			this.btn_Marker.Location = new System.Drawing.Point(86, 101);
			this.btn_Marker.Name = "btn_Marker";
			this.btn_Marker.Size = new System.Drawing.Size(20, 20);
			this.btn_Marker.TabIndex = 25;
			this.btn_Marker.UseVisualStyleBackColor = true;
			// 
			// btn_Line
			// 
			this.btn_Line.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Line.Icon = FontAwesome.Sharp.IconChar.Minus;
			this.btn_Line.IconColor = System.Drawing.Color.Black;
			this.btn_Line.IconSize = 20;
			this.btn_Line.Image = ((System.Drawing.Image)(resources.GetObject("btn_Line.Image")));
			this.btn_Line.Location = new System.Drawing.Point(111, 101);
			this.btn_Line.Name = "btn_Line";
			this.btn_Line.Size = new System.Drawing.Size(20, 20);
			this.btn_Line.TabIndex = 25;
			this.btn_Line.UseVisualStyleBackColor = true;
			// 
			// btn_Square
			// 
			this.btn_Square.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Square.Icon = FontAwesome.Sharp.IconChar.SquareO;
			this.btn_Square.IconColor = System.Drawing.Color.Black;
			this.btn_Square.IconSize = 20;
			this.btn_Square.Image = ((System.Drawing.Image)(resources.GetObject("btn_Square.Image")));
			this.btn_Square.Location = new System.Drawing.Point(60, 127);
			this.btn_Square.Name = "btn_Square";
			this.btn_Square.Size = new System.Drawing.Size(20, 20);
			this.btn_Square.TabIndex = 24;
			this.btn_Square.UseVisualStyleBackColor = true;
			// 
			// btn_Oval
			// 
			this.btn_Oval.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Oval.Icon = FontAwesome.Sharp.IconChar.CircleO;
			this.btn_Oval.IconColor = System.Drawing.Color.Black;
			this.btn_Oval.IconSize = 20;
			this.btn_Oval.Image = ((System.Drawing.Image)(resources.GetObject("btn_Oval.Image")));
			this.btn_Oval.Location = new System.Drawing.Point(86, 127);
			this.btn_Oval.Name = "btn_Oval";
			this.btn_Oval.Size = new System.Drawing.Size(20, 20);
			this.btn_Oval.TabIndex = 24;
			this.btn_Oval.UseVisualStyleBackColor = true;
			// 
			// btn_Text
			// 
			this.btn_Text.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Text.Icon = FontAwesome.Sharp.IconChar.Font;
			this.btn_Text.IconColor = System.Drawing.Color.Black;
			this.btn_Text.IconSize = 20;
			this.btn_Text.Image = ((System.Drawing.Image)(resources.GetObject("btn_Text.Image")));
			this.btn_Text.Location = new System.Drawing.Point(111, 127);
			this.btn_Text.Name = "btn_Text";
			this.btn_Text.Size = new System.Drawing.Size(20, 20);
			this.btn_Text.TabIndex = 24;
			this.btn_Text.UseVisualStyleBackColor = true;
			// 
			// btn_Eraser
			// 
			this.btn_Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Eraser.Icon = FontAwesome.Sharp.IconChar.Eraser;
			this.btn_Eraser.IconColor = System.Drawing.Color.Black;
			this.btn_Eraser.IconSize = 20;
			this.btn_Eraser.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eraser.Image")));
			this.btn_Eraser.Location = new System.Drawing.Point(137, 101);
			this.btn_Eraser.Name = "btn_Eraser";
			this.btn_Eraser.Size = new System.Drawing.Size(20, 46);
			this.btn_Eraser.TabIndex = 25;
			this.btn_Eraser.UseVisualStyleBackColor = true;
			// 
			// btn_Dock
			// 
			this.btn_Dock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Dock.Icon = FontAwesome.Sharp.IconChar.ArrowsAlt;
			this.btn_Dock.IconColor = System.Drawing.Color.Black;
			this.btn_Dock.IconSize = 32;
			this.btn_Dock.Image = ((System.Drawing.Image)(resources.GetObject("btn_Dock.Image")));
			this.btn_Dock.Location = new System.Drawing.Point(135, 293);
			this.btn_Dock.Name = "btn_Dock";
			this.btn_Dock.Size = new System.Drawing.Size(32, 32);
			this.btn_Dock.TabIndex = 26;
			this.btn_Dock.UseVisualStyleBackColor = true;
			this.btn_Dock.Click += new System.EventHandler(this.btn_Dock_Click);
			// 
			// f_SettingPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(166, 324);
			this.Controls.Add(this.btn_Dock);
			this.Controls.Add(this.btn_Eraser);
			this.Controls.Add(this.btn_Line);
			this.Controls.Add(this.btn_Marker);
			this.Controls.Add(this.btn_Text);
			this.Controls.Add(this.btn_Oval);
			this.Controls.Add(this.btn_Square);
			this.Controls.Add(this.btn_Pen);
			this.Controls.Add(this.lbl_Demo);
			this.Controls.Add(this.cb_Follow);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btn_Font);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
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
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f_SettingPanel";
			this.Opacity = 0.9D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tools";
			this.TopMost = true;
			this.LocationChanged += new System.EventHandler(this.f_SettingPanel_LocationChanged);
			this.SizeChanged += new System.EventHandler(this.f_SettingPanel_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_SettingPanel_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.num_Border)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btn_Font;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox cb_Follow;
		private System.Windows.Forms.Label lbl_Demo;
		private FontAwesome.Sharp.IconButton btn_Pen;
		private FontAwesome.Sharp.IconButton btn_Marker;
		private FontAwesome.Sharp.IconButton btn_Line;
		private FontAwesome.Sharp.IconButton btn_Square;
		private FontAwesome.Sharp.IconButton btn_Oval;
		private FontAwesome.Sharp.IconButton btn_Text;
		private FontAwesome.Sharp.IconButton btn_Eraser;
		private FontAwesome.Sharp.IconButton btn_Dock;
	}
}
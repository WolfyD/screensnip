namespace WolfPaw_ScreenSnip
{
	partial class f_Preview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Preview));
			this.ss_Status = new System.Windows.Forms.StatusStrip();
			this.ts_Tools = new System.Windows.Forms.ToolStrip();
			this.pb_Pic = new System.Windows.Forms.PictureBox();
			this.btn_ED_Background = new System.Windows.Forms.ToolStripButton();
			this.btn_ED_Border = new System.Windows.Forms.ToolStripButton();
			this.btn_ED_TransparencyRender = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ss_Status.SuspendLayout();
			this.ts_Tools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).BeginInit();
			this.SuspendLayout();
			// 
			// ss_Status
			// 
			this.ss_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.ss_Status.Location = new System.Drawing.Point(0, 612);
			this.ss_Status.Name = "ss_Status";
			this.ss_Status.Size = new System.Drawing.Size(872, 22);
			this.ss_Status.TabIndex = 0;
			this.ss_Status.Text = "statusStrip1";
			// 
			// ts_Tools
			// 
			this.ts_Tools.BackColor = System.Drawing.Color.Transparent;
			this.ts_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btn_ED_Background,
            this.toolStripSeparator1,
            this.btn_ED_Border,
            this.toolStripSeparator2,
            this.btn_ED_TransparencyRender});
			this.ts_Tools.Location = new System.Drawing.Point(0, 0);
			this.ts_Tools.Name = "ts_Tools";
			this.ts_Tools.Size = new System.Drawing.Size(872, 25);
			this.ts_Tools.TabIndex = 1;
			this.ts_Tools.Text = "toolStrip1";
			// 
			// pb_Pic
			// 
			this.pb_Pic.BackColor = System.Drawing.Color.Black;
			this.pb_Pic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb_Pic.Location = new System.Drawing.Point(0, 25);
			this.pb_Pic.Name = "pb_Pic";
			this.pb_Pic.Size = new System.Drawing.Size(872, 587);
			this.pb_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_Pic.TabIndex = 2;
			this.pb_Pic.TabStop = false;
			// 
			// btn_ED_Background
			// 
			this.btn_ED_Background.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_ED_Background.Image = ((System.Drawing.Image)(resources.GetObject("btn_ED_Background.Image")));
			this.btn_ED_Background.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_ED_Background.Name = "btn_ED_Background";
			this.btn_ED_Background.Size = new System.Drawing.Size(107, 22);
			this.btn_ED_Background.Text = "Background Color";
			this.btn_ED_Background.Click += new System.EventHandler(this.btn_ED_Background_Click);
			// 
			// btn_ED_Border
			// 
			this.btn_ED_Border.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_ED_Border.Image = ((System.Drawing.Image)(resources.GetObject("btn_ED_Border.Image")));
			this.btn_ED_Border.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_ED_Border.Name = "btn_ED_Border";
			this.btn_ED_Border.Size = new System.Drawing.Size(46, 22);
			this.btn_ED_Border.Text = "Border";
			this.btn_ED_Border.Click += new System.EventHandler(this.btn_ED_Border_Click);
			// 
			// btn_ED_TransparencyRender
			// 
			this.btn_ED_TransparencyRender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_ED_TransparencyRender.Image = ((System.Drawing.Image)(resources.GetObject("btn_ED_TransparencyRender.Image")));
			this.btn_ED_TransparencyRender.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_ED_TransparencyRender.Name = "btn_ED_TransparencyRender";
			this.btn_ED_TransparencyRender.Size = new System.Drawing.Size(122, 22);
			this.btn_ED_TransparencyRender.Text = "Transparency Render";
			this.btn_ED_TransparencyRender.Click += new System.EventHandler(this.btn_ED_TransparencyRender_Click);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(88, 22);
			this.toolStripLabel1.Text = "Enable/Disable:";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
			this.toolStripStatusLabel1.Text = "Image Statistics:";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 17);
			this.toolStripStatusLabel2.Text = "|LBL|";
			// 
			// f_Preview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(872, 634);
			this.Controls.Add(this.pb_Pic);
			this.Controls.Add(this.ts_Tools);
			this.Controls.Add(this.ss_Status);
			this.Name = "f_Preview";
			this.Text = "Snip preview Window";
			this.ss_Status.ResumeLayout(false);
			this.ss_Status.PerformLayout();
			this.ts_Tools.ResumeLayout(false);
			this.ts_Tools.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_Pic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip ss_Status;
		private System.Windows.Forms.ToolStrip ts_Tools;
		private System.Windows.Forms.PictureBox pb_Pic;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton btn_ED_Background;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btn_ED_Border;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btn_ED_TransparencyRender;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
	}
}
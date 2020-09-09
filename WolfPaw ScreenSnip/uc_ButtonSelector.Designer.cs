namespace WolfPaw_ScreenSnip
{
	partial class uc_ButtonSelector
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
            this.components = new System.ComponentModel.Container();
            this.btn_DropDown = new FontAwesome.Sharp.IconButton();
            this.btn_Button = new System.Windows.Forms.Button();
            this.cms_Buttons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // btn_DropDown
            // 
            this.btn_DropDown.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_DropDown.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            this.btn_DropDown.IconColor = System.Drawing.Color.Black;
            this.btn_DropDown.IconSize = 16;
            this.btn_DropDown.Location = new System.Drawing.Point(48, 0);
            this.btn_DropDown.Name = "btn_DropDown";
            this.btn_DropDown.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btn_DropDown.Rotation = 0D;
            this.btn_DropDown.Size = new System.Drawing.Size(16, 50);
            this.btn_DropDown.TabIndex = 1;
            this.btn_DropDown.UseVisualStyleBackColor = true;
            this.btn_DropDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_DropDown_MouseDown);
            this.btn_DropDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_DropDown_MouseUp);
            // 
            // btn_Button
            // 
            this.btn_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Button.Location = new System.Drawing.Point(0, 0);
            this.btn_Button.Name = "btn_Button";
            this.btn_Button.Size = new System.Drawing.Size(50, 50);
            this.btn_Button.TabIndex = 2;
            this.btn_Button.UseVisualStyleBackColor = true;
            this.btn_Button.Click += new System.EventHandler(this.btn_Button_Click);
            // 
            // cms_Buttons
            // 
            this.cms_Buttons.AutoSize = false;
            this.cms_Buttons.Name = "cms_Buttons";
            this.cms_Buttons.ShowImageMargin = false;
            this.cms_Buttons.Size = new System.Drawing.Size(153, 26);
            // 
            // uc_ButtonSelector
            // 
            this.Controls.Add(this.btn_Button);
            this.Controls.Add(this.btn_DropDown);
            this.Name = "uc_ButtonSelector";
            this.Size = new System.Drawing.Size(65, 50);
            this.ResumeLayout(false);

		}

		#endregion
		private FontAwesome.Sharp.IconButton btn_DropDown;
		private System.Windows.Forms.Button btn_Button;
		private System.Windows.Forms.ContextMenuStrip cms_Buttons;
	}
}

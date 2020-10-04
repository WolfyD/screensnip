namespace SharpSnip
{
    partial class f_DPISetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_DPISetup));
            this.p_MeasureBox = new System.Windows.Forms.Panel();
            this.p_ResizePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_AddItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // p_MeasureBox
            // 
            this.p_MeasureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.p_MeasureBox.Location = new System.Drawing.Point(52, 95);
            this.p_MeasureBox.Name = "p_MeasureBox";
            this.p_MeasureBox.Size = new System.Drawing.Size(250, 341);
            this.p_MeasureBox.TabIndex = 0;
            this.p_MeasureBox.LocationChanged += new System.EventHandler(this.p_MeasureBox_LocationChanged);
            this.p_MeasureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_MeasureBox_MouseDown);
            this.p_MeasureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.p_MeasureBox_MouseMove);
            this.p_MeasureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.p_MeasureBox_MouseUp);
            // 
            // p_ResizePanel
            // 
            this.p_ResizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_ResizePanel.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.p_ResizePanel.Location = new System.Drawing.Point(296, 91);
            this.p_ResizePanel.Name = "p_ResizePanel";
            this.p_ResizePanel.Size = new System.Drawing.Size(10, 10);
            this.p_ResizePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set DPI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(513, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(667, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Measured Item:";
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Location = new System.Drawing.Point(666, 28);
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(123, 22);
            this.btn_AddItem.TabIndex = 6;
            this.btn_AddItem.Text = "Add Item";
            this.btn_AddItem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Item Description: ";
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.Location = new System.Drawing.Point(584, 109);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(204, 147);
            this.lbl_Desc.TabIndex = 7;
            this.lbl_Desc.Text = "Item Description: ";
            this.lbl_Desc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(725, 427);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // f_DPISetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_Desc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_AddItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_ResizePanel);
            this.Controls.Add(this.p_MeasureBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "f_DPISetup";
            this.Text = "DPI value setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_MeasureBox;
        private System.Windows.Forms.Panel p_ResizePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_AddItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Button btn_Close;
    }
}
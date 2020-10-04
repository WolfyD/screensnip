namespace SharpSnip
{
    partial class uc_ValueButton
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
            this.num_Val = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.btn_Set = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // num_Val
            // 
            this.num_Val.Location = new System.Drawing.Point(43, 8);
            this.num_Val.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_Val.Name = "num_Val";
            this.num_Val.Size = new System.Drawing.Size(54, 20);
            this.num_Val.TabIndex = 1;
            this.num_Val.ValueChanged += new System.EventHandler(this.num_Val_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "s";
            this.label1.Click += new System.EventHandler(this.pb_Image_Click);
            // 
            // pb_Image
            // 
            this.pb_Image.Location = new System.Drawing.Point(0, 1);
            this.pb_Image.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(36, 36);
            this.pb_Image.TabIndex = 0;
            this.pb_Image.TabStop = false;
            this.pb_Image.Click += new System.EventHandler(this.pb_Image_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Set.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Set.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Set.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Set.Location = new System.Drawing.Point(42, 24);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(55, 15);
            this.btn_Set.TabIndex = 3;
            this.btn_Set.Text = "SET";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Visible = false;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // uc_ValueButton
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_Val);
            this.Controls.Add(this.pb_Image);
            this.MinimumSize = new System.Drawing.Size(40, 40);
            this.Name = "uc_ValueButton";
            this.Size = new System.Drawing.Size(42, 42);
            this.Click += new System.EventHandler(this.pb_Image_Click);
            ((System.ComponentModel.ISupportInitialize)(this.num_Val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Image;
        private System.Windows.Forms.NumericUpDown num_Val;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Set;
    }
}

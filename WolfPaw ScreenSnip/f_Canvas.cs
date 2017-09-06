﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class f_Canvas : Form
	{
		public Size bounds { get; set; }
		public Bitmap bmp { get; set; }
		public Bitmap retImg { get; set; }

		private Rectangle cut = new Rectangle(0,0,-1,-1);
		private bool cutting = false;
		
		public f_Canvas()
		{
			InitializeComponent();

			Load += F_Canvas_Load;
		}
		
		private void F_Canvas_Load(object sender, EventArgs e)
		{
			Location = new Point(0, 0);
			Size = bounds;

			BackgroundImage = bmp;
		}

		public static Image Snip()
		{
			var rc = Screen.PrimaryScreen.Bounds;
			using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
			{
				using (Graphics gr = Graphics.FromImage(bmp))
					gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
				using (var snipper = new f_Canvas() { bounds = new Size(100, 100), bmp = new Bitmap(1,1)  })
				{
					if (snipper.ShowDialog() == DialogResult.OK)
					{
						return snipper.Image;
					}
				}
				return null;
			}
		}

		public Image Image { get; set; }

		private Rectangle rcSelect = new Rectangle();
		private Point pntStart;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			// Start the snip on mouse down
			if (e.Button != MouseButtons.Left) return;
			pntStart = e.Location;
			rcSelect = new Rectangle(e.Location, new Size(0, 0));
			this.Invalidate();
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			// Modify the selection on mouse move
			if (e.Button != MouseButtons.Left) return;
			int x1 = Math.Min(e.X, pntStart.X);
			int y1 = Math.Min(e.Y, pntStart.Y);
			int x2 = Math.Max(e.X, pntStart.X);
			int y2 = Math.Max(e.Y, pntStart.Y);
			rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			// Complete the snip on mouse-up
			if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
			retImg = new Bitmap(rcSelect.Width, rcSelect.Height);
			using (Graphics gr = Graphics.FromImage(retImg))
			{
				gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, retImg.Width, retImg.Height),
					rcSelect, GraphicsUnit.Pixel);
			}


			DialogResult = DialogResult.OK;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the current selection
			using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
			{
				int x1 = rcSelect.X; int x2 = rcSelect.X + rcSelect.Width;
				int y1 = rcSelect.Y; int y2 = rcSelect.Y + rcSelect.Height;
				e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, this.Height));
				e.Graphics.FillRectangle(br, new Rectangle(x2, 0, this.Width - x2, this.Height));
				e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
				e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
			}
			using (Pen pen = new Pen(Color.Blue, 2))
			{
				e.Graphics.DrawRectangle(pen, rcSelect);
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Allow canceling the snip with the Escape key
			if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
			return base.ProcessCmdKey(ref msg, keyData);
		}


	}
}

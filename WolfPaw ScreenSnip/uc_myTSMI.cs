using System.Drawing;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
    public partial class uc_myTSMI : ToolStripMenuItem
	{
		public string myText = "";
		public string mySubTitle = "";

		public uc_myTSMI()
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawImage(this.Image, new PointF(Width / 2 - this.Image.Width / 2 - 4, 0));
			//e.Graphics.DrawRectangle(Pens.Red, new Rectangle(0, 0, 40, 40));,
			Bitmap bmp = new Bitmap(Width, Image.Height);
			if (mySubTitle != "")
			{
				Font f = this.Font;
				int fSize = 20;
				Size size = new Size(Width + 1, 10);

				while (size.Width > Width)
				{
					fSize--;
					f = new Font("Consolas", fSize, FontStyle.Bold);
					size = TextRenderer.MeasureText(mySubTitle, f);
				}
				e.Graphics.DrawString(mySubTitle, f, Brushes.Gray, new Point(Width / 2, Image.Height - (size.Height - 2)), new StringFormat() { Alignment = StringAlignment.Center });
			}
		}
	}
}

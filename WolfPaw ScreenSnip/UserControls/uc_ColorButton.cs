using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace SharpSnip
{
    public partial class uc_ColorButton : Panel
    {
        private Color color = Color.White;
        private Color textColor = Color.Black;
        public override Color BackColor { get { return color; } set { color = value; Invalidate(); } }
        private readonly string[] hexChars = { "A", "B", "C", "D", "E", "F" };
        private readonly StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center};
        private readonly int vPadding = 2;
        private readonly int hPadding = 12;

        public uc_ColorButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var g = e.Graphics)
            {
                g.Clear(color);
                g.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 0), new Size(Width - 3, Height - 3)));

                Rectangle rec = new Rectangle(new Point(hPadding, vPadding), new Size(Width - (hPadding * 2), Height - (vPadding * 2)));

                Font f = GetFittingFont(rec.Size);

                GetInvertedColor();
                string hex = GetHex();
                g.DrawString(hex, f, new SolidBrush(textColor), new Point(Width / 2, Height / 2 - ((int)(GetStringSize(f,hex).Height / 1.5))), sf);
            }
        }

        private void GetInvertedColor()
        {
            //int r = GetClashing(color.R);
            //int g = GetClashing(color.G);
            //int b = GetClashing(color.B);



            //inverseColor = Color.FromArgb(255, r, g, b);
            textColor = Normalize(color.R, color.G, color.B);
        }

        private String GetHex()
        {
            StringBuilder ret = new StringBuilder("#");

            ret.Append(GetHexFromInt(color.R));
            ret.Append(GetHexFromInt(color.G));
            ret.Append(GetHexFromInt(color.B));
            
            return ret.ToString();
        }

        private string GetHexFromInt(int input)
        {
            if(input == 0) { return "00"; }

            string ret = "";

            int q = input;

            while(q != 0)
            {
                ret += DoDiv(q, out q);
            } 

            return ret.PadLeft(2, '0');
        }

        private string DoDiv(int input, out int output)
        {
            int hret = input % 16;
            output = input / 16;
            string ret = hret < 10 ? hret.ToString() : hexChars[hret - 10];

            return ret;
        }

        //Not ideal...
        private int GetNegative(int input)
        {
            return (input - 255) * -1;
        }

        //Doesn't really work...
        private int GetClashing(int input)
        {
            return (input - 63) * (input > 63 ? 1 : -1) % 255;
        }

        //Eh... kinda works... good enough for now
        private Color Normalize(int r, int g, int b)
        {
            r = ((r * 2) + 100) / 2 % 255;
            g = ((g * 2) + 140) / 2 % 255;
            b = ((b * 2) + 180) / 2 % 255;

            return Color.FromArgb(255, r, g, b);
        }

        private Font GetFittingFont(Size size)
        {

            float fSize = 6;
            Font f = null;

            if (size != Size.Empty)
            {
                do
                {
                    fSize += 0.2f;
                    f = new Font(this.Font.FontFamily, fSize, FontStyle.Regular);
                }
                while (!IsRectOverflowing(GetStringSize(f, "#000000"), size));
                f = new Font(this.Font.FontFamily, fSize, FontStyle.Regular);
            }

            return f;
        }

        private Size GetStringSize(Font f, String s)
        {
            return TextRenderer.MeasureText(s, f);
        }

        private bool IsRectOverflowing(Size TextSize, Size BoxSize)
        {
            return (TextSize.Width > BoxSize.Width || TextSize.Height > BoxSize.Height);
        }
    }
}

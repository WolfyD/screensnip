using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSnip
{
    public partial class f_DPISetup : Form
    {
        int mx = 0;
        int my = 0;
        bool mdown = false;

        List<MeasuredItem> Items = new List<MeasuredItem>();

        public f_DPISetup()
        {
            InitializeComponent();

            Load += F_DPISetup_Load;
        }

        private void F_DPISetup_Load(object sender, EventArgs e)
        {
            Items.Add(new MeasuredItem("Credit Card", 86, 54, MeasurementUnit.millimeter));
            Items.Add(new MeasuredItem("A6 sheet of paper", 105, 148, MeasurementUnit.millimeter));
            Items.Add(new MeasuredItem("A5 sheet of paper", 148, 210, MeasurementUnit.millimeter));
            Items.Add(new MeasuredItem("TF card", 15, 11, MeasurementUnit.millimeter));
            Items.Add(new MeasuredItem("SD card", 1.25f, 0.95f, MeasurementUnit.Inch));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using(Graphics g = Graphics.FromHwnd(p_MeasureBox.Handle))
            {
                //p_MeasureBox.Invalidate();
                int w = p_MeasureBox.Width;
                int h = p_MeasureBox.Height;
                g.DrawCurve(Pens.Black, new PointF[] { new PointF(1, 30), new PointF(4,4), new PointF(30, 1) });
                g.DrawCurve(Pens.Black, new PointF[] { new PointF(w - 1, 30), new PointF(w - 4, 4), new PointF(w - 30, 1) });
                g.DrawCurve(Pens.Black, new PointF[] { new PointF(1, h - 30), new PointF(4, h - 4), new PointF(30, h - 1) });
                g.DrawCurve(Pens.Black, new PointF[] { new PointF(w - 1, h - 30), new PointF(w - 4, h -4 ), new PointF(w - 30, h - 1) });
                g.DrawLine(Pens.Black, new Point(30, 1), new Point(w - 30, 1));
                g.DrawLine(Pens.Black, new Point(1, 30), new Point(1, h - 30));
                g.DrawLine(Pens.Black, new Point(30, h - 1), new Point(w - 30, h - 1));
                g.DrawLine(Pens.Black, new Point(w - 1, 30), new Point(w - 1, h - 30));
                //g.DrawRectangle(Pens.Black, new Rectangle(0, 0, p_MeasureBox.Width - 1, p_MeasureBox.Height - 1));
            }
        }

        private void p_MeasureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;
            mdown = true;
        }

        private void p_MeasureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }

        private void p_MeasureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(mdown)
                p_MeasureBox.Location = new Point(p_MeasureBox.Left + e.X - mx, p_MeasureBox.Top + e.Y - my);
        }

        private void p_MeasureBox_LocationChanged(object sender, EventArgs e)
        {
            p_ResizePanel.Location = new Point(p_MeasureBox.Right - 5, p_MeasureBox.Top - 5);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class MeasuredItem
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public MeasurementUnit Unit { get; set; }
        public String Name { get; set; }
        public float Ratio { get; private set; }

        public MeasuredItem(string name, float width, float height, MeasurementUnit unit)
        {
            Name = name;
            Unit = unit;
            Width = width;
            Height = height;
            CalculateRatio();
        }

        private void CalculateRatio()
        {
            Ratio = Width / Height;
        }
    }

    public enum MeasurementUnit
    {
        Centimeter,
        millimeter,
        Inch,
        Eighth_Inch,
        Thousandth_Inch,
    }
}

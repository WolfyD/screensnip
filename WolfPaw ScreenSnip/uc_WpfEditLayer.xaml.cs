using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WolfPaw_ScreenSnip
{
	/// <summary>
	/// Interaction logic for uc_WpfEditLayer.xaml
	/// </summary>
	public partial class uc_WpfEditLayer : UserControl
	{
		public bool mdown = false;
		public f_Screen parent { get; set; }
		public System.Windows.Point curpos = new System.Windows.Point(-1, -1);
		public System.Drawing.Point mpos = new System.Drawing.Point(-1, -1);
		Bitmap bmp = null;
		Bitmap old = null;
		private int Tool;
		public int toolSize = 1;
		public int tool
		{
			get { return Tool; }
			set { Tool = value; setTool(Tool); }
		}

		public f_Screen screen_parent { get; set; }

		public List<c_DrawnPoints> points = new List<c_DrawnPoints>();

        Line lineGuide = null;
        List<Line> drawPoints = new List<Line>();

		//System.Drawing.Point currloc = new System.Drawing.Point(0,0);

		public uc_WpfEditLayer()
		{
			InitializeComponent();

			Loaded += Uc_WpfEditLayer_Loaded;
		}
		
		private void Uc_WpfEditLayer_Loaded(object sender, RoutedEventArgs e)
		{

		}

		public void callGraphics()
		{

		}

		public void setTool(int _tool)
		{

		}

		private void c_Canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{
			mdown = true;
			curpos = e.GetPosition(this);
            

		}

		private void c_Canvas_MouseMove(object sender, MouseEventArgs e)
		{
            if (mdown)
            {
                if (Tool == 1)
                {
                    Line l = new Line();
                    l.StrokeEndLineCap = PenLineCap.Round;
                    l.StrokeThickness = toolSize;
                    l.Stroke = System.Windows.Media.Brushes.Black;
                    l.X1 = curpos.X;
                    l.Y1 = curpos.Y;
                    l.X2 = e.GetPosition(this).X;
                    l.Y2 = e.GetPosition(this).Y;
                    c_Canvas.Children.Add(l);
                    c_Canvas.InvalidateVisual();
                    curpos = e.GetPosition(this);
					points.Add(new c_DrawnPoints(toolSize, (int)l.X1, (int)l.Y1, this.screen_parent.toolColor));
					points.Add(new c_DrawnPoints(toolSize, (int)l.X2, (int)l.Y2, this.screen_parent.toolColor));
				}
                else if (tool == 2)
                {
                    if(lineGuide != null && c_Canvas.Children.Contains(lineGuide)) { c_Canvas.Children.Remove(lineGuide);  }

                    lineGuide = new Line();
                    lineGuide.StrokeEndLineCap = PenLineCap.Round;
                    lineGuide.StrokeThickness = toolSize;
                    lineGuide.Stroke = System.Windows.Media.Brushes.Black;
                    lineGuide.X1 = curpos.X;
                    lineGuide.Y1 = curpos.Y;
                    lineGuide.X2 = e.GetPosition(this).X;
                    lineGuide.Y2 = e.GetPosition(this).Y;
                    lineGuide.Name = "LineGuide";
                    c_Canvas.Children.Add(lineGuide);
                    c_Canvas.InvalidateVisual();
                }
            }
		}

		private void c_Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{

		}

        private void c_Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mdown = false;

            if(tool == 2)
            {
                if (lineGuide != null && c_Canvas.Children.Contains(lineGuide)) { c_Canvas.Children.Remove(lineGuide); }
				
                Line l = new Line();
                l.StrokeEndLineCap = PenLineCap.Round;
                l.StrokeThickness = toolSize;
                l.Stroke = System.Windows.Media.Brushes.Black;
                l.X1 = lineGuide.X1;
                l.Y1 = lineGuide.Y1;
                l.X2 = lineGuide.X2;
                l.Y2 = lineGuide.Y2;
                c_Canvas.Children.Add(l);
                c_Canvas.InvalidateVisual();
				points.Add(new c_DrawnPoints(toolSize,(int)l.X1, (int)l.Y1, this.screen_parent.toolColor));
				points.Add(new c_DrawnPoints(toolSize,(int)l.X2, (int)l.Y2, this.screen_parent.toolColor));
			}

			for (int i = 0; i < points.Count - 1; i++)
			{
				if (points[i].X >= points[i + 1].X - 1 && points[i].X <= points[i + 1].X + 1)
				{
					points[i].X = points[i + 1].X;
					points[i].Y = points[i + 1].Y;

					points.Remove(points[i + 1]);
				}
                /*
				List<Line> ll = new List<Line>();
				foreach (Line l in c_Canvas.Children)
				{
					ll.Add(l);
				}

				for (int ii = 0; ii < ll.Count; ii++) { c_Canvas.Children.Remove(ll[ii]); }

				for(int _i = 0; _i < points.Count - 1; _i++)
				{
					Line l = new Line();
					l.X1 = points[_i].X;
					l.Y1 = points[_i].Y;
					l.X2 = points[_i + 1].X;
					l.Y2 = points[_i + 1].Y;
					l.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
					l.StrokeThickness = points[_i].width;
					c_Canvas.Children.Add(l);
				}*/
			}

        }
    }
}

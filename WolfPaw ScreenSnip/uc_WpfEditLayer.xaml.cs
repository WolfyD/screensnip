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
			Line l = new Line();
			l.X1 = curpos.X;
			l.Y1 = curpos.Y;
			l.X2 = e.GetPosition(this).X;
			l.Y2 = e.GetPosition(this).Y;
			c_Canvas.Children.Add(l);
		}

		private void c_Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("x");
		}
	}
}

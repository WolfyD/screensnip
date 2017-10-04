using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: ADD DRAG DROP

namespace WolfPaw_ScreenSnip
{
    public partial class f_Screen : Form
    {
		public f_SettingPanel child = null;
		public Form1 parent = null;

		string[] imageFormats = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "image/png", "image/x-png", "image/tiff", "image/bmp", "image/x-xbitmap", "image/x-jg", "image/x-emf", "image/x-wmf" };
		string[] stringFormats = new string[] { "text/plain", "text/html", "text/xml", "text/richtext", "text/scriptlet" };


		bool handleDrag = false;
		Font dragableFont = new Font("Consolas", 12, FontStyle.Regular);
		Bitmap dragableImage = null;
		Size dragableSize = new Size(1,1);
		Point dragablePoint = new Point(0, 0);
		bool udUP = false;
		bool lrUP = false;

		public f_Screen()
        {
            InitializeComponent();

            Load += F_Screen_Load;
        }

		public void setScrollBars()
		{
			if (ts_Tools.Visible)
			{
				sb_PrecMovUD.Left = Width - (sb_PrecMovUD.Width + 16);
				sb_PrecMovUD.Height = Height - (39 + ts_Tools.Height + sb_PrecMovLR.Height);
				sb_PrecMovUD.Top =ts_Tools.Height;
				sb_PrecMovLR.Width = Width - (16 + sb_PrecMovUD.Width);
			}
			else if (p_Tools.Width > 0)
			{
				sb_PrecMovUD.Left = p_Tools.Left - sb_PrecMovUD.Width;
				sb_PrecMovUD.Height = Height - (39 + sb_PrecMovLR.Height);
				sb_PrecMovUD.Top = 0;
				sb_PrecMovLR.Width = Width - (16 + sb_PrecMovUD.Width + p_Tools.Width);
			}
			else
			{
				sb_PrecMovUD.Left = Width - (sb_PrecMovUD.Width + 16);
				sb_PrecMovUD.Height = Height - (39 + sb_PrecMovLR.Height);
				sb_PrecMovUD.Top = 0;
				sb_PrecMovLR.Width = Width - (16 + sb_PrecMovUD.Width);
			}
		}

		private void F_Screen_Load(object sender, EventArgs e)
        {
            Bitmap b = IconChar.Desktop.ToBitmap(128, Color.Black);
            b.MakeTransparent(Color.White);
            System.IntPtr icH = b.GetHicon();
            this.Icon = System.Drawing.Icon.FromHandle(icH);

			if (Properties.Settings.Default.s_ToolbarPanel == 1)
			{
				//splitContainer1.Panel2Collapsed = false;
				p_Tools.Width = 200;
				ts_Tools.Hide();
			}
			else 
			{
				//splitContainer1.Panel2Collapsed = true;
				p_Tools.Width = 0;
				if (Properties.Settings.Default.s_ToolbarPanel == 2)
				{
					ts_Tools.Show();
				}
			}

			setScrollBars();

		}

		public void addImage(Bitmap img)
		{
			if (Properties.Settings.Default.s_ToolbarPanel == 2)
			{
				addImage(img, new Point(5, ts_Tools.Height + 5));
			}
			else
			{
				addImage(img, new Point(5, 5));
			}
		}

		public void addImage(Bitmap img, Point pos)
		{
			if (img != null)
			{
				var box = new uc_CutoutHolder();
				box.Parent = this;

				box.Width = img.Width;
				box.Height = img.Height;

				box.Left = pos.X;
				box.Top = pos.Y;

				box.BMP = img;
			}
        }

		private void f_Screen_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(child != null) { child.Close(); }
			parent.Activate();
		}

        public void f_Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var c = c_ImgGen.returnCutouts(this);
                uc_CutoutHolder u = null;
                foreach (var v in c.Values)
                {
                    if (v.moveMode)
                    {
                        u = v;
                        break;
                    }
                }

                if(u != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Left:
                            u.Left--;
                            break;

                        case Keys.Right:
                            u.Left++;
                            break;

                        case Keys.Up:
                            u.Top--;
                            break;

                        case Keys.Down:
                            u.Top++;
                            break;
                    }
                }

            }
            else
            {
                parent.Form1_KeyDown(sender, e);
            }
        }
		
		private void f_Screen_DragDrop(object sender, DragEventArgs e)
		{
			handleDrag = false;

			addImage(dragableImage, dragablePoint);

			dragableSize = new Size(0, 0);
			dragableImage = null;
			dragablePoint = new Point(0, 0);

			Refresh();
		}

		private void f_Screen_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;

			if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(typeof(String)))
			{
				string[] item = new string[1];

				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					item = e.Data.GetData(DataFormats.FileDrop) as string[];
				}
				else
				{
					try
					{
						item[0] = e.Data.GetData(DataFormats.Text).ToString();
					}
					catch
					{
						item = null;
					}
				}

				

				//TODO: Make Image mime detection recursive!!
				if (item != null && e.Effect == DragDropEffects.Copy)
				{
					foreach (string s in item)
					{
						if (e.Data.GetDataPresent(DataFormats.FileDrop))
						{
							string ret = c_Converter.fileToMime(s).ToString() ?? "";
							if (imageFormats.Contains(ret))
							{
								dragableImage = c_Converter.fileToImage(s);
								dragableSize = dragableImage.Size;
								handleDrag = true;
							}
							else if (stringFormats.Contains(ret))
							{
                                dragableImage = textToImg(s);
                                handleDrag = true;
                            }
							else
							{
								e.Effect = DragDropEffects.None;
							}
						}
						else
						{
							try
							{
								string ss = s.Replace("\t", "              ");
                                dragableImage = textToImg(ss);
								handleDrag = true;
							}
							catch
							{
								e.Effect = DragDropEffects.None;
							}
						}
						
					}
				}
			}

		}

        public Bitmap textToImg(string s)
        {
            Size textSize = TextRenderer.MeasureText(s, dragableFont);
            Bitmap di  = new Bitmap(textSize.Width + 10, textSize.Height + 10);
            using (Graphics g = Graphics.FromImage(di))
            {
                g.DrawString(s, dragableFont, Brushes.Black, new PointF(5, 5));
            }
            dragableSize = di.Size;
            return di;
        }

		private void f_Screen_DragOver(object sender, DragEventArgs e)
		{
			if (handleDrag)
			{
				Refresh();
				using(Graphics g = Graphics.FromHwnd(this.Handle))
				{
					Point p = PointToClient(new Point(e.X - dragableSize.Width / 2, e.Y - 10));
					dragablePoint = p;
					int w = dragableSize.Width;
					int h = dragableSize.Height;

					Rectangle[] rects = new Rectangle[1];
					rects[0] = new Rectangle(p.X + 1, p.Y + 9 + 1, dragableSize.Width - 2, dragableSize.Height - 2 - 9);
					g.DrawRectangles(Pens.Black, rects);


					g.FillRectangle(Brushes.CornflowerBlue, new RectangleF(p.X + 1, p.Y, w - 1, 10));
				}
			}
		}

		public void showToolBar()
		{
			if (child != null && !child.IsDisposed) { child.Close(); }
			//splitContainer1.Panel2Collapsed = false;
			p_Tools.Width = 200;
			ts_Tools.Hide();
			Properties.Settings.Default.s_ToolbarPanel = 1;
			Properties.Settings.Default.Save();
			setScrollBars();
		}

		public void hideToolBar()
		{
			child = new f_SettingPanel();
			child.parent = this;
			child.Show();
			Properties.Settings.Default.s_ToolbarPanel = 0;
			Properties.Settings.Default.Save();
			//splitContainer1.Panel2Collapsed = true;
			p_Tools.Width = 0;
			ts_Tools.Hide();
			setScrollBars();
		}

		public void showToolStrip()
		{
			//splitContainer1.Panel2Collapsed = true;
			p_Tools.Width = 0;
			if (child != null && !child.IsDisposed) { child.Close(); }
			ts_Tools.Show();
			Properties.Settings.Default.s_ToolbarPanel = 2;
			Properties.Settings.Default.Save();
			setScrollBars();
		}

		private void btn_Dock_Click(object sender, EventArgs e)
		{
			hideToolBar();
		}

		private void btn_ToolStrip_Click(object sender, EventArgs e)
		{
			showToolStrip();
		}

		private void btn_ToolWindow_Click(object sender, EventArgs e)
		{
			showToolBar();
		}

		private void btn_ToolPanel_Click(object sender, EventArgs e)
		{
			hideToolBar();
		}

		public bool panelOpen()
		{
			return p_Tools.Width == 200;
		}

		public void toggleToolbar()
		{
			ts_Tools.Visible = !ts_Tools.Visible;
		}

		public void togglePanel()
		{
			p_Tools.Width = (p_Tools.Width == 0 ? 200 : 0);
		}

        public void paste()
        {
            if (Clipboard.ContainsImage())
            {
                addImage((Bitmap)Clipboard.GetImage());
            }
            else if (Clipboard.ContainsText())
            {
                addImage(textToImg(Clipboard.GetText()));
            }
        }
		

		private void t_Tick_Tick(object sender, EventArgs e)
		{

			if(sb_PrecMovLR.Value != 0 || sb_PrecMovUD.Value != 0)
			{
				var c = c_ImgGen.returnCutouts(this);
				if(c != null && c.Count > 0)
				{
					foreach (var v in c.Values)
					{
						if (v.moveMode)
						{
							v.Left += sb_PrecMovLR.Value;
							v.Top += sb_PrecMovUD.Value;
						}
					}
				}
			}

			if (udUP) { sb_PrecMovUD.Value = 0; udUP = false; }
			if (lrUP) { sb_PrecMovLR.Value = 0; lrUP = false; }

		}

		private void sb_PrecMovUD_Scroll(object sender, ScrollEventArgs e)
		{
			if(e.Type == ScrollEventType.EndScroll)
			{
				udUP = true;
			}
		}

		public void showSBS()
		{
			sb_PrecMovUD.Show();
			sb_PrecMovLR.Show();
		}

		public void hideSBS()
		{
			sb_PrecMovUD.Hide();
			sb_PrecMovLR.Hide();
		}

		private void sb_PrecMovLR_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.Type == ScrollEventType.EndScroll)
			{
				lrUP = true;
			}
		}

        private void btn_Dock_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var c = c_ImgGen.returnCutouts(this);
            if (c != null && c.Count > 0)
            {
                foreach (var v in c.Values)
                {
                    if (v.moveMode)
                    {
                        e.Graphics.DrawLine(Pens.Black, new Point(v.Left - 20, v.Top), new Point(v.Right + 20, v.Top));
                        e.Graphics.DrawLine(Pens.Black, new Point(v.Left - 20, v.Bottom), new Point(v.Right + 20, v.Bottom));
                        e.Graphics.DrawLine(Pens.Black, new Point(v.Left - 1, v.Top - 20), new Point(v.Left - 1, v.Bottom + 20));
                        e.Graphics.DrawLine(Pens.Black, new Point(v.Right + 1, v.Top - 20), new Point(v.Right + 1, v.Bottom + 20));
                    }
                }
            }

        }

    }
    
}

﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpSnip.c_ImageHolder;

namespace SharpSnip
{
    public partial class f_Screen : Form
	{
        #region Variables
        //-------VARIABLES

			#region WINDOWS

			public f_ToolsPanel child = null;
			public Form1 parent = null;
			public f_previewWindow pw = null;

			#endregion

			#region FORMAT ARRAYS

			string[] imageFormats = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "image/png", "image/x-png", "image/tiff", "image/bmp", "image/x-xbitmap", "image/x-jg", "image/x-emf", "image/x-wmf" };
			string[] stringFormats = new string[] { "text/plain", "text/html", "text/xml", "text/richtext", "text/scriptlet" };

			#endregion

			#region DRAG N DROP

			bool handleDrag = false;
			Font dragableFont = new Font("Consolas", 12, FontStyle.Regular);
			Bitmap dragableImage = null;
			Size dragableSize = new Size(1, 1);
			Point dragablePoint = new Point(0, 0);

			#endregion

			#region TOOLS

			public Color toolColor = Color.Black;
			private int CurrentTool;
			public float toolSize = 1;
			public int currentTool
			{
				get { return CurrentTool; }
				set { CurrentTool = value; changeTool(CurrentTool); }
			}
			c_ImageHolder cResizer = null;

			#endregion

			#region RENDERING

			public List<c_ImageHolder> Limages = new List<c_ImageHolder>();
			public bool mdown = false;
			public c_ImageHolder selectedImage = null;
			public c_ImageHolder mouseOverImage = null;
			public Point imageDragPoint = new Point();
			c_RenderHandler renhan = null;
			edges ed = edges.none;
			corners cor = corners.none;
			corners cRot = corners.none;
			ColorMatrix cm = new ColorMatrix();
			ImageAttributes attributes = new ImageAttributes();
			public bool drawTransparent = false;
			public bool drawAllTransparent = false;
			public bool drawAllTransparentToggle = false;
			public float opacityLevel = 0.4f;
			public bool editLayerOpen = false;
			c_EditLayer editLayer = new c_EditLayer();
			Font tooltipfont = new Font("Consolas", 9, FontStyle.Regular);
			public bool showToolTipsOnCutoutButtons = false;

			#endregion

			#region COLORS

			/// <summary> Color of handle above image containing buttons </summary>
			Color c_HandleColor = Color.FromArgb(255, 153, 180, 209);
			/// <summary> Color of border surrounding image when clicked on </summary>
			Color c_DefaultBorderColor = Color.FromArgb(255, 0, 0, 0);
			/// <summary> Color of border surrounging image when mouse is over image</summary>
			Color c_MouseOverBorderColor = Color.FromArgb(255, 180, 180, 180);
			/// <summary> Color of background of the Screen </summary>
			Color c_ScreenBackgroundColor = Color.FromArgb(255, 220, 220, 220);

			#endregion

		#endregion


		//-------FUNCTIONS
		public f_Screen()
		{
			InitializeComponent();

			Load += F_Screen_Load;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		public void setOpacity()
		{
			cm.Matrix33 = opacityLevel;
			attributes.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		}

		private void F_Screen_Load(object sender, EventArgs e)
		{
			c_ScreenBackgroundColor = Properties.Settings.Default.s_ScreenBGColor;
			c_MouseOverBorderColor = Properties.Settings.Default.s_CutoutMouseOverColor;
			c_DefaultBorderColor = Properties.Settings.Default.s_CutoutSelectionColor;
			c_HandleColor = Properties.Settings.Default.s_CutoutPanelColor;
			BackColor = c_ScreenBackgroundColor;
			showToolTipsOnCutoutButtons = Properties.Settings.Default.s_ShowTooltipOnCutout;

			setOpacity();

			Bitmap b = IconChar.Desktop.ToBitmap(128, Color.Black);
			b.MakeTransparent(Color.White);
			System.IntPtr icH = b.GetHicon();
			this.Icon = System.Drawing.Icon.FromHandle(icH);

			if (Properties.Settings.Default.s_ShowPreview && 
				Properties.Settings.Default.s_LastPreviewMode == 0)
			{
				pw = new f_previewWindow();
				pw.Show();
			}

			if (Properties.Settings.Default.s_ToolbarPanel == 1)
			{
				p_Tools.Width = 200;
				ts_Tools.Hide();
			}
			else
			{
				p_Tools.Width = 0;
				if (Properties.Settings.Default.s_ToolbarPanel == 2)
				{
					ts_Tools.Show();
				}
			}
			
			renhan = new c_RenderHandler(Limages);
			trackBar.OnValueChange += TrackBar_OnValueChange;
		}

		private void TrackBar_OnValueChange(object sender, ValueEventArgs e)
		{
			opacityLevel = (((float)e.Val) / 10.0f);
			lbl_Opacity.Text = opacityLevel + "";
			setOpacity();
			Invalidate();
		}

		public void addImage(Bitmap img, string cutoutID)
		{
			if (Properties.Settings.Default.s_ToolbarPanel == 2)
			{
				addImage(img, new Point(5, ts_Tools.Height + 5), cutoutID);
			}
			else
			{
				addImage(img, new Point(5, 5), cutoutID);
			}
		}

		public void addImage(Bitmap img, Point pos, string cutoutID)
		{
			if (img != null)
			{
				var box = new c_ImageHolder(cutoutID, this)
				{
					//parent = this,

					Size = new Size(img.Width, img.Height),

					Position = new Point(pos.X, pos.Y),

					Image = img,

					LayerIndex = Limages.Count,

					//selfContainingList = Limages
				};

				Limages.Add(box);

				box.arrangeLayers();
				parent.enableButtons(true);
			}
		}

		private void f_Screen_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (child != null) { child.Close(); }
			if (pw != null) { pw.Close(); }
			
			if(Limages != null)
			{
				foreach (c_ImageHolder c in Limages)
				{
					try
					{
						c.Dispose();
					}
					catch { }
				}

				Limages = null;
			}

			try
			{
				GC.AddMemoryPressure(GC.GetTotalMemory(true));
				GC.Collect(1, GCCollectionMode.Forced, true);
			} catch { }

			parent.enableButtons(false);
			parent.Activate();
		}

		public void f_Screen_KeyDown(object sender, KeyEventArgs e)
		{
			c_ImageHolder u = null;
			foreach (var cc in Limages)
			{
				if (cc.selected)
				{
					u = cc;
					break;
				}
			}

			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
				e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				int add = 1;
				if (e.Control) { add = 5; }

				if (u != null)
				{
					c_ImageHolder.directions dir = c_ImageHolder.directions.none;
					switch (e.KeyCode)
					{
						case Keys.Left:
							dir = c_ImageHolder.directions.left;
							break;

						case Keys.Right:
							dir = c_ImageHolder.directions.right;
							break;

						case Keys.Up:
							dir = c_ImageHolder.directions.up;
							break;

						case Keys.Down:
							dir = c_ImageHolder.directions.down;
							break;

						case Keys.Escape:
							u.selected = false;
							Invalidate();
							break;
					}

					if (dir != c_ImageHolder.directions.none)
					{
						u.move(dir, add);
						Invalidate();
					}
				}
			}
			else if ((e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey) && mdown && !resize)
			{
				drawTransparent = true;
				Invalidate();
			}
			else if ((e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu) && !resize)
			{
				drawAllTransparent = true;
				Invalidate();
			}
			else if ((e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey) && mdown && resize)
			{
				keepAspect = true;
			}
			else if ((e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu) && resize)
			{
				//TODO: Add Center Resize!
			}
			else if (e.KeyCode == Keys.F11)
			{
				toggleFullScreen();
			}
			else if (e.KeyCode == Keys.Delete)
			{
				if (u != null && Limages.Contains(u))
				{
					Limages.Remove(u);
					Limages.ForEach(x => x.arrangeLayers());
					Invalidate();
				}
			}
			else if (false)
            {
				//TODO: Add more functionality
				/*
					#1) HorisontalMove && VerticalMove only
					#2) Draw positioning lines
					#3) Line up with other image
				 */
			}
			else
			{
				parent.Form1_KeyDown(sender, e);
			}
		}

		public void toggleFullScreen()
		{
			if (WindowState == FormWindowState.Maximized)
			{
				WindowState = FormWindowState.Normal;
				FormBorderStyle = FormBorderStyle.Sizable;
			}
			else
			{
				FormBorderStyle = FormBorderStyle.None;
				WindowState = FormWindowState.Maximized;
				BringToFront();

			}
		}

		#region drag

		private void f_Screen_DragDrop(object sender, DragEventArgs e)
		{
			handleDrag = false;

			addImage(dragableImage, dragablePoint, "");

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
						//TODO: Add RTF/HTML processing
						item[0] = e.Data.GetData(DataFormats.Text).ToString();
					}
					catch
					{
						item = null;
					}
				}

				
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
								string ss = s.Replace("\t", "    ");
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

		private void f_Screen_DragOver(object sender, DragEventArgs e)
		{
			if (handleDrag)
			{
				Refresh();
				using (Graphics g = Graphics.FromHwnd(this.Handle))
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

		#endregion

		public Bitmap textToImg(string s)
		{
			Size textSize = TextRenderer.MeasureText(s, dragableFont);
			Bitmap di = new Bitmap(textSize.Width + 10, textSize.Height + 10);
			using (Graphics g = Graphics.FromImage(di))
			{
				g.DrawString(s, dragableFont, Brushes.Black, new PointF(5, 5));
			}
			dragableSize = di.Size;
			return di;
		}


		public void showToolBar()
		{
			if (child != null && !child.IsDisposed) { child.Close(); }
			p_Tools.Width = 200;
			ts_Tools.Hide();
			Properties.Settings.Default.s_ToolbarPanel = 1;
			Properties.Settings.Default.Save();
		}

		public void hideToolBar()
		{
			child = new f_ToolsPanel
			{
				parent = this
			};
			child.Show();
			Properties.Settings.Default.s_ToolbarPanel = 0;
			Properties.Settings.Default.Save();
			p_Tools.Width = 0;
			ts_Tools.Hide();
		}

		public void showToolStrip()
		{
			p_Tools.Width = 0;
			if (child != null && !child.IsDisposed) { child.Close(); }
			ts_Tools.Show();
			Properties.Settings.Default.s_ToolbarPanel = 2;
			Properties.Settings.Default.Save();
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

		public bool toolbarOpen()
		{
			return ts_Tools.Visible;
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
				addImage((Bitmap)Clipboard.GetImage(), "");
			}
			else if (Clipboard.ContainsText())
			{
				addImage(textToImg(Clipboard.GetText()), "");
			}
		}


		private void t_Tick_Tick(object sender, EventArgs e)
		{
			foreach(c_ImageHolder c in Limages)
			{
				if (c.panelShowing)
				{
					if (c.panelTimeLeft > 0)
						c.panelTimeLeft--;
					else
						c.hidePanel();
				}
			}

			if (pw != null && !pw.IsDisposed)
			{
				pw.refreshImage(this);
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
			if(Limages == null || Limages.Count < 1)
            {
				return;
            }

			base.OnPaint(e);

			var cr = new c_returnGraphicSettings();
			e.Graphics.InterpolationMode = cr.getIM();
			e.Graphics.PixelOffsetMode = cr.getPOM();
			e.Graphics.SmoothingMode = cr.getSM();

			//TODO: PAINT!!
			try
			{
				if (!editLayerOpen)
				{

					organizeImageList();
					foreach (c_ImageHolder c in Limages)
					{
						if (c != null && c.visible)
						{
							//c.rotated = true;
							//c.rotation = 50;

							if (c.rotated && c.rotation != 0)
							{
								Bitmap b = new Bitmap(100, 100);
								using (Graphics g = Graphics.FromImage(b))
								{
									g.RotateTransform(-c.rotation);
									g.DrawImage(c.getImage(), 0, 0);
									g.RotateTransform(c.rotation);
									e.Graphics.DrawImage(b, new Rectangle(c.Position, c.Size), 0, 0, c.Image.Size.Width, c.Image.Size.Height, GraphicsUnit.Pixel);
								}
							}
							else
							{
								if (drawAllTransparentToggle || drawAllTransparent)
								{
									e.Graphics.DrawImage(c.getImage(), new Rectangle(c.Position, c.Size), 0, 0, c.Image.Size.Width, c.Image.Size.Height, GraphicsUnit.Pixel, attributes);
								}
								else
								{
									if (selectedImage == c && drawTransparent)
									{
										e.Graphics.DrawImage(c.getImage(), new Rectangle(c.Position, c.Size), 0, 0, c.Image.Size.Width, c.Image.Size.Height, GraphicsUnit.Pixel, attributes);
									}
									else
									{
										e.Graphics.DrawImage(c.getImage(), new Rectangle(c.Position, c.Size), new Rectangle(new Point(0, 0), c.Image.Size), GraphicsUnit.Pixel);
									}
								}

								if (c.selected)
								{
									//TODO: Rotation stuff
									//e.Graphics.DrawRectangle(Pens.Black, new Rectangle(c.bounds().Left + c.bounds().Width + 10, c.bounds().Top + c.bounds().Height + 10, 10, 10));
									e.Graphics.DrawRectangle(new Pen(c_DefaultBorderColor), new Rectangle(c.Position, c.Size));

									//TODO: Clean this up -> move rectangles and rotation point outside of method into variables
									e.Graphics.FillRectangles(Brushes.White, new Rectangle[] {
										new Rectangle(){ Height = 3, Width = 3, X = c.Position.X + c.Size.Width / 2, Y = c.Position.Y  },
										new Rectangle(){ Height = 3, Width = 3, X = c.Position.X + c.Size.Width / 2, Y = c.Position.Y + c.Height },
										new Rectangle(){ Height = 3, Width = 3, X = c.Position.X, Y = c.Position.Y + c.Height / 2 },
										new Rectangle(){ Height = 3, Width = 3, X = c.Position.X + c.Size.Width, Y = c.Position.Y + c.Height / 2 },
									}) ;

									e.Graphics.DrawRectangles(Pens.Black, new Rectangle[] {
										new Rectangle(){ Height = 5, Width = 5, X = c.Position.X + c.Size.Width / 2 - 1, Y = c.Position.Y - 2  },
										new Rectangle(){ Height = 5, Width = 5, X = c.Position.X + c.Size.Width / 2 - 1, Y = c.Position.Y + c.Height - 2 },
										new Rectangle(){ Height = 5, Width = 5, X = c.Position.X - 2, Y = c.Position.Y + c.Height / 2 - 1 },
										new Rectangle(){ Height = 5, Width = 5, X = c.Position.X + c.Size.Width - 2, Y = c.Position.Y + c.Height / 2 - 1 },
									});

									Point Origin = new Point(c.Position.X + c.Width / 2, c.Position.Y + c.Height / 2);
									Point pos = c_Geometry.GetPointFromAngle(Origin, c.Height / 2 + 50, c.rotation + 90);
									Size siz = new Size(6, 6);
									e.Graphics.FillEllipse(Brushes.Red, new Rectangle(pos, siz));
									e.Graphics.DrawEllipse(Pens.Black,  new Rectangle(pos, siz));
								}
								else if (c.mouseOver)
								{
									e.Graphics.DrawRectangle(new Pen(c_MouseOverBorderColor), new Rectangle(c.Position, c.Size));
								}
								if (c.panelShowing)
								{
									e.Graphics.FillRectangle(new SolidBrush(c_HandleColor), new RectangleF(c.Position, new Size(c.Width, 20)));

									e.Graphics.DrawImage(renhan.renderButtons(PointToClient(Cursor.Position), c), new PointF(c.Position.X, c.Position.Y));

									Point p = PointToClient(Cursor.Position);

									if (c.isOverAButton(new Point(p.X - c.Left, p.Y - c.Top)) && !resize && MouseButtons.CompareTo(MouseButtons.Left) != 0)
									{
										CustomPanelButton bb = c.overWhichButton(new Point(p.X - c.Left, p.Y - c.Top));
										if (bb.visible)
										{
											string ttText = bb.Tooltiptext;
											if (!showToolTipsOnCutoutButtons)
											{
												lbl_Panel1_Info.Text = ttText;
												lbl_Panel2_Info.Text = ttText;
											}
											else
											{
												try
												{
                                                    int Y = c.Top + 20;
                                                    Rectangle rec = getTooltipRect(ttText, new Point(p.X, Y), out string title, out string text);
													e.Graphics.FillRectangle(new SolidBrush(SystemColors.Info), rec);
													e.Graphics.DrawString(title, tooltipfont, Brushes.Black, new Point(p.X - (p.X % 25) + 22, Y + 5 + 12));
													e.Graphics.DrawImage(bb.Image1, p.X - (p.X % 25) + 1, Y + 5 + 10);
													e.Graphics.DrawString(text, tooltipfont, Brushes.Black, new Point(p.X - (p.X % 25) + 2, Y + 5 + 24));
													e.Graphics.DrawRectangle(Pens.Black, new Rectangle(rec.Left - 1, rec.Top - 1, rec.Width + 2, rec.Height + 2));
												}
												catch (Exception ex)
												{
													MessageBox.Show(ex.ToString());
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					foreach(var c in Limages)
					{
						e.Graphics.DrawImage(c.getImage(), new Rectangle(c.Position, c.Size), new Rectangle(new Point(0, 0), c.Image.Size), GraphicsUnit.Pixel);
					}

					//TODO: PAINT EDITLAYER
					foreach (c_EditLayerElement element in editLayer.elements)
					{
						if (element.type == elementTypes.drawing)
						{
							e.Graphics.DrawImage(element._Drawing, element._Position);
							
							if (true || element._Selected)
							{
								e.Graphics.DrawRectangle(Pens.Black, new Rectangle(element._Position, element._Size));
							}
						}
						else if (element.type == elementTypes.arrow)
						{

						}
						else
						{

						}
					}
				}
			}
			catch
			{
				this.Close();
			}

		}

		public Rectangle getTooltipRect(string ins, Point pos, out string newstr1, out string newstr2)
		{
			Rectangle ret = new Rectangle(new Point(pos.X - (pos.X % 25), pos.Y + 10), new Size(0, 0));

			string[] s = ins.Split('\n');

			string s2 = s[1];
			s2 = "\n" + s2;
			if(s2.Length > 30)
			{
				while(s2.Substring(s2.LastIndexOf('\n')).Length > 30)
				{
					s2 = s2.Insert(s2.LastIndexOf('\n') + s2.Substring(s2.LastIndexOf('\n'), 30).LastIndexOf(' '), "\r\n");
				}
			}

			Size ss = TextRenderer.MeasureText(s2, tooltipfont);

			int height = 22 + ss.Height + 5;
			int width = 10 + ss.Width + 10;

			ret.Height = height;
			ret.Width = width;

			newstr1 = s[0];
			newstr2 = s2;
			return ret;
		}

		private void f_Screen_SizeChanged(object sender, EventArgs e)
		{

		}

		public void organizeImageList()
		{
			try
			{
                if (Limages != null && Limages.Count > 1)
                {
					Limages.Sort(new intComparer());
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		
		private void f_Screen_MouseClick(object sender, MouseEventArgs e)
		{
			foreach (c_ImageHolder c in Limages)
			{
				if (renhan.pointInPosition(e.Location, new Rectangle(c.Position, c.Size)))
				{
					c.select();
				}
			}
			Invalidate();
		}

		public bool buttonPress = false;

		private void f_Screen_MouseDown(object sender, MouseEventArgs e)
		{
			if (!editLayerOpen)
			{
				Limages.Sort(new intComparerDesc());
				foreach (c_ImageHolder c in Limages)
				{
					if (mouseOverImage != null && renhan.pointInPosition(e.Location, new Rectangle(c.Position, c.Size)))
					{
						c.select();

						if (!(renhan.pointInPosition(e.Location, new Rectangle(mouseOverImage.Position, new Size(mouseOverImage.Width, 20)))))
						{
							c.bringToTop();
						}

						selectedImage = c;
						imageDragPoint = new Point(e.X - c.Left, e.Y - c.Top);

						buttonPress = false;
						if (c.isOverAButton(imageDragPoint))
						{
							buttonPress = true;
						}

						if (!c.isOverAnEdge(imageDragPoint) && !c.isOverACorner(imageDragPoint)) { resize = false; cResizer = null; ed = edges.none; cor = corners.none; }
						else { resize = true; cResizer = c; if (c.isOverAnEdge(imageDragPoint)) { ed = c.overWhichEdge(imageDragPoint); cor = corners.none; } else { cor = c.overWhichCorner(imageDragPoint); ed = edges.none; } }
						mdown = true;
						break;
					}
					else if (c.isOverARotaPoint(e.Location))
					{
						cRot = corners.rightBottom;
						cResizer = c;
						mdown = true;
						resize = true;
						break;
					}
					else
					{
						c.selected = false;
					}
				}
			}
			else
			{
				Pen p = new Pen(toolColor, toolSize);
				Brush b = new SolidBrush(toolColor);
				//TODO: MOUSEDOWN EDITLAYER
				if(CurrentTool == 1)
				{
					if (editLayer.mouseOverElement(e.Location))
					{
						mdown = true;
					}
					else
					{
						editLayer.addElement(new Bitmap(50, 50), new Point(e.Location.X - 25, e.Location.Y - 25), new Size(50, 50));
						mdown = true;
					}
				}
			}

			
			Invalidate();
		}

		private void f_Screen_MouseUp(object sender, MouseEventArgs e)
		{
			selectedImage = null;
			mdown = false;
			resize = false;
			if(ed != edges.none) { ed = edges.none; }
			if(cor != corners.none) { cor = corners.none; }
			if(cRot != corners.none) { cRot = corners.none; }

			if (!editLayerOpen)
			{

				if (e.Button == MouseButtons.Right)
				{
					Limages.Sort(new intComparerDesc());
					foreach (c_ImageHolder c in Limages)
					{
						if (renhan.pointInPosition(e.Location, new Rectangle(c.Position, c.Size)))
						{
							c.select();
							cms_Panel.Show(this, e.Location);
							selectedImage = c;
							break;
						}
					}
				}
				else
				{

					Limages.Sort(new intComparerDesc());
					foreach (c_ImageHolder c in Limages)
					{
						if (renhan.pointInPosition(e.Location, new Rectangle(c.Position, c.Size)))
						{
							Point pp = new Point(e.X - c.Left, e.Y - c.Top);
							if (c.isOverAButton(pp) && !resize && buttonPress)
							{
								CustomPanelButton b = c.overWhichButton(pp);

								if (c._buttons.currentValue == CustomPanelButton.HiddenVal.W065)
								{
									if (b.Value == 10)
									{
										cms_Panel.Visible = true;
										cms_Panel.Show(this, e.Location);
										selectedImage = c;
									}
								}
								else if (c._buttons.currentValue == CustomPanelButton.HiddenVal.W135)
								{
									switch (b.Value)
									{
										case 0:
											c.Size = c.Image.Size;
											break;

										case 10:
											cms_Panel.Visible = true;
											cms_Panel.Show(this, e.Location);
											selectedImage = c;
											break;

										case -1:
											c.Dispose();
											Limages.Remove(c);
											GC.Collect();
											Invalidate();
											break;
									}
								}
								else if (c._buttons.currentValue == CustomPanelButton.HiddenVal.W175)
								{
									switch (b.Value)
									{
										case 0:
											c.Size = c.Image.Size;
											break;

										case 10:
											cms_Panel.Visible = true;
											cms_Panel.Show(this, e.Location);
											selectedImage = c;
											break;

										case 4:
											//TODO: EDIT!!
											break;

										case 5:
											c.saveImage();
											break;

										case 6:
											c.copyImage();
											break;

										case -1:
											c.Dispose();
											Limages.Remove(c);
											GC.Collect();
											Invalidate();
											break;
									}
								}
								else if (c._buttons.currentValue == CustomPanelButton.HiddenVal.FullWidth)
								{
									switch (b.Value)
									{
										case 0:
											c.Size = c.Image.Size;
											break;

										case 1:
											c.fullscreen();
											break;

										case 2:
											c.LayerUp();
											break;

										case 3:
											c.LayerDown();
											break;

										case 4:
											//TODO: EDIT!!
											break;

										case 5:
											c.saveImage();
											break;

										case 6:
											c.copyImage();
											break;

										case -1:
											c.Dispose();
											Limages.Remove(c);
											GC.Collect();
											Invalidate();
											break;


									}
								}

							}

							break;
						}

					}
				}
			}
			else
			{
				//TODO: MOUSEUP EDITLAYER
			}

			Invalidate();
		}

		bool resize = false;
		bool keepAspect = false;

		/// <summary>
		/// Gets new width from height using the current aspect ratio
		/// </summary>
		/// <param name="oWid">Original Width</param>
		/// <param name="oHei">Original Height</param>
		/// <param name="nHei">New Height</param>
		/// <returns>Int: new Width</returns>
		public int getSizeAspect(int oWid, int oHei, int nHei)
		{
			int ret = 0;

			double ratio = (oWid * 1.0) / (oHei * 1.0);
			double wid = ratio * nHei;

			ret = (int)Math.Floor(wid);

			return ret;
		}

		//TODO: MOUSE MOVE!!
		private void f_Screen_MouseMove(object sender, MouseEventArgs e)
		{
			if (!editLayerOpen)
			{
				foreach (c_ImageHolder cc in Limages)
				{
					Point pedge = new Point(e.X - cc.Left, e.Y - cc.Top);
					if (cc.bounds().Contains(e.Location))
					{
						if (cc.isOverAnEdge(pedge))
						{
							edges ed = cc.overWhichEdge(pedge);
							if (ed == edges.bottom || ed == edges.top)
							{
								Cursor = Cursors.SizeNS;
							}
							else if (ed == edges.left || ed == edges.right)
							{
								Cursor = Cursors.SizeWE;
							}
							break;
						}
						else if (cc.isOverACorner(pedge))
						{
							corners cir = cc.overWhichCorner(pedge);
							if (cir == corners.leftBottom)
							{
								Cursor = Cursors.SizeNESW;
							}
							else if (cir == corners.leftTop)
							{
								Cursor = Cursors.SizeNWSE;
							}
							else if (cir == corners.rightBottom)
							{
								Cursor = Cursors.SizeNWSE;
							}
							else if (cir == corners.rightTop)
							{
								Cursor = Cursors.SizeNESW;
							}
							break;
						}
						else
						{
							Cursor = Cursors.Default;
						}
					}
					else
					{
						Point pedge2 = new Point(e.X, e.Y);
						Rectangle rRota = new Rectangle(cc.bounds().Left - 20, cc.bounds().Top - 20, cc.bounds().Width + 40, cc.bounds().Height + 40);
						if (rRota.Contains(pedge2) && cc.isOverARotaPoint(pedge2))
						{
							corners cir2 = cc.overWhichRotaPoint(pedge2);
							if (cir2 == corners.rightBottom)
							{
								Cursor = Cursors.SizeNESW;
								cRot = cir2;
							}
							break;
						}
						else
						{
							Cursor = Cursors.Default;
						}
					}
				}

				if (mdown && resize)
				{
					var cc = cResizer;
					if (ed != edges.none)
					{
						if (ed == edges.bottom)
						{
							if (e.Location.Y - cc.Top > 20)
							{
								cc.Size = new Size(cc.Width, e.Location.Y - cc.Top);
							}
							else
							{
								cc.Size = new Size(cc.Width, 21);
							}
						}
						else if (ed == edges.top)
						{
							int top = cc.Top;
							if (cc.Height - (cc.Top - top) > 20)
							{
								cc.Position = new Point(cc.Left, e.Location.Y);
								cc.Size = new Size(cc.Width, cc.Height - (cc.Top - top));
							}
							else
							{

								cc.Size = new Size(cc.Width, 21);
							}
						}
						else if (ed == edges.left)
						{
							int left = cc.Left;
							if (cc.Width - (cc.Left - left) > 20)
							{
								cc.Position = new Point(e.Location.X, cc.Top);
								cc.Size = new Size(cc.Width - (cc.Left - left), cc.Height);
							}
							else
							{
								cc.Size = new Size(21, cc.Height);
								cc.Position = new Point(cc.Position.X - 2, cc.Position.Y);
							}
						}
						else if (ed == edges.right)
						{
							if (e.Location.X - cc.Left > 20)
							{
								cc.Size = new Size(e.Location.X - cc.Left, cc.Height);
							}
							else
							{
								cc.Size = new Size(21, cc.Height);
							}
						}
					}
					//CORNERS
					else if (cor != corners.none)
					{
						int top = cc.Top;
						int left = cc.Left;


						if (cor == corners.leftBottom)
						{
							if (!keepAspect)
							{
								cc.Position = new Point(e.Location.X, cc.Top);
								cc.Size = new Size(cc.Width - (cc.Left - left), e.Location.Y - cc.Top);
							}
							else
							{
								int newwid = (getSizeAspect(cc.Image.Width, cc.Image.Height, e.Location.Y - cc.Top));
								int _Oleft = cc.Left;
								int _right = cc.Left + cc.Width;
								cc.Size = new Size(newwid, e.Location.Y - cc.Top);
								int _newright = cc.Left + cc.Width;
								int _left = _right - _newright;
								cc.Position = new Point(_Oleft + _left, cc.Top);
							}

							//---LEFT BOTTOM
							if (cc.Height <= 20)
							{
								cc.Position = new Point(cc.Position.X, top);
								cc.Size = new Size(cc.Width, 21);
							}
							if (cc.Width - (cc.Left - left) <= 20)
							{
								cc.Position = new Point(cc.Position.X + cc.Width - 21, cc.Position.Y);
								cc.Size = new Size(21, cc.Height);
							}

						}
						else if (cor == corners.leftTop)
						{
							if (!keepAspect)
							{
								cc.Position = new Point(e.Location.X, e.Location.Y);
								cc.Size = new Size(cc.Width - (cc.Left - left), cc.Height - (cc.Top - top));
							}
							else
							{
								int newwid = (getSizeAspect(cc.Image.Width, cc.Image.Height, cc.Height - (e.Y - top)));
								int _Oleft = cc.Left;
								int _right = cc.Left + cc.Width;
								int _Otop = cc.Top;
								int _bottom = cc.Top + cc.Height;
								cc.Size = new Size(newwid, cc.Height - (e.Y - top));
								int _newright = cc.Left + cc.Width;
								int _newbottom = cc.Top + cc.Height;
								int _left = _right - _newright;
								int _top = _bottom - _newbottom;
								cc.Position = new Point(_Oleft + _left, _Otop + _top);
							}

							//---LEFT TOP
							if (cc.Height <= 20)
							{
								cc.Position = new Point(cc.Position.X, cc.Position.Y + cc.Height - 21);
								cc.Size = new Size(cc.Width, 21);
							}
							if (cc.Width - (cc.Left - left) <= 20)
							{
								cc.Position = new Point(cc.Position.X + cc.Width - 21, cc.Position.Y);
								cc.Size = new Size(21, cc.Height);
							}

						}
						else if (cor == corners.rightBottom)
						{

							if (!keepAspect)
							{
								cc.Position = new Point(cc.Left, cc.Top);
								cc.Size = new Size(e.Location.X - cc.Left, e.Location.Y - cc.Top);
							}
							else
							{
								cc.Position = new Point(cc.Left, cc.Top);
								int newwid = (getSizeAspect(cc.Image.Width, cc.Image.Height, e.Y - (cc.Top)));
								cc.Size = new Size(newwid, e.Location.Y - cc.Top);
							}

							//---RIGHT BOTTOM
							if (cc.Height <= 20)
							{
								cc.Position = new Point(cc.Position.X, top);
								cc.Size = new Size(cc.Width, 21);
							}
							if (cc.Width - (cc.Left - left) <= 20)
							{
								cc.Position = new Point(left, cc.Position.Y);
								cc.Size = new Size(21, cc.Height);
							}

						}
						else if (cor == corners.rightTop)
						{

							if (!keepAspect)
							{
								cc.Position = new Point(cc.Left, e.Location.Y);
								cc.Size = new Size(e.Location.X - cc.Left, cc.Height - (cc.Top - top));
							}
							else
							{
								int newwid = (getSizeAspect(cc.Image.Width, cc.Image.Height, cc.Height - (e.Y - top)));
								int _Otop = cc.Top;
								int _bottom = cc.Top + cc.Height;
								cc.Size = new Size(newwid, cc.Height - (e.Y - top));
								int _newbottom = cc.Top + cc.Height;
								int _top = _bottom - _newbottom;
								cc.Position = new Point(cc.Left, _Otop + _top);
							}


							//---RIGHT TOP
							if (cc.Height <= 20)
							{
								cc.Position = new Point(cc.Position.X, cc.Position.Y + cc.Height - 21);
								cc.Size = new Size(cc.Width, 21);
							}
							if (cc.Width - (cc.Left - left) <= 20)
							{
								cc.Position = new Point(left, cc.Position.Y);
								cc.Size = new Size(21, cc.Height);
							}
						}


					}
					else if (cRot != corners.none)
					{

					}
				}

				if (mdown && selectedImage != null && !resize)
				{
					buttonPress = false;
					selectedImage.Position = new Point(e.X - imageDragPoint.X, e.Y - imageDragPoint.Y);

					if (Properties.Settings.Default.s_DragaroundSetting > 0)
					{
						//DRAGAROUND X
						if (e.X <= 0 && new int[] { 1, 3 }.Contains(Properties.Settings.Default.s_DragaroundSetting))
						{
							if (selectedImage.Left + selectedImage.Width > PointToScreen(new Point(getBounds().Width, e.Y)).X)
							{
								imageDragPoint.X += getBounds().Width;
							}
							else
							{
								imageDragPoint.X = selectedImage.bounds().Width - 10;
							}
							Cursor.Position = PointToScreen(new Point(getBounds().Width - 19, e.Y));
						}
						else if (e.X >= getBounds().Width - 18 && new int[] { 1, 3 }.Contains(Properties.Settings.Default.s_DragaroundSetting))
						{
							if (selectedImage.Left < 0)
							{
								imageDragPoint.X -= (getBounds().Width);
							}
							else
							{
								imageDragPoint.X = 10;
							}
							Cursor.Position = new Point(new Point(getBounds().Left + 10, 0).X, PointToScreen(new Point(0, e.Y)).Y);
						}

						//DRAGAROUND Y
						if (e.Y < 0 && new int[] { 2, 3 }.Contains(Properties.Settings.Default.s_DragaroundSetting))
						{
							if (selectedImage.Top + selectedImage.Height > PointToScreen(new Point(e.X, getBounds().Height)).Y)
							{
								imageDragPoint.Y = getBounds().Height;
							}
							else
							{
								imageDragPoint.Y = selectedImage.bounds().Height - 10;
							}
							Cursor.Position = PointToScreen(new Point(e.X, getBounds().Height - 39));
						}
						else if (e.Y > getBounds().Height - 39 && new int[] { 2, 3 }.Contains(Properties.Settings.Default.s_DragaroundSetting))
						{
							if (selectedImage.Top < 0)
							{
								imageDragPoint.Y = getBounds().Y;
							}
							else
							{
								imageDragPoint.Y = 10;
							}
							Cursor.Position = new Point(PointToScreen(new Point(e.X, 0)).X, getBounds().Top + 39);
						}
					}

					Invalidate();
				}
				else
				{
					c_ImageHolder img = null;
					foreach (c_ImageHolder cc in Limages)
					{
						cc.mouseOver = false;
					}
					if (renhan.pointOverAny(e.Location, out img))
					{
						mouseOverImage = img;
						mouseOverImage.mouseOver = true;
						if (renhan.pointInPosition(e.Location, new Rectangle(mouseOverImage.Position, new Size(mouseOverImage.Width, 20))))
						{
							mouseOverImage.showPanel();
						}
					}
					else
					{
						mouseOverImage = null;
					}
					Invalidate();
				}
			}
			else
			{
				//TODO: MOUSEMOVE EDITLAYER
				if (mdown && editLayer.mouseOverElement(e.Location))
				{
					c_EditLayerElement elem = editLayer.getElementUnderMouse(e.Location);
					if (currentTool == 1 && elem.type == elementTypes.drawing)
					{
						elem._Points.Add(e.Location);
					}
				}
			}
		}
		
		public Rectangle getBounds()
		{
			return this.Bounds;
		}

		//----TOOL STUFF
		private void num_ToolSize_ValueChanged(object sender, EventArgs e)
		{
			
		}

		private void num_ToolSize_ValueChanged_1(object sender, EventArgs e)
		{
			
		}

		public void changeTool(int tool)
		{
			if (tool == 0)
			{
				showHideEditLayer(false);
			}
			else
			{
				showHideEditLayer(true);
			}
		}

		public Point[] getDrawnPoints()
		{
			//TODO: Add functionality
			return null;
		}
		
		//TODO: Drawing layer
		public void showHideEditLayer(bool show)
		{
			if (show)
			{
				editLayerOpen = true;
			}
			else
			{
				editLayerOpen = false;
			}
		}

		private void btn_Manipulate_Click(object sender, EventArgs e)
		{
			currentTool = 0;
		}

		private void btn_Pen_Click(object sender, EventArgs e)
		{
			currentTool = 1;
		}

		private void btn_Marker_Click(object sender, EventArgs e)
		{
			currentTool = 2;
		}

		private void btn_Line_Click(object sender, EventArgs e)
		{
			currentTool = 3;
		}

		public bool hasSelectedImage()
		{
			return (selectedImage != null && Limages.Contains(selectedImage));
		}

		private void cms_btn_Resize_Click(object sender, EventArgs e)
		{
			if(hasSelectedImage())
			{
				selectedImage.Size = selectedImage.Image.Size;
			}
		}

		private void cms_btn_Fit_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.fullscreen();
			}
		}

		private void cms_btn_LayerUp_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.LayerUp();
			}
		}

		private void cms_btn_LayerDown_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.LayerDown();
			}
		}

		private void cms_btn_EditImage_Click(object sender, EventArgs e)
		{

		}

		private void cms_btn_Save_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.saveImage();
			}
		}

		private void cms_btn_Copy_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.copyImage();
			}
		}

		private void cms_btn_Delete_Click(object sender, EventArgs e)
		{
			if (hasSelectedImage())
			{
				selectedImage.Dispose();
				Limages.Remove(selectedImage);
				GC.Collect();
				Invalidate();
			}
		}

		private void f_Screen_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Control || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey))
			{
				keepAspect = false;
				drawTransparent = false;
				Invalidate();
			}
			else if ((e.KeyCode == Keys.Alt || e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu))
			{
				drawAllTransparent = false;
				Invalidate();
			}
		}

		private void tb_Transparency_ValueChanged(object sender, EventArgs e)
		{
			
		}

		private void cb_Transparent_CheckedChanged(object sender, EventArgs e)
		{
			drawAllTransparentToggle = cb_Transparent.Checked;
			Invalidate();
		}
	}

}

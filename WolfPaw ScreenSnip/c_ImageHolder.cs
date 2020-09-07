using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace WolfPaw_ScreenSnip
{
	public class c_ImageHolder : IDisposable
	{
		#region ENUMS

		public enum imageBorder
		{
			none,
			singleLine,
			doubleLine,
			dashed,
			dotted
		}

		public enum directions
		{
			none,
			up,
			down,
			left,
			right
		}

		public enum edges
		{
			none,
			left,
			right,
			top,
			bottom
		}

		public enum corners
		{
			none,
			leftTop,
			rightTop,
			leftBottom,
			rightBottom
		}

		#endregion

		#region ========== Variables ==========

		//Size
		private Size size;
		private int width;
		public int Width { get { return width; } }
		private int height;
		public int Height { get { return height; } }
		public Size Size { get { return size; } set { setSize(value); } }
		//Position
		private Point position;
		private int left;
		public int Left { get { return left; } }
		private int top;
		public int Top { get { return top; } }
		public Point Position { get { return position; } set { setPosition(value); } }
		private int layerIndex;
		public int LayerIndex { get { return layerIndex; } set { setLayerIndex(value); } }
		//Image
		private Bitmap image;
		public Bitmap Image { get { return image; } set { setImage(value); } }
		public Bitmap scaledImage = null;
		public BitmapData bmd;
		private imageBorder border;
		public imageBorder Border { get { return border; } set { setBorder(value); }  }
		//Other
		public f_Screen parent { get; set; }
		public List<c_ImageHolder> selfContainingList { get; set; }
		public string backup_id { get; set; }
		public bool selected = false;
		public bool mouseOver = false;
		public bool panelShowing = false;
		public int panelTimeLeft = 0;
		public int rotation = 0;
		public bool rotated = false;
		public bool stayOnTop = false;
		public bool visible = false;

		public buttons _buttons = new buttons();
		
		public c_ImageHolder(string cid)
		{
			backup_id = cid;

			#region BUTTONS
			btn b_Resize = new btn() {
				image1 = IconChar.ArrowsAlt.ToBitmap(20, Color.Black),
				image2 = IconChar.ArrowsAlt.ToBitmap(20, Color.White),
				pos = 0,
				anchor = btn.anchors.left,
				borderWidth = 2,
				value = 0,
				hiddenAtVal = btn.hiddenVal.W065,
				tooltiptext = "Resize\r\nResize image to iriginal dimentions"
			};
			_buttons.add(b_Resize);

			btn b_FullScreen = new btn()
			{
				image1 = IconChar.ArrowsAlt.ToBitmap(20, Color.Black),
				image2 = IconChar.ArrowsAlt.ToBitmap(20, Color.White),
				pos = 1,
				anchor = btn.anchors.left,
				borderWidth = 2,
				value = 1,
				hiddenAtVal = btn.hiddenVal.W175,
				tooltiptext = "Full Screen\r\nResize image to fit the screen size\r\n(keeping aspect ratio)"
			};
			_buttons.add(b_FullScreen);

			btn b_LayerUp = new btn()
			{
				image1 = IconChar.ArrowCircleUp.ToBitmap(20, Color.Black),
				image2 = IconChar.ArrowCircleUp.ToBitmap(20, Color.White),
				pos = 2,
				anchor = btn.anchors.left,
				borderWidth = 2,
				value = 2,
				hiddenAtVal = btn.hiddenVal.W175,
				tooltiptext = "Layer Up\r\nMoves the image to a higher layer"
			};
			_buttons.add(b_LayerUp);

			btn b_LayerDown = new btn()
			{
				image1 = IconChar.ArrowCircleDown.ToBitmap(20, Color.Black),
				image2 = IconChar.ArrowCircleDown.ToBitmap(20, Color.White),
				pos = 3,
				anchor = btn.anchors.left,
				borderWidth = 2,
				value = 3,
				hiddenAtVal = btn.hiddenVal.W175,
				tooltiptext = "Layer Down\r\nMoves the image to a lower layer"
			};
			_buttons.add(b_LayerDown);

			btn b_CMS = new btn()
			{
				image1 = IconChar.CaretUp.ToBitmap(20, Color.Black),
				image2 = IconChar.CaretUp.ToBitmap(20, Color.White),
				pos = 4,
				anchor = btn.anchors.right,
				borderWidth = 2,
				value = 10,
				hiddenAtVal = btn.hiddenVal.FullWidthOnly,
				tooltiptext = "Open Menu\r\nOpens the dropdown menu allowing you to see more buttoins than can appear currently"
			};
			_buttons.add(b_CMS);

			btn b_EditImage = new btn()
			{
				image1 = IconChar.PaintBrush.ToBitmap(20, Color.Black),
				image2 = IconChar.PaintBrush.ToBitmap(20, Color.White),
				pos = 3,
				anchor = btn.anchors.right,
				borderWidth = 2,
				value = 4,
				hiddenAtVal = btn.hiddenVal.W135,
				tooltiptext = "Edit Image\r\nOpens this image for editing"
			};
			_buttons.add(b_EditImage);

			btn b_SaveImage = new btn()
			{
				image1 = IconChar.Save.ToBitmap(20, Color.Black),
				image2 = IconChar.Save.ToBitmap(20, Color.White),
				pos = 2,
				anchor = btn.anchors.right,
				borderWidth = 2,
				value = 5,
				hiddenAtVal = btn.hiddenVal.W135,
				tooltiptext = "Save Image\r\nSaves this image into a separate file"
			};
			_buttons.add(b_SaveImage);

			btn b_CopyImage = new btn()
			{
				image1 = IconChar.Clone.ToBitmap(20, Color.Black),
				image2 = IconChar.Clone.ToBitmap(20, Color.White),
				pos = 1,
				anchor = btn.anchors.right,
				borderWidth = 2,
				value = 6,
				hiddenAtVal = btn.hiddenVal.W135,
				tooltiptext = "Copy Image\r\nCopies this image to the clipboard"
			};
			_buttons.add(b_CopyImage);

			btn b_DeleteImage = new btn()
			{
				image1 = IconChar.Trash.ToBitmap(20, Color.Black),
				image2 = IconChar.Trash.ToBitmap(20, Color.White),
				pos = 0,
				anchor = btn.anchors.right,
				borderWidth = 2,
				value = -1,
				hiddenAtVal = btn.hiddenVal.W065,
				tooltiptext = "Delete Image\r\nRemoves this image from the screen"
			};
			_buttons.add(b_DeleteImage);

			foreach(btn bb in _buttons.btns)
			{
				bb.originalPos = bb.pos;
			}

			#endregion

			if(backup_id == "EDITLAYER")
			{
				stayOnTop = true;
				visible = false;
			}
			else
			{
				stayOnTop = false;
				visible = true;
			}
		}


		#endregion

		#region Size
		public void setSize(Size s)
		{
			size = s;
			width = s.Width;
			height = s.Height;

			_buttons.setupButtons(width);

			//resizeImage();
		}

		public Size getSize()
		{
			return size;
		}

		public int getWidth()
		{
			return width;
		}

		public int getHeight()
		{
			return height;
		}

		public Rectangle bounds()
		{
			return new Rectangle(position, size);
		}

		public int getRatio(int ow, int oh, int height)
		{
			int ret = 0;

			double ratio = (ow * 1.0) / (oh * 1.0);
			double wid = ratio * height;

			ret = (int)Math.Floor(wid);

			return ret;
		}

		public void fullscreen()
		{
			var pf = parent;
			int heightMod = 20 + (pf.toolbarOpen() ? 40 : 0);
			int widthMod = 20 + (pf.panelOpen() ? 200 : 0);

			int W=0, H=0;

			if (Width > Height)
			{
				W = pf.Width - (20 + widthMod);
				H = getRatio(image.Height, image.Width, pf.Width - (20 + widthMod));

				if (H > pf.Height - 20)
				{
					H = pf.Height - (10 + 39 + heightMod);
					W = getRatio(image.Width, image.Height, pf.Height - (10 + heightMod));
				}
			}
			else
			{
				H = pf.Height - (10 + 39 + heightMod);
				W = getRatio(image.Width, image.Height, pf.Height - (10 + heightMod));

				if (Width > pf.Width - 20)
				{
					W = pf.Width - (20 + widthMod);
					H = getRatio(image.Height, image.Width, pf.Width - (20 + widthMod));
				}
			}

			int L = 10;
			int T = heightMod - 10;

			setPosition(new Point(L, T));
			setSize(new Size(W, H));
		}

		public void arrangeLayers()
		{
			if(selfContainingList != null)
			{
				foreach(var c in selfContainingList)
				{
					if(c != selfContainingList.Last())
					{
						var v = selfContainingList[selfContainingList.IndexOf(c) + 1];
						int i = v.LayerIndex;
						if(c.LayerIndex == i) { v.LayerIndex++; }
					}
				}
			}
		}

		public void LayerUp()
		{
			int li = selfContainingList.Max(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex != li)
			{
				int ind = selfContainingList.IndexOf(this);
				int myLayer = LayerIndex;
				var c = selfContainingList[ind + 1];

				LayerIndex = c.LayerIndex;
				c.LayerIndex = myLayer;
			}

			arrangeLayers();
		}

		public void LayerDown()
		{
			int li = selfContainingList.Min(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex != li)
			{
				int ind = selfContainingList.IndexOf(this);
				int myLayer = LayerIndex;
				var c = selfContainingList[ind - 1];

				LayerIndex = c.LayerIndex;
				c.LayerIndex = myLayer;
			}

			arrangeLayers();
		}
		#endregion

		#region Position
		public void setPosition(Point p)
		{
			position = p;
			left = p.X;
			top = p.Y;
		}

		public Point getPosition()
		{
			return position;
		}

		public int getLeft()
		{
			return left;
		}

		public int getTop()
		{
			return top;
		}

		public void setLayerIndex(int lInd)
		{
			layerIndex = lInd;
		}

		public int getLayerIndex()
		{
			return layerIndex;
		}

		#endregion

		#region Image
		public bool lockBits()
		{
			try
			{
				bmd = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}

		public bool unlockBits()
		{
			try
			{
				image.UnlockBits(bmd);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}

		public BitmapData getBitmapData()
		{
			lockBits();
			return bmd;
		}

		public void setImage(Bitmap img)
		{
			try
			{
				image = img;
				parent.Invalidate();
				createScaledImage();
			}
			catch { }
		}

		public Bitmap getImage()
		{
			return image;
		}

		public void createScaledImage()
		{
			var cr = new c_returnGraphicSettings();
			if (getWidth() > 20 && getHeight() > 20)
			{
				scaledImage = new Bitmap(getWidth(), getHeight());
				using (Graphics g = Graphics.FromImage(scaledImage))
				{
					g.InterpolationMode = cr.getIM();
					g.PixelOffsetMode = cr.getPOM();
					g.SmoothingMode = cr.getSM();

					g.DrawImage(image, new Rectangle(new Point(0, 0), scaledImage.Size), new Rectangle(new Point(0, 0), image.Size), GraphicsUnit.Pixel);
				}
				
			}
		}

		public Bitmap getScaledImage()
		{
			createScaledImage();
			return scaledImage;
		}

		public void setBorder(imageBorder brd)
		{
			border = brd;
		}

		public imageBorder getBorder()
		{
			return border;
		}

		#endregion

		#region mouse position

		public Rectangle getButtonRect(btn b)
		{
			int lft = 0;

			Rectangle ret = new Rectangle(0, 0, 20, 20);
			if (b.anchor == btn.anchors.left)
			{
				lft = b.pos * 22;
			}
			else
			{
				lft = width - (((b.pos + 1) * 20) + (b.pos * 2));
			}

			ret.X = lft;

			return ret;
		}

		public bool isOverButton(Point P, btn b)
		{
			int lft = 0;

			if (P.Y >= 0 && P.Y <= 20)
			{
				if (b.anchor == btn.anchors.left)
				{
					lft = b.pos * 22;
				}
				else
				{
					lft = width - (((b.pos + 1) * 20) + (b.pos * 2));
				}
			}

			Rectangle r = new Rectangle(lft, 0, 20, 20);

			return r.Contains(P);
		}

		public bool isOverAButton(Point P)
		{
			foreach(btn b in _buttons.btns)
			{
				Rectangle r = getButtonRect(b);
				if (r.Contains(P)) { return true; }
			}
			return false;
		}

		public btn overWhichButton(Point P)
		{
			foreach (btn b in _buttons.btns)
			{
				Rectangle r = getButtonRect(b);
				if (r.Contains(P)) { return b; }
			}

			return null;
		}

		public bool isOverEdge(Point P, edges e)
		{
			if (e == edges.bottom)
			{
				if(((P.Y <= height && P.Y >= height - 10) && (P.X >= 20 && P.X <= width - 20)))		//BOTTOM
				{
					return true;
				}
			}
			else if (e == edges.top)
			{
				if (((P.Y >= 0 && P.Y <= 5) && (P.X >= 20 && P.X <= width - 20)))					//TOP
				{
					return true;
				}
			}
			else if (e == edges.left)
			{
				if (((P.X >= 0 && P.X <= 10) && (P.Y >= 20 && P.Y <= height - 20)))					//LEFT
				{
					return true;
				}
			}
			else if (e == edges.right)
			{
				if (((P.X <= width && P.X >= width - 10) && (P.Y >= 20 && P.Y <= height - 20)))		//RIGHT
				{
					return true;
				}
			}

			return false;
		}

		public bool isOverAnEdge(Point P)
		{
			if( ((P.X >= 0 && P.X <= 10) && (P.Y >= 20 && P.Y <= height - 20)) ||					//Left
				((P.X <= width && P.X >= width - 10) && (P.Y >= 20 && P.Y <= height - 20)) ||		//Right
				((P.Y >= 0 && P.Y <= 5) && (P.X >= 20 && P.X <= width - 20)) ||						//Top
				((P.Y <= height && P.Y >= height - 10) && (P.X >= 20 && P.X <= width - 20)))		//Bottom
			{
				return true;
			}
			return false;
		}

		public edges overWhichEdge(Point P)
		{
			if (((P.X >= 0 && P.X <= 10) && (P.Y >= 20 && P.Y <= height - 20)))						//Left
			{
				return edges.left;
			}
			else if (((P.X <= width && P.X >= width - 10) && (P.Y >= 20 && P.Y <= height - 20)))	//Right
			{
				return edges.right;
			}
			else if (((P.Y >= 0 && P.Y <= 5) && (P.X >= 20 && P.X <= width - 20)))					//Top
			{
				return edges.top;
			}
			else if (((P.Y <= height && P.Y >= height - 10) && (P.X >= 20 && P.X <= width - 20)))	//Bottom
			{
				return edges.bottom;
			}

			return edges.none;
		}

		public bool isOverCorner(Point P, corners c)
		{
			if (c == corners.leftBottom)
			{
				if ((P.X >= 0 && P.X <= 20) && P.Y <= height && P.Y >= Height - 20)
				{
					return true;
				}
			}
			else if (c == corners.leftTop)
			{
				if ((P.X >= 0 && P.X <= 5) && P.Y >= 0 && P.Y <= 5)
				{
					return true;
				}
			}
			else if (c == corners.rightBottom)
			{
				if ((P.X <= width && P.X >= width - 20) && P.Y <= height && P.Y >= Height - 20)
				{
					return true;
				}
			}
			else if (c == corners.rightTop)
			{
				if ((P.X <= width && P.X >= width - 5) && P.Y >= 0 && P.Y <= 5)
				{
					return true;
				}
			}

			return false;
		}

		public bool isOverACorner(Point P)
		{
			bool ret = false;

			if(isOverCorner(P, corners.leftBottom) ||
				isOverCorner(P, corners.leftTop) ||
				isOverCorner(P, corners.rightBottom) ||
				isOverCorner(P, corners.rightTop))
			{
				ret = true;
			}

			return ret;
		}

		public corners overWhichCorner(Point P)
		{
			if (isOverCorner(P, corners.leftBottom))	{ return corners.leftBottom; }
			if (isOverCorner(P, corners.leftTop))		{ return corners.leftTop; }
			if (isOverCorner(P, corners.rightBottom))	{ return corners.rightBottom; }
			if (isOverCorner(P, corners.rightTop))		{ return corners.rightTop; }
			return corners.none;
		}

		public bool isOverRotaPoint(Point P, corners c)
		{
			Rectangle bound = bounds();

			if (c == corners.leftBottom)
			{
				if ((P.X >= bound.Left -20 && P.X <= bound.Left -5) && P.Y <= bound.Top + height + 20 && P.Y >= bound.Top + Height + 5)
				{
					return true;
				}
			}
			else if (c == corners.leftTop)
			{
				if ((P.X >= bound.Left - 20 && P.X <= bound.Left - 5) && P.Y <= bound.Top - 5 && P.Y >= bound.Top - 20)
				{
					return true;
				}
			}
			else if (c == corners.rightBottom)
			{
				if ((P.X <= bound.Left + width + 20 && P.X >= bound.Left  + width + 5) && P.Y <= bound.Top + height + 20 && P.Y >= bound.Top + Height + 5)
				{
					return true;
				}
			}
			else if (c == corners.rightTop)
			{
				if ((P.X <= bound.Left + width + 20 && P.X >= bound.Left  + width + 5) && P.Y <= bound.Top - 5 && P.Y >= bound.Top - 20)
				{
					return true;
				}
			}

			return false;
		}

		public bool isOverARotaPoint(Point P)
		{
			bool ret = false;

			if (isOverRotaPoint(P, corners.leftBottom) ||
				isOverRotaPoint(P, corners.leftTop) ||
				isOverRotaPoint(P, corners.rightBottom) ||
				isOverRotaPoint(P, corners.rightTop))
			{
				ret = true;
			}

			return ret;
		}

		public corners overWhichRotaPoint(Point P)
		{
			if (isOverRotaPoint(P, corners.leftBottom)) { return corners.leftBottom; }
			if (isOverRotaPoint(P, corners.leftTop)) { return corners.leftTop; }
			if (isOverRotaPoint(P, corners.rightBottom)) { return corners.rightBottom; }
			if (isOverRotaPoint(P, corners.rightTop)) { return corners.rightTop; }
			return corners.none;
		}


		#endregion

		#region OtherFunctions

		public void saveImage()
		{
			Bitmap _b = getScaledImage();
			string savename = "ScreenSnip";

			if (true || Properties.Settings.Default.s_SaveHasDateTime)
			{
				string date = "";
				DateTime n = DateTime.Now;
				date = n.Year + "." + n.Month.ToString().PadLeft(2, '0') + "." + n.Day.ToString().PadLeft(2, '0') + "_" + n.Hour.ToString().PadLeft(2, '0') + "." + n.Minute.ToString().PadLeft(2, '0') + "." + n.Second.ToString().PadLeft(2, '0');
				if (Properties.Settings.Default.s_SaveHasDateTime)
				{
					savename += "_" + date;
				}
			}
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter =
						"Portable Network Graphics Image (PNG)|*.png|" +
						"Bitmap Image (BMP)|*.bmp|" +
						"Joint Photographic Experts Group Image (JPEG)|*.jpg;*.jpeg|" +
						"Graphics Interchange Format Image (GIF)|*.gif|" +
						"Tagged Image File Format Image (TIFF)|*.tif;*.tiff|" +
						"Windows Metafile Image (WMF)|*.wmf",

				FilterIndex = Properties.Settings.Default.s_lastSaveFormat,

				FileName = savename
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{

				ImageFormat _if = ImageFormat.Png;

				switch (sfd.FileName.Substring(sfd.FileName.LastIndexOf(".") + 1).ToLower())
				{
					case "png":
						_if = ImageFormat.Png;
						Properties.Settings.Default.s_lastSaveFormat = 0;
						break;

					case "bmp":
						_if = ImageFormat.Bmp;
						Properties.Settings.Default.s_lastSaveFormat = 1;
						break;

					case "jpg":
						_if = ImageFormat.Jpeg;
						Properties.Settings.Default.s_lastSaveFormat = 2;
						break;

					case "jpeg":
						_if = ImageFormat.Jpeg;
						Properties.Settings.Default.s_lastSaveFormat = 2;
						break;

					case "gif":
						_if = ImageFormat.Gif;
						Properties.Settings.Default.s_lastSaveFormat = 3;
						break;

					case "tif":
						_if = ImageFormat.Tiff;
						Properties.Settings.Default.s_lastSaveFormat = 4;
						break;

					case "tiff":
						_if = ImageFormat.Tiff;
						Properties.Settings.Default.s_lastSaveFormat = 4;
						break;

					case "wmf":
						_if = ImageFormat.Wmf;
						Properties.Settings.Default.s_lastSaveFormat = 5;
						break;

					default:
						_if = ImageFormat.Png;
						Properties.Settings.Default.s_lastSaveFormat = 0;
						break;
				}

				_b.Save(sfd.FileName, _if);

			}
		}

		public void copyImage()
		{
			Bitmap bmp = getScaledImage();
			Clipboard.SetImage(bmp);
		}

		public void select()
		{
			foreach(c_ImageHolder imgh in selfContainingList)
			{
				imgh.unselect();
			}
			selected = true;
		}

		public void unselect()
		{
			selected = false;
		}

		public void showPanel()
		{
			panelShowing = true;
			setPanelTimer(10);
		}

		public void hidePanel()
		{
			panelShowing = false;
			setPanelTimer(0);
		}
		
		public void setPanelTimer(int timeout)
		{
			panelTimeLeft = timeout;
		}

		public void move(directions dir, int len)
		{
			switch (dir)
			{
				case directions.down:
					setPosition(new Point(position.X, position.Y + len));
					break;

				case directions.left:
					setPosition(new Point(position.X - len, position.Y));
					break;

				case directions.right:
					setPosition(new Point(position.X + len, position.Y));
					break;

				case directions.up:
					setPosition(new Point(position.X, position.Y - len));
					break;
			}
		}

		public void bringToTop()
		{
			int li = selfContainingList.Max(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex != li)
			{
				foreach (c_ImageHolder ch in selfContainingList)
				{
					if (ch.LayerIndex > LayerIndex)
					{
						ch.LayerIndex--;
					}
				}

				this.LayerIndex = li;
			}

			arrangeLayers();
		}

		public bool mouseOverPanel(Point pos)
		{
			Rectangle r = new Rectangle(0, 0, Width, 20);
			return r.Contains(pos);
		}

		#endregion

		/// <summary> Dispose Calls  </summary>
		#region IDisposable Support
		public void Dispose()
		{
			Dispose(true);
		}
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (Properties.Settings.Default.s_KeepEditImage)
					{
						try
						{
							String editDBFileName = "editable_backup.db";
							string err;
							c_DatabaseHandler.deleteBackupsImage(c_DatabaseHandler.ConnectToDB("editable_backup.db", out err), backup_id);
						}
						catch { }
					}

					image.Dispose();
					Image.Dispose();
					//scaledImage.Dispose();
					parent.Invalidate();
				}
				
				disposedValue = true;
			}
		}
		
		void IDisposable.Dispose()
		{
			Dispose(true);
		}
		#endregion

	}

	public class buttons
	{
		public List<btn> btns = new List<btn>();
		private int wid;
		public int panelWidth { get { return wid; } set { wid = value; setupButtons(wid); } }
		public btn.hiddenVal currentValue = btn.hiddenVal.FullWidth;
		/// <summary>
		/// <para>1,	//Resize	 </para>
		/// <para>1,	//Fullscreen </para>
		/// <para>1,	//Layerup	 </para>
		/// <para>1,	//Layerdown	 </para>
		/// <para>0,	//CMS		 </para>
		/// <para>1,	//Edit		 </para>
		/// <para>1,	//Save		 </para>
		/// <para>1,	//Copy		 </para>
		/// <para>1	//Delete		 </para>
		/// </summary>
		public int[] visibleButtons = new int[] 
		{
			1,	//Resize
			1,	//Fullscreen
			1,	//Layerup
			1,	//Layerdown
			0,	//CMS
			1,	//Edit
			1,	//Save
			1,	//Copy
			1	//Delete
		};

		public void add(btn button)
		{
			btns.Add(button);
		}

		public void remove(btn button)
		{
			btns.Remove(button);
		}

		public void getCurrentValue(int w)
		{
			if (w >= 175)
			{
				currentValue = btn.hiddenVal.FullWidth;
			}
			else if (w >= 135)
			{
				currentValue = btn.hiddenVal.W175;
			}
			else if (w >= 65)
			{
				currentValue = btn.hiddenVal.W135;
			}
			else
			{
				currentValue = btn.hiddenVal.W065;
			}
		}
		
		public void setupButtons(int w)
		{
			getCurrentValue(w);

			foreach (btn b in btns)
			{
				if (b.hiddenAtVal != btn.hiddenVal.FullWidthOnly)
				{
					if (currentValue < b.hiddenAtVal)
					{
						b.visible = true;
						b.pos = b.originalPos;
					}
					else
					{
						b.visible = false;
						b.pos = -9999;
					}
				}
				else
				{
					if (currentValue != btn.hiddenVal.FullWidth)
					{
						b.visible = true;
						if(currentValue < btn.hiddenVal.W135)
						{
							b.pos = 4;
						}
						else if(currentValue == btn.hiddenVal.W135)
						{
							b.pos = 1;
						}
						else
						{
							b.pos = 0;
						}
					}
					else
					{
						b.visible = false;
					}
				}
			}

		}
	}

	public class btn
	{
		public enum anchors
		{ left, right }

		public enum hiddenVal
		{
			FullWidth,
			FullWidthOnly,
			W175,
			W135,
			W065
		}

		public Bitmap image1 { get; set; }
		public Bitmap image2 { get; set; }
		public int pos { get; set; }
		public int originalPos = 0;
		public anchors anchor { get; set; }
		public int borderWidth { get; set; }
		public int value { get; set; }
		public hiddenVal hiddenAtVal { get; set; }
		public string tooltiptext { get; set; }
		public bool visible = true;

		/// <summary>
		/// Bitmap image1  |  
		/// Bitmap image2  |  
		/// int pos  |  
		/// anchors anchor  |  
		/// int borderWidth  |  
		/// int value  |  
		/// hiddenVal hiddenAtVal  |  
		/// string tooltiptext
		/// </summary>
		public btn()
		{
			originalPos = pos;
		}
	}

}

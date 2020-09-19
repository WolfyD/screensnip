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
		public int Width { get { return width; } }
		private int width;
		public int Height { get { return height; } }
		private int height;
		public Size Size { get { return size; } set { setSize(value); } }
		private Size size;

		//Position
		public Point Offset { get { return offset; } set { offset = value; /*CallSetOffset*/ } }
		private Point offset;
		public int Left { get { return left; } }
		private int left;
		public int Top { get { return top; } }
		private int top;
		public Point Position { get { return position; } set { setPosition(value); } }
		private Point position;
		public int LayerIndex { get { return layerIndex; } set { setLayerIndex(value); } }
		private int layerIndex;

		//Image
		public Bitmap scaledImage = null;
		public BitmapData bmd;
		public Bitmap Image { get { return image; } set { setImage(value); } }
		private Bitmap image;
		public imageBorder Border { get { return border; } set { setBorder(value); }  }
		private imageBorder border;
		//TODO: Add float for scale and handling global scaling

		//Other
		public f_Screen parent; //{ get; set; }
		public List<c_ImageHolder> selfContainingList;// { get; set; }
		public string backup_id { get; set; }
		public bool selected = false;
		public bool mouseOver = false;
		public bool panelShowing = false;
		public int panelTimeLeft = 0;
		public int rotation = 0;
		public bool rotated = false;
		public bool stayOnTop = false;
		public bool visible = false;
		public int buttonSize = 20;

		public buttons _buttons = new buttons();

		#endregion

		public c_ImageHolder(string cid, f_Screen _parent)
		{
			parent = _parent;

			backup_id = cid;

			SetupButtons();

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

		private void SetupButtons()
        {
			#region BUTTONS
			CustomPanelButton b_Resize = new CustomPanelButton()
			{
				Image1 = IconChar.ArrowsAlt.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.ArrowsAlt.ToBitmap(buttonSize, Color.White),
				Pos = 0,
				PadRight = 1,
				Anchor = CustomPanelButton.Anchors.left,
				BorderWidth = 8,
				Value = 0,
				HiddenAtVal = CustomPanelButton.HiddenVal.W065,
				Tooltiptext = "Resize\r\nResize image to original dimentions"
			};
			_buttons.Add(b_Resize);

			CustomPanelButton b_FullScreen = new CustomPanelButton()
			{
				Image1 = IconChar.ExpandArrowsAlt.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.ExpandArrowsAlt.ToBitmap(buttonSize, Color.White),
				PadTop = 2,
				PadRight = 0,
				Pos = 1,
				Anchor = CustomPanelButton.Anchors.left,
				BorderWidth = 2,
				Value = 1,
				HiddenAtVal = CustomPanelButton.HiddenVal.W175,
				Tooltiptext = "Full Screen\r\nResize image to fit the screen size\r\n(keeping aspect ratio)"
			};
			_buttons.Add(b_FullScreen);

			CustomPanelButton b_LayerUp = new CustomPanelButton()
			{
				Image1 = IconChar.ArrowCircleUp.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.ArrowCircleUp.ToBitmap(buttonSize, Color.White),
				Pos = 2,
				Anchor = CustomPanelButton.Anchors.left,
				BorderWidth = 2,
				Value = 2,
				HiddenAtVal = CustomPanelButton.HiddenVal.W175,
				Tooltiptext = "Layer Up\r\nMoves the image to a higher layer"
			};
			_buttons.Add(b_LayerUp);

			CustomPanelButton b_LayerDown = new CustomPanelButton()
			{
				Image1 = IconChar.ArrowCircleDown.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.ArrowCircleDown.ToBitmap(buttonSize, Color.White),
				Pos = 3,
				Anchor = CustomPanelButton.Anchors.left,
				BorderWidth = 2,
				Value = 3,
				HiddenAtVal = CustomPanelButton.HiddenVal.W175,
				Tooltiptext = "Layer Down\r\nMoves the image to a lower layer"
			};
			_buttons.Add(b_LayerDown);

			CustomPanelButton b_CMS = new CustomPanelButton()
			{
				Image1 = IconChar.CaretUp.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.CaretUp.ToBitmap(buttonSize, Color.White),
				Pos = 4,
				Anchor = CustomPanelButton.Anchors.right,
				BorderWidth = 2,
				Value = 10,
				HiddenAtVal = CustomPanelButton.HiddenVal.FullWidthOnly,
				Tooltiptext = "Open Menu\r\nOpens the dropdown menu allowing you to see more buttoins than can appear currently"
			};
			_buttons.Add(b_CMS);

			CustomPanelButton b_EditImage = new CustomPanelButton()
			{
				Image1 = IconChar.PaintBrush.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.PaintBrush.ToBitmap(buttonSize, Color.White),
				Pos = 3,
				PadRight = -1,
				Anchor = CustomPanelButton.Anchors.right,
				BorderWidth = 2,
				Value = 4,
				HiddenAtVal = CustomPanelButton.HiddenVal.W135,
				Tooltiptext = "Edit Image\r\nOpens this image for editing"
			};
			_buttons.Add(b_EditImage);

			CustomPanelButton b_SaveImage = new CustomPanelButton()
			{
				Image1 = IconChar.Save.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.Save.ToBitmap(buttonSize, Color.White),
				Pos = 2,
				Anchor = CustomPanelButton.Anchors.right,
				BorderWidth = 2,
				Value = 5,
				HiddenAtVal = CustomPanelButton.HiddenVal.W135,
				Tooltiptext = "Save Image\r\nSaves this image into a separate file"
			};
			_buttons.Add(b_SaveImage);

			CustomPanelButton b_CopyImage = new CustomPanelButton()
			{
				Image1 = IconChar.Clone.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.Clone.ToBitmap(buttonSize, Color.White),
				Pos = 1,
				PadRight = 1,
				Anchor = CustomPanelButton.Anchors.right,
				BorderWidth = 2,
				Value = 6,
				HiddenAtVal = CustomPanelButton.HiddenVal.W135,
				Tooltiptext = "Copy Image\r\nCopies this image to the clipboard"
			};
			_buttons.Add(b_CopyImage);

			CustomPanelButton b_DeleteImage = new CustomPanelButton()
			{
				Image1 = IconChar.Trash.ToBitmap(buttonSize, Color.Black),
				Image2 = IconChar.Trash.ToBitmap(buttonSize, Color.White),
				Pos = 0,
				PadRight = 2,
				Anchor = CustomPanelButton.Anchors.right,
				BorderWidth = 2,
				Value = -1,
				HiddenAtVal = CustomPanelButton.HiddenVal.W065,
				Tooltiptext = "Delete Image\r\nRemoves this image from the screen"
			};
			_buttons.Add(b_DeleteImage);

			foreach (CustomPanelButton bb in _buttons.btns)
			{
				bb.originalPos = bb.Pos;
			}

			#endregion
		}


		#region Size

		public void setSize(Size s)
		{
			size = s;
			width = s.Width;
			height = s.Height;

			_buttons.SetupButtons(width);

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

            int W = 0, H = 0;

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

        #endregion

        #region Layer bs

        public void arrangeLayers()
		{
			selfContainingList = parent.Limages;

			if (selfContainingList != null)
			{
				selfContainingList = selfContainingList.OrderBy(x => x.LayerIndex).ToList();

                for (int i = 0; i < selfContainingList.Count; i++)
                {
					selfContainingList[i].LayerIndex = i;
                }
			}

			GC.Collect();
		}

		public void LayerUp_OLD()
		{
			int li = selfContainingList.Max(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex < li)
			{
				int ind = selfContainingList.IndexOf(this);
				if(ind < selfContainingList.Count - 1)
				{
					int myLayer = LayerIndex;
					var c = selfContainingList[ind + 1];
				
					LayerIndex = c.LayerIndex;
					c.LayerIndex = myLayer;
				}
			}
		}

		public void LayerUp()
		{
			arrangeLayers();

			int li = selfContainingList.Max(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex < li)
			{
				li = LayerIndex;
				selfContainingList[li].LayerIndex += 1;
				selfContainingList[li + 1].LayerIndex -= 1;
			}

			arrangeLayers();
		}

		public void LayerDown()
		{
			arrangeLayers();

			int li = selfContainingList.Min(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex > li)
			{
				li = LayerIndex;
				selfContainingList[li].LayerIndex -= 1;
				selfContainingList[li - 1].LayerIndex += 1;
			}

			arrangeLayers();
		}
		
		public void setLayerIndex(int lInd)
		{
			layerIndex = lInd;
		}

		public void bringToTop()
		{
			arrangeLayers();

			int li = selfContainingList.Max(x => x.LayerIndex);

			if (selfContainingList.Count > 1 && LayerIndex < li)
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

		#endregion

		#region Position
		public void setPosition(Point p)
		{
			//TODO: Add offset!!
			position = p;
			left = p.X;
			top = p.Y;
		}

		public Point getPosition()
		{
			return position;
		}

		//TODO: Add GetOffsetPosition: Get the position with the added offset value

		//TODO: Add SetOffsetPosition: Set the position whenever the offset changes

		public int getLeft()
		{
			return left;
		}

		public int getTop()
		{
			return top;
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
			catch(Exception ex) { Console.WriteLine("ERROR:setImage -> " + ex.Message); }
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

		public Rectangle getButtonRect(CustomPanelButton b)
		{
			int lft = 0;

			Rectangle ret = new Rectangle(0, 0, 20, 20);
			if (b.Anchor == CustomPanelButton.Anchors.left)
			{
				lft = b.Pos * 22;
			}
			else
			{
				lft = width - (((b.Pos + 1) * 20) + (b.Pos * 2));
			}

			ret.X = lft;

			return ret;
		}

		public bool isOverButton(Point P, CustomPanelButton b)
		{
			int lft = 0;

			if (P.Y >= 0 && P.Y <= 20)
			{
				if (b.Anchor == CustomPanelButton.Anchors.left)
				{
					lft = b.Pos * 22;
				}
				else
				{
					lft = width - (((b.Pos + 1) * 20) + (b.Pos * 2));
				}
			}

			Rectangle r = new Rectangle(lft, 0, 20, 20);

			return r.Contains(P);
		}

		public bool isOverAButton(Point P)
		{
			foreach(CustomPanelButton b in _buttons.btns)
			{
				Rectangle r = getButtonRect(b);
				if (r.Contains(P)) { return true; }
			}
			return false;
		}

		public CustomPanelButton overWhichButton(Point P)
		{
			foreach (CustomPanelButton b in _buttons.btns)
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
						//Try1
						try
						{
							//String editDBFileName = "editable_backup.db";
                            c_DatabaseHandler.deleteBackupsImage(c_DatabaseHandler.ConnectToDB("editable_backup.db", out string err), backup_id);
                        }
						catch(Exception ex) { Console.WriteLine("ERROR:Dispose / try1 -> " + ex.Message); }
					}

					//Try2
                    try
                    {
						image.Dispose();
						Image.Dispose();
						//scaledImage.Dispose();
						parent.Invalidate();
                    }
					catch (Exception ex) { Console.WriteLine("ERROR:Dispose / try2 -> " + ex.Message); }
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

}

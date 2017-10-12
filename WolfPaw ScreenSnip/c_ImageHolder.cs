using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public class c_ImageHolder
	{
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
		public BitmapData bmd;
		private imageBorder border;
		public imageBorder Border { get { return border; } set { setBorder(value); }  }
		//Other
		public f_Screen parent { get; set; }
		public List<c_ImageHolder> selfContainingList { get; set; }
		public bool selected = false;
		public bool mouseOver = false;
		public bool panelShowing = false;
		public int panelTimeLeft = 0;
	
		#endregion

		#region Size
		public void setSize(Size s)
		{
			size = s;
			width = s.Width;
			height = s.Height;
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
			image = img;
		}

		public Bitmap getImage()
		{
			return image;
		}

		public Bitmap getScaledImage()
		{
			Bitmap bmp = new Bitmap(getWidth(), getHeight());
			using(Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawImage(image, new Rectangle(new Point(0, 0), bmp.Size), new Rectangle(new Point(0, 0), image.Size), GraphicsUnit.Pixel);
			}

			return bmp;
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

		


		#region OtherFunctions

		public void saveImage()
		{
			Bitmap bmp = getScaledImage();
			//TODO: SAVE
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

		#endregion


	}
}

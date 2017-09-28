using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	public class c_Object
	{
		string title;
		string desc;
		string img;
		Bitmap bmp;
		string[] tags;
		string saveDate;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Title"></param>
		/// <param name="Desc"></param>
		/// <param name="Img"></param>
		/// <param name="Tags"></param>
		/// <param name="SaveDate"></param>
		public c_Object(string Title, string Desc, string Img, string Tags, string SaveDate)
		{
			title = Title;
			desc = Desc;
			img = Img;
			bmp = c_Converter.ConvertToImg(img);
			tags = Tags.Split(';');
			saveDate = SaveDate;
		}

		public string getTitle()
		{
			return title;
		}

		public string getDescription()
		{
			return desc;
		}

		public string[] getTags()
		{
			return tags;
		}

		public Bitmap getImage()
		{
			return bmp;
		}

		public Size getImageSize()
		{
			return bmp.Size;
		}

		public string getDate()
		{
			return saveDate;
		}
	}
}

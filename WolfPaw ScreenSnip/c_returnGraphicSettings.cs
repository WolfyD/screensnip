using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	class c_returnGraphicSettings
	{

		public PixelOffsetMode getPOM()
		{
			PixelOffsetMode pom;

			switch (Properties.Settings.Default.s_g_SmoothingMode)
			{
				case 0:
					pom = PixelOffsetMode.None;
					break;

				case 1:
					pom = PixelOffsetMode.HighSpeed;
					break;

				case 2:
					pom = PixelOffsetMode.Half;
					break;

				case 3:
					pom = PixelOffsetMode.HighQuality;
					break;

				default: pom = PixelOffsetMode.None; break;
			}
			
			return pom;
		}

		public SmoothingMode getSM()
		{
			SmoothingMode sm;

			switch (Properties.Settings.Default.s_g_SmoothingMode)
			{
				case 0:
					sm = SmoothingMode.None;
					break;

				case 1:
					sm = SmoothingMode.HighSpeed;
					break;

				case 2:
					sm = SmoothingMode.AntiAlias;
					break;

				case 3:
					sm = SmoothingMode.HighQuality;
					break;

				default: sm = SmoothingMode.None; break;
			}



			return sm;
		}

		public InterpolationMode getIM()
		{
			InterpolationMode im;

			switch (Properties.Settings.Default.s_g_InterpolationMode)
			{
				case 0:
					im = InterpolationMode.Bicubic;
					break;

				case 1:
					im = InterpolationMode.Bilinear;
					break;

				case 2:
					im = InterpolationMode.High	;
					break;

				case 3:
					im = InterpolationMode.HighQualityBicubic;
					break;

				case 4:
					im = InterpolationMode.HighQualityBilinear;
					break;

				case 5:
					im = InterpolationMode.Low;
					break;

				case 6:
					im = InterpolationMode.NearestNeighbor;
					break;
					
				default: im = InterpolationMode.Bicubic; break;
			}
			
			return im;
		}


	}
}

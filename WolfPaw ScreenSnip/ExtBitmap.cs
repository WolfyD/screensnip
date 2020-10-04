using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Accord.Imaging;
using Accord.Imaging.Filters;

namespace SharpSnip
{
    public static class ExtBitmap
    {
        

        private static Bitmap ConvolutionFilter(Bitmap sourceBitmap, 
                                             double[,] filterMatrix, 
                                                  double factor = 1, 
                                                       int bias = 0, 
                                             bool grayscale = false) 
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly, 
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth-1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < 
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < 
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY * 
                                 sourceData.Stride + 
                                 offsetX * 4;

                    for (int filterY = -filterOffset; 
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset + 
                                         (filterX * 4) + 
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset, 
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

		public static Bitmap filter(this Bitmap src, bool bnw)
		{
			if (src == null)
			{
				return null;
			}

			//Bitmap ret = ExtBitmap.ConvolutionFilter(src, matrix, 1.0, 0, bnw);
			//Bitmap ret = ExtBitmap.Laplacian5x5OfGaussian5x5Filter1(src);
            Bitmap ret = ExtBitmap.AccordCanny(src);

            return ret;
		}

        public static System.Drawing.Image Convert(Bitmap oldbmp)
        {
            using (var ms = new MemoryStream())
            {
                oldbmp.Save(ms, ImageFormat.Gif);
                ms.Position = 0;
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private static byte GetAVG(Bitmap bm)
        {
            byte[] totals = new byte[3];
            BitmapData srcData = bm.LockBits(
            new Rectangle(0, 0, bm.Width, bm.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;

            IntPtr Scan0 = srcData.Scan0;


            int width = bm.Width;
            int height = bm.Height;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            int idx = (y * stride) + x * 4 + color;

                            totals[color] += p[idx];
                        }
                    }
                }
            }

            int avgB = totals[0] / (width * height);
            int avgG = totals[1] / (width * height);
            int avgR = totals[2] / (width * height);

            int avgValue = (avgR + avgG + avgB) / 3;

            bm.UnlockBits(srcData);

            return (byte)avgValue;
        }

        public static Bitmap AccordCanny(Bitmap src)
        {
            Bitmap ret = (Bitmap)Convert(src);
            //Bitmap ret2 = (Bitmap)ret.Clone();
            byte avg = GetAVG(ret);
            //ret.UnlockBits(null);
            CannyEdgeDetector Canny = new CannyEdgeDetector((byte)(avg / 3 - 20), (byte)(2 * (avg / 3) + 20), 1);

            return Canny.Apply(ret);
        }

        public static Bitmap Laplacian5x5OfGaussian5x5Filter1(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap =
                   ExtBitmap.ConvolutionFilter(sourceBitmap,
                                    Gaussian5x5Type1,
                                       1.0 / 159.0, 0, true);


            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap,
                                 Laplacian5x5, 1.0, 0, false);


            return resultBitmap;
        }

        public static double[,] matrix
		{
			get
			{
				return new double[,]
				{ { -1, -1, -1, -1, -1, },
				  { -1, -1, -1, -1, -1, },
				  { -1, -1, 24, -1, -1, },
				  { -1, -1, -1, -1, -1, },
				  { -1, -1, -1, -1, -1  }, };
			}
		}

        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
              { { -1, -1, -1, -1, -1, },
                { -1, -1, -1, -1, -1, },
                { -1, -1, 24, -1, -1, },
                { -1, -1, -1, -1, -1, },
                { -1, -1, -1, -1, -1  } };
            }
        }

        public static double[,] Gaussian5x5Type1
        {
            get
            {
                return new double[,]
              { { 2, 04, 05, 04, 2 },
                { 4, 09, 12, 09, 4 },
                { 5, 12, 15, 12, 5 },
                { 4, 09, 12, 09, 4 },
                { 2, 04, 05, 04, 2 }, };
            }
        }


    }  
}

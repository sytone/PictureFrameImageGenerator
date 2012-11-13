using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.IO;
using LevDan.Exif;

namespace GenerateFrameImages
{
    class Program
    {
        /// <summary>
        /// Main loop, resizes and copies images every 60 seconds. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                UpdateImages();
                Console.WriteLine("Sleeping for 60");
                System.Threading.Thread.Sleep(Properties.Settings.Default.SleepPeriod);
            }
        }

        /// <summary>
        /// Generates all the images into the specified folder. The names
        /// are the same for feh can reload them without issue. 
        /// </summary>
        private static void UpdateImages()
        {
            GenerateDateImage();

            Console.WriteLine(DateTime.Now.ToLongTimeString());

            var allImages = System.IO.Directory.GetFiles(Properties.Settings.Default.ImageSourcePath, "*.jpg", SearchOption.AllDirectories);
            var random = new Random();

            for (int i = 0; i < Properties.Settings.Default.ImagesToGenerate; i++)
            {
                var randomImage = allImages[random.Next(allImages.Length)];
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Console.WriteLine(randomImage);
                try
                {

                    using (Image image = Bitmap.FromFile(randomImage))
                    {
                        ExifTagCollection exif = new ExifTagCollection(randomImage);
                        if (exif[274] != null)
                        {
                            Console.Out.WriteLine(exif[274]);
                            switch (exif[274].Value)
                            {
                                case "1":
                                    break;//) transform="";;
                                case "2":
                                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                    break;//) transform="-flip horizontal";;
                                case "3":
                                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    break;//) transform="-rotate 180";;
                                case "4":
                                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    break;//) transform="-flip vertical";;
                                case "5":
                                    image.RotateFlip(RotateFlipType.Rotate90FlipY);
                                    break;//) transform="-transpose";;
                                case "6":
                                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    break;//) transform="-rotate 90";;
                                case "7":
                                    image.RotateFlip(RotateFlipType.Rotate270FlipY);
                                    break;//) transform="-transverse";;
                                case "8":
                                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    break;//) transform="-rotate 270";;

                                default:
                                    break;
                            }
                        }

                        using (Bitmap resized = ResizeBitmap((Bitmap)image, Properties.Settings.Default.ImageWidth, Properties.Settings.Default.ImageHeight))
                        {
                            resized.SaveJpeg(Properties.Settings.Default.ImageDestinationPath + "image" + i.ToString() + ".jpg", 100L);
                        }
                    }
                }
                catch (Exception)
                {

                    //throw;
                }


            }
        }

        /// <summary>
        /// Creates a image with the date on it. 
        /// </summary>
        private static void GenerateDateImage()
        {
            string strDisplay = DateTime.Now.ToString(Properties.Settings.Default.DateFormat);

            using (Bitmap objBmpImage = new Bitmap(1024, 768))
            {
                Font objFont = new Font(Properties.Settings.Default.DateFont, Properties.Settings.Default.DateSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                using (Graphics objGraphics = Graphics.FromImage(objBmpImage))
                {
                    objGraphics.Clear(Color.Black);
                    objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    objGraphics.DrawString(strDisplay, objFont, new SolidBrush(Properties.Settings.Default.DateColor), Properties.Settings.Default.DateLeftPadding, Properties.Settings.Default.DateTopPadding);
                    objGraphics.Flush();

                    //objBmpImage.Save(@"\\HOME\picturebox\test.jpg");
                    objBmpImage.SaveJpeg(Properties.Settings.Default.ImageDestinationPath + "date.jpg", 100L);
                }
            }

        }

        /// <summary>
        /// No idea where I orginally found this code, handles the resize of the bitmap accounting for dimensions. 
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ResizeBitmap(Image imgPhoto, int width, int height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(width, height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;

        }


    }

    /// <summary>
    /// Handles the image saving for jpeg compression.
    /// </summary>
    public static class ImageExtensions
    {
        public static void SaveJpeg(this Image img, string filePath, long quality)
        {
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            img.Save(filePath, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static void SaveJpeg(this Image img, Stream stream, long quality)
        {
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            img.Save(stream, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            return codecs.Single(codec => codec.FormatID == format.Guid);
        }
    }
}

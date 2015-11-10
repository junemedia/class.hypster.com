using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace hypster_tv_DAL
{
    public class Image_Resize_Manager
    {
        enum Dimensions
        {
            Width,
            Height
        }
        enum AnchorPosition
        {
            Top,
            Center,
            Bottom,
            Left,
            Right
        }

        public Image_Resize_Manager()
        {

        }





        //-------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Resize and save new instance 
        /// </summary>
        /// <param name="_str_image_path"></param>
        /// <param name="_p_width"></param>
        /// <param name="_p_height"></param>
        /// <param name="img_fmt"></param>
        /// <param name="_NEW_image_path"></param>
        public void Resize_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt, string _NEW_image_path)
        {
            //  string _err_message = "";
            try
            {
                
                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                //check if new size bigger then original
                if (_p_width > imgPhotoVert.Width || _p_height > imgPhotoVert.Height)
                {
                    imgPhotoVert.Dispose();
                    return;
                }



                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;



                if (_p_width == -1)
                {
                    float scale_val = (float)imgPhotoVert.Height / (float)_height;
                    float f_width = (float)imgPhotoVert.Width / scale_val;
                    _width = (int)f_width;
                }


                if (_p_height == -1)
                {
                    float scale_val = (float)imgPhotoVert.Width / (float)_width;
                    float f_height = (float)imgPhotoVert.Height / scale_val;
                    _height = (int)f_height;
                }


                imgPhoto = Crop(imgPhotoVert, _width, _height, AnchorPosition.Center);

                imgPhotoVert.Dispose();




                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                imgPhoto.Save(_NEW_image_path, c_codec, Params);


            }
            catch (Exception ex)
            {   
            }

        }


        public void Resize_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt, string _NEW_image_path, Int64 p_quality)
        {
            //  string _err_message = "";
            try
            {

                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                //check if new size bigger then original
                if (_p_width > imgPhotoVert.Width || _p_height > imgPhotoVert.Height)
                {
                    //imgPhotoVert.Dispose();
                    //return;

                    _p_width = imgPhotoVert.Width;
                    _p_height = imgPhotoVert.Height;
                }
                



                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;



                if (_p_width == -1)
                {
                    float scale_val = (float)imgPhotoVert.Height / (float)_height;
                    float f_width = (float)imgPhotoVert.Width / scale_val;
                    _width = (int)f_width;
                }


                if (_p_height == -1)
                {
                    float scale_val = (float)imgPhotoVert.Width / (float)_width;
                    float f_height = (float)imgPhotoVert.Height / scale_val;
                    _height = (int)f_height;
                }


                imgPhoto = Crop(imgPhotoVert, _width, _height, AnchorPosition.Center);

                imgPhotoVert.Dispose();




                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, p_quality);
                imgPhoto.Save(_NEW_image_path, c_codec, Params);


            }
            catch (Exception ex)
            {
            }

        }




        /// <summary>
        /// Resize and save same instance 
        /// </summary>
        /// <param name="_str_image_path"></param>
        /// <param name="_p_width"></param>
        /// <param name="_p_height"></param>
        /// <param name="img_fmt"></param>
        public void Resize_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt)
        {
            //string _err_message = "";
            try
            {

                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                //check if new size bigger then original
                if (_p_width > imgPhotoVert.Width || _p_height > imgPhotoVert.Height)
                {
                    imgPhotoVert.Dispose();
                    return;
                }



                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;



                if (_p_width == -1)
                {
                    float scale_val = (float)imgPhotoVert.Height / (float)_height;
                    float f_width = (float)imgPhotoVert.Width / scale_val;
                    _width = (int)f_width;
                }


                if (_p_height == -1)
                {
                    float scale_val = (float)imgPhotoVert.Width / (float)_width;
                    float f_height = (float)imgPhotoVert.Height / scale_val;
                    _height = (int)f_height;
                }


                imgPhoto = Crop(imgPhotoVert, _width, _height, AnchorPosition.Center);


                imgPhotoVert.Dispose();



                FileInfo _f = new FileInfo(_str_image_path);
                _f.Delete();


                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                imgPhoto.Save(_str_image_path, c_codec, Params);


            }
            catch (Exception ex)
            {   
            }

        }




        //Crop and save new instance
        public void Crop_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt, string _NEW_image_path)
        {
            //string _err_message = "";
            try
            {

                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;


                imgPhoto = Crop(imgPhotoVert, _width, _height, AnchorPosition.Center);


                imgPhotoVert.Dispose();

                


                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);

                imgPhoto.Save(_NEW_image_path, c_codec, Params);

            }
            catch (Exception ex)
            {   
            }

        }


        //Default crop with center alignment and same store path
        public void Crop_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt)
        {
            //string _err_message = "";
            try
            {

                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;


                imgPhoto = Crop(imgPhotoVert, _width, _height, AnchorPosition.Center);


                imgPhotoVert.Dispose();



                FileInfo _f = new FileInfo(_str_image_path);
                _f.Delete();


                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                imgPhoto.Save(_str_image_path, c_codec, Params);

            }
            catch (Exception ex)
            {
            }

        }


        //Custom XY crop and same store path
        public void Crop_Image(string _str_image_path, int _p_width, int _p_height, ImageFormat img_fmt, int Start_X, int Start_Y)
        {
            //string _err_message = "";
            try
            {

                //create a image object containing a verticel photograph
                System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(_str_image_path, true);
                System.Drawing.Image imgPhoto = null;


                // HORISONTAL, VERTICAL
                int _width = _p_width;
                int _height = _p_height;


                imgPhoto = Crop(imgPhotoVert, _width, _height, Start_X, Start_Y);


                imgPhotoVert.Dispose();



                FileInfo _f = new FileInfo(_str_image_path);
                _f.Delete();


                ImageCodecInfo c_codec = GetEncoderInfo("image/jpeg");
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                imgPhoto.Save(_str_image_path, c_codec, Params);

            }
            catch (Exception ex)
            {  
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------------









        //-------------------------------------------------------------------------------------------------------------------------------------
        //INTERNAL FUNCTIONS
        //-------------------------------------------------------------------------------------------------------------------------------------

        //Crop With ANCHOR
        private System.Drawing.Image Crop(System.Drawing.Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
        {
            Bitmap bmPhoto = null;


            try
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

                nPercentW = ((float)Width / (float)sourceWidth);
                nPercentH = ((float)Height / (float)sourceHeight);

                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentW;
                    switch (Anchor)
                    {
                        case AnchorPosition.Top:
                            destY = 0;
                            break;
                        case AnchorPosition.Bottom:
                            destY = (int)(Height - (sourceHeight * nPercent));
                            break;
                        default:
                            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
                            break;
                    }
                }
                else
                {
                    nPercent = nPercentH;
                    switch (Anchor)
                    {
                        case AnchorPosition.Left:
                            destX = 0;
                            break;
                        case AnchorPosition.Right:
                            destX = (int)(Width - (sourceWidth * nPercent));
                            break;
                        default:
                            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
                            break;
                    }
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);


                if (destWidth < Width)
                {
                    destWidth = Width;
                }

                if (destHeight < Height)
                {
                    destHeight = Height;
                }





                //--------------------------------------------------------------------------------------------------------------






                bmPhoto = new Bitmap(Width, Height); //, PixelFormat.Max); //.Format32bppArgb); // Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;


                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
            }
            catch (Exception ex)
            {   
            }

            return bmPhoto;
        }

        //Crop with RECTANGLE
        private System.Drawing.Image Crop(System.Drawing.Image imgPhoto, int Width, int Height, int Start_X, int Start_Y)
        {
            Bitmap bmPhoto = null;


            try
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

                nPercentW = ((float)Width / (float)sourceWidth);
                nPercentH = ((float)Height / (float)sourceHeight);

                sourceX = Start_X;
                sourceY = Start_Y;


                int destWidth = Width;
                int destHeight = Height;




                bmPhoto = new Bitmap(Width, Height);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;


                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, Width, Height),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
            }
            catch (Exception ex)
            {
            }

            return bmPhoto;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------





        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }





    }
}

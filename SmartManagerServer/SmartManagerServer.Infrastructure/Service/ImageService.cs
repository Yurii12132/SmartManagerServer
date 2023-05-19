using Microsoft.Extensions.Options;
using SmartManagerServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using SmartManagerServer.Core.Models.Configuration;
using System.Net.Mime;

namespace SmartManagerServer.Infrastructure.Service
{
    public class ImageService : IImageService
    {
        private readonly ImagesConfiguration configuration;
        public ImageService(IOptions<ImagesConfiguration> imagesConfiguration)
        {
            configuration = imagesConfiguration.Value;
        }

        private Size GetPreferredImageSize(int maxWidth, int maxHeight, int width, int height)
        {
            int newWidth = width;
            int newHeight = height;

            if (width >= height)
            {
                if (width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round((double)height / ((double)width / (double)maxWidth));
                }
            }
            else
            {
                if (height > maxHeight)
                {
                    newHeight = maxHeight;
                    newWidth = (int)Math.Round((double)width / ((double)height / (double)maxHeight));
                }
            }

            return new Size(newWidth, newHeight);
        }

        public Image Resize(Image sourceImage)
        {
            var size = GetPreferredImageSize(
                configuration.PreferredUploadWidth,
                configuration.PreferredUploadHeight,
                sourceImage.Width,
                sourceImage.Height);

            var newImage = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);

            newImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(sourceImage, 0, 0, size.Width, size.Height);

            return newImage;
        }
    }
}

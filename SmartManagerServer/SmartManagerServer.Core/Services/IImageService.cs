using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SmartManagerServer.Core.Services
{
    public interface IImageService
    {
        Image Resize(Image sourceImage);
    }
}

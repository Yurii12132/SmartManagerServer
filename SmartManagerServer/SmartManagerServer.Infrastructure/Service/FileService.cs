using Microsoft.Extensions.Options;
using SmartManagerServer.Core.Models.Configuration;
using SmartManagerServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Service
{
    public class FileService : IFIleService
    {
        private readonly IImageService imageService;
        private readonly FileStorageConfiguration configuration;
        public FileService(IOptions<FileStorageConfiguration> filesConfiguration, IImageService imageService)
        {
            this.imageService = imageService;
            this.configuration = filesConfiguration.Value;
        }

        public async Task<byte[]> GetBytesFile(string guidFileName)
        {
            string filePath = $"{configuration.FilePath}\\{guidFileName}";
            try
            {
                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<string> CreateFileAsync(string fileBody, string originalName)
        {
            if (string.IsNullOrWhiteSpace(fileBody)) return null;

            string guidFileName = GetGuidFileName(originalName);

            string filePath = $"{configuration.FilePath}\\{guidFileName}";

            byte[] fileBytes = GetFileBytes(fileBody);

            return await CreateFile(fileBytes, filePath) ? guidFileName : null;
        }
        private async Task<bool> CreateFile(byte[] bytes, string fileName)
        {
            try
            {
                await File.WriteAllBytesAsync(fileName, bytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> CreateImageAsync(string fileBody, string originalFileName)
        {
            if (String.IsNullOrWhiteSpace(fileBody)) return null;

            string guidFileName = GetGuidFileName(originalFileName);

            string filePath = $"{configuration.FilePath}\\{guidFileName}";

            byte[] fileBytes = GetFileBytes(fileBody);

            return CreateImage(fileBytes, filePath) ? guidFileName : null;
        }

        public async Task<string> GetImageBase64ByGuidNameAsync(string guidFileName)
        {
            string filePath = $"{configuration.FilePath}\\{guidFileName}";
            var bytes = await File.ReadAllBytesAsync(filePath);

            return $"data:image/{Path.GetExtension(filePath).Replace(".", "")};base64,{Convert.ToBase64String(bytes)}";
        }












        private string GetGuidFileName(string originalFileName)
        {
            Guid newGuid = Guid.NewGuid();
            var ext = Path.GetExtension(originalFileName);

            return $"{newGuid}{ext}";
        }

        private byte[] GetFileBytes(string fileBody)
        {
            var fileDataParts = fileBody.Split(',');

            string fileBodyPart = fileDataParts.Length > 1 ? fileDataParts[1] : fileDataParts[0];

            return Convert.FromBase64String(fileBodyPart);
        }

        private bool CreateImage(byte[] imageBytes, string filePath)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(memoryStream);
                image = imageService.Resize(image);
                try
                {
                    image.Save(filePath, ImageFormat.Jpeg);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

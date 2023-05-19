using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Services
{
    public interface IFIleService
    {
        Task<byte[]> GetBytesFile(string guidFileName);
        Task<string> CreateFileAsync(string fileBody, string originalName);
        Task<string> CreateImageAsync(string fileBody, string originalFileName);
        Task<string> GetImageBase64ByGuidNameAsync(string guidFileName);
    }
}

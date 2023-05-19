using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class FileModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Body { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; } = "application/octet-stream";
    }
}

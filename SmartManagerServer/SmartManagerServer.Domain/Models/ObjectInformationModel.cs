using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class ObjectInformationModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<FileModel> Documents { get; set; }
        public List<FileModel> Images { get; set; }
    }
}

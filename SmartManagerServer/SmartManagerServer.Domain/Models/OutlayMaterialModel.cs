using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class OutlayMaterialModel
    {
        public int id { get; set; }
        public string ObjectName { get; set; }
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}

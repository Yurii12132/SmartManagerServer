using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class ObjectModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CloseDate { get; set; }
    }
}

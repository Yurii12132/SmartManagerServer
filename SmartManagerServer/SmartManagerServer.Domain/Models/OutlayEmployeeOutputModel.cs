using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class OutlayEmployeeOutputModel
    {
        public int id { get; set; }
        public int ObjectId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Minutes { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}

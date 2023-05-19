using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class OutlayEMployeeCreateFormModel
    {
        public int EmployeeId { get; set; }
        public int ObjectId { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
    }
}

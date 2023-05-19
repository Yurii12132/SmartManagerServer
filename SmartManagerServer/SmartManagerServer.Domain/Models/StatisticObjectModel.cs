using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class StatisticObjectModel
    {
        public string ObjectName { get; set; }
        public double Payout { get; set; }
        public double Outlay { get; set; }
        public double OutlayEmployee { get; set; }
        public DateTime Date { get; set; }
    }
}

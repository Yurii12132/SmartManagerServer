using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class EmployeeCalculationModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TermOfWork { get; set; }
        public int Minutes { get; set; }
        public double? Sum { get; set; }
        public double? PrepaidExpense { get; set; }
        public double? ToBePaid { get; set; }
        public DateTime Date { get; set; }
    }
}

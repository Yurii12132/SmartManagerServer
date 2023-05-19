using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class EmployeeCalculation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TermOfWork { get; set; }
        public int Minutes { get; set; }
        public double? Sum { get; set; }
        public double? PrepaidExpense { get; set; }
        public double? ToBePaid { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

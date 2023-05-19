using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeCalculation = new HashSet<EmployeeCalculation>();
            OutlayEmployee = new HashSet<OutlayEmployee>();
            Prepaid = new HashSet<Prepaid>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? Salary { get; set; }
        public int? ImageId { get; set; }
        public string DetailInformation { get; set; }
        public int? EducationId { get; set; }
        public string Recidence { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusId { get; set; }

        public virtual Education Education { get; set; }
        public virtual File Image { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<EmployeeCalculation> EmployeeCalculation { get; set; }
        public virtual ICollection<OutlayEmployee> OutlayEmployee { get; set; }
        public virtual ICollection<Prepaid> Prepaid { get; set; }
    }
}

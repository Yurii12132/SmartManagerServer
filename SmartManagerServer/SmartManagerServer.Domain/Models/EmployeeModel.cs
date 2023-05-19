using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double Salary { get; set; }
        public FileModel Image { get; set; }
        public string DetailInformation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public EducationModel Education { get; set; }
        public string Recidence { get; set; }
    }
}

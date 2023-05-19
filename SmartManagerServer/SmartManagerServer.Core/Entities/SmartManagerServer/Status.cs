using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class Status
    {
        public Status()
        {
            Employee = new HashSet<Employee>();
            Object = new HashSet<Object>();
            OutlayEmployee = new HashSet<OutlayEmployee>();
            OutlayMaterial = new HashSet<OutlayMaterial>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Object> Object { get; set; }
        public virtual ICollection<OutlayEmployee> OutlayEmployee { get; set; }
        public virtual ICollection<OutlayMaterial> OutlayMaterial { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class File
    {
        public File()
        {
            DocumentObject = new HashSet<DocumentObject>();
            Employee = new HashSet<Employee>();
            ImageObject = new HashSet<ImageObject>();
            Payout = new HashSet<Payout>();
        }

        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string GuidName { get; set; }

        public virtual ICollection<DocumentObject> DocumentObject { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<ImageObject> ImageObject { get; set; }
        public virtual ICollection<Payout> Payout { get; set; }
    }
}

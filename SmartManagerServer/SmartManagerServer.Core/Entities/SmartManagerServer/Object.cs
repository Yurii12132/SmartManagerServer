using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class Object
    {
        public Object()
        {
            DocumentObject = new HashSet<DocumentObject>();
            ImageObject = new HashSet<ImageObject>();
            OutlayEmployee = new HashSet<OutlayEmployee>();
            OutlayMaterial = new HashSet<OutlayMaterial>();
            Payout = new HashSet<Payout>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<DocumentObject> DocumentObject { get; set; }
        public virtual ICollection<ImageObject> ImageObject { get; set; }
        public virtual ICollection<OutlayEmployee> OutlayEmployee { get; set; }
        public virtual ICollection<OutlayMaterial> OutlayMaterial { get; set; }
        public virtual ICollection<Payout> Payout { get; set; }
    }
}

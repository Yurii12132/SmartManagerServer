﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Core.Entities.SmartManagerServer
{
    public partial class Payout
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? FileId { get; set; }
        public DateTime Date { get; set; }

        public virtual File File { get; set; }
        public virtual Object Object { get; set; }
    }
}

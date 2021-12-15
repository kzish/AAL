using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MTutorWorkExperience
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Organization { get; set; }
        public string Roles { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
    }
}

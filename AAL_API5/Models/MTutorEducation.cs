using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorEducation
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string InsituteOrUniversity { get; set; }
        public string DiplomaOrDegree { get; set; }
        public bool Verified { get; set; }

        public virtual AspNetUser AspnetUser { get; set; }
    }
}

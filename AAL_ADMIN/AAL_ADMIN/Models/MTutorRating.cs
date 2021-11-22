using System;
using System.Collections.Generic;

namespace AAL_ADMIN.Models
{
    public partial class MTutorRating
    {
        public int Id { get; set; }
        public string TutorAspnetIdFk { get; set; }
        public int? FiveStarRating { get; set; }
        public int? FourStarRating { get; set; }
        public int? ThreeStarRating { get; set; }
        public int? TwoStarRating { get; set; }
        public int? OneStarRating { get; set; }
        public string RatorsIdNfk { get; set; }

        public virtual AspNetUsers TutorAspnetIdFkNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AAL_TUTOR.Models
{
    public partial class MAspnetUserAvailableTimes
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Weekday { get; set; }
        public string TimePeriod { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
    }
}

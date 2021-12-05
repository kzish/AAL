using System;
using System.Collections.Generic;

namespace AAL_ADMIN.Models
{
    public partial class MTutorCourses
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int? MoodleCourseId { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
    }
}

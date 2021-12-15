using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MLanguages
    {
        public MLanguages()
        {
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguages>();
            MTutorLanguages = new HashSet<MTutorLanguages>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string Iso { get; set; }

        public virtual ICollection<MAspnetUserLanguages> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MTutorLanguages> MTutorLanguages { get; set; }
    }
}

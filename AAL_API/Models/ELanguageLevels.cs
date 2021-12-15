using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class ELanguageLevels
    {
        public ELanguageLevels()
        {
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguages>();
            MTutorLanguages = new HashSet<MTutorLanguages>();
        }

        public int Id { get; set; }
        public string LanguageLevel { get; set; }

        public virtual ICollection<MAspnetUserLanguages> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MTutorLanguages> MTutorLanguages { get; set; }
    }
}

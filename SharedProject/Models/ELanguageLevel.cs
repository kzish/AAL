using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class ELanguageLevel
    {
        public ELanguageLevel()
        {
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguage>();
            MTutorLanguages = new HashSet<MTutorLanguage>();
        }

        public int Id { get; set; }
        public string LanguageLevel { get; set; }

        public virtual ICollection<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MTutorLanguage> MTutorLanguages { get; set; }
    }
}

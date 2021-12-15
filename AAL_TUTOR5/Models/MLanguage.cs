using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MLanguage
    {
        public MLanguage()
        {
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguage>();
            MTutorLanguages = new HashSet<MTutorLanguage>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string Iso { get; set; }

        public virtual ICollection<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MTutorLanguage> MTutorLanguages { get; set; }
    }
}

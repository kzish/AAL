using System;
using System.Collections.Generic;

namespace AAL_TUTOR.Models
{
    public partial class MTutorLanguages
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
        public virtual MLanguages Language { get; set; }
        public virtual ELanguageLevels LanguageLevel { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MAspnetUserLanguages
    {
        public int Id { get; set; }
        public string AspnetUserIdFk { get; set; }
        public int LanguageIdFk { get; set; }
        public int LanguageLevelIdFk { get; set; }

        public virtual AspNetUsers AspnetUserIdFkNavigation { get; set; }
        public virtual MLanguages LanguageIdFkNavigation { get; set; }
        public virtual ELanguageLevels LanguageLevelIdFkNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MAspnetUserLanguage
    {
        public int Id { get; set; }
        public string AspnetUserIdFk { get; set; }
        public int LanguageIdFk { get; set; }
        public int LanguageLevelIdFk { get; set; }

        public virtual Aspnetuser AspnetUserIdFkNavigation { get; set; }
        public virtual ELanguageLevel LanguageIdFkNavigation { get; set; }
        public virtual MLanguage LanguageLevelIdFkNavigation { get; set; }
    }
}

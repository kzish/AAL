using Nest;
using System;
using System.Collections.Generic;

namespace Globals
{
    //[ElasticsearchType]
    [ElasticsearchType(RelationName = "apiTutor", IdProperty = "AspnetUserId")]
    public class apiTutor
    {
        [Keyword]
        public string AspnetUserId { get; set; }
        [Keyword]
        public string Firstname { get; set; }
        [Keyword]
        public string Surname { get; set; }
        [Keyword]
        public string Email { get; set; }
        [Keyword]
        public string ImageUrl { get; set; }
        [Keyword]
        public string CoutryIso { get; set; }
        [Keyword]
        public string CoutryName { get; set; }
        [Text]
        public string About { get; set; }
        [Object]
        public List<Language> Languages { get; set; } = new List<Language>();
        [Text]
        public List<string> Courses { get; set; } = new List<string>();
        [Keyword]
        public string Mobile { get; set; }
        [Keyword]
        public string OtherMobile { get; set; }
        //[Boolean(NullValue = false, Store = true)]
        public sbyte MobileAvailableOnWhatsapp { get; set; }
        //[Boolean(NullValue = false, Store = true)]
        public sbyte ShowEmail { get; set; }
    }

    public class Language
    {
        [Keyword]
        public int level { get; set; }
        [Keyword]
        public string lang { get; set; }

    }
}

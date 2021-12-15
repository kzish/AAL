using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MCountries
    {
        public string CountryIso { get; set; }
        public string CountryIso3 { get; set; }
        public int CallingCode { get; set; }
        public string CountryName { get; set; }
    }
}

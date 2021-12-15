using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MTutor
    {
        public string AspnetUserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string CoutryIso { get; set; }
        public string About { get; set; }
        public bool Active { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
    }
}

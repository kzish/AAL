using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
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

        public virtual AspNetUser AspnetUser { get; set; }
    }
}

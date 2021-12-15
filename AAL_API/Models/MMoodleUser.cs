using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MMoodleUser
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int? MoodleId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
    }
}

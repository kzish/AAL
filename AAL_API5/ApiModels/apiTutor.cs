using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAL_API5.ApiModels
{
    public class apiTutor
    {
        public string AspnetUserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string CoutryIso { get; set; }
        public string CoutryName { get; set; }
        public string About { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> Courses { get; set; } = new List<string>();
    }
}

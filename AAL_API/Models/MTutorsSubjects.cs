using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MTutorsSubjects
    {
        public MTutorsSubjects()
        {
            MTutorsSubjectsSpecialities = new HashSet<MTutorsSubjectsSpecialities>();
        }

        public int Id { get; set; }
        public int SubjectIdFk { get; set; }
        public string AspnetUserIdFk { get; set; }
        public decimal PricePerHour { get; set; }

        public virtual AspNetUsers AspnetUserIdFkNavigation { get; set; }
        public virtual MSubject SubjectIdFkNavigation { get; set; }
        public virtual ICollection<MTutorsSubjectsSpecialities> MTutorsSubjectsSpecialities { get; set; }
    }
}

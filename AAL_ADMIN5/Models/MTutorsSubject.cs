using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorsSubject
    {
        public MTutorsSubject()
        {
            MTutorsSubjectsSpecialities = new HashSet<MTutorsSubjectsSpeciality>();
        }

        public int Id { get; set; }
        public int SubjectIdFk { get; set; }
        public string AspnetUserIdFk { get; set; }
        public decimal PricePerHour { get; set; }

        public virtual Aspnetuser AspnetUserIdFkNavigation { get; set; }
        public virtual MSubject SubjectIdFkNavigation { get; set; }
        public virtual ICollection<MTutorsSubjectsSpeciality> MTutorsSubjectsSpecialities { get; set; }
    }
}

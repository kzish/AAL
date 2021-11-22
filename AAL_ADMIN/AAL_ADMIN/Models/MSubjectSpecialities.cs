using System;
using System.Collections.Generic;

namespace AAL_ADMIN.Models
{
    public partial class MSubjectSpecialities
    {
        public MSubjectSpecialities()
        {
            MTutorsSubjectsSpecialities = new HashSet<MTutorsSubjectsSpecialities>();
        }

        public int Id { get; set; }
        public int SubjectIdFk { get; set; }
        public string Speciality { get; set; }
        public string Description { get; set; }

        public virtual MSubject SubjectIdFkNavigation { get; set; }
        public virtual ICollection<MTutorsSubjectsSpecialities> MTutorsSubjectsSpecialities { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MSubjectSpeciality
    {
        public MSubjectSpeciality()
        {
            MTutorsSubjectsSpecialities = new HashSet<MTutorsSubjectsSpeciality>();
        }

        public int Id { get; set; }
        public int SubjectIdFk { get; set; }
        public string Speciality { get; set; }
        public string Description { get; set; }

        public virtual MSubject SubjectIdFkNavigation { get; set; }
        public virtual ICollection<MTutorsSubjectsSpeciality> MTutorsSubjectsSpecialities { get; set; }
    }
}

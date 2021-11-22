using System;
using System.Collections.Generic;

namespace AAL_TUTOR.Models
{
    public partial class MTutorsSubjectsSpecialities
    {
        public int Id { get; set; }
        public int TutorsSubjectIdFk { get; set; }
        public int SpecialityId { get; set; }

        public virtual MSubjectSpecialities Speciality { get; set; }
        public virtual MTutorsSubjects TutorsSubjectIdFkNavigation { get; set; }
    }
}

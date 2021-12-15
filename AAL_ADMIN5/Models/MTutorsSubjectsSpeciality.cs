using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorsSubjectsSpeciality
    {
        public int Id { get; set; }
        public int TutorsSubjectIdFk { get; set; }
        public int SpecialityId { get; set; }

        public virtual MSubjectSpeciality Speciality { get; set; }
        public virtual MTutorsSubject TutorsSubjectIdFkNavigation { get; set; }
    }
}

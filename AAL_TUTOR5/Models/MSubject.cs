using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MSubject
    {
        public MSubject()
        {
            MSubjectSpecialities = new HashSet<MSubjectSpeciality>();
            MTopics = new HashSet<MTopic>();
            MTutorsSubjects = new HashSet<MTutorsSubject>();
        }

        public int Id { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectDescription { get; set; }

        public virtual ICollection<MSubjectSpeciality> MSubjectSpecialities { get; set; }
        public virtual ICollection<MTopic> MTopics { get; set; }
        public virtual ICollection<MTutorsSubject> MTutorsSubjects { get; set; }
    }
}

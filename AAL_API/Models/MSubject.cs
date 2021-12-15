using System;
using System.Collections.Generic;

namespace AAL_API.Models
{
    public partial class MSubject
    {
        public MSubject()
        {
            MSubjectSpecialities = new HashSet<MSubjectSpecialities>();
            MTopics = new HashSet<MTopics>();
            MTutorsSubjects = new HashSet<MTutorsSubjects>();
        }

        public int Id { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectDescription { get; set; }

        public virtual ICollection<MSubjectSpecialities> MSubjectSpecialities { get; set; }
        public virtual ICollection<MTopics> MTopics { get; set; }
        public virtual ICollection<MTutorsSubjects> MTutorsSubjects { get; set; }
    }
}

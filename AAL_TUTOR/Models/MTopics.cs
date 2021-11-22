using System;
using System.Collections.Generic;

namespace AAL_TUTOR.Models
{
    public partial class MTopics
    {
        public int Id { get; set; }
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public string Tags { get; set; }
        public int? SubjectIdFk { get; set; }

        public virtual MSubject SubjectIdFkNavigation { get; set; }
    }
}

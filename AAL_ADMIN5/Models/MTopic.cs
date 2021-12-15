using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTopic
    {
        public int Id { get; set; }
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public string Tags { get; set; }
        public int? SubjectIdFk { get; set; }

        public virtual MSubject SubjectIdFkNavigation { get; set; }
    }
}

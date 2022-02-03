using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class Aspnetuser
    {
        public Aspnetuser()
        {
            Aspnetuserclaims = new HashSet<Aspnetuserclaim>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogin>();
            Aspnetuserroles = new HashSet<Aspnetuserrole>();
            Aspnetusertokens = new HashSet<Aspnetusertoken>();
            MAspnetUserAvailableTimes = new HashSet<MAspnetUserAvailableTime>();
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguage>();
            MMoodleUsers = new HashSet<MMoodleUser>();
            MTutorCourses = new HashSet<MTutorCourse>();
            MTutorEducations = new HashSet<MTutorEducation>();
            MTutorRatings = new HashSet<MTutorRating>();
            MTutorWorkExperiences = new HashSet<MTutorWorkExperience>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public ulong EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public ulong PhoneNumberConfirmed { get; set; }
        public ulong TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public ulong LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual MTutor MTutor { get; set; }
        public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; set; }
        public virtual ICollection<MAspnetUserAvailableTime> MAspnetUserAvailableTimes { get; set; }
        public virtual ICollection<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MMoodleUser> MMoodleUsers { get; set; }
        public virtual ICollection<MTutorCourse> MTutorCourses { get; set; }
        public virtual ICollection<MTutorEducation> MTutorEducations { get; set; }
        public virtual ICollection<MTutorRating> MTutorRatings { get; set; }
        public virtual ICollection<MTutorWorkExperience> MTutorWorkExperiences { get; set; }
    }
}

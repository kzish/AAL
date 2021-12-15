using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            MAspnetUserAvailableTimes = new HashSet<MAspnetUserAvailableTime>();
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguage>();
            MMoodleUsers = new HashSet<MMoodleUser>();
            MTutorCourses = new HashSet<MTutorCourse>();
            MTutorEducations = new HashSet<MTutorEducation>();
            MTutorLanguages = new HashSet<MTutorLanguage>();
            MTutorRatings = new HashSet<MTutorRating>();
            MTutorWorkExperiences = new HashSet<MTutorWorkExperience>();
            MTutorsSubjects = new HashSet<MTutorsSubject>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual MTutor MTutor { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<MAspnetUserAvailableTime> MAspnetUserAvailableTimes { get; set; }
        public virtual ICollection<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MMoodleUser> MMoodleUsers { get; set; }
        public virtual ICollection<MTutorCourse> MTutorCourses { get; set; }
        public virtual ICollection<MTutorEducation> MTutorEducations { get; set; }
        public virtual ICollection<MTutorLanguage> MTutorLanguages { get; set; }
        public virtual ICollection<MTutorRating> MTutorRatings { get; set; }
        public virtual ICollection<MTutorWorkExperience> MTutorWorkExperiences { get; set; }
        public virtual ICollection<MTutorsSubject> MTutorsSubjects { get; set; }
    }
}

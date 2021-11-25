﻿using System;
using System.Collections.Generic;

namespace AAL_TUTOR.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            MAspnetUserAvailableTimes = new HashSet<MAspnetUserAvailableTimes>();
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguages>();
            MMoodleUser = new HashSet<MMoodleUser>();
            MTutorEducation = new HashSet<MTutorEducation>();
            MTutorLanguages = new HashSet<MTutorLanguages>();
            MTutorRating = new HashSet<MTutorRating>();
            MTutorWorkExperience = new HashSet<MTutorWorkExperience>();
            MTutorsSubjects = new HashSet<MTutorsSubjects>();
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
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<MAspnetUserAvailableTimes> MAspnetUserAvailableTimes { get; set; }
        public virtual ICollection<MAspnetUserLanguages> MAspnetUserLanguages { get; set; }
        public virtual ICollection<MMoodleUser> MMoodleUser { get; set; }
        public virtual ICollection<MTutorEducation> MTutorEducation { get; set; }
        public virtual ICollection<MTutorLanguages> MTutorLanguages { get; set; }
        public virtual ICollection<MTutorRating> MTutorRating { get; set; }
        public virtual ICollection<MTutorWorkExperience> MTutorWorkExperience { get; set; }
        public virtual ICollection<MTutorsSubjects> MTutorsSubjects { get; set; }
    }
}

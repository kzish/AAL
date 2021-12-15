using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedModels
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<ELanguageLevel> ELanguageLevels { get; set; }
        public virtual DbSet<ETimePeriod> ETimePeriods { get; set; }
        public virtual DbSet<MAspnetUserAvailableTime> MAspnetUserAvailableTimes { get; set; }
        public virtual DbSet<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual DbSet<MCountry> MCountries { get; set; }
        public virtual DbSet<MLanguage> MLanguages { get; set; }
        public virtual DbSet<MMoodleUser> MMoodleUsers { get; set; }
        public virtual DbSet<MSubject> MSubjects { get; set; }
        public virtual DbSet<MSubjectSpeciality> MSubjectSpecialities { get; set; }
        public virtual DbSet<MTopic> MTopics { get; set; }
        public virtual DbSet<MTutor> MTutors { get; set; }
        public virtual DbSet<MTutorCourse> MTutorCourses { get; set; }
        public virtual DbSet<MTutorEducation> MTutorEducations { get; set; }
        public virtual DbSet<MTutorLanguage> MTutorLanguages { get; set; }
        public virtual DbSet<MTutorRating> MTutorRatings { get; set; }
        public virtual DbSet<MTutorWorkExperience> MTutorWorkExperiences { get; set; }
        public virtual DbSet<MTutorsSubject> MTutorsSubjects { get; set; }
        public virtual DbSet<MTutorsSubjectsSpeciality> MTutorsSubjectsSpecialities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=AAL;User Id=sa;Password=123abc!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ELanguageLevel>(entity =>
            {
                entity.ToTable("e_language_levels");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language_level");
            });

            modelBuilder.Entity<ETimePeriod>(entity =>
            {
                entity.ToTable("e_time_periods");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_period");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<MAspnetUserAvailableTime>(entity =>
            {
                entity.ToTable("m_aspnet_user_available_times");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_period");

                entity.Property(e => e.Weekday)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("weekday");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MAspnetUserAvailableTimes)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_m_aspnet_user_available_times_AspNetUsers");
            });

            modelBuilder.Entity<MAspnetUserLanguage>(entity =>
            {
                entity.ToTable("m_aspnet_user_languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserIdFk)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id_fk");

                entity.Property(e => e.LanguageIdFk).HasColumnName("language_id_fk");

                entity.Property(e => e.LanguageLevelIdFk)
                    .HasColumnName("language_level_id_fk")
                    .HasComment("join the tutor and the languages that he speaks together with the proficiency level");

                entity.HasOne(d => d.AspnetUserIdFkNavigation)
                    .WithMany(p => p.MAspnetUserLanguages)
                    .HasForeignKey(d => d.AspnetUserIdFk)
                    .HasConstraintName("FK_m_aspnet_user_languages_AspNetUsers");

                entity.HasOne(d => d.LanguageIdFkNavigation)
                    .WithMany(p => p.MAspnetUserLanguages)
                    .HasForeignKey(d => d.LanguageIdFk)
                    .HasConstraintName("FK_m_aspnet_user_languages_m_languages");

                entity.HasOne(d => d.LanguageLevelIdFkNavigation)
                    .WithMany(p => p.MAspnetUserLanguages)
                    .HasForeignKey(d => d.LanguageLevelIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_aspnet_user_languages_e_language_levels");
            });

            modelBuilder.Entity<MCountry>(entity =>
            {
                entity.HasKey(e => e.CountryIso)
                    .HasName("PK__m_countr__2932A17E3A3246AE");

                entity.ToTable("m_countries");

                entity.Property(e => e.CountryIso)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country_iso")
                    .IsFixedLength(true);

                entity.Property(e => e.CallingCode).HasColumnName("calling_code");

                entity.Property(e => e.CountryIso3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("country_iso3")
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<MLanguage>(entity =>
            {
                entity.ToTable("m_languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iso)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("iso")
                    .IsFixedLength(true);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MMoodleUser>(entity =>
            {
                entity.ToTable("m_moodle_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.MoodleId).HasColumnName("moodle_id");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MMoodleUsers)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutors_AspNetUsers");
            });

            modelBuilder.Entity<MSubject>(entity =>
            {
                entity.ToTable("m_subject");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("these subjects are the titles in moodle, each tutor will create his/her own course guided by these titles");

                entity.Property(e => e.SubjectDescription)
                    .IsUnicode(false)
                    .HasColumnName("subject_description");

                entity.Property(e => e.SubjectTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subject_title");
            });

            modelBuilder.Entity<MSubjectSpeciality>(entity =>
            {
                entity.ToTable("m_subject_specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Speciality)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("speciality");

                entity.Property(e => e.SubjectIdFk).HasColumnName("subject_id_fk");

                entity.HasOne(d => d.SubjectIdFkNavigation)
                    .WithMany(p => p.MSubjectSpecialities)
                    .HasForeignKey(d => d.SubjectIdFk)
                    .HasConstraintName("FK_m_subject_specialities_m_subject");
            });

            modelBuilder.Entity<MTopic>(entity =>
            {
                entity.ToTable("m_topics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectIdFk)
                    .HasColumnName("subject_id_fk")
                    .HasComment("topics fall under the subjects and are used as a guid for the student when searching for topics");

                entity.Property(e => e.Tags)
                    .IsUnicode(false)
                    .HasColumnName("tags")
                    .HasComment("tags are to help for search");

                entity.Property(e => e.TopicDescription)
                    .IsUnicode(false)
                    .HasColumnName("topic_description");

                entity.Property(e => e.TopicTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("topic_title");

                entity.HasOne(d => d.SubjectIdFkNavigation)
                    .WithMany(p => p.MTopics)
                    .HasForeignKey(d => d.SubjectIdFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_m_topics_m_subject");
            });

            modelBuilder.Entity<MTutor>(entity =>
            {
                entity.HasKey(e => e.AspnetUserId)
                    .HasName("PK_m_tutor_1");

                entity.ToTable("m_tutor");

                entity.Property(e => e.AspnetUserId).HasColumnName("aspnet_user_id");

                entity.Property(e => e.About)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CoutryIso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("coutry_iso");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.AspnetUser)
                    .WithOne(p => p.MTutor)
                    .HasForeignKey<MTutor>(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_AspNetUsers");
            });

            modelBuilder.Entity<MTutorCourse>(entity =>
            {
                entity.ToTable("m_tutor_courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duration");

                entity.Property(e => e.MoodleCourseId).HasColumnName("moodle_course_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorCourses)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_m_tutor_courses_AspNetUsers");
            });

            modelBuilder.Entity<MTutorEducation>(entity =>
            {
                entity.ToTable("m_tutor_education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("date_to");

                entity.Property(e => e.DiplomaOrDegree)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("diploma_or_degree");

                entity.Property(e => e.InsituteOrUniversity)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("insitute_or_university");

                entity.Property(e => e.Verified).HasColumnName("verified");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorEducations)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_tutor_education_AspNetUsers");
            });

            modelBuilder.Entity<MTutorLanguage>(entity =>
            {
                entity.ToTable("m_tutor_languages");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LanguageLevelId).HasColumnName("language_level_id");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorLanguages)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_languages_AspNetUsers");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.MTutorLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_m_tutor_languages_m_languages");

                entity.HasOne(d => d.LanguageLevel)
                    .WithMany(p => p.MTutorLanguages)
                    .HasForeignKey(d => d.LanguageLevelId)
                    .HasConstraintName("FK_m_tutor_languages_e_language_levels");
            });

            modelBuilder.Entity<MTutorRating>(entity =>
            {
                entity.ToTable("m_tutor_rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FiveStarRating).HasColumnName("five_star_rating");

                entity.Property(e => e.FourStarRating).HasColumnName("four_star_rating");

                entity.Property(e => e.OneStarRating).HasColumnName("one_star_rating");

                entity.Property(e => e.RatorsIdNfk)
                    .HasMaxLength(450)
                    .HasColumnName("rators_id_nfk");

                entity.Property(e => e.ThreeStarRating).HasColumnName("three_star_rating");

                entity.Property(e => e.TutorAspnetIdFk)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("tutor_aspnet_id_fk");

                entity.Property(e => e.TwoStarRating).HasColumnName("two_star_rating");

                entity.HasOne(d => d.TutorAspnetIdFkNavigation)
                    .WithMany(p => p.MTutorRatings)
                    .HasForeignKey(d => d.TutorAspnetIdFk)
                    .HasConstraintName("FK_m_tutor_rating_AspNetUsers");
            });

            modelBuilder.Entity<MTutorWorkExperience>(entity =>
            {
                entity.ToTable("m_tutor_work_experience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("date_to");

                entity.Property(e => e.Organization)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("organization");

                entity.Property(e => e.Roles)
                    .IsUnicode(false)
                    .HasColumnName("roles");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorWorkExperiences)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_work_experience_m_tutor_work_experience");
            });

            modelBuilder.Entity<MTutorsSubject>(entity =>
            {
                entity.ToTable("m_tutors_subjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserIdFk)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id_fk");

                entity.Property(e => e.PricePerHour)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price_per_hour");

                entity.Property(e => e.SubjectIdFk).HasColumnName("subject_id_fk");

                entity.HasOne(d => d.AspnetUserIdFkNavigation)
                    .WithMany(p => p.MTutorsSubjects)
                    .HasForeignKey(d => d.AspnetUserIdFk)
                    .HasConstraintName("FK_m_tutors_subjects_AspNetUsers");

                entity.HasOne(d => d.SubjectIdFkNavigation)
                    .WithMany(p => p.MTutorsSubjects)
                    .HasForeignKey(d => d.SubjectIdFk)
                    .HasConstraintName("FK_m_tutors_subjects_m_subject");
            });

            modelBuilder.Entity<MTutorsSubjectsSpeciality>(entity =>
            {
                entity.ToTable("m_tutors_subjects_specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.TutorsSubjectIdFk).HasColumnName("tutors_subject_id_fk");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.MTutorsSubjectsSpecialities)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_m_tutors_subjects_specialities_m_subject_specialities");

                entity.HasOne(d => d.TutorsSubjectIdFkNavigation)
                    .WithMany(p => p.MTutorsSubjectsSpecialities)
                    .HasForeignKey(d => d.TutorsSubjectIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_tutors_subjects_specialities_m_tutors_subjects");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

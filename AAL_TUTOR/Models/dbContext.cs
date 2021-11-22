using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AAL_TUTOR.Models
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

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ELanguageLevels> ELanguageLevels { get; set; }
        public virtual DbSet<ETimePeriods> ETimePeriods { get; set; }
        public virtual DbSet<MAspnetUserAvailableTimes> MAspnetUserAvailableTimes { get; set; }
        public virtual DbSet<MAspnetUserLanguages> MAspnetUserLanguages { get; set; }
        public virtual DbSet<MCountries> MCountries { get; set; }
        public virtual DbSet<MLanguages> MLanguages { get; set; }
        public virtual DbSet<MMoodleUser> MMoodleUser { get; set; }
        public virtual DbSet<MSubject> MSubject { get; set; }
        public virtual DbSet<MSubjectSpecialities> MSubjectSpecialities { get; set; }
        public virtual DbSet<MTopics> MTopics { get; set; }
        public virtual DbSet<MTutor> MTutor { get; set; }
        public virtual DbSet<MTutorEducation> MTutorEducation { get; set; }
        public virtual DbSet<MTutorLanguages> MTutorLanguages { get; set; }
        public virtual DbSet<MTutorRating> MTutorRating { get; set; }
        public virtual DbSet<MTutorWorkExperience> MTutorWorkExperience { get; set; }
        public virtual DbSet<MTutorsSubjects> MTutorsSubjects { get; set; }
        public virtual DbSet<MTutorsSubjectsSpecialities> MTutorsSubjectsSpecialities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=AAL;User Id=sa;Password=123abc!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ELanguageLevels>(entity =>
            {
                entity.ToTable("e_language_levels");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageLevel)
                    .HasColumnName("language_level")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ETimePeriods>(entity =>
            {
                entity.ToTable("e_time_periods");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TimePeriod)
                    .HasColumnName("time_period")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MAspnetUserAvailableTimes>(entity =>
            {
                entity.ToTable("m_aspnet_user_available_times");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspnetUserId)
                    .HasColumnName("aspnet_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.TimePeriod)
                    .HasColumnName("time_period")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weekday)
                    .HasColumnName("weekday")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MAspnetUserLanguages>(entity =>
            {
                entity.ToTable("m_aspnet_user_languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserIdFk)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id_fk")
                    .HasMaxLength(450);

                entity.Property(e => e.LanguageIdFk).HasColumnName("language_id_fk");

                entity.Property(e => e.LanguageLevelIdFk).HasColumnName("language_level_id_fk");

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

            modelBuilder.Entity<MCountries>(entity =>
            {
                entity.HasKey(e => e.CountryIso)
                    .HasName("PK__m_countr__2932A17E3A3246AE");

                entity.ToTable("m_countries");

                entity.Property(e => e.CountryIso)
                    .HasColumnName("country_iso")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CallingCode).HasColumnName("calling_code");

                entity.Property(e => e.CountryIso3)
                    .HasColumnName("country_iso3")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MLanguages>(entity =>
            {
                entity.ToTable("m_languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iso)
                    .HasColumnName("iso")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasColumnName("language_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MMoodleUser>(entity =>
            {
                entity.ToTable("m_moodle_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoodleId).HasColumnName("moodle_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MMoodleUser)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutors_AspNetUsers");
            });

            modelBuilder.Entity<MSubject>(entity =>
            {
                entity.ToTable("m_subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectDescription)
                    .HasColumnName("subject_description")
                    .IsUnicode(false);

                entity.Property(e => e.SubjectTitle)
                    .IsRequired()
                    .HasColumnName("subject_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MSubjectSpecialities>(entity =>
            {
                entity.ToTable("m_subject_specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Speciality)
                    .IsRequired()
                    .HasColumnName("speciality")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectIdFk).HasColumnName("subject_id_fk");

                entity.HasOne(d => d.SubjectIdFkNavigation)
                    .WithMany(p => p.MSubjectSpecialities)
                    .HasForeignKey(d => d.SubjectIdFk)
                    .HasConstraintName("FK_m_subject_specialities_m_subject");
            });

            modelBuilder.Entity<MTopics>(entity =>
            {
                entity.ToTable("m_topics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectIdFk).HasColumnName("subject_id_fk");

                entity.Property(e => e.Tags)
                    .HasColumnName("tags")
                    .IsUnicode(false);

                entity.Property(e => e.TopicDescription)
                    .HasColumnName("topic_description")
                    .IsUnicode(false);

                entity.Property(e => e.TopicTitle)
                    .IsRequired()
                    .HasColumnName("topic_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

                entity.Property(e => e.AspnetUserId)
                    .HasColumnName("aspnet_user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.About)
                    .HasColumnName("about")
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CoutryIso)
                    .HasColumnName("coutry_iso")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AspnetUser)
                    .WithOne(p => p.MTutor)
                    .HasForeignKey<MTutor>(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_AspNetUsers");
            });

            modelBuilder.Entity<MTutorEducation>(entity =>
            {
                entity.ToTable("m_tutor_education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiplomaOrDegree)
                    .HasColumnName("diploma_or_degree")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsituteOrUniversity)
                    .HasColumnName("insitute_or_university")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Verified).HasColumnName("verified");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorEducation)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_tutor_education_AspNetUsers");
            });

            modelBuilder.Entity<MTutorLanguages>(entity =>
            {
                entity.ToTable("m_tutor_languages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id")
                    .HasMaxLength(450);

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
                    .HasColumnName("rators_id_nfk")
                    .HasMaxLength(450);

                entity.Property(e => e.ThreeStarRating).HasColumnName("three_star_rating");

                entity.Property(e => e.TutorAspnetIdFk)
                    .IsRequired()
                    .HasColumnName("tutor_aspnet_id_fk")
                    .HasMaxLength(450);

                entity.Property(e => e.TwoStarRating).HasColumnName("two_star_rating");

                entity.HasOne(d => d.TutorAspnetIdFkNavigation)
                    .WithMany(p => p.MTutorRating)
                    .HasForeignKey(d => d.TutorAspnetIdFk)
                    .HasConstraintName("FK_m_tutor_rating_AspNetUsers");
            });

            modelBuilder.Entity<MTutorWorkExperience>(entity =>
            {
                entity.ToTable("m_tutor_work_experience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Organization)
                    .HasColumnName("organization")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Roles)
                    .HasColumnName("roles")
                    .IsUnicode(false);

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorWorkExperience)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_work_experience_m_tutor_work_experience");
            });

            modelBuilder.Entity<MTutorsSubjects>(entity =>
            {
                entity.ToTable("m_tutors_subjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserIdFk)
                    .IsRequired()
                    .HasColumnName("aspnet_user_id_fk")
                    .HasMaxLength(450);

                entity.Property(e => e.PricePerHour)
                    .HasColumnName("price_per_hour")
                    .HasColumnType("decimal(18, 2)");

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

            modelBuilder.Entity<MTutorsSubjectsSpecialities>(entity =>
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
        }
    }
}

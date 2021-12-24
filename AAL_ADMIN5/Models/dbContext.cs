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

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }
        public virtual DbSet<ELanguageLevel> ELanguageLevels { get; set; }
        public virtual DbSet<ETimePeriod> ETimePeriods { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<MAspnetUserAvailableTime> MAspnetUserAvailableTimes { get; set; }
        public virtual DbSet<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
        public virtual DbSet<MCountry> MCountries { get; set; }
        public virtual DbSet<MLanguage> MLanguages { get; set; }
        public virtual DbSet<MMoodleUser> MMoodleUsers { get; set; }
        public virtual DbSet<MTutor> MTutors { get; set; }
        public virtual DbSet<MTutorCourse> MTutorCourses { get; set; }
        public virtual DbSet<MTutorEducation> MTutorEducations { get; set; }
        public virtual DbSet<MTutorLanguage> MTutorLanguages { get; set; }
        public virtual DbSet<MTutorRating> MTutorRatings { get; set; }
        public virtual DbSet<MTutorWorkExperience> MTutorWorkExperiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Globals.AppSettings.connection_string, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnd).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ProviderDisplayName)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Value)
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<ELanguageLevel>(entity =>
            {
                entity.ToTable("e_language_levels");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageLevel)
                    .HasMaxLength(50)
                    .HasColumnName("language_level");
            });

            modelBuilder.Entity<ETimePeriod>(entity =>
            {
                entity.ToTable("e_time_periods");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(50)
                    .HasColumnName("time_period");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<MAspnetUserAvailableTime>(entity =>
            {
                entity.ToTable("m_aspnet_user_available_times");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_aspnet_user_available_times_AspNetUsers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TimePeriod)
                    .HasMaxLength(50)
                    .HasColumnName("time_period");

                entity.Property(e => e.Weekday)
                    .HasMaxLength(50)
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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserIdFk, "FK_m_aspnet_user_languages_AspNetUsers");

                entity.HasIndex(e => e.LanguageIdFk, "FK_m_aspnet_user_languages_e_language_levels");

                entity.HasIndex(e => e.LanguageLevelIdFk, "FK_m_aspnet_user_languages_m_languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserIdFk)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id_fk")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

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
                    .HasConstraintName("FK_m_aspnet_user_languages_e_language_levels");

                entity.HasOne(d => d.LanguageLevelIdFkNavigation)
                    .WithMany(p => p.MAspnetUserLanguages)
                    .HasForeignKey(d => d.LanguageLevelIdFk)
                    .HasConstraintName("FK_m_aspnet_user_languages_m_languages");
            });

            modelBuilder.Entity<MCountry>(entity =>
            {
                entity.HasKey(e => e.CountryIso)
                    .HasName("PRIMARY");

                entity.ToTable("m_countries");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CountryIso)
                    .HasMaxLength(2)
                    .HasColumnName("country_iso")
                    .IsFixedLength(true);

                entity.Property(e => e.CallingCode).HasColumnName("calling_code");

                entity.Property(e => e.CountryIso3)
                    .HasMaxLength(3)
                    .HasColumnName("country_iso3")
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<MLanguage>(entity =>
            {
                entity.ToTable("m_languages");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iso)
                    .HasMaxLength(2)
                    .HasColumnName("iso")
                    .IsFixedLength(true);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("language_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MMoodleUser>(entity =>
            {
                entity.ToTable("m_moodle_user");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_moodle_user_aspnetusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.MoodleId).HasColumnName("moodle_id");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MMoodleUsers)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_moodle_user_aspnetusers");
            });

            modelBuilder.Entity<MTutor>(entity =>
            {
                entity.HasKey(e => e.AspnetUserId)
                    .HasName("PRIMARY");

                entity.ToTable("m_tutor");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.AspnetUserId)
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CoutryIso)
                    .HasMaxLength(5)
                    .HasColumnName("coutry_iso");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.AspnetUser)
                    .WithOne(p => p.MTutor)
                    .HasForeignKey<MTutor>(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_aspnetusers");
            });

            modelBuilder.Entity<MTutorCourse>(entity =>
            {
                entity.ToTable("m_tutor_courses");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_tutor_courses_aspnetusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .HasColumnName("duration");

                entity.Property(e => e.MoodleCourseId).HasColumnName("moodle_course_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasColumnName("title");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorCourses)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_m_tutor_courses_aspnetusers");
            });

            modelBuilder.Entity<MTutorEducation>(entity =>
            {
                entity.ToTable("m_tutor_education");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_tutor_education_aspnetusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("date_to");

                entity.Property(e => e.DiplomaOrDegree)
                    .HasMaxLength(150)
                    .HasColumnName("diploma_or_degree");

                entity.Property(e => e.InsituteOrUniversity)
                    .HasMaxLength(150)
                    .HasColumnName("insitute_or_university");

                entity.Property(e => e.Verified).HasColumnName("verified");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorEducations)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_education_aspnetusers");
            });

            modelBuilder.Entity<MTutorLanguage>(entity =>
            {
                entity.ToTable("m_tutor_languages");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_tutor_languages_aspnetusers");

                entity.HasIndex(e => e.LanguageLevelId, "FK_m_tutor_languages_e_language_levels");

                entity.HasIndex(e => e.LanguageId, "FK_m_tutor_languages_m_languages");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LanguageLevelId).HasColumnName("language_level_id");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorLanguages)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_languages_aspnetusers");

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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.TutorAspnetIdFk, "FK_m_tutor_rating_aspnetusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FiveStarRating).HasColumnName("five_star_rating");

                entity.Property(e => e.FourStarRating).HasColumnName("four_star_rating");

                entity.Property(e => e.OneStarRating).HasColumnName("one_star_rating");

                entity.Property(e => e.RatorsIdNfk)
                    .HasMaxLength(450)
                    .HasColumnName("rators_id_nfk")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ThreeStarRating).HasColumnName("three_star_rating");

                entity.Property(e => e.TutorAspnetIdFk)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("tutor_aspnet_id_fk")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TwoStarRating).HasColumnName("two_star_rating");

                entity.HasOne(d => d.TutorAspnetIdFkNavigation)
                    .WithMany(p => p.MTutorRatings)
                    .HasForeignKey(d => d.TutorAspnetIdFk)
                    .HasConstraintName("FK_m_tutor_rating_aspnetusers");
            });

            modelBuilder.Entity<MTutorWorkExperience>(entity =>
            {
                entity.ToTable("m_tutor_work_experience");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AspnetUserId, "FK_m_tutor_work_experience_aspnetusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("aspnet_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("date_to");

                entity.Property(e => e.Organization)
                    .HasMaxLength(150)
                    .HasColumnName("organization");

                entity.Property(e => e.Roles).HasColumnName("roles");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.MTutorWorkExperiences)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_m_tutor_work_experience_aspnetusers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

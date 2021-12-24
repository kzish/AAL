USE [master]
GO
/****** Object:  Database [AAL]    Script Date: 2021/12/07 21:18:04 ******/
CREATE DATABASE [AAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AAL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AAL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AAL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AAL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AAL] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [AAL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AAL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AAL] SET  MULTI_USER 
GO
ALTER DATABASE [AAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AAL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AAL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AAL] SET QUERY_STORE = OFF
GO
USE [AAL]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[e_language_levels]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[e_language_levels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[language_level] [varchar](50) NULL,
 CONSTRAINT [PK_e_language_levels] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[e_time_periods]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[e_time_periods](
	[id] [varchar](50) NOT NULL,
	[time_period] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[sequence] [int] NULL,
 CONSTRAINT [PK_e_time_periods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_aspnet_user_available_times]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_aspnet_user_available_times](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id] [nvarchar](450) NULL,
	[weekday] [varchar](50) NULL,
	[time_period] [varchar](50) NULL,
 CONSTRAINT [PK_m_aspnet_user_available_times] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_aspnet_user_languages]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_aspnet_user_languages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id_fk] [nvarchar](450) NOT NULL,
	[language_id_fk] [int] NOT NULL,
	[language_level_id_fk] [int] NOT NULL,
 CONSTRAINT [PK_m_tutor_languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_countries]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_countries](
	[country_iso] [char](2) NOT NULL,
	[country_iso3] [char](3) NULL,
	[calling_code] [int] NOT NULL,
	[country_name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[country_iso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_languages]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_languages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[language_name] [char](50) NOT NULL,
	[iso] [char](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_moodle_user]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_moodle_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id] [nvarchar](450) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[moodle_id] [int] NULL,
	[password] [varchar](max) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_m_tutors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_subject]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject_title] [varchar](50) NOT NULL,
	[subject_description] [varchar](max) NULL,
 CONSTRAINT [PK_m_subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_subject_specialities]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_subject_specialities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject_id_fk] [int] NOT NULL,
	[speciality] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_m_subject_properties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_topics]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_topics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[topic_title] [varchar](50) NOT NULL,
	[topic_description] [varchar](max) NULL,
	[tags] [varchar](max) NULL,
	[subject_id_fk] [int] NULL,
 CONSTRAINT [PK_m_topics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor](
	[aspnet_user_id] [nvarchar](450) NOT NULL,
	[firstname] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[image_url] [varchar](max) NULL,
	[coutry_iso] [varchar](5) NULL,
	[about] [varchar](max) NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_m_tutor_1] PRIMARY KEY CLUSTERED 
(
	[aspnet_user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor_courses]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor_courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id] [nvarchar](450) NULL,
	[title] [varchar](150) NULL,
	[description] [varchar](max) NULL,
	[duration] [varchar](50) NULL,
	[moodle_course_id] [int] NULL,
 CONSTRAINT [PK_m_tutor_courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor_education]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor_education](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id] [nvarchar](450) NOT NULL,
	[date_from] [datetime] NULL,
	[date_to] [datetime] NULL,
	[insitute_or_university] [varchar](150) NULL,
	[diploma_or_degree] [varchar](150) NULL,
	[verified] [bit] NOT NULL,
 CONSTRAINT [PK_m_tutor_education] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor_languages]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor_languages](
	[id] [int] NOT NULL,
	[aspnet_user_id] [nvarchar](450) NOT NULL,
	[language_id] [int] NOT NULL,
	[language_level_id] [int] NOT NULL,
 CONSTRAINT [PK_m_tutor_languages_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor_rating]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor_rating](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tutor_aspnet_id_fk] [nvarchar](450) NOT NULL,
	[five_star_rating] [int] NULL,
	[four_star_rating] [int] NULL,
	[three_star_rating] [int] NULL,
	[two_star_rating] [int] NULL,
	[one_star_rating] [int] NULL,
	[rators_id_nfk] [nvarchar](450) NULL,
 CONSTRAINT [PK_m_tutor_rating] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutor_work_experience]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutor_work_experience](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_user_id] [nvarchar](450) NOT NULL,
	[date_from] [datetime] NULL,
	[date_to] [datetime] NULL,
	[organization] [varchar](150) NULL,
	[roles] [varchar](max) NULL,
 CONSTRAINT [PK_m_tutor_work_experience] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutors_subjects]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutors_subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject_id_fk] [int] NOT NULL,
	[aspnet_user_id_fk] [nvarchar](450) NOT NULL,
	[price_per_hour] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_m_tutors_subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_tutors_subjects_specialities]    Script Date: 2021/12/07 21:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_tutors_subjects_specialities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tutors_subject_id_fk] [int] NOT NULL,
	[speciality_id] [int] NOT NULL,
 CONSTRAINT [PK_m_tutors_subjects_specialities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2021/12/07 21:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2021/12/07 21:18:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2021/12/07 21:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2021/12/07 21:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2021/12/07 21:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2021/12/07 21:18:04 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2021/12/07 21:18:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[m_countries] ADD  DEFAULT (NULL) FOR [country_iso3]
GO
ALTER TABLE [dbo].[m_languages] ADD  DEFAULT (NULL) FOR [iso]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[m_aspnet_user_available_times]  WITH CHECK ADD  CONSTRAINT [FK_m_aspnet_user_available_times_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_aspnet_user_available_times] CHECK CONSTRAINT [FK_m_aspnet_user_available_times_AspNetUsers]
GO
ALTER TABLE [dbo].[m_aspnet_user_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_aspnet_user_languages_AspNetUsers] FOREIGN KEY([aspnet_user_id_fk])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_aspnet_user_languages] CHECK CONSTRAINT [FK_m_aspnet_user_languages_AspNetUsers]
GO
ALTER TABLE [dbo].[m_aspnet_user_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_aspnet_user_languages_e_language_levels] FOREIGN KEY([language_level_id_fk])
REFERENCES [dbo].[e_language_levels] ([id])
GO
ALTER TABLE [dbo].[m_aspnet_user_languages] CHECK CONSTRAINT [FK_m_aspnet_user_languages_e_language_levels]
GO
ALTER TABLE [dbo].[m_aspnet_user_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_aspnet_user_languages_m_languages] FOREIGN KEY([language_id_fk])
REFERENCES [dbo].[m_languages] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_aspnet_user_languages] CHECK CONSTRAINT [FK_m_aspnet_user_languages_m_languages]
GO
ALTER TABLE [dbo].[m_moodle_user]  WITH CHECK ADD  CONSTRAINT [FK_m_tutors_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_moodle_user] CHECK CONSTRAINT [FK_m_tutors_AspNetUsers]
GO
ALTER TABLE [dbo].[m_subject_specialities]  WITH CHECK ADD  CONSTRAINT [FK_m_subject_specialities_m_subject] FOREIGN KEY([subject_id_fk])
REFERENCES [dbo].[m_subject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_subject_specialities] CHECK CONSTRAINT [FK_m_subject_specialities_m_subject]
GO
ALTER TABLE [dbo].[m_topics]  WITH CHECK ADD  CONSTRAINT [FK_m_topics_m_subject] FOREIGN KEY([subject_id_fk])
REFERENCES [dbo].[m_subject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_topics] CHECK CONSTRAINT [FK_m_topics_m_subject]
GO
ALTER TABLE [dbo].[m_tutor]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor] CHECK CONSTRAINT [FK_m_tutor_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutor_courses]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_courses_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_courses] CHECK CONSTRAINT [FK_m_tutor_courses_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutor_education]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_education_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[m_tutor_education] CHECK CONSTRAINT [FK_m_tutor_education_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutor_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_languages_AspNetUsers] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_languages] CHECK CONSTRAINT [FK_m_tutor_languages_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutor_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_languages_e_language_levels] FOREIGN KEY([language_level_id])
REFERENCES [dbo].[e_language_levels] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_languages] CHECK CONSTRAINT [FK_m_tutor_languages_e_language_levels]
GO
ALTER TABLE [dbo].[m_tutor_languages]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_languages_m_languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[m_languages] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_languages] CHECK CONSTRAINT [FK_m_tutor_languages_m_languages]
GO
ALTER TABLE [dbo].[m_tutor_rating]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_rating_AspNetUsers] FOREIGN KEY([tutor_aspnet_id_fk])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_rating] CHECK CONSTRAINT [FK_m_tutor_rating_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutor_work_experience]  WITH CHECK ADD  CONSTRAINT [FK_m_tutor_work_experience_m_tutor_work_experience] FOREIGN KEY([aspnet_user_id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutor_work_experience] CHECK CONSTRAINT [FK_m_tutor_work_experience_m_tutor_work_experience]
GO
ALTER TABLE [dbo].[m_tutors_subjects]  WITH CHECK ADD  CONSTRAINT [FK_m_tutors_subjects_AspNetUsers] FOREIGN KEY([aspnet_user_id_fk])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutors_subjects] CHECK CONSTRAINT [FK_m_tutors_subjects_AspNetUsers]
GO
ALTER TABLE [dbo].[m_tutors_subjects]  WITH CHECK ADD  CONSTRAINT [FK_m_tutors_subjects_m_subject] FOREIGN KEY([subject_id_fk])
REFERENCES [dbo].[m_subject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutors_subjects] CHECK CONSTRAINT [FK_m_tutors_subjects_m_subject]
GO
ALTER TABLE [dbo].[m_tutors_subjects_specialities]  WITH CHECK ADD  CONSTRAINT [FK_m_tutors_subjects_specialities_m_subject_specialities] FOREIGN KEY([speciality_id])
REFERENCES [dbo].[m_subject_specialities] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[m_tutors_subjects_specialities] CHECK CONSTRAINT [FK_m_tutors_subjects_specialities_m_subject_specialities]
GO
ALTER TABLE [dbo].[m_tutors_subjects_specialities]  WITH CHECK ADD  CONSTRAINT [FK_m_tutors_subjects_specialities_m_tutors_subjects] FOREIGN KEY([tutors_subject_id_fk])
REFERENCES [dbo].[m_tutors_subjects] ([id])
GO
ALTER TABLE [dbo].[m_tutors_subjects_specialities] CHECK CONSTRAINT [FK_m_tutors_subjects_specialities_m_tutors_subjects]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'join the tutor and the languages that he speaks together with the proficiency level' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_aspnet_user_languages', @level2type=N'COLUMN',@level2name=N'language_level_id_fk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'these subjects are the titles in moodle, each tutor will create his/her own course guided by these titles' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_subject', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'tags are to help for search' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_topics', @level2type=N'COLUMN',@level2name=N'tags'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'topics fall under the subjects and are used as a guid for the student when searching for topics' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_topics', @level2type=N'COLUMN',@level2name=N'subject_id_fk'
GO
USE [master]
GO
ALTER DATABASE [AAL] SET  READ_WRITE 
GO

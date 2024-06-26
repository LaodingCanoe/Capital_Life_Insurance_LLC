USE [master]
GO
/****** Object:  Database [Capital_Life_Insurance_LLC]    Script Date: 10.06.2024 21:17:10 ******/
CREATE DATABASE [Capital_Life_Insurance_LLC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Capital_Life_Insurance_LLC', FILENAME = N'W:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\Capital_Life_Insurance_LLC.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Capital_Life_Insurance_LLC_log', FILENAME = N'W:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\Capital_Life_Insurance_LLC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Capital_Life_Insurance_LLC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ARITHABORT OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET RECOVERY FULL 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET  MULTI_USER 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Capital_Life_Insurance_LLC', N'ON'
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET QUERY_STORE = ON
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Capital_Life_Insurance_LLC]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerTitle] [nvarchar](max) NOT NULL,
	[AnswerWeightCoefficient] [float] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidateCard]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateCard](
	[CandidateID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Patranomic] [nvarchar](100) NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Bithday] [date] NOT NULL,
	[Position] [int] NOT NULL,
	[PhotoPath] [nvarchar](100) NULL,
	[CreateUserID] [int] NOT NULL,
 CONSTRAINT [PK__Candidat__DF539BFCEF061677] PRIMARY KEY CLUSTERED 
(
	[CandidateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidateEducation]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateEducation](
	[CandidateEducationID] [int] IDENTITY(1,1) NOT NULL,
	[Candidate] [int] NULL,
	[Education] [int] NULL,
 CONSTRAINT [PK_CandidateEducation] PRIMARY KEY CLUSTERED 
(
	[CandidateEducationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[EducationID] [int] IDENTITY(1,1) NOT NULL,
	[EducationLevel] [nvarchar](100) NOT NULL,
	[EducationDocument] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EducationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[CandidateID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswersID] [int] NOT NULL,
 CONSTRAINT [PK__Grade__54F87A3735CC4B1D] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionsID] [int] IDENTITY(1,1) NOT NULL,
	[PositionsTitle] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[QuashionWeightCoefficient] [float] NOT NULL,
 CONSTRAINT [PK__Quashion__8BA05495C3C71F3C] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speciality]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speciality](
	[SpecialityID] [int] IDENTITY(1,1) NOT NULL,
	[SpecialityTitle] [nvarchar](100) NOT NULL,
	[SpecialityInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SpecialityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.06.2024 21:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Patranomic] [nvarchar](100) NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserWeightCoefficient] [float] NULL,
 CONSTRAINT [PK__Users__1788CCACECADCFB9] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (1, 1, N'Кандидат создает приятную комфортную атмосферу, располагает к общению, легко выражает и формулирует свои мысли, общается тактично и вежливо, грамотно оперирует терминологией предметной области;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (2, 1, N'Кандидат во время общения скован, зажат, при этом достаточно вежлив и тактичен, формулирует свои мысли не с первого раза, тем не менее, старается четко донести их до собеседника. При общении недостаточно внимателен, упускает детали разговора;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (3, 1, N'Кандидат во время общения относится неуважительно к собеседнику. Излишне эмоционален, часто вступает в спор, перебивает собеседника, слушает невнимательно, чрезмерно жестикулирует.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (4, 2, N'Кандидат обладает глубокими знаниями, имеет целостное представление профессиональной области;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (5, 2, N'Кандидат обладает профессиональными знаниями на удовлетворительном уровне;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (6, 2, N'Знания кандидата поверхностные. Кандидат затрудняется ответить на вопросы в теме профессиональной области.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (7, 3, N'Кандидат выполняет работу без ошибок, либо с незначительными погрешностями, которые исправляются им самостоятельно. Работа выполнена аккуратно и точно, без чьей-либо помощи;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (8, 3, N'Качество работ соответствует предъявленным требованиям. Кандидат иногда (редко) допускает ошибки, нуждается в помощи;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (9, 3, N'Кандидат допускает множество ошибок в работе, следовательно, требует постоянной проверки и исправлений со стороны.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (10, 4, N'Кандидат заинтересован в развитии своего потенциала в профессиональной сфере, рассматривает работу как возможность самореализоваться и показать себя;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (11, 4, N'Кандидат проявляет умеренное стремление к работе, поскольку рассматривает ее как источник материальных благ. Главным стимулирующим фактором является заработок;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (12, 4, N'Кандидат не проявляет интереса к работе, не замотивирован к эффективному труду, не желает повышать свою квалификацию.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (13, 5, N'Кандидат не опоздал на собеседование;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (14, 5, N'Кандидат пришел на собеседование с минимальным опозданием; ', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (15, 5, N'Кандидат опоздал на собеседование на большое количество времени без уважительной причины.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (16, 6, N'Уверенное владение компьютером. Хорошее владение пакетом MS Office (Access, Excel, Power Point, Word, WordPad), графическими редакторами (Picture Manager, CorelDRAW), работа с электронной почтой (Outlook Express), уверенная работа с разными браузерами, навыки работы с операционными системами Linux и Windows.', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (17, 6, N'Среднее владение компьютером. Кандидат владеет такими программами для компьютера, как Excel, Word, умеет искать информацию в интернете через браузеры Mozilla, Opera', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (18, 6, N'Слабое владение компьютером. Кандидат умеет выполнять базовые вещи: запускать и выключать компьютер, работать с клавиатурой и мышью, разбирается в стандартных программах — блокнот, Paint, медиаплеер.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (19, 7, N'Кандидат владеет грамотной речью, то есть владеет всеми нормами литературного языка в целом: соблюдение правил пунктуации, орфографии и грамматики, логическое и выразительное изложение мыслей, структурированное и последовательное изложение информации;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (20, 7, N'Кандидат владеет грамотной речью, то есть владеет всеми нормами литературного языка в целом: соблюдение правил пунктуации, орфографии и грамматики, однако у кандидата не всегда логическое и выразительное изложение мыслей, и не структурированное и последовательное изложение информации;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (21, 7, N'Кандидат не владеет грамотной речью, то есть не владеет всеми нормами литературного языка в целом: несоблюдение правил пунктуации, орфографии и грамматики, нелогическое и невыразительное изложение мыслей, неструктурированное и непоследовательное изложение информации;', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (22, 8, N'Кандидат способен переносить значительные интеллектуальные, волевые, эмоциональные нагрузки. Имеет стабильное гармоничное состояние при собеседовании, отлично справляется со стрессовым воздействием;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (23, 8, N'Кандидат во врем стрессовых ситуаций остается в адекватном состоянии, но не всегда может принимать правильные решения в сильном нервном возбуждении;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (24, 8, N'Кандидат обладает низким уровнем стрессоустойчивости — не способен принимать правильные решения и правильные ответы при сильном нервном возбуждении, дезориентирован во времени и в пространстве.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (25, 9, N'В разговоре кандидата преобладают позитивны формулировки, об окружающих людях отзывается хорошо, увлекательно рассказывает, заряжает энергией, держит контакт глаз, стремится во всем видеть плюсы, видит много позитивного в окружающем мире.;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (26, 9, N'В разговоре кандидата преобладают нейтральные формулировки, об окружающих людях отзывается нейтрально, достаточно увлекательно рассказывает, не всегда держит контакт глаз, видит во всем как минусы, так и плюсы, улыбается, но не сильно;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (27, 9, N'В разговоре кандидата преобладают негативные формулировки, об окружающих людях отзывается не лестно, подчеркивает их недостатки, при разговоре отводит взгляд, смотрит в сторону, исподлобья, хмурится, не улыбается, во всем видит минусы, нежели плюсы.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (28, 10, N'Кандидат активен, стремится наладить контакт с новыми людьми, проявляет проактивную позицию, ведет активный образ жизни, ему нравится повышать свой профессиональный уровень, у кандидата можно выделить качества инициативности, самостоятельности и готовности к изменениям;', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (29, 10, N'Кандидат стремится наладить контакт, но не ведет активный образ жизни вне работы, также редко выделяет свое время для повышения профессионального уровня;', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (30, 10, N'Кандидат пассивен, не стремится наладить сам контакт, вне работы ведет пассивный образ жизни, не повышает и не хочет повышать свой профессиональный уровень, считает, что и так все знает и умеет.', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (31, 11, N'efwfwfe', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (32, 11, N'wefwefwef', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (33, 12, N'ewq', 0.7)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (34, 12, N'weq', 0.2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (35, 12, N'qwqw', 0.1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (36, 13, N'2332', 1)
INSERT [dbo].[Answers] ([AnswerId], [QuestionID], [AnswerTitle], [AnswerWeightCoefficient]) VALUES (37, 13, N'Новый ответ', 1)
SET IDENTITY_INSERT [dbo].[Answers] OFF
GO
SET IDENTITY_INSERT [dbo].[CandidateCard] ON 

INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (1, N'Новикова', N'Наталья', N'Геннадьевна', N'+79396526946', N'novikova47@mail.com', CAST(N'1997-04-04' AS Date), 1, N'photo/1.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (2, N'Васильева', N'Ирина', N'Александровна', N'+79537982616', N'irina.vas19@yopmail.com', CAST(N'1980-12-11' AS Date), 1, N'photo/2.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (3, N'Галкина', N'Елена', N'Петровна', N'+79813913696', N'galkina.elena@gmail.com', CAST(N'1991-01-21' AS Date), 1, N'photo/3.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (4, N'Иванов', N'Алексей', N'Викторович', N'+79023322323', N'ivanov@gmail.com', CAST(N'1982-05-23' AS Date), 8, N'photo/4.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (5, N'Морозова ', N'Екатерина', N'Андреевна', N'+79837251873', N'katya.morozova@mail.ru', CAST(N'1971-01-16' AS Date), 4, N'photo/5.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (6, N'Петрова', N'Мария', N'Алексеевна', N'+79234567890', N'maria.petrova@mail.ru', CAST(N'1993-07-23' AS Date), 2, N'photo/6.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (7, N'Смирнов', N'Александр', N'Николаевич', N'+79345678901', N'alex.smirnov@yandex.ru', CAST(N'1983-03-15' AS Date), 3, N'photo/7.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (8, N'Кузнецова', N'Ольга', N'Игоревна', N'+79456789012', N'kuznetsova22@gmail.com', CAST(N'1989-11-05' AS Date), 4, N'photo/8.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (9, N'Новикова', N'Наталья', N'Николаевна', N'+79278734384', N'natasha1312@yandex.ru', CAST(N'1990-11-05' AS Date), 4, N'photo/9.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (10, N'Степанов', N'Владимир', N'Иванович', N'+79371139834', N'stepanov.vova@yandex.ru', CAST(N'1983-11-05' AS Date), 2, N'photo/10.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (11, N'Голубкова', N'Анна', N'Андревна', N'+79271972671', N'retd@ds.ds', CAST(N'1980-01-01' AS Date), 1, N'C:\Users\iskan\OneDrive\Рабочий стол\12.jpg', 3)
INSERT [dbo].[CandidateCard] ([CandidateID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Bithday], [Position], [PhotoPath], [CreateUserID]) VALUES (19, N'Aaaaaaaaa', N'Rqew', N'Qwreqw`', N'+71276127862', N'tqwyutw@d.s', CAST(N'1950-01-01' AS Date), 1, NULL, 3)
SET IDENTITY_INSERT [dbo].[CandidateCard] OFF
GO
SET IDENTITY_INSERT [dbo].[CandidateEducation] ON 

INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (71, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (72, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (73, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (74, NULL, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (75, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (76, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (77, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (78, NULL, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (79, 10, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (80, 8, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (81, 8, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (82, 3, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (83, 3, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (84, 3, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (85, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (86, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (87, NULL, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (88, NULL, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (89, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (90, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (91, 9, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (92, 9, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (96, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (97, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (98, NULL, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (99, NULL, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (100, 2, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (101, 2, 8)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (102, 1, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (103, 1, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (104, 1, 8)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (105, 6, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (106, 6, 8)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (114, 11, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (115, 11, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (116, 11, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (117, 11, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (123, NULL, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (124, NULL, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (125, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (126, NULL, 2)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (127, NULL, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (128, NULL, 8)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (129, NULL, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (130, NULL, 1)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (136, 19, 4)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (137, 19, 8)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (138, 19, 6)
INSERT [dbo].[CandidateEducation] ([CandidateEducationID], [Candidate], [Education]) VALUES (139, 19, 1)
SET IDENTITY_INSERT [dbo].[CandidateEducation] OFF
GO
SET IDENTITY_INSERT [dbo].[Education] ON 

INSERT [dbo].[Education] ([EducationID], [EducationLevel], [EducationDocument]) VALUES (1, N'Среднее общее (10 и 11 классы)', N'Аттестат')
INSERT [dbo].[Education] ([EducationID], [EducationLevel], [EducationDocument]) VALUES (2, N'Среднее профессиональное', N'Диплом')
INSERT [dbo].[Education] ([EducationID], [EducationLevel], [EducationDocument]) VALUES (4, N'Высшее — специалитет, магистратура', N'Диплом')
INSERT [dbo].[Education] ([EducationID], [EducationLevel], [EducationDocument]) VALUES (6, N'Высшее — подготовка кадров высшей квалификации', N'Диплом')
INSERT [dbo].[Education] ([EducationID], [EducationLevel], [EducationDocument]) VALUES (8, N'Высшее - бакалавриат', N'Диплом')
SET IDENTITY_INSERT [dbo].[Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (40, 1, 3, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (41, 1, 3, 2, 6)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (42, 1, 3, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (43, 1, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (44, 1, 3, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (45, 1, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (46, 1, 3, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (47, 2, 3, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (48, 2, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (49, 2, 3, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (50, 2, 3, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (51, 2, 3, 5, 13)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (52, 2, 3, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (53, 2, 3, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (54, 2, 3, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (55, 2, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (56, 2, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (57, 1, 3, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (58, 1, 3, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (59, 1, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (60, 1, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (61, 1, 1, 2, 6)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (62, 1, 1, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (63, 1, 1, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (64, 1, 1, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (65, 1, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (66, 1, 1, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (67, 1, 1, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (68, 1, 1, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (69, 1, 1, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (70, 3, 3, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (71, 3, 3, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (72, 3, 3, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (73, 3, 3, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (74, 3, 3, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (75, 3, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (76, 3, 3, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (77, 3, 3, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (78, 3, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (79, 3, 3, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (80, 4, 3, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (81, 4, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (82, 4, 3, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (83, 4, 3, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (84, 4, 3, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (85, 4, 3, 6, 18)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (86, 4, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (87, 4, 3, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (88, 4, 3, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (89, 4, 3, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (90, 5, 3, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (91, 5, 3, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (92, 5, 3, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (93, 5, 3, 4, 11)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (94, 5, 3, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (95, 5, 3, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (96, 5, 3, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (97, 5, 3, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (98, 5, 3, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (99, 5, 3, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (100, 6, 3, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (101, 6, 3, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (102, 6, 3, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (103, 6, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (104, 6, 3, 5, 13)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (105, 6, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (106, 6, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (107, 6, 3, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (108, 6, 3, 9, 26)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (109, 6, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (110, 11, 3, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (111, 11, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (112, 11, 3, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (113, 11, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (114, 11, 3, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (115, 11, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (116, 11, 3, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (117, 11, 3, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (118, 11, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (119, 11, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (120, 10, 3, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (121, 10, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (122, 10, 3, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (123, 10, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (124, 10, 3, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (125, 10, 3, 6, 18)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (126, 10, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (127, 10, 3, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (128, 10, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (129, 10, 3, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (130, 8, 3, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (131, 8, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (132, 8, 3, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (133, 8, 3, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (134, 8, 3, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (135, 8, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (136, 8, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (137, 8, 3, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (138, 8, 3, 9, 26)
GO
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (139, 8, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (140, 9, 3, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (141, 9, 3, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (142, 9, 3, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (143, 9, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (144, 9, 3, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (145, 9, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (146, 9, 3, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (147, 9, 3, 9, 26)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (148, 9, 3, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (149, 9, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (150, 7, 3, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (151, 7, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (152, 7, 3, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (153, 7, 3, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (154, 7, 3, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (155, 7, 3, 6, 18)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (156, 7, 3, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (157, 7, 3, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (158, 7, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (159, 7, 3, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (160, 2, 1, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (161, 2, 1, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (162, 2, 1, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (163, 2, 1, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (164, 2, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (165, 2, 1, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (166, 2, 1, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (167, 2, 1, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (168, 2, 1, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (169, 2, 1, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (170, 3, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (171, 3, 1, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (172, 3, 1, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (173, 3, 1, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (174, 3, 1, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (175, 3, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (176, 3, 1, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (177, 3, 1, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (178, 3, 1, 9, 26)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (179, 3, 1, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (180, 4, 1, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (181, 4, 1, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (182, 4, 1, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (183, 4, 1, 4, 11)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (184, 4, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (185, 4, 1, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (186, 4, 1, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (187, 4, 1, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (188, 4, 1, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (189, 4, 1, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (190, 5, 1, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (191, 5, 1, 2, 6)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (192, 5, 1, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (193, 5, 1, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (194, 5, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (195, 5, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (196, 5, 1, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (197, 5, 1, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (198, 5, 1, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (199, 5, 1, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (200, 6, 1, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (201, 6, 1, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (202, 6, 1, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (203, 6, 1, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (204, 6, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (205, 6, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (206, 6, 1, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (207, 6, 1, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (208, 6, 1, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (209, 6, 1, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (210, 7, 1, 1, 3)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (211, 7, 1, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (212, 7, 1, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (213, 7, 1, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (214, 7, 1, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (215, 7, 1, 6, 18)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (216, 7, 1, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (217, 7, 1, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (218, 7, 1, 9, 26)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (219, 7, 1, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (220, 8, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (221, 8, 1, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (222, 8, 1, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (223, 8, 1, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (224, 8, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (225, 8, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (226, 8, 1, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (227, 8, 1, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (228, 8, 1, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (229, 8, 1, 10, 30)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (230, 9, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (231, 9, 1, 2, 5)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (232, 9, 1, 3, 9)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (233, 9, 1, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (234, 9, 1, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (235, 9, 1, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (236, 9, 1, 7, 21)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (237, 9, 1, 8, 23)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (238, 9, 1, 9, 27)
GO
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (239, 9, 1, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (240, 10, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (241, 10, 1, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (242, 10, 1, 3, 8)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (243, 10, 1, 4, 12)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (244, 10, 1, 5, 15)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (245, 10, 1, 6, 17)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (246, 10, 1, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (247, 10, 1, 8, 24)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (248, 10, 1, 9, 26)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (249, 10, 1, 10, 29)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (250, 11, 1, 1, 1)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (251, 11, 1, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (252, 11, 1, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (253, 11, 1, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (254, 11, 1, 5, 14)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (255, 11, 1, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (256, 11, 1, 7, 20)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (257, 11, 1, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (258, 11, 1, 9, 27)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (259, 11, 1, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (340, 19, 3, 1, 2)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (341, 19, 3, 2, 4)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (342, 19, 3, 3, 7)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (343, 19, 3, 4, 10)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (344, 19, 3, 5, 13)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (345, 19, 3, 6, 16)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (346, 19, 3, 7, 19)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (347, 19, 3, 8, 22)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (348, 19, 3, 9, 25)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (349, 19, 3, 10, 28)
INSERT [dbo].[Grade] ([GradeID], [CandidateID], [UserID], [QuestionID], [AnswersID]) VALUES (350, 19, 3, 11, 31)
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (1, N'Страховой агент')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (2, N'Бухгалтер')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (3, N'Менеджер по рекламе')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (4, N'Менеджер по маркетингу')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (5, N'Менеджер по работе с клиентами')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (6, N'Менеджер по продажам')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (7, N'Специалист по урегулированию убытков')
INSERT [dbo].[Positions] ([PositionsID], [PositionsTitle]) VALUES (8, N'HR-специалист')
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (1, N'Коммуникативные навыки кандидата.', 10)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (2, N'Знания кандидата профессиональной области.', 9)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (3, N'Качество работы, выполняемой кандидатом.', 8)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (4, N'Мотивированность кандидата к работе.', 7)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (5, N'Отвественность и пунктуальность.', 6)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (6, N'Уровень владения ПК.', 5)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (7, N'Грамотная устная и письменная речь.', 4)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (8, N'Стрессоустойчивость кандидата.', 3)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (9, N'Наличие позитивной энергетики.', 2)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (10, N'Активная жизненная позиция:', 1)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (11, N'wef', 4)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (12, N'weew', 2)
INSERT [dbo].[Question] ([QuestionID], [Title], [QuashionWeightCoefficient]) VALUES (13, N'332', 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Role_Name]) VALUES (1, N'Руководитель территориального подразделения')
INSERT [dbo].[Role] ([RoleID], [Role_Name]) VALUES (2, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [Role_Name]) VALUES (3, N'HR')
INSERT [dbo].[Role] ([RoleID], [Role_Name]) VALUES (4, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Speciality] ON 

INSERT [dbo].[Speciality] ([SpecialityID], [SpecialityTitle], [SpecialityInfo]) VALUES (1, N'Среднее общее (10 и 11 классы)', NULL)
INSERT [dbo].[Speciality] ([SpecialityID], [SpecialityTitle], [SpecialityInfo]) VALUES (2, N'Среднее профессиональное', NULL)
INSERT [dbo].[Speciality] ([SpecialityID], [SpecialityTitle], [SpecialityInfo]) VALUES (3, N'Высшее — бакалавриат', NULL)
INSERT [dbo].[Speciality] ([SpecialityID], [SpecialityTitle], [SpecialityInfo]) VALUES (4, N'Высшее — специалитет, магистратура', NULL)
INSERT [dbo].[Speciality] ([SpecialityID], [SpecialityTitle], [SpecialityInfo]) VALUES (5, N'Высшее — подготовка кадров высшей квалификации', NULL)
SET IDENTITY_INSERT [dbo].[Speciality] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (1, N'Шариров', N'Искандер', N'Илдарович', N'+79576713908', N'sharip007@gmail.com', N'iskan123', N'qwerty1', 1, 0.6)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (2, N'Байгузин', N'Егор', N'Евгеньевич', N'+79746312778', N'baiguz111@mail.com', N'egor123', N'qwerty1', 2, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (3, N'Тимербаев', N'Данис', N'Равильевич', N'+79772892240', N'timer666@hotmail.com', N'danis123', N'qwerty1', 3, 0.4)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (9, N'Ибаков', N'Равиль', N'Фидратович', N'+79279292917', N' RavilIbakov102@yandex.ru', N'RavilIbakov0012', N'qwerty1', 4, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (11, N'Уразбаев', N'Газинур', N'Ришатович', N'+79275626312', N'yraz@mail.com', N'yraz52', N'qwerty1', 2, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (16, N'Лучная', N'Нина', N'Валентиновна', N'+79379289702', N'luhik92@mail.ru', N'NinaLuch454', N'qwerty1', 4, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (18, N'Симонов', N'Григорий', N'Иванович', N'+79271121314', N'simov@mail.ru', N'GrigorSim', N'qwerty1', 4, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (19, N'Зорин', N'Андрей', N'', N'+79683723184', N'zorkandrey@mail.ru', N'Zorkadrey', N'qwerty1', 4, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [Name], [Patranomic], [Phone], [Email], [Login], [Password], [RoleID], [UserWeightCoefficient]) VALUES (21, N'Qeqeqe', N'Qeeq', N'Qeqe', N'+74444545454', N'qtr@w.qw', N'da', N'qwerty1', 4, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Question]
GO
ALTER TABLE [dbo].[CandidateCard]  WITH CHECK ADD  CONSTRAINT [FK__Candidate__Posit__787EE5A0] FOREIGN KEY([Position])
REFERENCES [dbo].[Positions] ([PositionsID])
GO
ALTER TABLE [dbo].[CandidateCard] CHECK CONSTRAINT [FK__Candidate__Posit__787EE5A0]
GO
ALTER TABLE [dbo].[CandidateCard]  WITH CHECK ADD  CONSTRAINT [FK_CandidateCard_Users] FOREIGN KEY([CreateUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CandidateCard] CHECK CONSTRAINT [FK_CandidateCard_Users]
GO
ALTER TABLE [dbo].[CandidateEducation]  WITH CHECK ADD  CONSTRAINT [FK_CandidateEducation_CandidateCard] FOREIGN KEY([Candidate])
REFERENCES [dbo].[CandidateCard] ([CandidateID])
GO
ALTER TABLE [dbo].[CandidateEducation] CHECK CONSTRAINT [FK_CandidateEducation_CandidateCard]
GO
ALTER TABLE [dbo].[CandidateEducation]  WITH CHECK ADD  CONSTRAINT [FK_CandidateEducation_Education] FOREIGN KEY([Education])
REFERENCES [dbo].[Education] ([EducationID])
GO
ALTER TABLE [dbo].[CandidateEducation] CHECK CONSTRAINT [FK_CandidateEducation_Education]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK__Grade__Candidate__7E37BEF6] FOREIGN KEY([CandidateID])
REFERENCES [dbo].[CandidateCard] ([CandidateID])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK__Grade__Candidate__7E37BEF6]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK__Grade__UserID__49C3F6B7] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK__Grade__UserID__49C3F6B7]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Answers] FOREIGN KEY([AnswersID])
REFERENCES [dbo].[Answers] ([AnswerId])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Answers]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Question]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleID__3C69FB99] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleID__3C69FB99]
GO
ALTER TABLE [dbo].[CandidateCard]  WITH CHECK ADD  CONSTRAINT [CK__Candidate__Email__778AC167] CHECK  (([Email] like '%_@_%._%'))
GO
ALTER TABLE [dbo].[CandidateCard] CHECK CONSTRAINT [CK__Candidate__Email__778AC167]
GO
ALTER TABLE [dbo].[CandidateCard]  WITH CHECK ADD  CONSTRAINT [CK__Candidate__Phone__76969D2E] CHECK  (([Phone] like '+7[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[CandidateCard] CHECK CONSTRAINT [CK__Candidate__Phone__76969D2E]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Email__3A81B327] CHECK  (([Email] like '%_@_%._%'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Email__3A81B327]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Password__3B75D760] CHECK  (([Password] like '%[0-9]%' AND (len([Password])>=(6) AND len([Password])<=(20))))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Password__3B75D760]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Phone__398D8EEE] CHECK  (([Phone] like '+7[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Phone__398D8EEE]
GO
USE [master]
GO
ALTER DATABASE [Capital_Life_Insurance_LLC] SET  READ_WRITE 
GO

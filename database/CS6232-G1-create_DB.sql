USE [master]
GO
/****** Object:  Database [CS6232-G1]    Script Date: 3/18/2016 8:54:57 AM ******/
CREATE DATABASE [CS6232-G1]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'Evaluations', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Evaluations.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
( NAME = N'Evaluations_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Evaluations_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CS6232-G1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CS6232-G1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CS6232-G1] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CS6232-G1] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CS6232-G1] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CS6232-G1] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CS6232-G1] SET ARITHABORT OFF
GO
ALTER DATABASE [CS6232-G1] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CS6232-G1] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CS6232-G1] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CS6232-G1] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CS6232-G1] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CS6232-G1] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CS6232-G1] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CS6232-G1] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CS6232-G1] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CS6232-G1] SET  DISABLE_BROKER
GO
ALTER DATABASE [CS6232-G1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CS6232-G1] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CS6232-G1] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CS6232-G1] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CS6232-G1] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CS6232-G1] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CS6232-G1] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CS6232-G1] SET RECOVERY FULL
GO
ALTER DATABASE [CS6232-G1] SET  MULTI_USER
GO
ALTER DATABASE [CS6232-G1] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CS6232-G1] SET DB_CHAINING OFF
GO
ALTER DATABASE [CS6232-G1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [CS6232-G1] SET TARGET_RECOVERY_TIME = 0 SECONDS
GO
ALTER DATABASE [CS6232-G1] SET DELAYED_DURABILITY = DISABLED
GO
USE [CS6232-G1]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answer](
	[answerId] [int] IDENTITY(1,1) NOT NULL,
	[evaluationId] [int] NOT NULL,
	[questionId] [int] NOT NULL,
	[answer] [int] NOT NULL,
 CONSTRAINT [PK_answer] PRIMARY KEY CLUSTERED
(
	[answerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[category](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[typeId] [int] NOT NULL,
	[categoryNo] [int] NOT NULL,
	[categoryName] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_category] UNIQUE NONCLUSTERED
(
	[typeId] ASC,
	[categoryNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cohort]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cohort](
	[cohortId] [int] IDENTITY(1,1) NOT NULL,
	[cohortName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cohort] PRIMARY KEY CLUSTERED
(
	[cohortId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employee]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee](
	[employeeId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[streetAddress] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[zipcode] [varchar](50) NOT NULL,
	[contactPhone] [varchar](20) NOT NULL,
	[emailAddress] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[isAdmin] [bit] NOT NULL,
	[cohortId] [int] NULL,
	[supervisorId] [int] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_employee] UNIQUE NONCLUSTERED
(
	[emailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[evaluation_schedule]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evaluation_schedule](
	[scheduleId] [int] IDENTITY(1,1) NOT NULL,
	[cohortId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[stageId] [int] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
 CONSTRAINT [PK_evaluation_shedule] PRIMARY KEY CLUSTERED
(
	[scheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_evaluation_schedule] UNIQUE NONCLUSTERED
(
	[cohortId] ASC,
	[typeId] ASC,
	[stageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[evaluations]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evaluations](
	[evaluationId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[stageId] [int] NOT NULL,
	[evaluator] [int] NOT NULL,
	[roleId] [int] NULL,
	[completionDate] [datetime] NULL,
 CONSTRAINT [PK_evaluations] PRIMARY KEY CLUSTERED
(
	[evaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[question]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[question](
	[questionId] [int] IDENTITY(1,1) NOT NULL,
	[typeId] [int] NOT NULL,
	[questionNo] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
	[question] [varchar](200) NOT NULL,
 CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED
(
	[questionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_question] UNIQUE NONCLUSTERED
(
	[typeId] ASC,
	[questionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[role]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stage]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stage](
	[stageId] [int] IDENTITY(1,1) NOT NULL,
	[stageName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_stage] PRIMARY KEY CLUSTERED
(
	[stageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type]    Script Date: 3/18/2016 8:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type](
	[typeId] [int] IDENTITY(1,1) NOT NULL,
	[typeName] [varchar](50) NOT NULL,
	[answerRange] [int] NOT NULL,
 CONSTRAINT [PK_type] PRIMARY KEY CLUSTERED
(
	[typeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_answer]    Script Date: 3/18/2016 8:54:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_answer] ON [dbo].[answer]
(
	[evaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_answer_1]    Script Date: 3/18/2016 8:54:57 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_answer_1] ON [dbo].[answer]
(
	[evaluationId] ASC,
	[questionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[answer]  WITH CHECK ADD  CONSTRAINT [FK_answer_evaluations] FOREIGN KEY([evaluationId])
REFERENCES [dbo].[evaluations] ([evaluationId])
GO
ALTER TABLE [dbo].[answer] CHECK CONSTRAINT [FK_answer_evaluations]
GO
ALTER TABLE [dbo].[answer]  WITH CHECK ADD  CONSTRAINT [FK_answer_question] FOREIGN KEY([questionId])
REFERENCES [dbo].[question] ([questionId])
GO
ALTER TABLE [dbo].[answer] CHECK CONSTRAINT [FK_answer_question]
GO
ALTER TABLE [dbo].[category]  WITH CHECK ADD  CONSTRAINT [FK_category_type] FOREIGN KEY([typeId])
REFERENCES [dbo].[type] ([typeId])
GO
ALTER TABLE [dbo].[category] CHECK CONSTRAINT [FK_category_type]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_cohort] FOREIGN KEY([cohortId])
REFERENCES [dbo].[cohort] ([cohortId])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_cohort]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_supervisor] FOREIGN KEY([supervisorId])
REFERENCES [dbo].[employee] ([employeeId])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_supervisor]
GO
ALTER TABLE [dbo].[evaluation_schedule]  WITH CHECK ADD  CONSTRAINT [FK_evaluation_shedule_cohort] FOREIGN KEY([cohortId])
REFERENCES [dbo].[cohort] ([cohortId])
GO
ALTER TABLE [dbo].[evaluation_schedule] CHECK CONSTRAINT [FK_evaluation_shedule_cohort]
GO
ALTER TABLE [dbo].[evaluation_schedule]  WITH CHECK ADD  CONSTRAINT [FK_evaluation_shedule_stage] FOREIGN KEY([stageId])
REFERENCES [dbo].[stage] ([stageId])
GO
ALTER TABLE [dbo].[evaluation_schedule] CHECK CONSTRAINT [FK_evaluation_shedule_stage]
GO
ALTER TABLE [dbo].[evaluation_schedule]  WITH CHECK ADD  CONSTRAINT [FK_evaluation_shedule_type] FOREIGN KEY([typeId])
REFERENCES [dbo].[type] ([typeId])
GO
ALTER TABLE [dbo].[evaluation_schedule] CHECK CONSTRAINT [FK_evaluation_shedule_type]
GO
ALTER TABLE [dbo].[evaluations]  WITH CHECK ADD  CONSTRAINT [FK_evaluations_employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[employee] ([employeeId])
GO
ALTER TABLE [dbo].[evaluations] CHECK CONSTRAINT [FK_evaluations_employee]
GO
ALTER TABLE [dbo].[evaluations]  WITH CHECK ADD  CONSTRAINT [FK_evaluations_employee1] FOREIGN KEY([evaluator])
REFERENCES [dbo].[employee] ([employeeId])
GO
ALTER TABLE [dbo].[evaluations] CHECK CONSTRAINT [FK_evaluations_employee1]
GO
ALTER TABLE [dbo].[evaluations]  WITH CHECK ADD  CONSTRAINT [FK_evaluations_role] FOREIGN KEY([roleId])
REFERENCES [dbo].[role] ([roleId])
GO
ALTER TABLE [dbo].[evaluations] CHECK CONSTRAINT [FK_evaluations_role]
GO
ALTER TABLE [dbo].[evaluations]  WITH CHECK ADD  CONSTRAINT [FK_evaluations_stage] FOREIGN KEY([stageId])
REFERENCES [dbo].[stage] ([stageId])
GO
ALTER TABLE [dbo].[evaluations] CHECK CONSTRAINT [FK_evaluations_stage]
GO
ALTER TABLE [dbo].[evaluations]  WITH CHECK ADD  CONSTRAINT [FK_evaluations_type] FOREIGN KEY([typeId])
REFERENCES [dbo].[type] ([typeId])
GO
ALTER TABLE [dbo].[evaluations] CHECK CONSTRAINT [FK_evaluations_type]
GO
ALTER TABLE [dbo].[question]  WITH CHECK ADD  CONSTRAINT [FK_question_category1] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([categoryId])
GO
ALTER TABLE [dbo].[question] CHECK CONSTRAINT [FK_question_category1]
GO
ALTER TABLE [dbo].[question]  WITH CHECK ADD  CONSTRAINT [FK_question_type] FOREIGN KEY([typeId])
REFERENCES [dbo].[type] ([typeId])
GO
ALTER TABLE [dbo].[question] CHECK CONSTRAINT [FK_question_type]
GO
IF OBJECT_ID('dbo.EvaluationScheduleView', 'V') IS NOT NULL
    DROP VIEW dbo.EvaluationScheduleView;
GO
CREATE VIEW [dbo].[EvaluationScheduleView]
AS
SELECT  es.scheduleId,
        es.cohortId,
        es.typeId,
        ty.typeName,
        ty.answerRange,
        es.stageId,
        st.stageName,
        startDate,
        endDate
  FROM dbo.evaluation_schedule es
  LEFT JOIN dbo.type ty ON (ty.typeId = es.typeId)
  LEFT JOIN dbo.stage st ON (st.stageId = es.stageId)

GO
USE [master]
GO
ALTER DATABASE [CS6232-G1] SET  READ_WRITE
GO

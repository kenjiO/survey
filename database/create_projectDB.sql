USE [CS6232-G1]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 2/20/2016 11:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answer](
	[evaluationId] [int] NOT NULL,
	[questionId] [int] NOT NULL,
	[answer] [int] NOT NULL,
 CONSTRAINT [PK_answer] PRIMARY KEY CLUSTERED 
(
	[evaluationId] ASC,
	[questionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[cohort]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[employee]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[evaluation_schedule]    Script Date: 2/20/2016 11:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evaluation_schedule](
	[cohortId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[stageId] [int] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
 CONSTRAINT [PK_evaluation_shedule] PRIMARY KEY CLUSTERED 
(
	[cohortId] ASC,
	[typeId] ASC,
	[stageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[evaluations]    Script Date: 2/20/2016 11:42:44 AM ******/
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
	[roleId] [int] NOT NULL,
	[completionDate] [datetime] NULL,
 CONSTRAINT [PK_evaluations] PRIMARY KEY CLUSTERED 
(
	[evaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_evaluations] UNIQUE NONCLUSTERED 
(
	[employeeId] ASC,
	[typeId] ASC,
	[stageId] ASC,
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[question]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[role]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[stage]    Script Date: 2/20/2016 11:42:44 AM ******/
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
/****** Object:  Table [dbo].[type]    Script Date: 2/20/2016 11:42:44 AM ******/
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

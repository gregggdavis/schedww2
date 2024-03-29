SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[RepeatRule] [nvarchar](1000) NULL,
	[NegetiveException] [nvarchar](4000) NULL,
	[RecurrenceText] [nvarchar](255) NULL,
	[EventStatus] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastmodified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
	[Finalized] [bit] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[UserType] [int] NOT NULL,
	[ContactID] [int] NULL,
	[UserStatus] [int] NOT NULL CONSTRAINT [DF_User_UserStatus]  DEFAULT (0),
	[CreatedByUserId] [int] NULL,
	[DateLastLogin] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalendarEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CalendarEvent](
	[CalendarEventId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[EventType] [nvarchar](50) NULL,
	[Name] [nvarchar](255) NULL,
	[NamePhonetic] [nvarchar](255) NULL,
	[NameRomaji] [nvarchar](255) NULL,
	[DateCompleted] [datetime] NULL,
	[Location] [nvarchar](50) NULL,
	[BlockCode] [nvarchar](15) NULL,
	[RoomNumber] [nvarchar](50) NULL,
	[Note] [nvarchar](4000) NULL,
	[ScheduledTeacherId] [int] NULL,
	[RealTeacherId] [int] NULL,
	[ChangeReason] [nvarchar](100) NULL,
	[IsHoliday] [int] NOT NULL,
	[CalendarEventStatus] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
	[ExceptionReason] [nvarchar](200) NULL,
 CONSTRAINT [PK_CalendarEvent] PRIMARY KEY CLUSTERED 
(
	[CalendarEventId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[RefID] [int] NULL CONSTRAINT [DF_Contact_RefID]  DEFAULT ((0)),
	[LastName] [nvarchar](255) NULL,
	[LastNamePhonetic] [nvarchar](255) NULL,
	[LastNameRomaji] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[FirstNamePhonetic] [nvarchar](255) NULL,
	[FirstNameRomaji] [nvarchar](255) NULL,
	[NickName] [nvarchar](255) NULL,
	[CompanyName] [nvarchar](255) NULL,
	[CompanyNamePhonetic] [nvarchar](255) NULL,
	[CompanyNameRomaji] [nvarchar](255) NULL,
	[TitleForname] [nvarchar](50) NULL,
	[TitleForJob] [nvarchar](50) NULL,
	[Street1] [nvarchar](255) NULL,
	[Street2] [nvarchar](255) NULL,
	[Street3] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ContactType] [int] NOT NULL,
	[BlockCode] [nchar](15) NULL,
	[Email1] [nvarchar](255) NULL,
	[Email2] [nvarchar](255) NULL,
	[AccountRepLastName] [nvarchar](255) NULL,
	[AccountRepLastNamePhonetic] [nvarchar](255) NULL,
	[AccountRepLastNameRomaji] [nvarchar](255) NULL,
	[AccountRepFirstName] [nvarchar](255) NULL,
	[AccountRepFirstNamePhonetic] [nvarchar](255) NULL,
	[AccountRepFirstNameRomaji] [nvarchar](255) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[PhoneMobile1] [nvarchar](50) NULL,
	[PhoneMobile2] [nvarchar](50) NULL,
	[PhoneBusiness1] [nvarchar](50) NULL,
	[PhoneBusiness2] [nvarchar](50) NULL,
	[PhoneFax1] [nvarchar](50) NULL,
	[PhoneFax2] [nvarchar](50) NULL,
	[PhoneOther] [nvarchar](50) NULL,
	[Url] [nvarchar](255) NULL,
	[DateBirth] [datetime] NULL,
	[DateJoined] [datetime] NULL,
	[DateEnded] [datetime] NULL,
	[TimeStatus] [nvarchar](50) NULL,
	[Nationality] [nvarchar](50) NULL,
	[Married] [int] NULL,
	[NumberDependents] [int] NULL,
	[VisaStatus] [nvarchar](255) NULL,
	[VisaFromDate] [datetime] NULL,
	[VisaUntilDate] [datetime] NULL,
	[ClosestStation1] [nvarchar](50) NULL,
	[Closestline1] [nvarchar](50) NULL,
	[MinutesToStation1] [int] NULL,
	[ClosestStation2] [nvarchar](50) NULL,
	[Closestline2] [nvarchar](50) NULL,
	[MinutesToStation2] [int] NULL,
	[ContactStatus] [int] NOT NULL CONSTRAINT [DF_Contact_ContactStatus]  DEFAULT ((0)),
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
	[BasePayField] [decimal](18, 0) NOT NULL CONSTRAINT [DF_Contact_BasePayField]  DEFAULT ((0)),
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Program](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[NamePhonetic] [nvarchar](255) NULL,
	[NameRomaji] [nvarchar](255) NULL,
	[NickName] [nvarchar](255) NULL,
	[DepartmentId] [int] NOT NULL,
	[Contact1ID] [int] NULL,
	[Contact2ID] [int] NULL,
	[Description] [nvarchar](4000) NULL,
	[SpecialRemarks] [nvarchar](4000) NULL,
	[ReportAttendence] [nvarchar](20) NOT NULL,
	[TestInitialEventId] [int] NULL,
	[TestMidtermEventId] [int] NULL,
	[TestFinalEventId] [int] NULL,
	[TestInitialForm] [nvarchar](50) NULL,
	[TestMidtermForm] [nvarchar](50) NULL,
	[TestFinalForm] [nvarchar](50) NULL,
	[EvaluationMidtermForm] [nvarchar](50) NULL,
	[EvaluationFinalForm] [nvarchar](50) NULL,
	[QuestionaireMidtermForm] [nvarchar](50) NULL,
	[QuestionaireFinalForm] [nvarchar](50) NULL,
	[ProgramStatus] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
	[Billing] [nvarchar](50) NOT NULL DEFAULT ('No'),
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[NamePhonetic] [nvarchar](255) NULL,
	[NameRomaji] [nvarchar](255) NULL,
	[NickName] [nvarchar](255) NULL,
	[ProgramId] [int] NOT NULL,
	[CourseType] [nvarchar](60) NOT NULL,
	[EventId] [int] NULL,
	[Description] [nvarchar](4000) NULL,
	[SpecialRemarks] [nvarchar](4000) NULL,
	[Curriculam] [nvarchar](4000) NULL,
	[NumberStudents] [int] NULL,
	[HomeworkMinutes] [int] NULL,
	[TestInitialEventId] [int] NULL,
	[TestMidtermEventId] [int] NULL,
	[TestFinalEventId] [int] NULL,
	[TestInitialForm] [nvarchar](50) NULL,
	[TestMidtermForm] [nvarchar](50) NULL,
	[TestFinalForm] [nvarchar](50) NULL,
	[CourseStatus] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
	[BreakDuration] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[ContactID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[DepartmentStatus] [int] NOT NULL CONSTRAINT [DF_Department_DepartmentStatus]  DEFAULT (0),
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateLastModified] [datetime] NOT NULL,
	[LastModifiedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Program_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[Program]'))
ALTER TABLE [dbo].[Program]  WITH NOCHECK ADD  CONSTRAINT [FK_Program_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Department]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Program_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Program]'))
ALTER TABLE [dbo].[Program]  WITH NOCHECK ADD  CONSTRAINT [FK_Program_User] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Course_Program]') AND parent_object_id = OBJECT_ID(N'[dbo].[Course]'))
ALTER TABLE [dbo].[Course]  WITH NOCHECK ADD  CONSTRAINT [FK_Course_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Program]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Course_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Course]'))
ALTER TABLE [dbo].[Course]  WITH NOCHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_Contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department]  WITH NOCHECK ADD  CONSTRAINT [FK_Department_Contact] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ContactId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Contact]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department]  WITH NOCHECK ADD  CONSTRAINT [FK_Department_User] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_User]

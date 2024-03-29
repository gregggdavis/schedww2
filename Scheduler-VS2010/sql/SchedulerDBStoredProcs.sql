SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpClassEventsN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpClassEventsN]
-- CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Add the parameters for the procedure here

    -- Insert statements for procedure here

	-- Create temp table of needed CalEvent Data to join
	CREATE TABLE #tmpTbCalEvent(
		EventId int,
		StartDateTime datetime,
		EndDateTime datetime,
		ScheduledTeacherID int,
		ScheduledTeacherName nvarchar(200),
		CalendarEventStatus int
	)

	INSERT INTO #tmpTbCalEvent (EventId, StartDateTime, EndDateTime, ScheduledTeacherID, ScheduledTeacherName, CalendarEventStatus)
	SELECT
		EventId,
		StartDateTime,
		EndDateTime,
		ScheduledTeacherID,
		(SELECT LastName + '', '' + FirstName FROM dbo.Contact WHERE ContactID=ScheduledTeacherID) AS ScheduledTeacherName,
		CalendarEventStatus
	FROM dbo.CalendarEvent ORDER BY CalendarEventId


	-- Return equivalent of ViewCourseEventsN
	SELECT DISTINCT TOP (100) PERCENT
		CourseId,
		Name,
		NamePhonetic,
		NameRomaji,
		NickName,
		ProgramId,
		CourseType,
		v.EventId,
		Description,
		SpecialRemarks,
		Curriculam,
		NumberStudents,
		HomeworkMinutes,
		ISNULL(TestInitialEventId, 0) AS TestInitialEventId,
		ISNULL(TestMidtermEventId, 0) AS TestMidtermEventId,
		ISNULL(TestFinalEventId, 0) AS TestFinalEventId,
		ISNULL(TestInitialForm, 0) AS TestInitialForm,
		ISNULL(TestMidtermForm, 0) AS TestMidtermForm,
		ISNULL(TestFinalForm, 0) AS TestFinalForm,
		CourseStatus,
		CreatedByUserId,
		DateCreated,
		DateLastModified, 
		LastModifiedByUserId,
		BreakDuration,
		BrowseName,
		ProgramNickName,
		Program,
		Department,
		Client,
		(SELECT TOP 1 t.StartDateTime FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS EventStartDateTime,
		(SELECT TOP 1 t.ScheduledTeacherName FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS ScheduledInstructor,
		(SELECT MAX(t.EndDateTime) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS EventEndDateTime,
		CAST((SELECT Count(*) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId AND t.StartDateTime < GetDate() AND t.CalendarEventStatus = 0) AS nvarchar(30))
			+ '' / '' + 
			CAST((SELECT Count(*) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId AND t.CalendarEventStatus = 0) AS nvarchar(30)) AS OccurrenceCount
	FROM dbo.ViewCourseN AS v ORDER BY CourseId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CourseClone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_CourseClone]
	@CourseID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @name nvarchar(1000)
	
	Select @name = [Name] from [Course] Where CourseId = @CourseID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Course] WHERE [Name] like ''Copy of '' + @name + ''%''

	INSERT INTO [Course]
		([Name],
		NamePhonetic,
		NameRomaji,
		NickName,
		ProgramId,
		CourseType,
		EventId,
		Description,
		SpecialRemarks,
		Curriculam,
		NumberStudents,
		HomeworkMinutes,
		TestInitialEventId,
		TestMidtermEventId,
		TestFinalEventId,
		TestInitialForm,
		TestMidtermForm,
		TestFinalForm,
		CourseStatus,
		CreatedByUserId,
		DateCreated,
		DateLastModified,
		LastModifiedByUserId,
        BreakDuration)
	SELECT 
		''Copy of '' + [Name] + '' '' + CAST(@numberMatched as varchar),
		NamePhonetic,
		NameRomaji,
		''Copy of '' + CASE WHEN LEN([NickName]) = 0 THEN [Name] ELSE [NickName] END + '' '' + CAST(@numberMatched as varchar),
		ProgramId,
		CourseType,
		0,
		Description,
		SpecialRemarks,
		Curriculam,
		NumberStudents,
		HomeworkMinutes,
		0,
		0,
		0,
		TestInitialForm,
		TestMidtermForm,
		TestFinalForm,
		CourseStatus,
		@creatorID,
		GetDate(),
		GetDate(),
		@creatorId,
        BreakDuration
	FROM 
		Course
	WHERE 
		CourseID = @CourseID


	SELECT @insertedID = @@IDENTITY

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ProgramClone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_ProgramClone]
	@ProgramID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @name nvarchar(1000)
	
	Select @name = Name from [Program] Where ProgramID = @programID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Program] WHERE [Name] like ''Copy of '' + @name + ''%''

	INSERT INTO [Program]
		(
		Name,
		NamePhonetic,
		NameRomaji,
		NickName,
		DepartmentId,
		Contact1ID,
		Contact2ID,
		Description,
		SpecialRemarks,
		ReportAttendence,
		TestInitialEventId,
		TestMidtermEventId,
		TestFinalEventId,
		TestInitialForm,
		TestMidtermForm,
		TestFinalForm,
		EvaluationMidtermForm,
		EvaluationFinalForm,
		QuestionaireMidtermForm,
		QuestionaireFinalForm,
		ProgramStatus,
		CreatedByUserId,
		DateCreated,
		DateLastModified,
		LastModifiedByUserId,
		Billing
	)
	SELECT 
		''Copy of '' + [Name] + '' '' + CAST(@numberMatched as varchar),
		NamePhonetic,
		NameRomaji,
		NickName,
		DepartmentId,
		Contact1ID,
		Contact2ID,
		Description,
		SpecialRemarks,
		ReportAttendence,
		0,
		0,
		0,
		TestInitialForm,
		TestMidtermForm,
		TestFinalForm,
		EvaluationMidtermForm,
		EvaluationFinalForm,
		QuestionaireMidtermForm,
		QuestionaireFinalForm,
		ProgramStatus,
		@creatorID,
		GetDate(),
		GetDate(),
		@creatorID,
		Billing
	FROM 
		[Program]
	WHERE 
		[ProgramID] = @ProgramID
		
	SELECT @insertedID = @@IDENTITY
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UserClone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_UserClone]
	@userID int,
	@creatorID int,
	@insertedID int OUTPUT
AS 
BEGIN
	DECLARE @numberMatched int	
	DECLARE @userName nvarchar(1000)
	Select @userName = userName from [User] Where UserID = @userID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [User] WHERE [UserName] like ''Copy of '' + @userName + ''%'' 
	
	INSERT INTO [User]
		(UserName,
		Password,
		UserType,
		ContactID,
		UserStatus,
		CreatedByUserId,
		DateLastLogin,
		DateCreated,
		DateLastModified,
		LastModifiedByUserId
		)
	SELECT
		''Copy of '' + [UserName] + '' '' + CAST(@numberMatched as varchar),
		Password,
		UserType,
		ContactID,
		UserStatus,
		@creatorID,
		GetDate(),
		GetDate(),
		GetDate(),
		@creatorID
	FROM 
		[User]
	WHERE
		[UserID] = @userId

	SELECT @insertedID = @@IDENTITY
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ContactClone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_ContactClone]
	@ContactID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @contactType int
	DECLARE @fullname nvarchar(1000)
	
	Select @fullname = LastName + ''%'' + FirstName, @contactType = ContactType  from [Contact] Where ContactID = @ContactID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Contact] WHERE LastName + FirstName like ''Copy of '' + @fullname  and ContactType = @ContactType
	
	INSERT INTO [Contact]
		(
			RefID,
			LastName,
			LastNamePhonetic,
			LastNameRomaji,
			FirstName,
			FirstNamePhonetic,
			FirstNameRomaji,
			NickName,
			CompanyName,
			CompanyNamePhonetic,
			CompanyNameRomaji,
			TitleForname,
			TitleForJob,
			Street1,
			Street2,
			Street3,
			City,
			State,
			PostalCode,
			Country,
			ContactType,
			BlockCode,
			Email1,
			Email2,
			AccountRepLastName,
			AccountRepLastNamePhonetic,
			AccountRepLastNameRomaji,
			AccountRepFirstName,
			AccountRepFirstNamePhonetic,
			AccountRepFirstNameRomaji,
			Phone1,
			Phone2,
			PhoneMobile1,
			PhoneMobile2,
			PhoneBusiness1,
			PhoneBusiness2,
			PhoneFax1,
			PhoneFax2,
			PhoneOther,
			Url,
			DateBirth,
			DateJoined,
			DateEnded,
			TimeStatus,
			Nationality,
			Married,
			NumberDependents,
			VisaStatus,
			VisaFromDate,
			VisaUntilDate,
			ClosestStation1,
			Closestline1,
			MinutesToStation1,
			ClosestStation2,
			Closestline2,
			MinutesToStation2,
			ContactStatus,
			CreatedByUserId,
			DateCreated,
			DateLastModified,
			LastModifiedByUserId
		)
	SELECT
			RefID,
			''Copy of '' + LastName+ '' '' + CAST(@numberMatched as varchar),
			LastNamePhonetic,
			LastNameRomaji,
			FirstName,
			FirstNamePhonetic,
			FirstNameRomaji,
			NickName,
			[CompanyName],
			CompanyNamePhonetic,
			CompanyNameRomaji,
			TitleForname,
			TitleForJob,
			Street1,
			Street2,
			Street3,
			City,
			State,
			PostalCode,
			Country,
			ContactType,
			BlockCode,
			Email1,
			Email2,
			AccountRepLastName,
			AccountRepLastNamePhonetic,
			AccountRepLastNameRomaji,
			AccountRepFirstName,
			AccountRepFirstNamePhonetic,
			AccountRepFirstNameRomaji,
			Phone1,
			Phone2,
			PhoneMobile1,
			PhoneMobile2,
			PhoneBusiness1,
			PhoneBusiness2,
			PhoneFax1,
			PhoneFax2,
			PhoneOther,
			Url,
			DateBirth,
			DateJoined,
			DateEnded,
			TimeStatus,
			Nationality,
			Married,
			NumberDependents,
			VisaStatus,
			VisaFromDate,
			VisaUntilDate,
			ClosestStation1,
			Closestline1,
			MinutesToStation1,
			ClosestStation2,
			Closestline2,
			MinutesToStation2,
			ContactStatus,
			@creatorID,
			GetDate(),
			GetDate(),
			@creatorID
	FROM
		[Contact]
	WHERE
		ContactID = @ContactID		

	SELECT @insertedID = @@IDENTITY
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPayrollByInstructor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPayrollByInstructor]
	-- Add the parameters for the stored procedure here
	@StartDateTime DateTime = NULL,
	@EndDateTime DateTime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (@StartDateTime IS NOT NULL AND @EndDateTime IS NOT NULL)
	Begin
	
	--------------------
	--------------------
	-- Main Statement --
	--------------------
	--------------------
	
	SELECT     TeacherID, InstructorName, CAST(TotalHours as Decimal(18,2)) as TotalHours, 
	CAST(HourlyRate as Decimal(18,2)) as HourlyRate, Cast(BasePayField as int) as BasePayField, 
    CAST(TotalHours * HourlyRate * dbo.Contact.BasePayField AS Decimal(18, 1)) 
    AS Total, DayType, dbo.Contact.TimeStatus

	From
	(

	

	-- Daytime Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT     TeacherID, InstructorName, SUM(DaytimeMinutes) AS TotalHours, CAST(1.0 AS Decimal(18, 2)) AS HourlyRate, ''1-Daytime'' AS DayType
	FROM         
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1
	WHERE     (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS DayTime

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	-- Saturday Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(SaturdayMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, 
    ''2-Saturday'' AS DayType
	FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) as ViewTemp
    WHERE     (DayName = ''Sat'') OR (DayName = ''Sun'') OR (IsHoliday = 1)
    GROUP BY TeacherID, InstructorName) AS SaturdayTB
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------

	-- Morning Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(MorningMinutes) AS TotalHours, CAST(1.1 AS Decimal(18, 2)) AS HourlyRate, ''3-Morning'' AS DayType
    FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1 
	WHERE (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS MorningTB

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	
	-- Evening Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(EveningMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, ''4-Evening'' AS DayType
    FROM  
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1
    WHERE     (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS EveningTB
	
	
	-------------------
	-------------------
	) as tviewsubPayrollByInstructor
	INNER JOIN dbo.Contact ON tviewsubPayrollByInstructor.TeacherID = dbo.Contact.ContactId
	
	END
	ELSE
	Begin

	--------------------
	--------------------
	-- Main Statement --
	--------------------
	--------------------
	
	SELECT     TeacherID, InstructorName, CAST(TotalHours as Decimal(18,2)) as TotalHours, 
	CAST(HourlyRate as Decimal(18,2)) as HourlyRate, Cast(BasePayField as int) as BasePayField, 
    CAST(TotalHours * HourlyRate * dbo.Contact.BasePayField AS Decimal(18, 1)) 
    AS Total, DayType, dbo.Contact.TimeStatus

	From
	(
	-- Daytime Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT     TeacherID, InstructorName, SUM(DaytimeMinutes) AS TotalHours, CAST(1.0 AS Decimal(18, 2)) AS HourlyRate, ''1-Daytime'' AS DayType
	FROM         
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1
	WHERE     (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS DayTime
	-------------------
	-------------------

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	-- Saturday Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(SaturdayMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, 
    ''2-Saturday'' AS DayType
	FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors
	) as ViewTemp
    WHERE     (ViewTemp.DayName = ''Sat'') OR (ViewTemp.DayName = ''Sun'') OR (ViewTemp.IsHoliday = 1)
    GROUP BY TeacherID, InstructorName) AS SaturdayTB
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------

	-- Morning Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(MorningMinutes) AS TotalHours, CAST(1.1 AS Decimal(18, 2)) AS HourlyRate, ''3-Morning'' AS DayType
    FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1 
	WHERE (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS MorningTB

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	
	-- Evening Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(EveningMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, ''4-Evening'' AS DayType
    FROM  
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1
    WHERE     (DayName <> ''Sat'') AND (DayName <> ''Sun'') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS EveningTB
		

	
	) as tviewsubPayrollByInstructor
	INNER JOIN dbo.Contact ON tviewsubPayrollByInstructor.TeacherID = dbo.Contact.ContactId
	END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContactInfoByContactID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetContactInfoByContactID]
	@ContactID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Phone1,Phone2,PhoneOther,Url,PhoneFax1,PhoneFax2,AccountRepLastName,AccountRepLastNamePhonetic,AccountRepLastNameRomaji,AccountRepFirstName,AccountRepFirstNamePhonetic,AccountRepFirstNameRomaji,Street1,Street2,Street3,City,[State],PostalCode,Country,BlockCode,ClosestStation1,ClosestLine1,MinutesToStation1,ClosestStation2,ClosestLine2,MinutesToStation2,BlockCode from Contact where ContactID = @ContactID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DepartmentClone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_DepartmentClone]
	@DepartmentID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @contactID int	
	DECLARE @clientID int
	
	SELECT 
		@contactID = contactID ,
		@clientID = clientID
	FROM
		Department
	WHERE
		DepartmentID = @departmentID

	DECLARE @newcontactID int
	DECLARE @newclientID int

	EXEC usp_ContactClone @contactID, @creatorID, @newcontactID OUTPUT
	--EXEC usp_ContactClone @clientID, @creatorID, @newclientID OUTPUT


	UPDATE Contact
		SET NickName = ''Copy of '' + t.NickName,
			CompanyName = ''Copy of '' + t.CompanyName
	FROM
		Contact t
	WHERE 
		t.ContactID = @newcontactID

--select * from department
--select * from contact where contactid = 133
	INSERT INTO [Department]
		(
			ContactID,
			ClientID,
			DepartmentStatus,
			CreatedByUserId,
			DateCreated,
			DateLastModified,
			LastModifiedByUserId
		)
	SELECT 
		@newcontactid,
		ClientID,
		DepartmentStatus,
		@creatorID,
		GetDate(),
		GetDate(),
		@creatorID
	FROM 
		Department
	Where 
		DepartmentID = @departmentID


	SELECT @insertedID = @@IDENTITY
END' 
END

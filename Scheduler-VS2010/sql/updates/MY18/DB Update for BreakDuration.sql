set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[GetDaytimeMinutes] 
(
	-- Add the parameters for the function here
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@IsHoliday as int,
	@DayName as nvarchar(20),
	@BreakDuration as int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0
	select @minutes = CASE When @IsHoliday<>1 AND @DayName <> 'Sat' AND @DayName <> 'Sun' AND @StartDateTime <= dbo.GetTime(@StartDateTime,'5:00PM')THEN 
	CASE When @StartDateTime > dbo.GetTime(@StartDateTime,'8:29AM') AND @EndDateTime <= dbo.GetTime(@EndDateTime,'5:00PM') THEN 
	DateDiff(mi,@StartDateTime,@EndDateTime)
	Else CASE When @StartDateTime > dbo.GetTime(@StartDateTime,'8:29AM') AND @EndDateTime > dbo.GetTime(@EndDateTime,'5:00PM') THEN 
	DateDiff(mi,@StartDateTime,dbo.GetTime(@EndDateTime,'5:00PM')) 
	ELSE CASE WHEN @StartDateTime <= dbo.GetTime(@StartDateTime,'8:29AM')
	AND @EndDateTime <= dbo.GetTime(@EndDateTime,'5:00PM') AND @EndDateTime >= dbo.GetTime(@EndDateTime,'11:00AM') THEN DateDiff(mi,dbo.GetTime(@StartDateTime,'11:00AM'),@EndDateTime) 
	ELSE CASE When @StartDateTime <= dbo.GetTime(@StartDateTime,'8:29AM') AND @EndDateTime > dbo.GetTime(@EndDateTime,'5:00PM') THEN
	DateDiff(mi,dbo.GetTime(@StartDateTime,'11:00AM'),dbo.GetTime(@EndDateTime,'5:00PM'))
	END END END END ELSE 0.00 END

    SET @minutes = @minutes - @BreakDuration

	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + ' ' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END








set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[GetSaturdayMinutes] 
(
	-- Add the parameters for the function here
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@IsHoliday as int,
	@DayName as nvarchar(20),
	@BreakDuration as int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0
	select @minutes = CASE WHEN @DayName = 'Sat' OR @DayName = 'Sun' OR
                      @IsHoliday = 1 THEN DATEDIFF(mi, @StartDateTime, @EndDateTime) 
                      ELSE 0.00 END

    SET @minutes = @minutes - @BreakDuration

	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + ' ' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[newvwCalendarEventInstructors]
AS
SELECT dbo.newvwCalendarEvents.CalendarEventId, dbo.newvwCalendarEvents.EventId, dbo.newvwCalendarEvents.StartDateTime, 
               dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.EventType, dbo.newvwCalendarEvents.EventName, 
               dbo.newvwCalendarEvents.ScheduledTeacherId, dbo.newvwCalendarEvents.RealTeacherId, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.EventStatus, dbo.newvwCalendarEvents.TeacherId, CAST(dbo.newvwCalendarEvents.EventMinutes AS Decimal(18, 2)) 
               AS EventMinutes, CAST(CAST(dbo.newvwCalendarEvents.EventMinutes - dbo.Course.BreakDuration AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS ScheduledHours, dbo.newvwCalendarEvents.DayName, 
               dbo.Contact.LastName + N', ' + dbo.Contact.FirstName AS InstructorName, dbo.Contact.BasePayField, 
               CAST(CAST(dbo.GetSaturdayMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, 
               dbo.newvwCalendarEvents.IsHoliday, dbo.newvwCalendarEvents.DayName, dbo.Course.BreakDuration) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) 
               AS SaturdayMinutes, CAST(CAST(dbo.GetMorningMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, 
               dbo.newvwCalendarEvents.IsHoliday, dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS MorningMinutes, 
               CAST(CAST(dbo.GetEveningMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS EveningMinutes, 
               CAST(CAST(dbo.GetDaytimeMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.DayName, dbo.Course.BreakDuration) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS DaytimeMinutes
FROM  dbo.newvwCalendarEvents INNER JOIN
               dbo.Contact ON dbo.newvwCalendarEvents.TeacherId = dbo.Contact.ContactId INNER JOIN
               dbo.Course ON dbo.newvwCalendarEvents.EventId = dbo.Course.EventId
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_CourseClone]
	@CourseID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @name nvarchar(1000)
	
	Select @name = [Name] from [Course] Where CourseId = @CourseID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Course] WHERE [Name] like 'Copy of ' + @name + '%'

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
		'Copy of ' + [Name] + ' ' + CAST(@numberMatched as varchar),
		NamePhonetic,
		NameRomaji,
		'Copy of ' + CASE WHEN LEN([NickName]) = 0 THEN [Name] ELSE [NickName] END + ' ' + CAST(@numberMatched as varchar),
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
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO













SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SpClassEventsN]
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
		(SELECT LastName + ', ' + FirstName FROM dbo.Contact WHERE ContactID=ScheduledTeacherID) AS ScheduledTeacherName,
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
			+ ' / ' + 
			CAST((SELECT Count(*) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId AND t.CalendarEventStatus = 0) AS nvarchar(30)) AS OccurrenceCount
	FROM dbo.ViewCourseN AS v ORDER BY CourseId
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewCourseN]
AS
SELECT     C.CourseId, C.Name, C.NamePhonetic, C.NameRomaji, C.NickName, C.ProgramId, C.CourseType, C.EventId, C.Description, C.SpecialRemarks, C.Curriculam, 
                      C.NumberStudents, C.HomeworkMinutes, C.TestInitialEventId, C.TestMidtermEventId, C.TestFinalEventId, C.TestInitialForm, C.TestMidtermForm, C.TestFinalForm, 
                      CASE WHEN CourseStatus = 0 THEN 'Active' ELSE 'Inactive' END AS CourseStatus, C.CreatedByUserId, C.DateCreated, C.DateLastModified, C.LastModifiedByUserId, C.BreakDuration,
                      CASE WHEN C.NickName IS NULL THEN C.Name WHEN C.NickName = '' THEN C.Name ELSE C.NickName END AS BrowseName, P.NickName AS ProgramNickName, 
                      CASE WHEN P.NickName IS NULL THEN P.Name WHEN P.NickName = '' THEN P.Name ELSE P.NickName END AS Program, CASE WHEN CO.NickName IS NULL 
                      THEN CO.CompanyName WHEN CO.NickName = '' THEN CO.CompanyName ELSE CO.NickName END AS Department, CASE WHEN CO1.NickName IS NULL 
                      THEN CO1.CompanyName WHEN CO1.NickName = '' THEN CO1.CompanyName ELSE CO1.NickName END AS Client
FROM         dbo.Course AS C LEFT OUTER JOIN
                      dbo.Program AS P ON C.ProgramId = P.ProgramId LEFT OUTER JOIN
                      dbo.Department AS D ON P.DepartmentId = D.DepartmentID LEFT OUTER JOIN
                      dbo.Contact AS CO ON D.ContactID = CO.ContactId LEFT OUTER JOIN
                      dbo.Contact AS CO1 ON D.ClientID = CO1.ContactId
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SpClassEventsN]
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
		(SELECT LastName + ', ' + FirstName FROM dbo.Contact WHERE ContactID=ScheduledTeacherID) AS ScheduledTeacherName,
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
		BrowseName,
		ProgramNickName,
		Program,
		Department,
		Client,
		(SELECT TOP 1 t.StartDateTime FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS EventStartDateTime,
		(SELECT TOP 1 t.ScheduledTeacherName FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS ScheduledInstructor,
		(SELECT MAX(t.EndDateTime) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId) AS EventEndDateTime,
		CAST((SELECT Count(*) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId AND t.StartDateTime < GetDate() AND t.CalendarEventStatus = 0) AS nvarchar(30))
			+ ' / ' + 
			CAST((SELECT Count(*) FROM #tmpTbCalEvent AS t WHERE v.EventId=t.EventId AND t.CalendarEventStatus = 0) AS nvarchar(30)) AS OccurrenceCount, BreakDuration
	FROM dbo.ViewCourseN AS v ORDER BY CourseId
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewClassEventsN]
AS
SELECT TOP (100) PERCENT CourseId, Name, NamePhonetic, NameRomaji, NickName, ProgramId, CourseType, EventId, Description, 
                      SpecialRemarks, Curriculam, NumberStudents, HomeworkMinutes, ISNULL(TestInitialEventId, 0) AS TestInitialEventId, 
                      ISNULL(TestMidtermEventId, 0) AS TestMidtermEventId, ISNULL(TestFinalEventId, 0) AS TestFinalEventId, ISNULL(TestInitialForm, 0) 
                      AS TestInitialForm, ISNULL(TestMidtermForm, 0) AS TestMidtermForm, ISNULL(TestFinalForm, 0) AS TestFinalForm, CourseStatus, 
                      CreatedByUserId, DateCreated, DateLastModified, LastModifiedByUserId, BreakDuration, BrowseName, ProgramNickName, Program, Department, 
                      Client, dbo.GetEventTextStartDate(EventId) AS EventStartDateTime, dbo.GetEventTextInstructorName(EventId) 
                      AS ScheduledInstructor, dbo.GetEventTextEndDate(EventId) AS EventEndDateTime, dbo.GetEventOccurranceCount(EventId) 
                      AS OccurrenceCount
FROM      dbo.ViewCourseN
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


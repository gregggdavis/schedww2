SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetHoursByDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ramy Mostafa
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetHoursByDate]
(
	-- Add the parameters for the function here
	@StartTime datetime,
	@EndTime datetime
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @NMinutes int
	Declare @NHours decimal(18,2)
	Select @NMinutes = DateDiff(mi,@StartTime,@EndTime)
	-- Add the T-SQL statements to compute the return value here
	SELECT @NHours = @NMinutes/60 + CAST((@Nminutes%60) as Decimal(18,2))/100

	-- Return the result of the function
	RETURN @NHours

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetHoursByMinutes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetHoursByMinutes]
(
	-- Add the parameters for the function here
	@NMinutes int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	Declare @NHours decimal(18,2)
	-- Add the T-SQL statements to compute the return value here
	SELECT @NHours = @NMinutes/60 + CAST((@Nminutes%60) as Decimal(18,2))/100

	-- Return the result of the function
	RETURN @NHours

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DateAndTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[DateAndTime]
(
	@StartDate datetime,
	@EndDate datetime
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @TStartTime nvarchar(25)
	Declare @TEndTime nvarchar(25)
	Declare @Result nvarchar(50)
	Declare @equalDates bit
	-- Add the T-SQL statements to compute the return value here
	SELECT @TStartTime = CAST (DatePart(yyyy,@StartDate) as nvarchar(4))+ ''/'' + CASE When DatePart(mm,@StartDate) < 10 Then ''0'' + CAST (DatePart(mm,@StartDate) as nvarchar(2)) Else CAST (DatePart(mm,@StartDate) as nvarchar(2)) End + ''/'' + CASE When DatePart(dd,@StartDate) < 10 Then ''0'' + CAST (DatePart(dd,@StartDate) as nvarchar(2)) Else CAST (DatePart(dd,@StartDate) as nvarchar(2)) End 
    SELECT @TEndTime = Cast( DatePart(yyyy,@EndDate) as nvarchar(4)) + ''/'' + CASE When DatePart(mm,@EndDate) < 10 Then ''0'' + CAST (DatePart(mm,@EndDate) as nvarchar(2)) Else CAST (DatePart(mm,@EndDate) as nvarchar(2)) End + ''/'' + CASE When DatePart(dd,@EndDate) < 10 Then ''0'' + CAST (DatePart(dd,@EndDate) as nvarchar(2)) Else CAST (DatePart(dd,@EndDate) as nvarchar(2)) End 
	Select @equalDates = Case When @TStartTime = @TEndTime Then  1 Else 0 End
	Select @TStartTime = @TStartTime + '' '' + CASE When DatePart(hh,@StartDate) < 10 Then ''0'' + CAST (DatePart(hh,@StartDate) as nvarchar(2)) Else CAST (DatePart(hh,@StartDate) as nvarchar(2)) End + '':'' + CASE When DatePart(mi,@StartDate) < 10 Then ''0'' + CAST (DatePart(mi,@StartDate)as nvarchar(2)) ELSE CAST (DatePart(mi,@StartDate)as nvarchar(2)) End
    Select @TEndTime = CASE When @equalDates = 1 Then CASE When DatePart(hh,@EndDate)  < 10 Then ''0'' + CAST (DatePart(hh,@EndDate) as nvarchar(2)) Else CAST (DatePart(hh,@EndDate) as nvarchar(2)) End + '':'' + CASE When DatePart(mi,@EndDate) <10 Then ''0'' + CAST(DatePart(mi,@EndDate) as nvarchar(2)) Else CAST(DatePart(mi,@EndDate) as nvarchar(2)) End
	Else @TEndTime + '' '' + CASE When DatePart(hh,@EndDate) < 10 Then ''0'' + CAST(DatePart(hh,@EndDate) as nvarchar(2)) Else CAST(DatePart(hh,@EndDate) as nvarchar(2)) End + '':'' + CASE When DatePart(mi,@EndDate) < 10 Then ''0'' + CAST (DatePart(mi,@EndDate) as nvarchar(2)) Else CAST (DatePart(mi,@EndDate) as nvarchar(2)) End End
	Select @Result = @TStartTime + '' - '' + @TEndTime
	
	-- Return the result of the function
	RETURN @Result

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetScheduledTeacherID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetScheduledTeacherID]
(
	-- Add the parameters for the function here
	@ID int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
if(@ID is null)
begin
 return 0
end
	return @ID

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSaturdayMinutes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetSaturdayMinutes] 
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
	select @minutes = CASE WHEN @DayName = ''Sat'' OR @DayName = ''Sun'' OR
                      @IsHoliday = 1 THEN DATEDIFF(mi, @StartDateTime, @EndDateTime) 
                      ELSE 0.00 END

    SET @minutes = @minutes - @BreakDuration

	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + '' '' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END






' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetTime] 
(
	-- Add the parameters for the function here
	@CurrentDate DateTime,
	@timestamp nvarchar(7)
)
RETURNS DateTime
AS
BEGIN
	-- Declare the return variable here
	Declare @DateSet DateTime
	Declare @ALLSTRING nvarchar(40)
	SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + '' '' + @timestamp
	Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @DateSet

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewPivotCourseDetails]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewPivotCourseDetails]
AS
SELECT     dbo.Program.ProgramId, dbo.Course.EventId, dbo.Course.Name, dbo.Course.CourseId, LEFT(DATENAME(dw, dbo.CalendarEvent.StartDateTime), 3) 
                      AS DAYNAME, dbo.Contact.LastName + N'', '' + dbo.Contact.FirstName AS InstructorName, dbo.CalendarEvent.StartDateTime, 
                      dbo.CalendarEvent.ScheduledTeacherId
FROM         dbo.Program INNER JOIN
                      dbo.Course ON dbo.Program.ProgramId = dbo.Course.ProgramId INNER JOIN
                      dbo.CalendarEvent ON dbo.Course.EventId = dbo.CalendarEvent.EventId INNER JOIN
                      dbo.Contact ON dbo.CalendarEvent.ScheduledTeacherId = dbo.Contact.ContactId
WHERE     (dbo.Course.EventId <> 0)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllEvents]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewAllEvents]
AS
SELECT     dbo.Event.EventId, dbo.Event.RepeatRule, dbo.Event.NegetiveException, dbo.Event.Description, dbo.Event.RecurrenceText, dbo.CalendarEvent.CalendarEventId, 
                      dbo.CalendarEvent.Note, CASE CalendarEvent.CalendarEventStatus WHEN ''0'' THEN ''Active'' WHEN ''1'' THEN ''Inactive'' END AS EventStatus, 
                      dbo.CalendarEvent.StartDateTime, dbo.CalendarEvent.EndDateTime, LEFT(DATENAME(dw, dbo.CalendarEvent.StartDateTime), 3) AS DayOfWeek, 
                      dbo.CalendarEvent.DateCompleted, dbo.CalendarEvent.Name, dbo.CalendarEvent.NamePhonetic, dbo.CalendarEvent.NameRomaji, dbo.CalendarEvent.Location, 
                      dbo.CalendarEvent.BlockCode, dbo.CalendarEvent.RoomNumber, dbo.CalendarEvent.ScheduledTeacherId, dbo.CalendarEvent.RealTeacherId, 
                      dbo.CalendarEvent.ChangeReason, dbo.CalendarEvent.IsHoliday, dbo.CalendarEvent.EventType, dbo.CalendarEvent.ExceptionReason, 
                      ISNULL(CC1.LastName + '', '' + CC1.FirstName, '''') AS ScheduledTeacher, ISNULL(CC2.LastName + '', '' + CC2.FirstName, '''') AS RealTeacher, dbo.Course.CourseId, 
                      dbo.Course.Name AS Class, dbo.Program.ProgramId, dbo.Program.Name AS ProgramName, CASE WHEN Program.NickName IS NULL 
                      THEN Program.Name WHEN Program.NickName = '''' THEN Program.Name ELSE Program.NickName END AS Program, 
                      dbo.DateAndTime(dbo.CalendarEvent.StartDateTime, dbo.CalendarEvent.EndDateTime) AS DateAndTime, dbo.Course.EventId AS CEvent1, 
                      dbo.Course.TestInitialEventId AS CEvent2, dbo.Course.TestMidtermEventId AS CEvent3, dbo.Course.TestFinalEventId AS CEvent4, 
                      dbo.Program.TestInitialEventId AS PEvent1, dbo.Program.TestMidtermEventId AS PEvent2, dbo.Program.TestFinalEventId AS PEvent3, 
                      CASE WHEN CC2.LastName + '', '' + CC2.FirstName IS NOT NULL AND 
                      CC2.LastName + '', '' + CC2.FirstName <> '', '' THEN CC2.LastName + '', '' + CC2.FirstName ELSE CASE WHEN CC1.LastName + '', '' + CC1.FirstName IS NOT NULL AND 
                      CC1.LastName + '', '' + CC1.FirstName <> '', '' THEN CC1.LastName + '', '' + CC1.FirstName ELSE '''' END END AS Instructor, CASE WHEN (CourseId IS NOT NULL AND 
                      CourseId > 0) THEN CASE WHEN dbo.Course.EventId IS NOT NULL AND 
                      dbo.Course.EventId > 0 THEN ''Class Event'' ELSE CASE WHEN dbo.Course.TestInitialEventId IS NOT NULL AND 
                      dbo.Course.TestInitialEventId > 0 THEN ''Test Initial'' ELSE CASE WHEN Course.TestMidtermEventId IS NOT NULL AND 
                      Course.TestMidtermEventId > 0 THEN ''Test Midterm'' ELSE CASE WHEN Course.TestFinalEventId IS NOT NULL AND 
                      Course.TestFinalEventId > 0 THEN ''Test Final'' END END END END ELSE CASE WHEN (Program.ProgramId IS NOT NULL AND Program.ProgramId > 0) 
                      THEN CASE WHEN Program.TestInitialEventId IS NOT NULL AND 
                      Program.TestInitialEventId > 0 THEN ''Test Initial'' ELSE CASE WHEN Program.TestMidtermEventId IS NOT NULL AND 
                      Program.TestMidtermEventId > 0 THEN ''Test Midterm'' ELSE CASE WHEN Program.TestFinalEventId IS NOT NULL AND 
                      Program.TestFinalEventId > 0 THEN ''Test Final'' END END END END END AS TestEvent, dbo.Program.DepartmentId
FROM         dbo.Event INNER JOIN
                      dbo.CalendarEvent ON dbo.Event.EventId = dbo.CalendarEvent.EventId LEFT OUTER JOIN
                      dbo.Contact AS CC1 ON CC1.ContactId = dbo.CalendarEvent.ScheduledTeacherId LEFT OUTER JOIN
                      dbo.Contact AS CC2 ON CC2.ContactId = dbo.CalendarEvent.RealTeacherId LEFT OUTER JOIN
                      dbo.Course ON dbo.Event.EventId = dbo.Course.EventId OR dbo.Event.EventId = dbo.Course.TestInitialEventId OR 
                      dbo.Event.EventId = dbo.Course.TestMidtermEventId OR dbo.Event.EventId = dbo.Course.TestFinalEventId LEFT OUTER JOIN
                      dbo.Program ON dbo.Program.ProgramId = dbo.Course.ProgramId OR dbo.Event.EventId = dbo.Program.TestInitialEventId OR 
                      dbo.Event.EventId = dbo.Program.TestMidtermEventId OR dbo.Event.EventId = dbo.Program.TestFinalEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewCourseN]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[ViewCourseN]
AS
SELECT     C.CourseId, C.Name, C.NamePhonetic, C.NameRomaji, C.NickName, C.ProgramId, C.CourseType, C.EventId, C.Description, C.SpecialRemarks, C.Curriculam, 
                      C.NumberStudents, C.HomeworkMinutes, C.TestInitialEventId, C.TestMidtermEventId, C.TestFinalEventId, C.TestInitialForm, C.TestMidtermForm, C.TestFinalForm, 
                      CASE WHEN CourseStatus = 0 THEN ''Active'' ELSE ''Inactive'' END AS CourseStatus, C.CreatedByUserId, C.DateCreated, C.DateLastModified, C.LastModifiedByUserId, C.BreakDuration,
                      CASE WHEN C.NickName IS NULL THEN C.Name WHEN C.NickName = '''' THEN C.Name ELSE C.NickName END AS BrowseName, P.NickName AS ProgramNickName, 
                      CASE WHEN P.NickName IS NULL THEN P.Name WHEN P.NickName = '''' THEN P.Name ELSE P.NickName END AS Program, CASE WHEN CO.NickName IS NULL 
                      THEN CO.CompanyName WHEN CO.NickName = '''' THEN CO.CompanyName ELSE CO.NickName END AS Department, CASE WHEN CO1.NickName IS NULL 
                      THEN CO1.CompanyName WHEN CO1.NickName = '''' THEN CO1.CompanyName ELSE CO1.NickName END AS Client
FROM         dbo.Course AS C LEFT OUTER JOIN
                      dbo.Program AS P ON C.ProgramId = P.ProgramId LEFT OUTER JOIN
                      dbo.Department AS D ON P.DepartmentId = D.DepartmentID LEFT OUTER JOIN
                      dbo.Contact AS CO ON D.ContactID = CO.ContactId LEFT OUTER JOIN
                      dbo.Contact AS CO1 ON D.ClientID = CO1.ContactId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwGroupCalendarEvents]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwGroupCalendarEvents]
AS
SELECT     EventId, TestInitialEventId, TestMidtermEventId, TestFinalEventId, StartDateTime, EndDateTime, Name AS CourseName, EventType, EventName, 
                      ScheduledTeacherId, RealTeacherId, IsHoliday, CalendarEventStatus, CalendarEventId, HomeworkMinutes, CourseStatus, CourseType, 
                      ProgramId
FROM         (SELECT     dbo.CalendarEvent.EventId, dbo.CalendarEvent.StartDateTime, dbo.CalendarEvent.EndDateTime, dbo.Course.Name, 
                                              dbo.Course.TestInitialEventId, dbo.Course.TestMidtermEventId, dbo.Course.TestFinalEventId, dbo.CalendarEvent.EventType, 
                                              dbo.CalendarEvent.Name AS EventName, dbo.CalendarEvent.ScheduledTeacherId, dbo.CalendarEvent.RealTeacherId, 
                                              dbo.CalendarEvent.IsHoliday, dbo.CalendarEvent.CalendarEventStatus, dbo.CalendarEvent.CalendarEventId, 
                                              dbo.Course.HomeworkMinutes, dbo.Course.CourseStatus, dbo.Course.CourseType, dbo.Course.ProgramId
                        FROM         dbo.CalendarEvent FULL OUTER JOIN
                                              dbo.Course ON dbo.CalendarEvent.EventId = dbo.Course.EventId
                        UNION
                        SELECT     CalendarEvent_3.EventId, CalendarEvent_3.StartDateTime, CalendarEvent_3.EndDateTime, Course_3.Name, Course_3.TestInitialEventId, 
                                              Course_3.TestMidtermEventId, Course_3.TestFinalEventId, CalendarEvent_3.EventType, CalendarEvent_3.Name AS EventName, 
                                              CalendarEvent_3.ScheduledTeacherId, CalendarEvent_3.RealTeacherId, CalendarEvent_3.IsHoliday, 
                                              CalendarEvent_3.CalendarEventStatus, CalendarEvent_3.CalendarEventId, Course_3.HomeworkMinutes, Course_3.CourseStatus, 
                                              Course_3.CourseType, Course_3.ProgramId
                        FROM         dbo.CalendarEvent AS CalendarEvent_3 FULL OUTER JOIN
                                              dbo.Course AS Course_3 ON CalendarEvent_3.EventId = Course_3.TestInitialEventId
                        UNION
                        SELECT     CalendarEvent_2.EventId, CalendarEvent_2.StartDateTime, CalendarEvent_2.EndDateTime, Course_2.Name, Course_2.TestInitialEventId, 
                                              Course_2.TestMidtermEventId, Course_2.TestFinalEventId, CalendarEvent_2.EventType, CalendarEvent_2.Name AS EventName, 
                                              CalendarEvent_2.ScheduledTeacherId, CalendarEvent_2.RealTeacherId, CalendarEvent_2.IsHoliday, 
                                              CalendarEvent_2.CalendarEventStatus, CalendarEvent_2.CalendarEventId, Course_2.HomeworkMinutes, Course_2.CourseStatus, 
                                              Course_2.CourseType, Course_2.ProgramId
                        FROM         dbo.CalendarEvent AS CalendarEvent_2 FULL OUTER JOIN
                                              dbo.Course AS Course_2 ON CalendarEvent_2.EventId = Course_2.TestMidtermEventId
                        UNION
                        SELECT     CalendarEvent_1.EventId, CalendarEvent_1.StartDateTime, CalendarEvent_1.EndDateTime, Course_1.Name, Course_1.TestInitialEventId, 
                                              Course_1.TestMidtermEventId, Course_1.TestFinalEventId, CalendarEvent_1.EventType, CalendarEvent_1.Name AS EventName, 
                                              CalendarEvent_1.ScheduledTeacherId, CalendarEvent_1.RealTeacherId, CalendarEvent_1.IsHoliday, 
                                              CalendarEvent_1.CalendarEventStatus, CalendarEvent_1.CalendarEventId, Course_1.HomeworkMinutes, Course_1.CourseStatus, 
                                              Course_1.CourseType, Course_1.ProgramId
                        FROM         dbo.CalendarEvent AS CalendarEvent_1 FULL OUTER JOIN
                                              dbo.Course AS Course_1 ON CalendarEvent_1.EventId = Course_1.TestFinalEventId) AS vwGroupCalendarEvents
WHERE     (EventId IS NOT NULL) AND (ProgramId IS NOT NULL)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCourseEventsByEventID]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCourseEventsByEventID]
AS
SELECT     dbo.newvwCalendarEventInstructors.CalendarEventId, dbo.newvwCalendarEventInstructors.EventId, 
                      dbo.newvwCalendarEventInstructors.StartDateTime, dbo.newvwCalendarEventInstructors.EndDateTime, 
                      dbo.newvwCalendarEventInstructors.EventType, dbo.newvwCalendarEventInstructors.EventName, dbo.newvwCalendarEventInstructors.EventStatus, 
                      dbo.newvwCalendarEventInstructors.TeacherId, dbo.newvwCalendarEventInstructors.InstructorName, 
                      dbo.newvwCalendarEventInstructors.ScheduledHours, dbo.newvwCalendarEventInstructors.DayName, 
                      dbo.newvwCalendarEventInstructors.BasePayField, dbo.Course.Name, dbo.Course.ProgramId, dbo.Course.CourseType, 
                      dbo.Course.HomeworkMinutes, dbo.Course.CourseStatus, dbo.Course.CourseId
FROM         dbo.newvwCalendarEventInstructors LEFT OUTER JOIN
                      dbo.Course ON dbo.newvwCalendarEventInstructors.EventId = dbo.Course.EventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetScheduledTeacherNameForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[GetScheduledTeacherNameForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS nvarchar(100)
AS
BEGIN
	-- Declare the return variable here
	Declare @SchedID as int
	DECLARE @Result nvarchar(50)
	Declare @FirstName as nvarchar(50)
	Declare @LastName as nvarchar(50)
	-- Add the T-SQL statements to compute the return value here
SEt @Result = ''''
	SELECT @SchedID = ScheduledTeacherId From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID
	if(@SchedID is not null)
	begin

		Select @FirstName = FirstName From Contact Where ContactID = @SchedID
		Select @LastName = LastName From Contact Where ContactID = @SchedID
		Select @Result = @LastName + N'', '' + @FirstName
	end

	-- Return the result of the function
	RETURN @Result

END


' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEventTextStartDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEventTextStartDate] 
(
	-- Add the parameters for the function here
	@EventId int
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	Declare @StartDate datetime

	SELECT @StartDate =  StartDateTime From [CalendarEvent] WHERE EventID= @EventId Order By CalendarEventID

	-- Return the result of the function
	RETURN @StartDate

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEventTextInstructorName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[GetEventTextInstructorName]
(
	-- Add the parameters for the function here
	@EventId int
)
RETURNS nvarchar(200)
AS
BEGIN
	-- Declare the return variable here
	Declare @InstructorId int
	Declare @Result nvarchar(200)
	SELECT @InstructorId =  ScheduledTeacherID From [CalendarEvent] WHERE EventID= @EventId Order By CalendarEventID
	if(@InstructorId is not null)
	begin
		Select @Result = LastName + '', '' + FirstName from Contact Where ContactID = @InstructorId
	end
	-- Return the result of the function
	RETURN @Result
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEventTextEndDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEventTextEndDate]
(
	-- Add the parameters for the function here
	@EventId int
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	Declare @EndDateTime datetime
	SELECT @EndDateTime =  EndDateTime From [CalendarEvent] WHERE EventID= @EventId Order By CalendarEventID Desc
	-- Return the result of the function
	RETURN @EndDateTime
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEventOccurranceCount]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEventOccurranceCount]
(
	-- Add the parameters for the function here
	@EventId int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	Declare @Result nvarchar(50)
	Declare @result1 nvarchar(30)
	declare @result2 nvarchar(30)
	Select @result1 = Count(*) from [CalendarEvent] WHERE EventId=@EventId AND StartDateTime < GetDate() AND CalendarEventStatus = 0
	Select @result2 = Count(*) from [CalendarEvent] WHERE EventId=@EventId AND CalendarEventStatus = 0
	
	Set @Result = @result1 + '' / '' + @result2
	return @Result
END



' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCalendarEvents]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCalendarEvents]
AS
SELECT     CalendarEventId, EventId, StartDateTime, EndDateTime, EventType, Name AS EventName, ScheduledTeacherId, RealTeacherId, IsHoliday, 
                      CASE dbo.CalendarEvent.CalendarEventStatus WHEN ''0'' THEN ''Active'' WHEN ''1'' THEN ''Inactive'' END AS EventStatus, CASE WHEN RealTeacherId IS NULL OR
                      RealTeacherId = 0 THEN ScheduledTeacherId ELSE RealTeacherId END AS TeacherId, CAST(DATEDIFF(mi, StartDateTime, EndDateTime) AS Decimal(18, 2)) 
                      AS EventMinutes, LEFT(DATENAME(dw, StartDateTime), 3) AS DayName
FROM         dbo.CalendarEvent
WHERE     (CalendarEventStatus = 0)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewTempCalendarEvent]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewTempCalendarEvent]
AS
SELECT     EventId, StartDateTime, CalendarEventId
FROM         dbo.CalendarEvent
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPaidHoursForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[GetPaidHoursForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(18,2)
	Declare @TempCalendarEventID int
	Set @Result = 0
	-- Add the T-SQL statements to compute the return value here
	SELECT @TempCalendarEventID = CalendarEventID From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Desc
	if (@TempCalendarEventID is not null)
	begin
		Select @Result = PaidHours From viewInstructorPaymentDetails Where CalendarEventID = @TempCalendarEventID
	end

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCourseTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCourseTime]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS nvarchar(50)
AS
BEGIN
DECLARE @ResultStart DateTime
DECLARE @ResultEnd DateTime
Declare @Result as nvarchar(50)
SELECT @ResultStart = StartDateTime From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID
SELECT @ResultEnd = EndDateTime From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Desc

Set @Result = RIGHT(@ResultStart,8) + '' - '' + RIGHT(@ResultEnd,8)
	-- Declare the return variable here

--                      RIGHT(CAST(dbo.GetStartDateTimeForEventID(dbo.Course.EventId) AS nvarchar(50)), 8) 
--                      + '''' - '''' + RIGHT(CAST(dbo.GetEndDateTimeForEventID(dbo.Course.EventId) AS nvarchar(50)), 8) AS CourseTime

	-- Add the T-SQL statements to compute the return value here
	

	-- Return the result of the function
	RETURN @Result

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStartDateTimeForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetStartDateTimeForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS DateTime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result DateTime

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = StartDateTime From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Desc

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEndDateTimeForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEndDateTimeForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS DateTime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result DateTime

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = EndDateTime From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Asc

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLocationForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[GetLocationForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Location From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Desc

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRoomNumberForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetRoomNumberForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = RoomNumber From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID Desc
	
	-- Return the result of the function
	RETURN @Result

END



' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetScheduledTeacherIDForEventID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[GetScheduledTeacherIDForEventID]
(
	-- Add the parameters for the function here
	@EventID int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result int

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = ScheduledTeacherId From [CalendarEvent] WHERE EventID=@EventID Order By CalendarEventID

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCalendarEventActivePerTotalCount]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCalendarEventActivePerTotalCount]
(
	-- Add the parameters for the function here
	@EventId int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	Declare @Result nvarchar(50)
	Declare @result1 nvarchar(30)
	declare @result2 nvarchar(30)

	Select @result1 = Count(*) from [CalendarEvent] WHERE EventId=@EventId AND CalendarEventStatus = 0
	Select @result2 = Count(*) from [CalendarEvent] WHERE EventId=@EventId
	
	Set @Result = @result1 + '' / '' + @result2
	return @Result
END


' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewRefferedContacts]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewRefferedContacts]
AS
SELECT     TOP (100) PERCENT RefID, LastName + '', '' + FirstName AS ContactName, Phone1, Email1, ContactId
FROM         dbo.Contact
WHERE     (ContactType = 4)
ORDER BY ContactId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContactNameByContactID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetContactNameByContactID]
(
	-- Add the parameters for the function here
	@ID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)
Set @Result = ''''
	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE WHEN NickName IS NULL THEN LastName + '', '' + FirstName ELSE CASE WHEN NickName = '''' THEN LastName + '', '' + FirstName ELSE NickName END END From Contact Where ContactID = @ID

	-- Return the result of the function
	RETURN @Result

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContactPhoneByContactID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetContactPhoneByContactID]
(
	-- Add the parameters for the function here
	@ID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)
Set @Result = ''''
	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Phone1 From Contact Where ContactID = @ID

	-- Return the result of the function
	RETURN @Result

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContactEmailByContactID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetContactEmailByContactID]
(
	-- Add the parameters for the function here
	@ID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)
Set @Result = ''''
	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Email1 From Contact Where ContactID = @ID

	-- Return the result of the function
	RETURN @Result

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContactFaxByContactID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

Create FUNCTION [dbo].[GetContactFaxByContactID]
(
	-- Add the parameters for the function here
	@ID int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(50)
Set @Result = ''''
	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = PhoneFax1 From Contact Where ContactID = @ID

	-- Return the result of the function
	RETURN @Result

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMorningMinutes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetMorningMinutes] 
(
	-- Add the parameters for the function here
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@IsHoliday as int,
	@DayName as nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0
	select @minutes = CASE WHEN @DayName <> ''Sat'' AND @DayName <> ''Sun'' AND @IsHoliday <> 1 AND @StartDateTime <= dbo.GetTime(@StartDateTime, 
                      ''8:29AM'') AND @StartDateTime <= dbo.GetTime(@StartDateTime, ''11:00AM'') THEN CASE WHEN @EndDateTime <= dbo.GetTime(@EndDateTime, ''11:00AM'') 
                      THEN DATEDIFF(mi, @StartDateTime, @EndDateTime) ELSE DATEDIFF(mi, 
                      @StartDateTime, dbo.GetTime(@EndDateTime, ''11:00AM'')) END ELSE 0.00 END 
	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + '' '' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END






' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEveningMinutes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEveningMinutes]
(
	-- Add the parameters for the function here
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@IsHoliday as int,
	@DayName as nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0

	select @minutes = CASE When @IsHoliday<>1 AND @DayName <> ''Sat'' AND @DayName <> ''Sun'' AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
	CASE When @StartDateTime >= dbo.GetTime(@StartDateTime,''5:00PM'') THEN DateDiff(mi,@StartDateTime,@EndDateTime) Else
	DateDiff(mi,dbo.GetTime(@StartDateTime,''5:00PM''),@EndDateTime) END ELSE 0.00 END
	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + '' '' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END





' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDaytimeMinutes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetDaytimeMinutes] 
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
	select @minutes = CASE When @IsHoliday<>1 AND @DayName <> ''Sat'' AND @DayName <> ''Sun'' AND @StartDateTime <= dbo.GetTime(@StartDateTime,''5:00PM'')THEN 
	CASE When @StartDateTime > dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime <= dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
	DateDiff(mi,@StartDateTime,@EndDateTime)
	Else CASE When @StartDateTime > dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
	DateDiff(mi,@StartDateTime,dbo.GetTime(@EndDateTime,''5:00PM'')) 
	ELSE CASE WHEN @StartDateTime <= dbo.GetTime(@StartDateTime,''8:29AM'')
	AND @EndDateTime <= dbo.GetTime(@EndDateTime,''5:00PM'') AND @EndDateTime >= dbo.GetTime(@EndDateTime,''11:00AM'') THEN DateDiff(mi,dbo.GetTime(@StartDateTime,''11:00AM''),@EndDateTime) 
	ELSE CASE When @StartDateTime <= dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN
	DateDiff(mi,dbo.GetTime(@StartDateTime,''11:00AM''),dbo.GetTime(@EndDateTime,''5:00PM''))
	END END END END ELSE 0.00 END

    SET @minutes = @minutes - @BreakDuration

	--SELECT @ALLSTRING = CONVERT(char(10),@CurrentDate,101) + '' '' + @timestamp
	--Select @DateSet = CAST(@ALLSTRING as DateTime)
	
	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN @minutes

END








' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewPivotCourseDetailsTemp]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewPivotCourseDetailsTemp]
AS
SELECT     dbo.Program.ProgramId, dbo.Course.EventId, dbo.Course.Name, dbo.Course.CourseId, dbo.GetStartDateTimeForEventID(dbo.Course.EventId) 
                      AS StartDateTime, LEFT(DATENAME(dw, dbo.GetStartDateTimeForEventID(dbo.Course.EventId)), 3) AS DAYNAME, 
                      dbo.GetScheduledTeacherIDForEventID(dbo.Course.EventId) AS ScheduledTeacherID, dbo.GetScheduledTeacherNameForEventID(dbo.Course.EventId) 
                      AS InstructorName
FROM         dbo.Program INNER JOIN
                      dbo.Course ON dbo.Program.ProgramId = dbo.Course.ProgramId
WHERE     (dbo.Course.EventId <> 0)' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewClassEventsN]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[ViewClassEventsN]
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
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewProgramReport]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[ViewProgramReport]
AS
SELECT     dbo.Program.ProgramId, dbo.Department.DepartmentID, CASE WHEN C.NickName IS NULL 
                      THEN C.CompanyName ELSE CASE WHEN C.NickName = '''' THEN C.CompanyName ELSE C.NickName END END AS DepartmentName, 
                      CASE WHEN C1.NickName IS NULL 
                      THEN C1.CompanyName ELSE CASE WHEN C1.NickName = '''' THEN C1.CompanyName ELSE C1.NickName END END AS ClientName, 
                      CASE WHEN (C1.Street1 + '', '' + C1.Street2 + '', '' + C1.Street3 + '', '' + C1.City + '', '' + C1.State + '' '' + C1.Country) 
                      = '', , , ,  '' THEN '''' ELSE (C1.Street1 + '', '' + C1.Street2 + '', '' + C1.Street3 + '', '' + C1.City + '', '' + C1.State + '' '' + C1.Country) END AS ClientAddress, 
                      dbo.GetContactNameByContactID(dbo.Program.Contact1ID) AS Contact1Name, dbo.GetContactNameByContactID(dbo.Program.Contact2ID) 
                      AS Contact2Name, CASE WHEN Program.NickName IS NULL 
                      THEN Program.Name ELSE CASE WHEN Program.NickName = '''' THEN Program.Name ELSE Program.NickName END END AS ProgramName, 
                      dbo.Program.TestInitialForm, dbo.Program.TestMidtermForm, dbo.GetContactPhoneByContactID(dbo.Program.Contact1ID) AS Contact1Phone, 
                      dbo.GetContactFaxByContactID(dbo.Program.Contact1ID) AS Contact1Fax, dbo.GetContactEmailByContactID(dbo.Program.Contact1ID) 
                      AS Contact1Email, dbo.GetContactPhoneByContactID(dbo.Program.Contact2ID) AS Contact2Phone, 
                      dbo.GetContactEmailByContactID(dbo.Program.Contact2ID) AS Contact2Email, dbo.GetContactFaxByContactID(dbo.Program.Contact2ID) 
                      AS Contact2Fax, dbo.Program.TestFinalForm, InitialEvent.StartDateTime AS InitialEventStartDate, InitialEvent.EndDateTime AS InitialEventEndDate, 
                      CAST(InitialEvent.StartDateTime AS nvarchar(50)) + '' - '' + CAST(InitialEvent.EndDateTime AS nvarchar(50)) AS InitialEventDateTime, 
                      MidTermEvent.StartDateTime AS MidTermStartDate, MidTermEvent.EndDateTime AS MidTermEndDate, FinalEvent.StartDateTime AS FinalStartDate, 
                      FinalEvent.EndDateTime AS FinalEndDate, REPLACE(dbo.Program.EvaluationMidtermForm, ''|'', '''') AS EvaluationMidtermForm, 
                      REPLACE(dbo.Program.EvaluationFinalForm, ''|'', '''') AS EvaluationFinalForm, REPLACE(dbo.Program.QuestionaireMidtermForm, ''|'', '''') 
                      AS QuestionaireMidtermForm, REPLACE(dbo.Program.QuestionaireFinalForm, ''|'', '''') AS QuestionaireFinalForm, dbo.Program.ReportAttendence, 
                      dbo.Program.SpecialRemarks, dbo.Program.Contact1ID, dbo.Program.Contact2ID
FROM         dbo.Program INNER JOIN
                      dbo.Department ON dbo.Program.DepartmentId = dbo.Department.DepartmentID INNER JOIN
                      dbo.Contact AS C ON dbo.Department.ContactID = C.ContactId INNER JOIN
                      dbo.Contact AS C1 ON dbo.Department.ClientID = C1.ContactId LEFT OUTER JOIN
                      dbo.CalendarEvent AS FinalEvent ON dbo.Program.TestFinalEventId = FinalEvent.EventId LEFT OUTER JOIN
                      dbo.CalendarEvent AS MidTermEvent ON dbo.Program.TestMidtermEventId = MidTermEvent.EventId LEFT OUTER JOIN
                      dbo.CalendarEvent AS InitialEvent ON dbo.Program.TestInitialEventId = InitialEvent.EventId

' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllEventCourseDetails]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewAllEventCourseDetails]
AS
SELECT     v.EventId, v.RepeatRule, v.NegetiveException, v.Description, v.RecurrenceText, v.CalendarEventId, v.Note, v.EventStatus, v.StartDateTime, v.EndDateTime, 
                      v.DayOfWeek, v.DateCompleted, v.Name, v.NamePhonetic, v.NameRomaji, v.Location, v.BlockCode, v.RoomNumber, v.ScheduledTeacherId, v.RealTeacherId, 
                      v.ChangeReason, v.IsHoliday, v.EventType, v.ExceptionReason, v.ScheduledTeacher, v.RealTeacher, v.CourseId, v.Class, v.ProgramId, v.ProgramName, v.Program, 
                      v.DateAndTime, v.CEvent1, v.CEvent2, v.CEvent3, v.CEvent4, v.PEvent1, v.PEvent2, v.PEvent3, v.Instructor, v.TestEvent, v.DepartmentId, 
                      CO.CompanyName AS DeptName, CASE WHEN CO.NickName IS NULL OR
                      CO.NickName = '''' THEN CO.CompanyName ELSE CO.NickName END AS Department, CO1.CompanyName AS ClientName, CASE WHEN CO1.NickName IS NULL OR
                      CO1.NickName = '''' THEN CO1.CompanyName ELSE CO1.NickName END AS Client
FROM         dbo.ViewAllEvents AS v LEFT OUTER JOIN
                      dbo.Course AS c ON v.CourseId = c.CourseId LEFT OUTER JOIN
                      dbo.Program AS p ON p.ProgramId = c.ProgramId LEFT OUTER JOIN
                      dbo.Department AS d ON p.DepartmentId = d.DepartmentID LEFT OUTER JOIN
                      dbo.Contact AS CO ON d.ContactID = CO.ContactId LEFT OUTER JOIN
                      dbo.Contact AS CO1 ON d.ClientID = CO1.ContactId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCalendarEventInstructors]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[newvwCalendarEventInstructors]
AS
SELECT dbo.newvwCalendarEvents.CalendarEventId, dbo.newvwCalendarEvents.EventId, dbo.newvwCalendarEvents.StartDateTime, 
               dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.EventType, dbo.newvwCalendarEvents.EventName, 
               dbo.newvwCalendarEvents.ScheduledTeacherId, dbo.newvwCalendarEvents.RealTeacherId, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.EventStatus, dbo.newvwCalendarEvents.TeacherId, CAST(dbo.newvwCalendarEvents.EventMinutes AS Decimal(18, 2)) 
               AS EventMinutes, CAST(CAST(dbo.newvwCalendarEvents.EventMinutes - dbo.Course.BreakDuration AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS ScheduledHours, dbo.newvwCalendarEvents.DayName, 
               dbo.Contact.LastName + N'', '' + dbo.Contact.FirstName AS InstructorName, dbo.Contact.BasePayField, 
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
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewClientContact]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewClientContact]
AS
SELECT     dbo.Contact.ContactId, CASE WHEN Contact.NickName IS NULL 
                      THEN Contact.CompanyName WHEN Contact.NickName = '''' THEN Contact.CompanyName ELSE Contact.NickName END AS ContactName, 
                      dbo.ViewRefferedContacts.ContactName AS RefContactName, dbo.ViewRefferedContacts.Phone1 AS RefPhone, 
                      CASE WHEN (dbo.Contact.Street1 + '',  '' + dbo.Contact.City + '', '' + dbo.Contact.State + '', '' + dbo.Contact.Country) 
                      = '',  , , '' THEN '''' ELSE (dbo.Contact.Street1 + '',  '' + dbo.Contact.City + '', '' + dbo.Contact.State + '', '' + dbo.Contact.Country) END AS Address, 
                      dbo.ViewRefferedContacts.Email1 AS RefEmail
FROM         dbo.Contact LEFT OUTER JOIN
                      dbo.ViewRefferedContacts ON dbo.Contact.ContactId = dbo.ViewRefferedContacts.RefID
WHERE     (dbo.Contact.ContactType = 2)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewSimpleProgramInfo]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewSimpleProgramInfo]
AS
SELECT     dbo.Program.ProgramId, dbo.Course.CourseId, dbo.Course.EventId, CASE WHEN Course.NickName IS NULL 
                      THEN Course.Name ELSE CASE WHEN Course.NickName = '''' THEN Course.Name ELSE Course.NickName END END AS CourseName, 
                      CASE WHEN Program.NickName IS NULL 
                      THEN Program.Name ELSE CASE WHEN Program.NickName = '''' THEN Program.Name ELSE Program.NickName END END AS ProgramName, 
                      CASE WHEN dbo.GetStartDateTimeForEventID(dbo.Course.EventId) IS NULL THEN ''None'' ELSE CONVERT(nvarchar(38), 
                      dbo.GetStartDateTimeForEventID(dbo.Course.EventId), 1) END AS StartDateTime, CASE WHEN dbo.GetEndDateTimeForEventID(dbo.Course.EventId) 
                      IS NULL THEN ''None'' ELSE CONVERT(nvarchar(38), dbo.GetEndDateTimeForEventID(dbo.Course.EventId), 1) END AS EndDateTime
FROM         dbo.Program INNER JOIN
                      dbo.Course ON dbo.Program.ProgramId = dbo.Course.ProgramId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCourseEventsByInitialEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCourseEventsByInitialEventId]
AS
SELECT     dbo.newvwCourseEventsByEventID.CalendarEventId, dbo.newvwCourseEventsByEventID.EventId, dbo.newvwCourseEventsByEventID.StartDateTime, 
                      dbo.newvwCourseEventsByEventID.EndDateTime, dbo.newvwCourseEventsByEventID.EventType, dbo.newvwCourseEventsByEventID.EventName, 
                      dbo.newvwCourseEventsByEventID.EventStatus, dbo.newvwCourseEventsByEventID.TeacherId, dbo.newvwCourseEventsByEventID.InstructorName, 
                      dbo.newvwCourseEventsByEventID.ScheduledHours, dbo.newvwCourseEventsByEventID.DayName, 
                      dbo.newvwCourseEventsByEventID.BasePayField, CASE WHEN dbo.newvwCourseEventsByEventID.ProgramId IS NULL 
                      THEN Course.ProgramID ELSE dbo.newvwCourseEventsByEventID.ProgramId END AS ProgramId, 
                      CASE WHEN dbo.newvwCourseEventsByEventID.Name IS NULL THEN Course.Name ELSE dbo.newvwCourseEventsByEventID.Name END AS Name, 
                      CASE WHEN dbo.newvwCourseEventsByEventID.CourseID IS NULL 
                      THEN Course.CourseID ELSE dbo.newvwCourseEventsByEventID.CourseID END AS CourseID, 
                      CASE WHEN dbo.newvwCourseEventsByEventID.CourseType IS NULL 
                      THEN Course.CourseType ELSE dbo.newvwCourseEventsByEventID.CourseType END AS CourseType, 
                      CASE WHEN dbo.newvwCourseEventsByEventID.HomeworkMinutes IS NULL 
                      THEN Course.HomeworkMinutes ELSE dbo.newvwCourseEventsByEventID.HomeworkMinutes END AS HomeworkMinutes, 
                      CASE WHEN dbo.newvwCourseEventsByEventID.CourseStatus IS NULL 
                      THEN Course.CourseStatus ELSE dbo.newvwCourseEventsByEventID.CourseStatus END AS CouseStatus
FROM         dbo.newvwCourseEventsByEventID LEFT OUTER JOIN
                      dbo.Course ON dbo.newvwCourseEventsByEventID.EventId = dbo.Course.TestInitialEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewProgramReportHelper]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewProgramReportHelper]
AS
SELECT COUNT(*) AS Total, dbo.GetCalendarEventActivePerTotalCount(EventId) AS TotalString, EventId
FROM  dbo.CalendarEvent
GROUP BY EventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllEventsFull]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ViewAllEventsFull]
AS
SELECT     v.EventId, v.RepeatRule, v.NegetiveException, v.Description, v.RecurrenceText, v.CalendarEventId, v.Note, v.EventStatus, v.StartDateTime, v.EndDateTime, 
                      v.DayOfWeek, v.DateCompleted, v.Name, v.NamePhonetic, v.NameRomaji, v.Location, v.BlockCode, v.RoomNumber, v.ScheduledTeacherId, v.RealTeacherId, 
                      v.ChangeReason, v.IsHoliday, v.EventType, v.ExceptionReason, v.ScheduledTeacher, v.RealTeacher, v.CourseId, v.Class, v.ProgramId, v.ProgramName, v.Program, 
                      v.DateAndTime, v.CEvent2, v.CEvent1, v.CEvent3, v.CEvent4, v.PEvent1, v.PEvent2, v.PEvent3, v.Instructor, v.TestEvent, CASE WHEN ProgramId IS NOT NULL AND 
                      CourseId IS NULL AND ProgramId > 0 THEN CO.CompanyName ELSE v.DeptName END AS DeptName, CASE WHEN ProgramId IS NOT NULL AND CourseId IS NULL 
                      AND ProgramId > 0 THEN CASE WHEN CO.NickName IS NULL OR
                      CO.NickName = '''' THEN CO.CompanyName ELSE CO.NickName END ELSE v.Department END AS Department, CASE WHEN ProgramId IS NOT NULL AND 
                      CourseId IS NULL AND ProgramId > 0 THEN CO1.CompanyName ELSE v.ClientName END AS ClientName, CASE WHEN ProgramId IS NOT NULL AND CourseId IS NULL
                       AND ProgramId > 0 THEN CASE WHEN CO1.NickName IS NULL OR
                      CO1.NickName = '''' THEN CO1.CompanyName ELSE CO1.NickName END ELSE v.Client END AS Client
FROM         dbo.ViewAllEventCourseDetails AS v LEFT OUTER JOIN
                      dbo.Department AS d ON v.DepartmentId = d.DepartmentID LEFT OUTER JOIN
                      dbo.Contact AS CO ON d.ContactID = CO.ContactId LEFT OUTER JOIN
                      dbo.Contact AS CO1 ON d.ClientID = CO1.ContactId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewProgramReportClassDetails]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewProgramReportClassDetails]
AS
SELECT dbo.Program.ProgramId, CASE WHEN Course.NickName IS NULL 
               THEN dbo.Course.Name ELSE CASE WHEN Course.NickName = '''' THEN Course.Name ELSE Course.NickName END END AS CourseName, dbo.Course.EventId, 
               CASE WHEN (dbo.Course.HomeworkMinutes = 0 OR
               dbo.Course.HomeworkMinutes IS NULL) THEN ''NO'' ELSE CAST(dbo.Course.HomeworkMinutes AS nvarchar(50)) END AS HomeworkMinutes, 
               dbo.viewProgramReportHelper.TotalString, dbo.Course.CourseId, dbo.GetEndDateTimeForEventID(dbo.Course.EventId) AS EndDateTime, 
               dbo.GetStartDateTimeForEventID(dbo.Course.EventId) AS StartDateTime, dbo.GetLocationForEventID(dbo.Course.EventId) AS Location, 
               dbo.GetRoomNumberForEventID(dbo.Course.EventId) AS RoomNumber, dbo.GetPaidHoursForEventID(dbo.Course.EventId) AS PaidHours, 
               dbo.GetCourseTime(dbo.Course.EventId) AS CourseTime
FROM  dbo.Program RIGHT OUTER JOIN
               dbo.Course ON dbo.Program.ProgramId = dbo.Course.ProgramId LEFT OUTER JOIN
               dbo.viewProgramReportHelper ON dbo.Course.EventId = dbo.viewProgramReportHelper.EventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCourseEventsByMidtermEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCourseEventsByMidtermEventId]
AS
SELECT     dbo.newvwCourseEventsByInitialEventId.CalendarEventId, dbo.newvwCourseEventsByInitialEventId.EventId, 
                      dbo.newvwCourseEventsByInitialEventId.StartDateTime, dbo.newvwCourseEventsByInitialEventId.EndDateTime, 
                      dbo.newvwCourseEventsByInitialEventId.EventType, dbo.newvwCourseEventsByInitialEventId.EventName, 
                      dbo.newvwCourseEventsByInitialEventId.EventStatus, dbo.newvwCourseEventsByInitialEventId.TeacherId, 
                      dbo.newvwCourseEventsByInitialEventId.InstructorName, dbo.newvwCourseEventsByInitialEventId.ScheduledHours, 
                      dbo.newvwCourseEventsByInitialEventId.DayName, dbo.newvwCourseEventsByInitialEventId.BasePayField, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.ProgramId IS NULL 
                      THEN Course.ProgramId ELSE dbo.newvwCourseEventsByInitialEventId.ProgramId END AS ProgramId, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.Name IS NULL 
                      THEN Course.Name ELSE dbo.newvwCourseEventsByInitialEventId.Name END AS Name, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.CourseID IS NULL 
                      THEN Course.CourseID ELSE dbo.newvwCourseEventsByInitialEventId.CourseID END AS CourseID, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.CourseType IS NULL 
                      THEN Course.CourseType ELSE dbo.newvwCourseEventsByInitialEventId.CourseType END AS CourseType, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.HomeworkMinutes IS NULL 
                      THEN Course.HomeworkMinutes ELSE dbo.newvwCourseEventsByInitialEventId.HomeworkMinutes END AS HomeworkMinutes, 
                      CASE WHEN dbo.newvwCourseEventsByInitialEventId.CouseStatus IS NULL 
                      THEN Course.CourseStatus ELSE dbo.newvwCourseEventsByInitialEventId.CouseStatus END AS CourseStatus
FROM         dbo.newvwCourseEventsByInitialEventId LEFT OUTER JOIN
                      dbo.Course ON dbo.newvwCourseEventsByInitialEventId.EventId = dbo.Course.TestMidtermEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCourseEventsByFinalEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCourseEventsByFinalEventId]
AS
SELECT     ce.CalendarEventId, ce.EventId, ce.StartDateTime, ce.EndDateTime, ce.EventType, ce.EventName, ce.EventStatus, ce.TeacherId, ce.InstructorName, 
                      ce.ScheduledHours, ce.DayName, ce.BasePayField, CASE WHEN ce.ProgramId IS NULL 
                      THEN course.ProgramId ELSE ce.ProgramId END AS ProgramId, CASE WHEN ce.Name IS NULL THEN course.Name ELSE ce.Name END AS Name, 
                      CASE WHEN ce.CourseID IS NULL THEN course.CourseID ELSE ce.CourseID END AS CourseID, CASE WHEN ce.CourseType IS NULL 
                      THEN Course.CourseType ELSE ce.CourseType END AS CourseType, CASE WHEN ce.HomeworkMinutes IS NULL 
                      THEN course.HomeworkMinutes ELSE ce.HomeworkMinutes END AS HomeworkMinutes, CASE WHEN ce.CourseStatus IS NULL 
                      THEN course.CourseStatus ELSE ce.CourseStatus END AS CourseStatus
FROM         dbo.newvwCourseEventsByMidtermEventId AS ce LEFT OUTER JOIN
                      dbo.Course ON ce.EventId = dbo.Course.TestFinalEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwNewProgramEventsbyTestInitialEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwNewProgramEventsbyTestInitialEventId]
AS
SELECT     ce.CalendarEventId, ce.EventId, ce.StartDateTime, ce.EndDateTime, ce.EventType, ce.EventName, ce.EventStatus, ce.TeacherId, ce.InstructorName, 
                      ce.ScheduledHours, ce.DayName, ce.BasePayField, CASE WHEN ce.ProgramId IS NULL THEN p.ProgramId ELSE ce.ProgramId END AS ProgramId, 
                      ce.Name AS CourseName, ce.CourseType, ce.HomeworkMinutes, ce.CourseStatus, ce.CourseID
FROM         dbo.newvwCourseEventsByFinalEventId AS ce LEFT OUTER JOIN
                      dbo.Program AS p ON ce.EventId = p.TestInitialEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwNewProgamEventsbyTestMidtermEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwNewProgamEventsbyTestMidtermEventId]
AS
SELECT     ce.CalendarEventId, ce.EventId, ce.StartDateTime, ce.EndDateTime, ce.EventType, ce.EventName, ce.EventStatus, ce.TeacherId, ce.InstructorName, 
                      ce.ScheduledHours, ce.DayName, ce.BasePayField, CASE WHEN ce.ProgramId IS NULL THEN p.ProgramId ELSE ce.ProgramId END AS ProgramId, 
                      ce.CourseType, ce.HomeworkMinutes, ce.CourseStatus, ce.CourseName, ce.CourseID
FROM         dbo.vwNewProgramEventsbyTestInitialEventId AS ce LEFT OUTER JOIN
                      dbo.Program AS p ON ce.EventId = p.TestMidtermEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwNewProgramEventsbyTestFinalEventId]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwNewProgramEventsbyTestFinalEventId]
AS
SELECT     ce.CalendarEventId, ce.EventId, ce.StartDateTime, ce.EndDateTime, ce.EventType, ce.EventName, ce.EventStatus, ce.TeacherId, ce.InstructorName, 
                      ce.ScheduledHours, ce.DayName, ce.BasePayField, CASE WHEN ce.ProgramId IS NULL THEN p.ProgramId ELSE ce.ProgramId END AS ProgramId, 
                      ce.CourseType, ce.HomeworkMinutes, ce.CourseStatus, ce.CourseName, ce.CourseID
FROM         dbo.vwNewProgamEventsbyTestMidtermEventId AS ce LEFT OUTER JOIN
                      dbo.Program AS p ON ce.EventId = p.TestFinalEventId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwProgramEvents]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwProgramEvents]
AS
SELECT     dbo.vwNewProgramEventsbyTestFinalEventId.CalendarEventId, dbo.vwNewProgramEventsbyTestFinalEventId.EventId, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.StartDateTime, dbo.vwNewProgramEventsbyTestFinalEventId.EndDateTime, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.EventType, dbo.vwNewProgramEventsbyTestFinalEventId.EventName, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.EventStatus, dbo.vwNewProgramEventsbyTestFinalEventId.TeacherId, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.InstructorName, dbo.vwNewProgramEventsbyTestFinalEventId.ScheduledHours, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.DayName, dbo.vwNewProgramEventsbyTestFinalEventId.BasePayField, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.ProgramId, dbo.vwNewProgramEventsbyTestFinalEventId.CourseType, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.HomeworkMinutes, dbo.vwNewProgramEventsbyTestFinalEventId.CourseStatus, dbo.Program.Name AS ProgramName, 
                      dbo.Program.NickName AS ProgramNickName, dbo.Program.DepartmentId, dbo.Program.ProgramStatus, dbo.vwNewProgramEventsbyTestFinalEventId.CourseName, 
                      dbo.vwNewProgramEventsbyTestFinalEventId.CourseID, dbo.Program.Billing
FROM         dbo.vwNewProgramEventsbyTestFinalEventId LEFT OUTER JOIN
                      dbo.Program ON dbo.vwNewProgramEventsbyTestFinalEventId.ProgramId = dbo.Program.ProgramId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwProgramEventDepartments]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwProgramEventDepartments]
AS
SELECT     dbo.newvwProgramEvents.CalendarEventId, dbo.newvwProgramEvents.EventId, dbo.newvwProgramEvents.StartDateTime, dbo.newvwProgramEvents.EndDateTime, 
                      dbo.newvwProgramEvents.EventType, dbo.newvwProgramEvents.EventName, dbo.newvwProgramEvents.EventStatus, dbo.newvwProgramEvents.TeacherId, 
                      dbo.newvwProgramEvents.InstructorName, dbo.newvwProgramEvents.ScheduledHours, dbo.newvwProgramEvents.DayName, 
                      dbo.newvwProgramEvents.BasePayField, dbo.newvwProgramEvents.ProgramId, dbo.newvwProgramEvents.CourseName, dbo.newvwProgramEvents.CourseType, 
                      dbo.newvwProgramEvents.HomeworkMinutes, dbo.newvwProgramEvents.CourseStatus, dbo.newvwProgramEvents.ProgramName, 
                      dbo.newvwProgramEvents.ProgramNickName, dbo.newvwProgramEvents.DepartmentId, dbo.newvwProgramEvents.ProgramStatus, 
                      dbo.Department.ClientID AS CustomerId, dbo.Contact.CompanyName AS Department, dbo.newvwProgramEvents.Billing
FROM         dbo.newvwProgramEvents LEFT OUTER JOIN
                      dbo.Department ON dbo.newvwProgramEvents.DepartmentId = dbo.Department.DepartmentID LEFT OUTER JOIN
                      dbo.Contact ON dbo.Department.ContactID = dbo.Contact.ContactId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwSubPayDetailsByInstructor]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwSubPayDetailsByInstructor]
AS
SELECT     dbo.newvwProgramEventDepartments.CalendarEventId, dbo.newvwProgramEventDepartments.EventId, dbo.newvwProgramEventDepartments.StartDateTime, 
                      dbo.newvwProgramEventDepartments.EndDateTime, dbo.newvwProgramEventDepartments.EventType, dbo.newvwProgramEventDepartments.EventName, 
                      dbo.newvwProgramEventDepartments.EventStatus, dbo.newvwProgramEventDepartments.TeacherId, dbo.newvwProgramEventDepartments.ScheduledHours, 
                      dbo.newvwProgramEventDepartments.InstructorName, dbo.newvwProgramEventDepartments.DayName, dbo.newvwProgramEventDepartments.ProgramId, 
                      dbo.newvwProgramEventDepartments.BasePayField, dbo.newvwProgramEventDepartments.CourseName, dbo.newvwProgramEventDepartments.CourseType, 
                      CASE WHEN dbo.newvwProgramEventDepartments.HomeworkMinutes IS NULL 
                      THEN 0 ELSE dbo.newvwProgramEventDepartments.HomeworkMinutes END AS HomeworkMinutes, dbo.newvwProgramEventDepartments.CourseStatus, 
                      dbo.newvwProgramEventDepartments.ProgramName, dbo.newvwProgramEventDepartments.ProgramNickName, dbo.newvwProgramEventDepartments.DepartmentId, 
                      dbo.newvwProgramEventDepartments.ProgramStatus, dbo.newvwProgramEventDepartments.CustomerId, dbo.newvwProgramEventDepartments.Department, 
                      dbo.Contact.CompanyName AS CustomerName, dbo.Contact.NickName AS CustomerNickName, CAST(CASE WHEN EventType = ''Test Initial'' OR
                      EventType = ''Test Midterm'' OR
                      EventType = ''Test Final'' THEN ''true'' ELSE CASE WHEN EventType IS NULL THEN NULL ELSE ''False'' END END AS bit) AS IsTest, 
                      dbo.newvwProgramEventDepartments.Billing
FROM         dbo.Contact RIGHT OUTER JOIN
                      dbo.newvwProgramEventDepartments ON dbo.Contact.ContactId = dbo.newvwProgramEventDepartments.CustomerId
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewInstructorPaymentDetails]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewInstructorPaymentDetails]
AS
SELECT     CalendarEventId, TeacherId, InstructorName, StartDateTime, EndDateTime, CASE WHEN CustomerName IS NULL THEN '''' ELSE CustomerName END AS ClientName, 
                      CASE WHEN CustomerNickName IS NULL THEN '''' ELSE CustomerNickName END AS ClientNickName, CASE WHEN ProgramName IS NULL 
                      THEN '''' ELSE ProgramName END AS ProgramName, CASE WHEN CourseName IS NULL THEN '''' ELSE CourseName END AS Class, CASE WHEN CourseType IS NULL 
                      THEN '''' ELSE CourseType END AS JobType, DayName, ScheduledHours, 
                      CASE WHEN IsTest = ''True'' THEN ScheduledHours ELSE CAST(CAST(HomeworkMinutes AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) 
                      + ScheduledHours END AS PaidHours, CAST(CAST(HomeworkMinutes AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS HomeworkMinutes, Billing
FROM         dbo.newvwSubPayDetailsByInstructor AS subPayments
' 

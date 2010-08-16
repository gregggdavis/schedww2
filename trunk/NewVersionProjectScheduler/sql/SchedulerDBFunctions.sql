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
	@DayName as nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0
	select @minutes = CASE WHEN @DayName = ''Saturday'' OR @DayName = ''Sunday'' OR
                      @IsHoliday = 1 THEN DATEDIFF(mi, @StartDateTime, @EndDateTime) 
                      ELSE 0.00 END 
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
	select @minutes = CASE WHEN @DayName <> ''Saturday'' AND @DayName <> ''Sunday'' AND @IsHoliday <> 1 AND @StartDateTime <= dbo.GetTime(@StartDateTime, 
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

	select @minutes = CASE When @IsHoliday<>1 AND @DayName <> ''Saturday'' AND @DayName <> ''Sunday'' AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
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
	@DayName as nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @minutes int
	SET @minutes = 0
	select @minutes = CASE When @IsHoliday<>1 AND @DayName <> ''Saturday'' AND @DayName <> ''Sunday'' AND @StartDateTime <= dbo.GetTime(@StartDateTime,''5:00PM'')THEN 
	CASE When @StartDateTime > dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime <= dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
	DateDiff(mi,@StartDateTime,@EndDateTime)
	Else CASE When @StartDateTime > dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN 
	DateDiff(mi,@StartDateTime,dbo.GetTime(@EndDateTime,''5:00PM'')) 
	ELSE CASE WHEN @StartDateTime <= dbo.GetTime(@StartDateTime,''8:29AM'')
	AND @EndDateTime <= dbo.GetTime(@EndDateTime,''5:00PM'') AND @EndDateTime >= dbo.GetTime(@EndDateTime,''11:00AM'') THEN DateDiff(mi,dbo.GetTime(@StartDateTime,''11:00AM''),@EndDateTime) 
	ELSE CASE When @StartDateTime <= dbo.GetTime(@StartDateTime,''8:29AM'') AND @EndDateTime > dbo.GetTime(@EndDateTime,''5:00PM'') THEN
	DateDiff(mi,dbo.GetTime(@StartDateTime,''11:00AM''),dbo.GetTime(@EndDateTime,''5:00PM''))
	END END END END ELSE 0.00 END
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


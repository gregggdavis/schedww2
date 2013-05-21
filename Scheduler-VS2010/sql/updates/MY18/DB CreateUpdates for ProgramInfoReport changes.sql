IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewProgramReportClassDetails]'))
DROP VIEW [dbo].[viewProgramReportClassDetails]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewProgramReportHelper]'))
DROP VIEW [dbo].[viewProgramReportHelper]
GO

-- ---------------------------

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


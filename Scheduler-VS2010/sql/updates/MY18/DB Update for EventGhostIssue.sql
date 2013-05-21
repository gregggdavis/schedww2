IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCalendarEventInstructors]'))
DROP VIEW [dbo].[newvwCalendarEventInstructors]
GO

-- ---------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[newvwCalendarEventInstructors]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[newvwCalendarEventInstructors]
AS
SELECT dbo.newvwCalendarEvents.CalendarEventId, dbo.newvwCalendarEvents.EventId, dbo.newvwCalendarEvents.StartDateTime, 
               dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.EventType, dbo.newvwCalendarEvents.EventName, 
               dbo.newvwCalendarEvents.ScheduledTeacherId, dbo.newvwCalendarEvents.RealTeacherId, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.EventStatus, dbo.newvwCalendarEvents.TeacherId, CAST(dbo.newvwCalendarEvents.EventMinutes AS Decimal(18, 2)) 
               AS EventMinutes, CAST(CAST(dbo.newvwCalendarEvents.EventMinutes AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS ScheduledHours, 
               dbo.newvwCalendarEvents.DayName, dbo.Contact.LastName + N', ' + dbo.Contact.FirstName AS InstructorName, dbo.Contact.BasePayField, 
               CAST(CAST(dbo.GetSaturdayMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, 
               dbo.newvwCalendarEvents.IsHoliday, dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS SaturdayMinutes, 
               CAST(CAST(dbo.GetMorningMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS MorningMinutes, 
               CAST(CAST(dbo.GetEveningMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS EveningMinutes, 
               CAST(CAST(dbo.GetDaytimeMinutes(dbo.newvwCalendarEvents.StartDateTime, dbo.newvwCalendarEvents.EndDateTime, dbo.newvwCalendarEvents.IsHoliday, 
               dbo.newvwCalendarEvents.DayName) AS Decimal(18, 2)) / 60 AS Decimal(18, 2)) AS DaytimeMinutes
FROM  dbo.newvwCalendarEvents INNER JOIN
               dbo.Contact ON dbo.newvwCalendarEvents.TeacherId = dbo.Contact.ContactId INNER JOIN
               dbo.Course ON dbo.newvwCalendarEvents.EventId = dbo.Course.EventId
' 
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO










-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetPayrollByInstructor]
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
	FROM (SELECT     TeacherID, InstructorName, SUM(DaytimeMinutes) AS TotalHours, CAST(1.0 AS Decimal(18, 2)) AS HourlyRate, '1-Daytime' AS DayType
	FROM         
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1
	WHERE     (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
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
    '2-Saturday' AS DayType
	FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) as ViewTemp
    WHERE     (DayName = 'Sat') OR (DayName = 'Sun') OR (IsHoliday = 1)
    GROUP BY TeacherID, InstructorName) AS SaturdayTB
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------

	-- Morning Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(MorningMinutes) AS TotalHours, CAST(1.1 AS Decimal(18, 2)) AS HourlyRate, '3-Morning' AS DayType
    FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1 
	WHERE (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS MorningTB

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	
	-- Evening Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(EveningMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, '4-Evening' AS DayType
    FROM  
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,MorningMinutes,SaturdayMinutes,EveningMinutes,DaytimeMinutes
		EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors Where (StartDateTime >= @StartDateTime AND StartDateTime <= @EndDateTime)
	) AS viewInstructorPaymentDetails_1
    WHERE     (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
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
	FROM (SELECT     TeacherID, InstructorName, SUM(DaytimeMinutes) AS TotalHours, CAST(1.0 AS Decimal(18, 2)) AS HourlyRate, '1-Daytime' AS DayType
	FROM         
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1
	WHERE     (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
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
    '2-Saturday' AS DayType
	FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday,DaytimeMinutes
		FROM newvwCalendarEventInstructors
	) as ViewTemp
    WHERE     (ViewTemp.DayName = 'Sat') OR (ViewTemp.DayName = 'Sun') OR (ViewTemp.IsHoliday = 1)
    GROUP BY TeacherID, InstructorName) AS SaturdayTB
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------

	-- Morning Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(MorningMinutes) AS TotalHours, CAST(1.1 AS Decimal(18, 2)) AS HourlyRate, '3-Morning' AS DayType
    FROM 
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1 
	WHERE (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS MorningTB

	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	UNION
	-----------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------
	
	-- Evening Record
	SELECT TeacherID, InstructorName, TotalHours, HourlyRate, DayType
	FROM (SELECT TeacherID, InstructorName, SUM(EveningMinutes) AS TotalHours, CAST(1.2 AS Decimal(18, 2)) AS HourlyRate, '4-Evening' AS DayType
    FROM  
	(
		Select TeacherID,InstructorName,StartDateTime,EndDateTime,DayName,SaturdayMinutes,MorningMinutes,
		EveningMinutes,EventMinutes,IsHoliday
		FROM newvwCalendarEventInstructors
	) AS viewInstructorPaymentDetails_1
    WHERE     (DayName <> 'Sat') AND (DayName <> 'Sun') AND (IsHoliday <> 1)
    GROUP BY TeacherID, InstructorName) AS EveningTB
		

	
	) as tviewsubPayrollByInstructor
	INNER JOIN dbo.Contact ON tviewsubPayrollByInstructor.TeacherID = dbo.Contact.ContactId
	END
END


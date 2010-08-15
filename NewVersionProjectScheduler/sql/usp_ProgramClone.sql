set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_ProgramClone]
	@ProgramID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @name nvarchar(1000)
	
	Select @name = Name from [Program] Where ProgramID = @programID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Program] WHERE [Name] like 'Copy of ' + @name + '%'

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
		'Copy of ' + [Name] + ' ' + CAST(@numberMatched as varchar),
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

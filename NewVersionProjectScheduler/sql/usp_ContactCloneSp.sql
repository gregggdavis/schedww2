USE [SchedulerDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_ContactClone]    Script Date: 08/09/2010 21:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ContactClone]
	@ContactID int,
	@creatorID int,
	@insertedID int OUTPUT
AS
BEGIN
	DECLARE @numberMatched int	
	DECLARE @contactType int
	DECLARE @fullname nvarchar(1000)
	
	Select @fullname = LastName + '%' + FirstName, @contactType = ContactType  from [Contact] Where ContactID = @ContactID
	
	SELECT @numberMatched = COUNT(*) + 1 FROM [Contact] WHERE LastName + FirstName like 'Copy of ' + @fullname  and ContactType = @ContactType
	
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
			'Copy of ' + LastName+ ' ' + CAST(@numberMatched as varchar),
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
END
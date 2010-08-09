set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetContactInfoByContactID]
	@ContactID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Phone1,Phone2,PhoneOther,Url,PhoneFax1,PhoneFax2,AccountRepLastName,AccountRepLastNamePhonetic,AccountRepLastNameRomaji,AccountRepFirstName,AccountRepFirstNamePhonetic,AccountRepFirstNameRomaji,Street1,Street2,Street3,City,[State],PostalCode,Country,BlockCode,ClosestStation1,ClosestLine1,MinutesToStation1,ClosestStation2,ClosestLine2,MinutesToStation2,BlockCode from Contact where ContactID = @ContactID
END



IF OBJECT_ID('[dbo].[SelectEventsById]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectEventsById]
END
GO

CREATE PROCEDURE [dbo].[SelectEventsById]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        EV.Id AS EventId,
		EV.UserOwnerId,
        EV.EventName,
        EV.StartDate,
        EV.EndDate,
        EV.EventShortDescription,
        EV.EventDescription,
        EV.TicketsLimit,
        US.UserName AS EventOwnerName,
        US.Email AS EventOwnerEmail,
		AD.PublicPlaceId,
		PP.PlaceName AS PublicPlaceName,
        AD.Id AS AdressId,
		AD.PlaceName,
        AD.City,
        AD.UF,
        AD.CEP,
        AD.Neighborhood,
        AD.AdressComplement,
        AD.AdressNumber
    FROM
        [dbo].[Event] EV

    INNER JOIN
        [dbo].[User] US
    ON
        EV.UserOwnerId = US.Id

    INNER JOIN
        [dbo].[Adress] AD
    ON
        EV.AdressId = AD.Id
	
	INNER JOIN
		[dbo].[PublicPlace] PP
	ON AD.PublicPlaceId = PP.Id

    WHERE
        EV.Id = @Id
END
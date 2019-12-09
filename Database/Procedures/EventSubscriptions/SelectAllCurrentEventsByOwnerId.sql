IF OBJECT_ID('[dbo].[SelectAllCurrentEventsByOwnerId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllCurrentEventsByOwnerId]
END
GO

CREATE PROCEDURE [dbo].[SelectAllCurrentEventsByOwnerId]
    @UserOwnerId INT
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

    WHERE
        EV.ActiveEvent = 1
	AND EV.EndDate > GETDATE()
	AND US	.Id = @UserOwnerId
    
    ORDER BY
		EV.StartDate DESC
END
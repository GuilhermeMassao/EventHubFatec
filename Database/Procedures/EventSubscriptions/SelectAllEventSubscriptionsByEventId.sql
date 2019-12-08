IF OBJECT_ID('[dbo].[SelectAllEventSubscriptionsByEventId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllEventSubscriptionsByEventId]
END
GO

CREATE PROCEDURE [dbo].[SelectAllEventSubscriptionsByEventId]
    @EventId INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        U.Id,
		U.UserName,
		U.Email
    FROM
        [dbo].[EventSubscriptions] ES
	
	INNER JOIN
		[dbo].[User] U
	ON
		ES.UserId = U.Id
	
	WHERE
		ES.EventId = @EventId
END
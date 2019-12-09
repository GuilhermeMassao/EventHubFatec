IF OBJECT_ID('[dbo].[DeleteInscriptionByUserId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[DeleteInscriptionByUserId]
END
GO

CREATE PROCEDURE [dbo].[DeleteInscriptionByUserId]
    @UserId INT,
	@EventId INT
AS

SET NOCOUNT ON

BEGIN
    DELETE
        [dbo].[EventSubscriptions]
    WHERE
        UserId = @UserId
	AND EventId = @EventId
END
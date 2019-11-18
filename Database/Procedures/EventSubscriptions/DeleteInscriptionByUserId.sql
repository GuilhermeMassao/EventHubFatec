IF OBJECT_ID('[dbo].[DeleteInscriptionByUserId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[DeleteInscriptionByUserId]
END
GO

CREATE PROCEDURE [dbo].[DeleteInscriptionByUserId]
    @UserId INT
AS

SET NOCOUNT ON

BEGIN
    DELETE
        [dbo].[EventSubscriptions]
    WHERE
        UserId = @UserId
END
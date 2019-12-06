IF OBJECT_ID('[dbo].[UpdateUserGoogleToken]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateUserGoogleToken]
END
GO

CREATE PROCEDURE [dbo].[UpdateUserGoogleToken]
    @Id INT,
    @GoogleRefreshToken VARCHAR(200)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        GoogleRefreshToken = @GoogleRefreshToken
    WHERE
        Id = @Id
END
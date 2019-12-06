IF OBJECT_ID('[dbo].[UpdateUserTwitterToken]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateUserTwitterToken]
END
GO

CREATE PROCEDURE [dbo].[UpdateUserTwitterToken]
    @Id INT,
    @TwitterAccessToken VARCHAR(200),
    @TwitterAccessTokenSecret VARCHAR(100)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        TwitterAccessToken = @TwitterAccessToken,
        TwitterAccessTokenSecret = @TwitterAccessTokenSecret
    WHERE
        Id = @Id
END
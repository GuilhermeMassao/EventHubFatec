IF OBJECT_ID('[dbo].[UpdateUserTwitterToken]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateUserTwitterToken]
END
GO

CREATE PROCEDURE [dbo].[UpdateUserTwitterToken]
    @Id INT,
    @TwitterAcessToken VARCHAR(200),
    @TwitterAcessTokenSecret VARCHAR(100)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        TwitterAcessToken = @TwitterAcessToken,
        TwitterAcessTokenSecret = @TwitterAcessTokenSecret
    WHERE
        Id = @Id
END
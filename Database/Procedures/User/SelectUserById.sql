IF OBJECT_ID('[dbo].[SelectUserById]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectUserById]
END
GO

CREATE PROCEDURE [dbo].[SelectUserById]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        UserName,
        Email,
        UserPassword
    FROM
        [dbo].[User]
    WHERE
        Id = @Id
	AND ActiveUser = 1;
END
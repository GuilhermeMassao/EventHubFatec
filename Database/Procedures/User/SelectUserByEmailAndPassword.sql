IF OBJECT_ID('[dbo].[SelectUserByEmailAndPassword]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectUserByEmailAndPassword]
END
GO

CREATE PROCEDURE [dbo].[SelectUserByEmailAndPassword]
    @Email VARCHAR(50),
    @UserPassword VARCHAR(15)
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        UserName,
        Email
    FROM
        [dbo].[User]
    WHERE
        Email = @Email
    AND UserPassword = @UserPassword
END
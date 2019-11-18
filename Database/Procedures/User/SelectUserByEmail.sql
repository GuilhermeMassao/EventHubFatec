IF OBJECT_ID('[dbo].[SelectUserByEmail]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectUserByEmail]
END
GO

CREATE PROCEDURE [dbo].[SelectUserByEmail]
    @Email VARCHAR(50)
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        UserName,
        Email
    FROM
        [dbo].[User]
    WHERE
        Email = @Email
END
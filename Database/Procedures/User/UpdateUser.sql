IF OBJECT_ID('[dbo].[UpdateUser]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateUser]
END
GO

CREATE PROCEDURE [dbo].[UpdateUser]
    @Id INT,
    @UserName VARCHAR(50),
    @Email VARCHAR(50),
    @UserPassword VARCHAR(15)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        UserName = @UserName,
        Email = @Email,
        UserPassword = @UserPassword
    WHERE
        Id = @Id
END
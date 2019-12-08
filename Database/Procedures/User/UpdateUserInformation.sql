IF OBJECT_ID('[dbo].[UpdateUserInformation]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateUserInformation]
END
GO

CREATE PROCEDURE [dbo].[UpdateUserInformation]
    @Id INT,
    @UserName VARCHAR(50),
    @Email VARCHAR(50)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        UserName = @UserName,
        Email = @Email
    WHERE
        Id = @Id
END
IF OBJECT_ID('[dbo].[InsertUser]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertUser]
END
GO

CREATE PROCEDURE [dbo].[InsertUser]
    @UserName VARCHAR(50),
    @Email VARCHAR(50),
    @UserPassword VARCHAR(15)
AS

SET NOCOUNT ON

BEGIN
    DECLARE @UserId INT;

    INSERT INTO [dbo].[User](
        UserName,
        Email,
        UserPassword
    )
    VALUES(
        @UserName, 
        @Email,
        @UserPassword
    )

    SELECT @UserId = SCOPE_IDENTITY();
    SELECT @UserId AS UserId
END
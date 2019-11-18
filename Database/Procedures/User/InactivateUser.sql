IF OBJECT_ID('[dbo].[InactivateUser]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InactivateUser]
END
GO

CREATE PROCEDURE [dbo].[InactivateUser]
    @Id INT
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        ActiveUser = 0
    WHERE
        Id = @Id
END
IF OBJECT_ID('[dbo].[InactivateAdress]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InactivateAdress]
END
GO

CREATE PROCEDURE [dbo].[InactivateAdress]
    @Id INT
AS

SET NOCOUNT ON

BEGIN
    UPDATE
        [dbo].[Adress]
    SET
        ActiveAdress = 0
    WHERE
        Id = @Id
END
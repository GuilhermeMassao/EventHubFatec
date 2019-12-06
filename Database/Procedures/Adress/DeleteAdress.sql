IF OBJECT_ID('[dbo].[DeleteAdress]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[DeleteAdress]
END
GO

CREATE PROCEDURE [dbo].[DeleteAdress]
    @Id INT
AS

SET NOCOUNT ON

BEGIN
    DELETE FROM
        [dbo].[Adress]
    WHERE
        Id = @Id
END
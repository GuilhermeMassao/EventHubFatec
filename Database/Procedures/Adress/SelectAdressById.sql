IF OBJECT_ID('[dbo].[SelectAdressById]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAdressById]
END
GO

CREATE PROCEDURE [dbo].[SelectAdressById]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        PP.PlaceName,
        AD.City,
        AD.UF,
        AD.CEP,
        AD.Neighborhood,
        AD.AdressComplement,
        AD.AdressNumber
    FROM
        [dbo].[Adress] AD

    INNER JOIN
        [dbo].[PublicPlace] PP
    ON
        AD.PublicPlaceId = PP.Id

    WHERE
        AD.Id = @Id
END
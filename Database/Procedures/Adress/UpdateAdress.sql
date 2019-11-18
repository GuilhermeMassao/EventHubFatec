IF OBJECT_ID('[dbo].[UpdateAdress]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateAdress]
END
GO

CREATE PROCEDURE [dbo].[UpdateAdress]
    @Id INT,
    @PublicPlaceId INT,
    @City VARCHAR(50),
    @UF VARCHAR(2),
    @CEP VARCHAR(10),
    @Neighborhood VARCHAR(50),
    @AdressComplement VARCHAR(50),
    @AdressNumber VARCHAR(5)
AS

SET NOCOUNT ON

BEGIN
    UPDATE
        [dbo].[Adress]
    SET
        PublicPlaceId = @PublicPlaceId,
        City = @City,
        UF = @UF,
        CEP = @CEP,
        Neighborhood = @Neighborhood,
        AdressComplement = @AdressComplement,
        AdressNumber = @AdressNumber
    WHERE
        Id = @Id
END
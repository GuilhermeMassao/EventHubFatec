IF OBJECT_ID('[dbo].[InsertAdress]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertAdress]
END
GO

CREATE PROCEDURE [dbo].[InsertAdress]
    @PublicPlaceId INT,
	@PlaceName VARCHAR(100),
    @City VARCHAR(50),
    @UF VARCHAR(2),
    @CEP VARCHAR(10),
    @Neighborhood VARCHAR(50),
    @AdressComplement VARCHAR(50),
    @AdressNumber VARCHAR(5)
AS

SET NOCOUNT ON

BEGIN
    DECLARE @AdressId INT;

    INSERT INTO [dbo].[Adress](
        PublicPlaceId,
		PlaceName,
        City,
        UF,
        CEP,
        Neighborhood,
        AdressComplement,
        AdressNumber
    )

    VALUES(
        @PublicPlaceId,
		@PlaceName,
        @City,
        @UF,
        @CEP,
        @Neighborhood,
        @AdressComplement,
        @AdressNumber
    )

    SELECT @AdressId = SCOPE_IDENTITY();
    SELECT @AdressId AS AdressId
END
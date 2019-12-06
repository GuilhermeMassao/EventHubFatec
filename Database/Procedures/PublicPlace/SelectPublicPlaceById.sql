IF OBJECT_ID('[dbo].[SelectPublicPlaceById]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectPublicPlaceById]
END
GO

CREATE PROCEDURE [dbo].[SelectPublicPlaceById]
	@Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        PlaceName
    FROM
        [dbo].[PublicPlace]
    WHERE
		Id = @Id
END
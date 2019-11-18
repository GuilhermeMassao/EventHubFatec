IF OBJECT_ID('[dbo].[SelectAllPublicPlaces]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllPublicPlaces]
END
GO

CREATE PROCEDURE [dbo].[SelectAllPublicPlaces]
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        PlaceName
    FROM
        [dbo].[PublicPlace]
    ORDER BY
        PlaceName ASC
END
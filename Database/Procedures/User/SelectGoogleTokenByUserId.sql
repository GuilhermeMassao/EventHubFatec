IF OBJECT_ID('[dbo].[SelectGoogleTokenByUserId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectGoogleTokenByUserId]
END
GO

CREATE PROCEDURE [dbo].[SelectGoogleTokenByUserId]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        GoogleRefreshToken
    FROM
        [dbo].[User]
    WHERE
        Id = @Id
END
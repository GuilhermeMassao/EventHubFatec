IF OBJECT_ID('[dbo].[SelectTwitterTokensByUserId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectTwitterTokensByUserId]
END
GO

CREATE PROCEDURE [dbo].[SelectTwitterTokensByUserId]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        TwitterAcessTokenSecret,
        TwitterAcessToken
    FROM
        [dbo].[User]
    WHERE
        Id = @Id
END
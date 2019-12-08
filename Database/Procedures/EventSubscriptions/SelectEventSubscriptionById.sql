IF OBJECT_ID('[dbo].[SelectEventSubscriptionById]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectEventSubscriptionById]
END
GO

CREATE PROCEDURE [dbo].[SelectEventSubscriptionById]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        UserId,
		EventId
    FROM
        [dbo].[EventSubscriptions]
    WHERE
        Id = @Id
END
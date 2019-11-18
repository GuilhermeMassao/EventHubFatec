IF OBJECT_ID('[dbo].[CancelEvent]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[CancelEvent]
END
GO

CREATE PROCEDURE [dbo].[CancelEvent]
    @Id INT
AS

SET NOCOUNT ON

BEGIN
    DECLARE @AdressId INT;

    SELECT @AdressId = (
        SELECT
            AdressId
        FROM
            [dbo].[Event]
        WHERE
            Id = @Id
    )

    EXEC InactivateAdress @Id = @AdressId

    UPDATE
        [dbo].[Event]
    SET
        ActiveEvent = 0
    WHERE
        Id = @Id
END
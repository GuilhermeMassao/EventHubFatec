IF OBJECT_ID('[dbo].[InsertInscription]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertInscription]
END
GO

CREATE PROCEDURE [dbo].[InsertInscription]
    @UserId INT,
    @EventId INT
AS

SET NOCOUNT ON

BEGIN
    INSERT INTO [dbo].[EventSubscriptions](
        UserId,
        EventId
    )
    VALUES(
        @UserId,
        @EventId
    )
END
IF OBJECT_ID('[dbo].[InsertEvent]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertEvent]
END
GO

CREATE PROCEDURE [dbo].[InsertEvent]
    @UserOwnerId INT,
    @AdressId INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @EventName VARCHAR(80),
    @EventShortDescription VARCHAR(50),
    @EventDescription VARCHAR(1000),
    @TicketsLimit INT
AS

SET NOCOUNT ON

BEGIN
    DECLARE @EventId INT;

    INSERT INTO [dbo].[Event](
        UserOwnerId,
        AdressId,
        StartDate,
        EndDate,
        EventName,
        EventShortDescription,
        EventDescription,
        TicketsLimit
    )
    VALUES(
        @UserOwnerId,
        @AdressId,
        @StartDate,
        @EndDate,
        @EventName,
        @EventShortDescription,
        @EventDescription,
        @TicketsLimit
    )

    SELECT @EventId = SCOPE_IDENTITY();
    SELECT @EventId AS EventId
END
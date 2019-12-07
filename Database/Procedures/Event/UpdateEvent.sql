IF OBJECT_ID('[dbo].[UpdateEvent]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[UpdateEvent]
END
GO

CREATE PROCEDURE [dbo].[UpdateEvent]
    @Id INT,
    @UserOwnerId INT,
    @AdressId INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @EventName VARCHAR(80),
    @EventShortDescription VARCHAR(150),
    @EventDescription VARCHAR(1000),
    @TicketsLimit INT
AS

SET NOCOUNT ON

BEGIN
    UPDATE
        [dbo].[Event]
    SET
        UserOwnerId = @UserOwnerId,
        AdressId = @AdressId,
        StartDate = @StartDate,
        EndDate = @EndDate,
        EventName = @EventName,
        EventShortDescription = @EventShortDescription,
        EventDescription = @EventDescription,
        TicketsLimit = @TicketsLimit
    WHERE
        Id = @Id
END
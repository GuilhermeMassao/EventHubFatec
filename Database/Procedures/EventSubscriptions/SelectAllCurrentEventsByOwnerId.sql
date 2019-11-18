IF OBJECT_ID('[dbo].[SelectAllCurrentEventsByOwnerId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllCurrentEventsByOwnerId]
END
GO

CREATE PROCEDURE [dbo].[SelectAllCurrentEventsByOwnerId]
    @UserOwnerId INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        StartDate,
        EndDate,
        EventName,
        EventShortDescription,
        TicketsLimit
    FROM
        [dbo].[Event]
    WHERE
        UserOwnerId = @UserOwnerId
    AND EndDate > GETDATE()
    AND ActiveEvent = 1
    
    ORDER BY
        StartDate DESC
END
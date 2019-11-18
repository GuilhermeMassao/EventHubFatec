IF OBJECT_ID('[dbo].[SelectAllEvents]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllEvents]
END
GO

CREATE PROCEDURE [dbo].[SelectAllEvents]
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        Id,
        StartDate,
        EndDate,
        EventName,
        EventShortDescription
    FROM
        [dbo].[Event]
    WHERE
        EndDate > GETDATE()
    AND ActiveEvent = 1
    ORDER BY
        StartDate DESC
END
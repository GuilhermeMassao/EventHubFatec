USE [EventHub]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllEvents]    Script Date: 08/12/2019 01:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SelectAllEvents]
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
		ev.UserOwnerId as UserOwnerId,
        ev.Id as Id,
        ev.EventName as EventName,
        ev.StartDate as StartDate,
        ev.EndDate as EndDate,
        ev.EventDescription as EventDescription,
		ev.EventShortDescription as EventShortDescription
    FROM
        [dbo].[Event] ev
    WHERE
        ActiveEvent = 1
    ORDER BY
        StartDate DESC
END
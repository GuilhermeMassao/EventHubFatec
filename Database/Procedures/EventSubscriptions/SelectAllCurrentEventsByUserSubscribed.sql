IF OBJECT_ID('[dbo].[SelectAllCurrentEventsByUserSubscribed]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectAllCurrentEventsByUserSubscribed]
END
GO

CREATE PROCEDURE [dbo].[SelectAllCurrentEventsByUserSubscribed]
    @UserId INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    IF OBJECT_ID('TEMPDB..#UserSubscriptions') IS NOT NULL
        DROP TABLE #UserSubscriptions
        
    -------------------------------------------------------
    -- Armazena todas as incrições de eventos do usuário --
    -------------------------------------------------------
    CREATE TABLE #UserSubscriptions(
        EventId INT
    )

    INSERT INTO #UserSubscriptions(
        EventId
    )
    SELECT
        EventId
    FROM
        [dbo].[EventSubscriptions]
    WHERE
        UserId = @UserId

    -----------------------------------------------------------
    -- Retorna dos dados dos enventos inscritos pelo usuário --
    -----------------------------------------------------------
    SELECT
        EV.Id,
        EV.StartDate,
        EV.EndDate,
        EV.EventName,
        EV.EventShortDescription,
        EV.TicketsLimit
    FROM
        [dbo].[Event] EV

    INNER JOIN
        #UserSubscriptions US
    ON
        EV.Id = US.EventId

    WHERE
        EV.EndDate > GETDATE()
    AND ActiveEvent = 1
        
    ORDER BY
        EV.StartDate DESC

    IF OBJECT_ID('TEMPDB..#UserSubscriptions') IS NOT NULL
        DROP TABLE #UserSubscriptions
END
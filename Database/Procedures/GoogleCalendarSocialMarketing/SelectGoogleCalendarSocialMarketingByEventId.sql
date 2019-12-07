IF OBJECT_ID('[dbo].[SelectGoogleCalendarSocialMarketingByEventId]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SelectGoogleCalendarSocialMarketingByEventId]
END
GO

CREATE PROCEDURE [dbo].[SelectGoogleCalendarSocialMarketingByEventId]
	@Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        EventId,
        HashCalendar,
		HashEvent,
        CalendarLink
    FROM
        [dbo].[GoogleCalendarSocialMarketing]
    WHERE
		Id = @Id
END
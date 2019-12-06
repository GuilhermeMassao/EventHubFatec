IF OBJECT_ID('[dbo].[InsertGoogleCalendarSocialMarketing]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertGoogleCalendarSocialMarketing]
END
GO

CREATE PROCEDURE [dbo].[InsertGoogleCalendarSocialMarketing]
	@EventId INT,
    @HashCalendar VARCHAR(50),
    @CalendarLink VARCHAR(100)
AS

SET NOCOUNT ON

BEGIN
    DECLARE @GoogleSocialMarketingId INT;

    INSERT INTO [dbo].[GoogleCalendarSocialMarketing](
        EventId,
        HashCalendar,
        CalendarLink
    )
    VALUES(
        @EventId,
        @HashCalendar,
        @CalendarLink
    )

    SELECT @GoogleSocialMarketingId = SCOPE_IDENTITY();
    SELECT @GoogleSocialMarketingId AS GoogleSocialMarketingId
END
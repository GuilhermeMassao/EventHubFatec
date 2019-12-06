IF OBJECT_ID('[dbo].[InsertTwitterSocialMarketing]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[InsertTwitterSocialMarketing]
END
GO

CREATE PROCEDURE [dbo].[InsertTwitterSocialMarketing]
	@EventId INT,
    @TweetId VARCHAR(30),
    @ShortUrlTweet VARCHAR(100)
AS

SET NOCOUNT ON

BEGIN
    DECLARE @TwitterSocialMarketingId INT;

    INSERT INTO [dbo].[TwitterSocialMarketing](
        EventId,
        TweetId,
        ShortUrlTweet
    )
    VALUES(
        @EventId,
        @TweetId,
        @ShortUrlTweet
    )

    SELECT @TwitterSocialMarketingId = SCOPE_IDENTITY();
    SELECT @TwitterSocialMarketingId AS TwitterSocialMarketingId
END
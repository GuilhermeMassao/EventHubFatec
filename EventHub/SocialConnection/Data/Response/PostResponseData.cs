using System;

namespace SocialConnection.Data.Response
{
    public class PostResponseData
    {
        public long Id { get; set; }
        public string GoogleId { get; set; }
        public string ShortUrlTweet { get; set; }
        public string ShortUrlGoogle { get; set; }

        public PostResponseData(long id, string shortUrlTweet)
        {
            Id = id;
            ShortUrlTweet = shortUrlTweet;
        }

        public PostResponseData(string googleId, string shortUrlGoogle)
        {
            GoogleId = googleId;
            ShortUrlGoogle = shortUrlGoogle;
        }
    }
}
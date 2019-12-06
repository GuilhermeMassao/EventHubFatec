using System;

namespace SocialConnection.Data.Response
{
    public class PostResponseData
    {
        public long Id { get; set; }
        public string ShortUrlTweet { get; set; }

        public PostResponseData(long id, string shortUrlTweet)
        {
            Id = id;
            ShortUrlTweet = shortUrlTweet;
        }
    }
}
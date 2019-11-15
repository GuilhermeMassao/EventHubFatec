using System;
namespace EventHub.Domain.Entities
{
    public class TwitterSocialMarketing
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string TweetId { get; set; }
        public string ShortUrlTweet { get; set; }
    }
}

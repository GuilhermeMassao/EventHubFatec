using SocialConnection.Models;

namespace SocialConnection.Data.Request
{
    public class TwitterPostContentData : BasePostContentRequestData
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Text { get; set; }
        public TweetMedia[] Medias { get; set; }

        public TwitterPostContentData(string accessToken, string appId, string appSecret, string accessTokenSecret, string text, TweetMedia[] medias)
            : base(accessToken)
        {
            AppId = appId;
            AppSecret = appSecret;
            AccessTokenSecret = accessTokenSecret;
            Text = text;
            Medias = medias;
        }
    }
}
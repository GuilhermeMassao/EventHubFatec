using SocialConnection.Models;

namespace SocialConnection.Data.Request
{
    public class PostContentRequestData
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Text { get; set; }
        public TweetMedia[] Medias { get; set; }

        public PostContentRequestData(string appId, string appSecret, string accessToken, string accessTokenSecret, string text, TweetMedia[] medias)
        {
            AppId = appId;
            AppSecret = appSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            Text = text;
            Medias = medias;
        }
    }
}

using SocialConnection.Models;

namespace EventHubApi.SocialTestApi.Models
{
    public class TwitterPostRequestBody
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Text { get; set; }
        public TweetMedia[] Medias { get; set; }

        public TwitterPostRequestBody(string accessToken, string accessTokenSecret, string text, TweetMedia[] medias)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            Text = text;
            Medias = medias;
        }
    }
}
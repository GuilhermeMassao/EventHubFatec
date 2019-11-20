namespace SocialConnection.Data.Request
{
    public class OAuth1AuthorizationData
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public OAuth1AuthorizationData(string appId, string appSecret, string accessToken, string accessTokenSecret)
        {
            AppId = appId;
            AppSecret = appSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}
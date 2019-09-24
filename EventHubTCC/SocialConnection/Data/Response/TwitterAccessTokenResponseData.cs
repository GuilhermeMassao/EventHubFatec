namespace SocialConnection.Data.Response
{
    public class TwitterAccessTokenResponseData : OAuth1AccessTokenResponseData
    {
        public string UserId { get; set; }
        public string UserScreenName { get; set; }

        public TwitterAccessTokenResponseData(string accessToken, string accessTokenSecret, string userId, string userScreenName) : base(accessToken, accessTokenSecret)
        {
            UserId = userId;
            UserScreenName = userScreenName;
        }
    }
}
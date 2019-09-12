namespace EventHubApi.Data
{
    public class TwitterPostContentData
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Text { get; set; }

        public TwitterPostContentData(string accessToken, string accessTokenSecret, string text)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            Text = text;
        }
    }
}
namespace SocialConnection.Data.Response
{
    public class RequestTokenResponseData
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public bool OAuthCallbackConfirmed { get; set; }
        
        public RequestTokenResponseData(string token, string tokenSecret, bool oAuthCallbackConfirmed)
        {
            Token = token;
            TokenSecret = tokenSecret;
            OAuthCallbackConfirmed = oAuthCallbackConfirmed;
        }
    }
}
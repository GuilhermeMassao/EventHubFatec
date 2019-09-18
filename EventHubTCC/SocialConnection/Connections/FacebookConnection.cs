using RestSharp;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections
{
    public class FacebookConnection : IOAuth2Connection<OAuth2AccessTokenResponseData>
    {
        private const string ApiUrl = "https://graph.facebook.com";
        private const string FacebookUrl = "https://www.facebook.com/v4.0";

        public string GetAuthenticationUri(string appId, string redirectUri)
        {
            var client = new RestClient(FacebookUrl);
            var request = new RestRequest(GetAuthenticationEndPoint(appId, redirectUri));

            return client.BuildUri(request).ToString();
        }

        public OAuth2AccessTokenResponseData GetAccessToken(string appId, string appSecret, string code, string redirectUri)
        {
            var client = new RestClient(ApiUrl);
            var request = new RestRequest(GetAccessEndPoint(appId, appSecret, code, redirectUri));

            // TODO implementar
            return null;
        }

        public OAuth2AccessTokenResponseData RefreshAccessToken(string appId, string appSecret, string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public PostResponseData Post(PostContentRequestData contentRequestData)
        {
            // TODO implementar
            throw new System.NotImplementedException();
        }

        private string GetAuthenticationEndPoint(string appId, string redirectUri)
        {
            return $"/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&state=access_token_state";
        }
        
        private string GetAccessEndPoint(string appId, string appSecret, string code, string redirectUri)
        {
            return $"/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&client_secret={appSecret}&code={code}";
        }
    }
}

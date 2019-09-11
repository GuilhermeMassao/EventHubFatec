using RestSharp;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data;
using SocialConnection.Models;

namespace SocialConnection.Connections
{
    public class FacebookConnection : IFacebookConnection<ClientFacebookAccessTokenData>
    {
        // Todos os endpoints e URL salvar em config files
        // TODO Verificar a possibilidade de transportar essas variáveis para a nossa API
        private const string ApiUrl = "https://graph.facebook.com";
        private const string FacebookUrl = "https://www.facebook.com/v4.0";
        
        private const string AppId = "412268042729337";
        private const string AppSecret = "ba75ac7497a95f93aef3a629be09f764";
        
        public string GetAuthenticationUri(string redirectUri)
        {
            var client = new RestClient(FacebookUrl);
            var request = new RestRequest(GetAuthenticationEndPoint(redirectUri));

            return client.BuildUri(request).ToString();
        }

        public ClientFacebookAccessTokenData GetAccessToken(string code, string redirectUri)
        {
            var client = new RestClient(ApiUrl);
            var request = new RestRequest(GetAccessEndPoint(code, redirectUri));

            return null;
        }
        
        public PostResponseData Post(PostContent content, ClientFacebookAccessTokenData clientFacebookAccessTokenData)
        {
            // TODO implementar
            throw new System.NotImplementedException();
        }

        private string GetAuthenticationEndPoint(string redirectUri)
        {
            return $"/dialog/oauth?client_id={AppId}&redirect_uri={redirectUri}&state=123";
        }
        
        private string GetAccessEndPoint(string code, string redirectUri)
        {
            return $"/dialog/oauth?client_id={AppId}&redirect_uri={redirectUri}&client_secret={AppSecret}&code={code}";
        }
    }
}
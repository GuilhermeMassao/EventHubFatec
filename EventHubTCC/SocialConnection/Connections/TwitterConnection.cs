using System;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data;
using SocialConnection.Exceptions;
using SocialConnection.Models;

namespace SocialConnection.Connections
{
    public class TwitterConnection : ITwitterConnection<ClientTwitterAccessTokenData>
    {
        // Todos os endpoints e URL salvar em config files
        // TODO Verificar a possibilidade de transportar essas variáveis para a nossa API 
        private const string BaseUrl = "https://api.twitter.com";
        private const string AppKey = "py2O8NqmRQzaJCWzTigwvUolY";
        private const string AppSecretKey = "3lMsLhtFYnrsGPgqjVj7DTYW5mNJZGUauT8GhRDblvbLmCfhEd";

        /// <summary>
        /// Get temporary oauth_token and oauth_secret from twitter API.
        /// Doc: https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token
        /// </summary>
        /// <param name="callBackUrl">URL to redirect after get authentication token and token secret</param>
        /// <returns>OAuthTokenData object with authentication tokens information</returns>
        public OAuth1TokenData GetRequestToken(string callBackUrl)
        {
            var client = new RestClient(BaseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(AppKey, AppSecretKey, callBackUrl)
            };

            var request = new RestRequest("/oauth/request_token", Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new OAuth1TokenData(queryString["oauth_token"],
                    queryString["oauth_token_secret"],
                    bool.TryParse(queryString["oauth_token_secret"], out _));
            }

            throw new CouldNotConnectException("Error while connecting to Twitter Api.");
        }

        /// <summary>
        /// Get the authorize token uri to redirect to authorize the authentication token. 
        /// Doc: https://developer.twitter.com/en/docs/basics/authentication/api-reference/authorize
        /// </summary>
        /// <param name="oauthToken">String with the authentication token</param>
        /// <returns>Full authotization token uri</returns>
        public string GetAuthorizeTokenUri(string oauthToken)
        {
            var client = new RestClient(BaseUrl);
            // Ver se isso da certo client.DefaultParameters.Add(new Parameter("oauth_token", oauthToken, ParameterType.UrlSegment));
            var request = new RestRequest("/oauth/authorize?oauth_token=" + oauthToken);
            return client.BuildUri(request).ToString();
        }
        
        /// <summary>
        /// Get the access information for user operations (access token, access token secret, id and screen name).
        /// Doc: https://developer.twitter.com/en/docs/basics/authentication/api-reference/access_token
        /// </summary>
        /// <param name="tokenData">OAuthTokenData with oauth_token, oauth_token_secret, oatuh</param>
        /// <returns>ClientAccessTokenData with the access token, token secret, user id, screen name</returns>
        public ClientTwitterAccessTokenData GetAccessToken(OAuth1TokenData tokenData)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(GetAccessTokenEndPoint(tokenData), Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            return new ClientTwitterAccessTokenData(queryString["oauth_token"],
                queryString["oauth_token_secret"],
                queryString["user_id"],
                queryString["screen_name"]);
        }

        /// <summary>
        /// Post a new tweet based on given Tweet data object with tweet information
        /// Doc: https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update
        /// </summary>
        /// <param name="content">PostContent with tweet information</param>
        /// <param name="clientTwitterAccessTokenData">ClientAccessTokenData with the access token, token secret, user id, screen name</param>
        /// <returns>TweetResponseData response object</returns>
        public PostResponseData Post(PostContent content, ClientTwitterAccessTokenData clientTwitterAccessTokenData)
        {
            var client = new RestClient(BaseUrl)
            {
                Authenticator = OAuth1Authenticator.ForClientAuthentication(AppKey, AppSecretKey,
                    clientTwitterAccessTokenData.AccessToken,
                    clientTwitterAccessTokenData.AccessTokenSecret)
            };
            var request = new RestRequest(GetPostTweetEndPoint(content), Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            // TODO Verificar as informações retornadas e adicioná-las no objeto
            return new PostResponseData();
        }

        private static string GetPostTweetEndPoint(PostContent content)
        {
            return $"/statuses/update.json?status={content.Text}";
        }

        private static string GetAccessTokenEndPoint(OAuth1TokenData tokenData)
        {
            return $"/oauth/access_token?oauth_verifier={tokenData.TokenVerifier}&oauth_token={tokenData.Token}";
        }
    }
/*
 * Base Flow:
 *     Ao usuário solicitar acessso ao titter, o nosso front manda para a nossa api (/oauth/) que chama o método
 *     GetRequestToken(), esse método acessa a api do twitter e retorna o token de acesso requisitado e o token secret,
 *     que são armazenados em um objeto OAuthTokenData. Após obter esse token o Controller redireciona para o end point de
 *     autorização da nossa api (/oauth/authorize/) que redireciona o usuário para a api do twitter para o usuário logar
 *     e autenticar o token de acesso, retornando um token verificador e redirecionando
 *     para a callback_url passada. Após isso essa callback_url deverar acessar a api do twitter para pegar o token e o
 *     token_secret de acesso do usuário e salvá-los em um objeto do tipo ClientAccessTokenData;
 */
}
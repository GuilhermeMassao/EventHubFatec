using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using SocialConnection.Exceptions;

namespace SocialConnection.Connections
{
    public class TwitterConnection : ITwitterConnection<ClientTwitterAccessTokenResponseData>
    {
        private const string BaseUrl = "https://api.twitter.com/";

        /// <summary>
        /// Get temporary oauth_token and oauth_secret from twitter API.
        /// Doc: https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token
        /// </summary>
        /// <param name="appKey">App customer key</param>
        /// <param name="appSecretKey">App customer secret key</param>
        /// <param name="callBackUrl">URL to redirect after get authentication token and token secret</param>
        /// <returns>OAuthTokenData object with authentication tokens information</returns>
        public RequestTokenResponseData GetRequestToken(string appKey, string appSecretKey, string callBackUrl) 
        {
            var client = new RestClient(BaseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(appKey, appSecretKey, callBackUrl)
            };

            var request = new RestRequest("/oauth/request_token", Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new RequestTokenResponseData(queryString["oauth_token"],
                    queryString["oauth_token_secret"],
                    bool.TryParse(queryString["oauth_callback_confirmed"], out _));
            }

            throw new CouldNotConnectException(
                "Error while connecting to Twitter Api when requesting token. Twitter EndPoint:{/oauth/request_token}.", response.StatusCode);
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
        /// <param name="tokenResponseData">OAuthTokenData with oauth_token, oauth_token_secret, oatuh</param>
        /// <returns>ClientAccessTokenData with the access token, token secret, user id, screen name</returns>
        public ClientTwitterAccessTokenResponseData GetAccessToken(OAuth1TokenResponseData tokenResponseData)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(GetAccessTokenEndPoint(tokenResponseData), Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new ClientTwitterAccessTokenResponseData(queryString["oauth_token"],
                    queryString["oauth_token_secret"],
                    queryString["user_id"],
                    queryString["screen_name"]);
            }

            throw new CouldNotConnectException(
                $"Error while connecting to Twitter Api when requesting Access Token. Twitter EndPoint:{GetAccessTokenEndPoint(tokenResponseData)}.", response.StatusCode);
        }

        /// <summary>
        /// Post a new tweet based on given Tweet data object with tweet information
        /// Doc: https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update
        /// </summary>
        /// <param name="contentRequestData">PostContent with tweet information</param>
        /// <returns>TweetResponseData response object</returns>
        public PostResponseData Post(PostContentRequestData contentRequestData)
        {
            var client = new RestClient(BaseUrl)
            {
                DefaultParameters =
                {
                    CreateAuthorizationParameter(contentRequestData)
                }
            };
            var request = new RestRequest(GetPostTweetEndPoint(contentRequestData), Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            // TODO Verificar as informações retornadas e adicioná-las no objeto
            return new PostResponseData();
        }

        private static string GetPostTweetEndPoint(PostContentRequestData contentRequestData)
        {
            return $"/1.1/statuses/update.json?status={contentRequestData.Text}";
        }

        private static string GetAccessTokenEndPoint(OAuth1TokenResponseData tokenResponseData)
        {
            return $"/oauth/access_token?oauth_verifier={tokenResponseData.TokenVerifier}&oauth_token={tokenResponseData.Token}";
        }
        
        // TODO Extrair esse método para uma nova classe própria para a criaçaõ do header
        private Parameter CreateAuthorizationParameter(PostContentRequestData contentRequestData)
        {
            return new Parameter("Authorization", $"OAuth oauth_consumer_key=\"{contentRequestData.AppId}\","+
                                                  $"oauth_token=\"{contentRequestData.AccessToken}\","+
                                                  "oauth_signature_method=\"HMAC-SHA1\","+
                                                  $"oauth_timestamp=\"{((DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalSeconds)}\","+
                                                  "oauth_nonce=\"XalVggftEJC\","+
                                                  "oauth_version=\"1.0\","+
                                                  "oauth_signature=\"hRqmYDmql7jwGxDp3CG1SHfUN14%3D\"", ParameterType.HttpHeader);
        }
        
        public string CreateSignature(string url)
        {
            //string builder will be used to append all the key value pairs
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("POST&");
            stringBuilder.Append(Uri.EscapeDataString(url));
            stringBuilder.Append("&");
 
            //the key value pairs have to be sorted by encoded key
            var dictionary = new SortedDictionary<string, string>
            {
                {"oauth_version", "1.0"},
                {"oauth_consumer_key", OauthConsumerKey},
                {"oauth_nonce", _oauthNonce},
                {"oauth_signature_method", OauthSignatureMethod},
                {"oauth_timestamp", _oathTimestamp},
                {"oauth_token", OauthToken}
            };
            
            foreach (var keyValuePair in dictionary)
            {
                //append a = between the key and the value and a & after the value
                stringBuilder.Append(Uri.EscapeDataString(string.Format("{0}={1}&", keyValuePair.Key, keyValuePair.Value)));
            }
            string signatureBaseString = stringBuilder.ToString().Substring(0, stringBuilder.Length - 3);
 
            //generation the signature key the hash will use
            string signatureKey =
                Uri.EscapeDataString(OauthConsumerKey) + "&" +
                Uri.EscapeDataString(OauthToken);
 
            var hmacsha1 = new HMACSHA1(
                new ASCIIEncoding().GetBytes(signatureKey));
 
            //hash the values
            string signatureString = Convert.ToBase64String(
                hmacsha1.ComputeHash(
                    new ASCIIEncoding().GetBytes(signatureBaseString)));
            
            return signatureString;
        }
    }
/*
 * Base Flow:
 *     Ao usuário solicitar acessso ao twitter, o nosso front manda para a nossa api (/oauth/) que chama o método
 *     GetRequestToken(), esse método acessa a api do twitter e retorna o token de acesso requisitado e o token secret,
 *     que são armazenados em um objeto OAuthTokenData. Após obter esse token o Controller redireciona para o end point de
 *     autorização da nossa api (/oauth/authorize/) que redireciona o usuário para a api do twitter para o usuário logar
 *     e autenticar o token de acesso, retornando um token verificador e redirecionando
 *     para a callback_url passada. Após isso essa callback_url deverar acessar a api do twitter para pegar o token e o
 *     token_secret de acesso do usuário e salvá-los em um objeto do tipo ClientAccessTokenData;
 */
}

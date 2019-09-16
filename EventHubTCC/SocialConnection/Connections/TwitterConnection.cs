using System.Collections.Generic;
using System.Net;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using SocialConnection.Exceptions;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

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
        /// Get the authorize token uri to redirect, to authorize the authentication token. 
        /// Doc: https://developer.twitter.com/en/docs/basics/authentication/api-reference/authorize
        /// </summary>
        /// <param name="oauthToken">String with the authentication token</param>
        /// <returns>Full authorization token uri</returns>
        public string GetAuthorizeTokenUri(string oauthToken)
        {
            return $"{BaseUrl}/oauth/authorize?oauth_token={oauthToken}";
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
        /// TweetInvi publish tweet doc: https://github.com/linvi/tweetinvi/wiki/Upload
        /// </summary>
        /// <param name="contentRequestData">PostContent with tweet information</param>
        /// <returns>TweetResponseData response object</returns>
        public PostResponseData Post(PostContentRequestData contentRequestData)
        {
            Auth.SetUserCredentials(contentRequestData.AppId,
                contentRequestData.AppSecret,
                contentRequestData.AccessToken,
                contentRequestData.AccessTokenSecret);
            var response = PublishTweet(contentRequestData);

            if (response != null)
            {
                // TODO Verificar as informações retornadas e adicioná-las no objeto
                return PostResponseDataBuilder.AModel().Build();
            }
            
            throw new CouldNotConnectException(
                $"Error while connecting to Twitter Api when posting a new Tweet. Twitter EndPoint:{GetPostTweetEndPoint(contentRequestData)}.", HttpStatusCode.BadRequest);
        }

        private ITweet PublishTweet(PostContentRequestData contentRequestData)
        {
            /* Descomentar para fazer o teste gambiarra 
                var file = File.ReadAllBytes("/home/rodrigosoares/Pictures/wallhaven-dgo8jm.jpg");
                var media = Upload.UploadBinary(file);
            */
            if (!contentRequestData.Medias.IsNullOrEmpty())
            {
                var medias = getMediasList(contentRequestData);

                return Tweet.PublishTweet(contentRequestData.Text, new PublishTweetOptionalParameters()
                {
                    Medias = medias
                });
            }
            else
            {
                return Tweet.PublishTweet(contentRequestData.Text);
            }
        }

        private List<IMedia> getMediasList(PostContentRequestData contentRequestData)
        {
            var medias = new List<IMedia>(); 
            foreach (var media in contentRequestData.Medias)
            {
                medias.Add(Upload.UploadBinary(media.Content));
            }

            return medias;
        }

        private static string GetPostTweetEndPoint(PostContentRequestData contentRequestData)
        {
            return $"/1.1/statuses/update.json?status={contentRequestData.Text}";
        }

        private static string GetAccessTokenEndPoint(OAuth1TokenResponseData tokenResponseData)
        {
            return $"/oauth/access_token?oauth_verifier={tokenResponseData.TokenVerifier}&oauth_token={tokenResponseData.Token}";
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

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
    public class TwitterConnection : ITwitterConnection
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
                $"Error while connecting to Twitter Api when requesting token. Twitter EndPoint: /oauth/request_token.\n {response.Content}", response.StatusCode);
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
        public TwitterAccessTokenResponseData GetAccessToken(OAuth1TokenResponseData tokenResponseData)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(GetAccessTokenEndPoint(tokenResponseData), Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new TwitterAccessTokenResponseData(queryString["oauth_token"],
                    queryString["oauth_token_secret"],
                    queryString["user_id"],
                    queryString["screen_name"]);
            }

            throw new CouldNotConnectException(
                $"Error while connecting to Twitter Api when requesting Access Token. Twitter EndPoint:{GetAccessTokenEndPoint(tokenResponseData)}.\n {response.Content}", response.StatusCode);
        }

        /// <summary>
        /// Post a new tweet based on given Tweet data object with tweet information
        /// Doc: https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update
        /// Tweetinvi publish tweet doc: https://github.com/linvi/tweetinvi/wiki/Upload
        /// </summary>
        /// <param name="contentRequestData">PostContent with tweet information</param>
        /// <returns>TweetResponseData response object</returns>
        public PostResponseData PostTweet(TwitterPostContentData contentRequestData)
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

        /*private string Header(TwitterPostContentData contentRequestData)
        {
            return "OAuth " + string.Join(
                ", ",
                data
                    .Where(kvp => kvp.Key.StartsWith("oauth_"))
                    .Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );
        }*/

        /// <summary>
        /// Delete previous created Tweet
        /// Doc: https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id
        /// </summary>
        /// <param name="authorizationData">Authorization Data</param>
        /// <param name="id">Tweet Id</param>
        /// <returns>Boolean operation result</returns>
        public bool DeleteTweet(OAuth1AuthorizationData authorizationData, string id)
        {
            Auth.SetUserCredentials(authorizationData.AppId,
                authorizationData.AppSecret,
                authorizationData.AccessToken,
                authorizationData.AccessTokenSecret);

            return Tweet.DestroyTweet(long.Parse(id));
        }

        private static ITweet PublishTweet(TwitterPostContentData contentRequestData)
        {
            /* Descomentar para fazer o teste gambiarra 
                var file = File.ReadAllBytes("/home/rodrigosoares/Pictures/wallhaven-dgo8jm.jpg");
                var media = Upload.UploadBinary(file);
            */
            if (!contentRequestData.Medias.IsNullOrEmpty())
            {
                var medias = GetMediasList(contentRequestData);

                return Tweet.PublishTweet(contentRequestData.Text, new PublishTweetOptionalParameters()
                {
                    Medias = medias
                });
            }

            return Tweet.PublishTweet(contentRequestData.Text);
        }

        private static List<IMedia> GetMediasList(TwitterPostContentData contentRequestData)
        {
            var medias = new List<IMedia>(); 
            foreach (var media in contentRequestData.Medias)
            {
                medias.Add(Upload.UploadBinary(media.Content));
            }

            return medias;
        }

        private static string GetPostTweetEndPoint(TwitterPostContentData contentRequestData)
        {
            return $"/1.1/statuses/update.json?status={contentRequestData.Text}";
        }

        private static string GetAccessTokenEndPoint(OAuth1TokenResponseData tokenResponseData)
        {
            return $"/oauth/access_token?oauth_verifier={tokenResponseData.TokenVerifier}&oauth_token={tokenResponseData.Token}";
        }
    }
}

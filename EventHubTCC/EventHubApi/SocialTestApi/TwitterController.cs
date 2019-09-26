using System.Configuration;
using EventHubApi.SocialTestApi.Models;
using Microsoft.AspNetCore.Mvc;
using SocialConnection.Connections;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace EventHubApi.SocialTestApi
{
    [Route("social/twitter")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private static readonly string AppId = ConfigurationManager.AppSettings["twitter.appid"];
        private static readonly string AppSecret = ConfigurationManager.AppSettings["twitter.appsecret"];
        private ITwitterConnection Twitter;

        public TwitterController()
        {
            Twitter = new TwitterConnection();
        }

        // GET social/twitter/oauth
        [HttpGet]
        [Route("oauth")]
        public ActionResult<RequestTokenResponseData> GetRequestToken(string callbackUrl)
        {
            return Twitter.GetRequestToken(AppId, AppSecret, callbackUrl);
        }
        
        // GET social/twitter/oauth/authorize
        [HttpGet]
        [Route("oauth/authorize")]
        public ActionResult<string> GetAuthorizeTokenUri(string oatuhToken)
        {
            return Twitter.GetAuthorizeTokenUri(oatuhToken);
        }
        
        // GET social/twitter/oauth/access_token
        [HttpGet]
        [Route("oauth/access_token")]
        public ActionResult<OAuth1AccessTokenResponseData> GetAccessToken(string oatuhToken, string verifierToken)
        {
            return Twitter.GetAccessToken(CreateOAuth1TokenDataForAccessToken(oatuhToken, verifierToken));
        }
        
        // GET social/twitter/post
        [HttpGet]
        [Route("post")]
        public ActionResult<PostResponseData> Post([FromBody] TwitterPostRequestBody content)
        {
            return Twitter.PostTweet(PopulateContentData(content));
        }
        
        // GET social/twitter/delete
        [HttpGet]
        [Route("delete")]
        public ActionResult<bool> Delete([FromBody] OAuth1BasicAuthentication authentication, string id)
        {
            return Twitter.DeleteTweet(PopulateAutorizationData(authentication) ,id);
        }

        private static TwitterPostContentData PopulateContentData(TwitterPostRequestBody content)
        {
            return new TwitterPostContentData(content.AccessToken,
                AppId,
                AppSecret,
                content.AccessTokenSecret,
                content.Text,
                content.Medias);
        }

        private static OAuth1AuthorizationData PopulateAutorizationData(OAuth1BasicAuthentication authentication)
        {
            return new OAuth1AuthorizationData(AppId,
                AppSecret,
                authentication.AccessToken,
                authentication.AccessTokenSecret);
        }

        private static OAuth1TokenResponseData CreateOAuth1TokenDataForAccessToken(string oatuhToken, string verifierToken)
        {
            return new OAuth1TokenResponseData(oatuhToken, verifierToken);
        }
    }
}

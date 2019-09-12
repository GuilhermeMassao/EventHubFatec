using System.Configuration;
using EventHubApi.Data;
using Microsoft.AspNetCore.Mvc;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace EventHubApi.Controllers.Social
{
    [Microsoft.AspNetCore.Mvc.Route("social/twitter")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private static readonly string AppId = ConfigurationManager.AppSettings["twitter.appid"];
        private static readonly string AppSecret = ConfigurationManager.AppSettings["twitter.appsecret"];
        private ITwitterConnection<ClientTwitterAccessTokenResponseData> Twitter;

        public TwitterController(ITwitterConnection<ClientTwitterAccessTokenResponseData> twitter)
        {
            Twitter = twitter;
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
        public ActionResult<ClientTwitterAccessTokenResponseData> GetAccessToken(string oatuhToken, string verifierToken)
        {
            return Twitter.GetAccessToken(CreateOAuth1TokenDataForAccessToken(oatuhToken, verifierToken));
        }
        
        // GET social/twitter/post
        [HttpGet]
        [Route("post")]
        public ActionResult<PostResponseData> Post([FromBody] TwitterPostContentData content)
        {
            return Twitter.Post(CreatePostContent(content));
        }

        private static OAuth1TokenResponseData CreateOAuth1TokenDataForAccessToken(string oatuhToken, string verifierToken)
        {
            return new OAuth1TokenResponseData(oatuhToken, verifierToken);
        }

        private static PostContentRequestData CreatePostContent(TwitterPostContentData content)
        {
            return new PostContentRequestData(AppId, AppSecret, content.AccessToken, content.AccessTokenSecret, content.Text);
        }
    }
}

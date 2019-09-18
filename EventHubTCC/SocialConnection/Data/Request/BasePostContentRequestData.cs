using SocialConnection.Models;

namespace SocialConnection.Data.Request
{
    public abstract class BasePostContentRequestData
    {
        public string AccessToken { get; set; }
        
        public BasePostContentRequestData(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}

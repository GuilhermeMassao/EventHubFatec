using EventHub.Business.Business;
using SocialConnection.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.Services.SocialApplication
{
    public class SocialApplication
    {
        private readonly SocialBusiness socialBusiness;

        public SocialApplication(SocialBusiness socialBusiness)
        {
            this.socialBusiness = socialBusiness;
        }

        public async Task<string> GetTwitterAtuhUri(string callbackurl)
        {
            return await socialBusiness.GetTwitterAtuhUri(callbackurl);
        }

        public async Task<TwitterAccessTokenResponseData> GetTwitterAccessToken(OAuth1TokenResponseData input)
        {
            return await socialBusiness.GetTwitterAccessToken(input);
        }
    }
}

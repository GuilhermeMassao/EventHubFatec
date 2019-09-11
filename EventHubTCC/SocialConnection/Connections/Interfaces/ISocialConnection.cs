using SocialConnection.Data;
using SocialConnection.Models;

namespace SocialConnection.Connections.Interfaces
{
    public interface ISocialConnection<T>
    {
        PostResponseData Post(PostContent content, T clientAccessTokenData);
    }
}
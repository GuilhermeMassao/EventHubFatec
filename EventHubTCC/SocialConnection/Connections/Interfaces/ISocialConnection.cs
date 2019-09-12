using SocialConnection.Data;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections.Interfaces
{
    public interface ISocialConnection<T>
    {
        PostResponseData Post(PostContentRequestData contentRequestData);
    }
}
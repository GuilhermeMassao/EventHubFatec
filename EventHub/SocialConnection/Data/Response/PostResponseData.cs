using System;

namespace SocialConnection.Data.Response
{
    public class PostResponseData
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UserId { get; set; }
        
    }

    public class PostResponseDataBuilder
    {
        private static PostResponseData Model;
        
        private PostResponseDataBuilder()
        {
            Model = new PostResponseData();
        }
        
        public static PostResponseDataBuilder AModel()
        {
            return new PostResponseDataBuilder();
        }

        public PostResponseDataBuilder WithId(long id)
        {
            Model.Id = id;
            return this;
        }

        public PostResponseData Build()
        {
            return Model;
        }
    }
}
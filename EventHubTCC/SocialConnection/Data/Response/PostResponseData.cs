using System;

namespace SocialConnection.Data.Response
{
    public class PostResponseData
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Organizer { get; set; }
        public DateTime CreateDate { get; set; }
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

        public PostResponseDataBuilder WithId(string id)
        {
            Model.Id = id;
            return this;
        }
        
        public PostResponseDataBuilder WithUserId(string id)
        {
            Model.UserId = id;
            return this;
        }

        public PostResponseDataBuilder WithContent(string content)
        {
            Model.Content = content;
            return this;
        }

        public PostResponseDataBuilder WithOrganizer(string organizer)
        {
            Model.Organizer = organizer;
            return this;
        }

        public PostResponseDataBuilder WithCreateDate(DateTime createDate)
        {
            Model.CreateDate = createDate;
            return this;
        }

        public PostResponseData Build()
        {
            return Model;
        }
    }
}
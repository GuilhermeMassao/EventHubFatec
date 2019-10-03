using System;

namespace SocialConnection.Data.Response
{
    public class PostResponseData
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public string CreateDate { get; set; }
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
        
        public PostResponseDataBuilder WithUserId(long id)
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
        
        public PostResponseDataBuilder WithPlace(string place)
        {
            Model.Place = place;
            return this;
        }
        
        public PostResponseDataBuilder WithCreateDate(string createDate)
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
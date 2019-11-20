namespace SocialConnection.Data.Response
{
    public class GoogleAgendaResponseData
    {
        public string Id { get; set; }
        public string Summary { get; set; }

        public GoogleAgendaResponseData(string id, string summary)
        {
            Id = id;
            Summary = summary;
        }
    }
}
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using SocialConnection.Exceptions;

namespace SocialConnection.Connections
{
    public class GoogleConnection : IGoogleConnection
    {
        private const string AuthUrl = "https://accounts.google.com/o";
        private const string CalendarUrl = "https://www.googleapis.com/calendar";
        private const string CalendarScope = "https://www.googleapis.com/auth/calendar";

        public string GetAuthenticationUri(string appId, string redirectUri)
        {
            var client = new RestClient(AuthUrl);
            var request = new RestRequest(GetAuthenticationEndPoint(appId, redirectUri));

            return client.BuildUri(request).ToString();
        }

        public OAuth2AccessTokenResponseData GetAccessToken(string appId, string appSecret, string code, string redirectUri)
        {
            var client = new RestClient(AuthUrl);
            var request = new RestRequest("/oauth2/token", Method.POST);
            request.AddJsonBody(
                new
                {
                    code,
                    client_id = appId,
                    client_secret = appSecret,
                    grant_type = "authorization_code",
                    redirect_uri = redirectUri
                });
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new OAuth2AccessTokenResponseData(queryString["access_token"],
                    queryString["token_type"],
                    queryString["refresh_token"]);
            }

            throw new CouldNotConnectException(
                $"Error while connecting to Google Api when requesting Access Token. Google Calendar EndPoint: {AuthUrl}/oauth2/token.", response.StatusCode);
        }

        public OAuth2AccessTokenResponseData RefreshAccessToken(string appId, string appSecret, string refreshToken)
        {
            var client = new RestClient(AuthUrl);
            var request = new RestRequest("/oauth2/token", Method.POST);
            request.AddJsonBody(
                new
                {
                    client_id = appId,
                    client_secret = appSecret,
                    refresh_token = refreshToken,
                    grant_type = "refresh_token"
                });
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                return new OAuth2AccessTokenResponseData(queryString["access_token"],
                    queryString["token_type"]);
            }

            throw new CouldNotConnectException(
                $"Error while connecting to Google Api when refreshing Access Token. Google Calendar EndPoint: {AuthUrl}/oauth2/token.", response.StatusCode);
        }

        public PostResponseData CreateEvent(GoogleCalendarPostContentData contentData)
        {
            var client = new RestClient(CalendarUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(contentData.AccessToken)
            };
            var request = new RestRequest($"/v3/calendars/{contentData.CalendarId}/events", Method.POST);
            request.AddHeader("Authorization", $"Bearer {contentData.AccessToken}");
            request.AddJsonBody(
                new
                {
                    start = new
                    {
                        dateTime = contentData.Start
                    },
                    end = new
                    {
                        dateTime = contentData.End
                    },
                    summary = contentData.Summary,
                    description = contentData.Description,
                    location = contentData.Location,
                    organizer = contentData.Organizer
                });
            var response = client.Execute(request);
            var queryString = HttpUtility.ParseQueryString(response.Content);

            if (response.IsSuccessful)
            {
                // TODO Popular com as informações para salvar no banco
                return new PostResponseData();
            }

            throw new CouldNotConnectException(
                $"Error while connecting to Google Api when creating new event. Google Calendar EndPoint: {AuthUrl}/v3/calendars/{contentData.CalendarId}/events.\n {response.Content}", response.StatusCode);
        }

        private static string GetAuthenticationEndPoint(string appId, string redirectUri)
        {
            return $"oauth2/auth?scope={CalendarScope}&response_type=code&access_type=offline&redirect_uri={redirectUri}&client_id={appId}";
        }
    }
}

/*
 * Fluxo para criar um novo evento no calendário:
 * 
 * Deixar o usuario escolher a agenda que ele deseja (listar todas as agendas dele)
 *     -Caso não houver uma escolhida, permitir criar uma nova (criar uma nova agenda)
 *
 * Criar um novo evento a partir do ID dessa agenda escolhida ou criada.
 */

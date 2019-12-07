using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using EventHub.Infrastructure.Interfaces.Repository;
using SocialConnection.Connections;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using SocialConnection.Models;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        private readonly string TWITTER_APP_KEY = "QZ3bVW2dy0fqi2kQ4XynqOJXO";
        private readonly string TWITTER_APP_KEY_SECRET = "Wj9pf4xSRa0lxzcMLS0IU3iSD86GBaquSM3lUpI8FaZHBerueA";

        private readonly string GOOGLE_APP_ID = "1096581191116-5ee78kmkthcahuhjr6bifpaooq34icct.apps.googleusercontent.com";
        private readonly string GOOGLE_APP_SECRET = "9ojQerHg5M3zdXkZ_fVBFXpr";

        private readonly IAdressRepository _adressRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPublicPlaceRepository _publicPlaceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITwitterSocialMarketingRepository _twitterSocialMarketingRepository;

        private readonly IGoogleCalendarSocialMarketingRepository _googleCalendarSocialMarketingRepository;

        public EventBusiness(IUserRepository userRepository,
            IAdressRepository adressRepository,
            IEventRepository eventRepository,
            IPublicPlaceRepository publicPlaceRepository,
            ITwitterSocialMarketingRepository twitterSocialMarketingRepository,
            IGoogleCalendarSocialMarketingRepository googleCalendarSocialMarketingRepository)
        {
            _adressRepository = adressRepository;
            _eventRepository = eventRepository;
            _publicPlaceRepository = publicPlaceRepository;
            _userRepository = userRepository;
            _twitterSocialMarketingRepository = twitterSocialMarketingRepository;
            _googleCalendarSocialMarketingRepository = googleCalendarSocialMarketingRepository;
        }

        public async Task<EventDto> CreateEvent(Event newEvent, Adress adress, bool twitterLogin, bool googleLogin)
        {
            var adressResultId = await _adressRepository.CreateAdress(adress);

            if(adressResultId != null)
            {
                newEvent.AdressId = adressResultId.GetValueOrDefault();

                var eventResultId = await _eventRepository.CreateEvent(newEvent);

                if(eventResultId != null)
                {
                    ShareEvent(eventResultId.GetValueOrDefault(), newEvent, adress, googleLogin, twitterLogin);
                    
                    return new EventDto(eventResultId.GetValueOrDefault(), newEvent.EventName);

                } else
                {
                    await _adressRepository.Delete(adressResultId.GetValueOrDefault());
                }
            }
            return null;
        }

        public async Task<bool> EditEvent(int id, Event eventInput, Adress adress)
        {
            var adressEditId = await _adressRepository.EditAdress(adress.Id, adress);

            if(adressEditId != null)
            {
                var eventEditId = await _eventRepository.UpdateEvent(id, eventInput);

                if (eventEditId != null)
                {
                    return true;
                }
            }
            return false;
        }
        public Task<CompleteEventDto> GetById(int id)
        {
            return _eventRepository.GetById(id);
        }

        public async Task<IEnumerable<PublicPlace>> GetPublicPlaces()
        {
            return await _publicPlaceRepository.GetAll();
        }

        private async void ShareEvent(int eventResultId, Event newEvent, Adress adress, bool googleLogin, bool twitterLogin)
        {
            PostResponseData googleAgendaResult = null;
            if (googleLogin)
            {
                var userGoogleToken = await _userRepository.GetGoogleTokenByUserId(newEvent.UserOwnerId);
                try
                {
                    googleAgendaResult = await CreateGoogleEvent(userGoogleToken.GoogleRefreshToken, eventResultId, newEvent, adress);
                }
                catch (Exception e) { }
            }

            if (twitterLogin)
            {
                var userTokens = await _userRepository.GetTwitterTokenByUserId(newEvent.UserOwnerId);

                try
                {
                    PostTweet(userTokens, eventResultId, newEvent, adress, googleAgendaResult);
                }
                catch (Exception e) { }
            }
        }

        private async void PostTweet(User userTokens, int? eventResultId, Event newEvent, Adress adress, PostResponseData googleEvent)
        {
            var publicPlace = await _publicPlaceRepository.SelectById(adress.PublicPlaceId);

            TwitterConnection twitter = new TwitterConnection();
            var tweetResponse = twitter.PostTweet(new TwitterPostContentData(userTokens.TwitterAccessToken,
                TWITTER_APP_KEY,
                TWITTER_APP_KEY_SECRET,
                userTokens.TwitterAccessTokenSecret,
                CreateTweetMessage(newEvent, adress, publicPlace, googleEvent),
                null));

            if (tweetResponse != null)
            {
                await _twitterSocialMarketingRepository.CreateTwitterSocialMarketing(new TwitterSocialMarketing(eventResultId.GetValueOrDefault(),
                                                                                                                tweetResponse.Id.ToString(),
                                                                                                                tweetResponse.ShortUrlTweet));
            }
        }

        private async Task<PostResponseData> CreateGoogleEvent(string refreshToken, int newEventId, Event newEvent, Adress adress)
        {
            var publicPlace = await _publicPlaceRepository.SelectById(adress.PublicPlaceId);
            var user = await _userRepository.GetById(newEvent.UserOwnerId);

            GoogleConnection google = new GoogleConnection();
            var accessToken = google.RefreshAccessToken(GOOGLE_APP_ID, GOOGLE_APP_SECRET, refreshToken).AccessToken;

            var agendaId = google.CreateAgenda(accessToken, newEvent.EventName);

            var googleEvent = google.CreateEvent(CreateGoogleCalendarPostContentData(accessToken, agendaId, user, newEvent, adress, publicPlace));

            await _googleCalendarSocialMarketingRepository.CreateGoogleCalendarSocialMarketing(new GoogleCalendarSocialMarketing(newEventId, agendaId, googleEvent.ShortUrlGoogle));

            return googleEvent;
        }

        private GoogleCalendarPostContentData CreateGoogleCalendarPostContentData(string accessToken, string agendaId, UserDTO user, Event newEvent, Adress adress, PublicPlace publicPlace)
        {
            return new GoogleCalendarPostContentData(accessToken,
                agendaId,
                newEvent.StartDate.ToString("yyyy-MM-dd'T'HH:mm:ss-03:00"),
                newEvent.EndDate.ToString("yyyy-MM-dd'T'HH:mm:ss-03:00"),
                newEvent.EventName,
                newEvent.EventDescription,
                $"{publicPlace.PlaceName} {adress.PlaceName}, {adress.Neighborhood}, {adress.CEP}, {adress.City} {adress.UF}",
                newEvent.TicketsLimit,
                new GoogleCalendarOrganizer(user.UserName, user.Email));
        }

        private string CreateTweetMessage(Event newEvent, Adress adress, PublicPlace publicPlace, PostResponseData googleEvent)
        {
            var googleEventUrl = (googleEvent != null) ? googleEvent.ShortUrlGoogle : "";
            return $"Novo evento: {newEvent.EventName}\n"+
                $"{newEvent.EventDescription}\n" +
                $"Local: {publicPlace.PlaceName} {adress.PlaceName} - {adress.AdressNumber}, Bairro: {adress.Neighborhood}, CEP: {adress.CEP}, Cidade {adress.City} {adress.UF}\n" +
                $"Limite de vagas: {newEvent.TicketsLimit}\n" +
                $"{googleEventUrl}\n\n" +
                "Tweet gerado automaticamente por EventHub.";
        }
    }
}

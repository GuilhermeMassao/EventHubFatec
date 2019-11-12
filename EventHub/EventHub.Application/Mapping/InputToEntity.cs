using AutoMapper;
using EventHub.Application.Services.EventApplication;
using EventHub.Application.Services.EventApplication.Input;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain;

namespace EventHub.Application.Mapping
{
    public class InputToEntity : Profile
    {
        public InputToEntity()
        {
            // user
            CreateMap<UserInput, User>();
            CreateMap<UserTokensInput, User>();

            // event
            CreateMap<EventInput, Event>();
            CreateMap<EventAdress, Adress>();
            CreateMap<AdressPublicPlace, PublicPlace>();
        }
    }
}

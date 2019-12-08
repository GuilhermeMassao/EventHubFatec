using AutoMapper;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;

namespace EventHub.Application.Mapping
{
    public class InputToEntity : Profile
    {
        public InputToEntity()
        {
            // user
            CreateMap<UserInput, User>();
            CreateMap<UserTwitterTokensInput, User>();

            // event
            CreateMap<EventInput, Event>();
            CreateMap<EventEditInput, Event>();
            CreateMap<EventAdress, Adress>();

            // event subscription
            //CreateMap<EventSubscriberInput, EventSubscribers>();
        }
    }
}

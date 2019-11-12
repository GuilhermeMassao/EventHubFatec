using System;
using System.Threading.Tasks;
using EventHub.Domain;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        public Task<Event> CreateEvent(Event newEvent, Adress adress, PublicPlace publicPlace)
        {
            throw new NotImplementedException();
            // chamar o repo de cada classe, inserindo os dados na ordem para recuperar depois
        }
    }
}

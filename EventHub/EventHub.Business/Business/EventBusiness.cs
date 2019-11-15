using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventHub.Domain;
using EventHub.Domain.Entities;
using EventHub.Infraestructure.Interfaces.Repository;
using EventHub.Infrastructure.Repository;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        private readonly EventRepository repository;

        public EventBusiness(IRepository<Event> repository)
        {
            this.repository = (EventRepository)repository;
        }

        public Task<Event> CreateEvent(Event newEvent, Adress adress, PublicPlace publicPlace)
        {
            throw new NotImplementedException();
            // chamar o repo de cada classe, inserindo os dados na ordem para recuperar depois
        }

        public async Task<Event> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<object> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}

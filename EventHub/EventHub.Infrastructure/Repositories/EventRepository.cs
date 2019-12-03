using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Helpers.Interfaces;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Infrastructure.Interfaces.StroreProcedures;
using EventHub.Infrastructure.Repositories.StoreProcedures;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public EventRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }
        public Task<int?> CreateEvent(Event entity)
        {
            throw new NotImplementedException();
        }

        public Task<EventDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

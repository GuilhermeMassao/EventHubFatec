using Dapper;
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
using System.Data;
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
        public async Task<int?> CreateEvent(Event entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserOwnerId", entity.UserOwnerId, DbType.Int32);
            parameters.Add("@AdressId", entity.AdressId, DbType.String);
            parameters.Add("@StartDate", entity.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);
            parameters.Add("@EventName", entity.EventName, DbType.String);
            parameters.Add("@EventShortDescription", entity.EventShortDescription, DbType.String);
            parameters.Add("@EventDescription", entity.EventDescription, DbType.String);
            parameters.Add("@TicketsLimit", entity.TicketsLimit, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertEvent,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return createdId;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateEvent(int id, Event entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);
            parameters.Add("@UserOwnerId", entity.UserOwnerId, DbType.Int32);
            parameters.Add("@AdressId", entity.AdressId, DbType.String);
            parameters.Add("@StartDate", entity.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);
            parameters.Add("@EventName", entity.EventName, DbType.String);
            parameters.Add("@EventShortDescription", entity.EventShortDescription, DbType.String);
            parameters.Add("@EventDescription", entity.EventDescription, DbType.String);
            parameters.Add("@TicketsLimit", entity.TicketsLimit, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.ExecuteAsync
                    (
                        _storeProcedure.UpdateEvent,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<CompleteEventDto> GetById(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var eventDto = await _connection.QueryFirstOrDefaultAsync<CompleteEventDto>
                    (
                        _storeProcedure.SelectEventsById,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return eventDto;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<EventDto>> GetEventsButUser(int id)
        {
            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var _eventDto = await _connection.QueryAsync<EventDto>
                    (
                        _storeProcedure.GetAllEvents,
                        commandType: CommandType.StoredProcedure
                    );
                    return _eventDto.Where(x=>x.UserOwnerId != id);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

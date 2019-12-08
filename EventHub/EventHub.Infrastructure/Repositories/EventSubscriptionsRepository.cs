using Dapper;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.DTOs.User;
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
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Repositories
{
    public class EventSubscriptionsRepository : IEventSubscriptionsRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public EventSubscriptionsRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }

        public async Task<int?> CreateEventSubscriptions(EventSubscriberInput input)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@EventId", input.EventId, DbType.Int32);
            parameters.Add("@UserId", input.UserId, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertInscription,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return createdId;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Events>> GetEventsByUserId(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserId", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var events = await _connection.QueryAsync<Events>
                    (
                        _storeProcedure.SelectAllCurrentEventsByUserSubscribed,
                        param: parameter,
                        commandType: CommandType.StoredProcedure
                    );

                    if (events.Any())
                    {
                        return events;
                    }

                    return default(IEnumerable<Events>);
                }
            }
            catch (Exception)
            {
                return default(IEnumerable<Events>);
            }
        }

        public async Task<IEnumerable<Events>> GetEventsByOwnerId(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserOwnerId", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var events = await _connection.QueryAsync<Events>
                    (
                        _storeProcedure.SelectAllCurrentEventsByOwnerId,
                        param: parameter,
                        commandType: CommandType.StoredProcedure
                    );

                    if (events.Any())
                    {
                        return events;
                    }

                    return default(IEnumerable<Events>);
                }
            }
            catch (Exception)
            {
                return default(IEnumerable<Events>);
            }
        }

        public async Task<EventSubscribers> GetById (int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    return await _connection.QueryFirstOrDefaultAsync<EventSubscribers>
                    (
                        _storeProcedure.SelectEventSubscriptionById,
                        param: parameter,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception)
            {
                return default(EventSubscribers);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllEventsSubscriptionsByEventId(int id)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("@EventId", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var subscribers = await _connection.QueryAsync<UserDTO>
                    (
                        _storeProcedure.SelectAllEventSubscriptionsByEventId,
                        param: paramenter,
                        commandType: CommandType.StoredProcedure
                    );

                    if (subscribers.Any())
                    {
                        return subscribers;
                    }

                    return default(IEnumerable<UserDTO>);
                }
            }
            catch (Exception)
            {
                return default(IEnumerable<UserDTO>);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserId", id, DbType.Int32);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.ExecuteAsync
                    (
                        _storeProcedure.DeleteInscriptionByUserId,
                        param: parameter,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

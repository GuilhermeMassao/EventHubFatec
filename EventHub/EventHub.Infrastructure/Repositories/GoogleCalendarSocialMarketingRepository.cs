using Dapper;
using EventHub.Domain.Entities;
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
    public class GoogleCalendarSocialMarketingRepository : IGoogleCalendarSocialMarketingRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public GoogleCalendarSocialMarketingRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }

        public async Task<int?> CreateGoogleCalendarSocialMarketing(GoogleCalendarSocialMarketing entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@EventId", entity.EventId, DbType.Int32);
            parameters.Add("@HashCalendar", entity.HashCalendar, DbType.String);
            parameters.Add("@CalendarLink", entity.CalendarLink, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertGoogleCalendarSocialMarketing,
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
    }
}

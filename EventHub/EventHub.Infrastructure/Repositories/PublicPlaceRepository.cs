
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Helpers.Interfaces;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Infrastructure.Interfaces.StroreProcedures;
using EventHub.Infrastructure.Repositories.StoreProcedures;

namespace EventHub.Infrastructure.Repositories
{
    public class PublicPlaceRepository : IPublicPlaceRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public PublicPlaceRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }

        public async Task<IEnumerable<PublicPlace>> GetAll()
        {
            var parameters = new DynamicParameters();

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var publicPlaces = await _connection.QueryAsync<PublicPlace>
                (
                    _storeProcedure.SelectAllPublicPlaces,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                    if(publicPlaces != null)
                        return publicPlaces;

                    return new List<PublicPlace>();
                }
            }
            catch (Exception)
            {
                return new List<PublicPlace>();
            }
        }
    }
}

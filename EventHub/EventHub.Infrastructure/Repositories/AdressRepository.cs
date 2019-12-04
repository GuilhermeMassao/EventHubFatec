using Dapper;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Helpers.Interfaces;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Infrastructure.Interfaces.StroreProcedures;
using EventHub.Infrastructure.Repositories.StoreProcedures;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Repositories
{
    public class AdressRepository : IAdressRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public AdressRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }
        public async Task<int?> CreateAdress(Adress entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PublicPlaceId", entity.PublicPlaceId, DbType.Int32);
            parameters.Add("@PlaceName", entity.PlaceName, DbType.String);
            parameters.Add("@City", entity.City, DbType.String);
            parameters.Add("@UF", entity.UF, DbType.String);
            parameters.Add("@CEP", entity.CEP, DbType.String);
            parameters.Add("@Neighborhood", entity.Neighborhood, DbType.String);
            parameters.Add("@AdressComplement", entity.AdressComplement, DbType.String);
            parameters.Add("@AdressNumber", entity.AdressNumber, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertAdress,
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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

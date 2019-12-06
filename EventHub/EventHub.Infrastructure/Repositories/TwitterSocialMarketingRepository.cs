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
    public class TwitterSocialMarketingRepository : ITwitterSocialMarketingRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public TwitterSocialMarketingRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }

        public async Task<int?> CreateTwitterSocialMarketing(TwitterSocialMarketing entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@EventId", entity.EventId, DbType.Int32);
            parameters.Add("@TweetId", entity.TweetId, DbType.String);
            parameters.Add("@ShortUrlTweet", entity.ShortUrlTweet, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertTwitterSocialMarketing,
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

using EventHub.Infrastructure.Helpers.Interfaces;
using System.Data.SqlClient;

namespace EventHub.Infrastructure.Helpers
{
    public class ConnectionHelper : IConnectionDatabase
    {
        public string ConnectionString()
        {
            var buildConnectionString = new SqlConnectionStringBuilder
            {
                ["Data Sorce"] = @"Server=localhost\SQLEXPRESS",
                ["Initial Catolog"] = "EventHub",
                ["Connect Timeout"] = "120",
                ["Integrated Security"] = true
            };

            return buildConnectionString.ToString();
        }
        //public static readonly string ConnectionString = @"Server =localhost\SQLEXPRESS;Database=EventHub;Trusted_Connection=True;";
        //public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}

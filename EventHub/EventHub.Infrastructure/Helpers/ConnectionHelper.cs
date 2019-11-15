using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Helpers
{
    public class ConnectionHelper
    {
        private ConnectionHelper() { }

        public static readonly string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=EventHub;Trusted_Connection=True;";
        //public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}

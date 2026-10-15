using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HireNova.Data_Connection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection string not found.");

            return new SqlConnection(connectionString);
        }
    }
}

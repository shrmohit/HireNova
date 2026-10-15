using System.Data;
using System.Threading.Tasks;
using HireNova.Data_Connection;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class DatabaseTestService : IDatabaseTestService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseTestService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> TestConnectionAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.OpenAsync();

            return connection.State == ConnectionState.Open;
        }
    }
}

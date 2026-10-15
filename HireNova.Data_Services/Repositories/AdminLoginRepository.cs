using System.Data;
using System.Threading.Tasks;
using Dapper;
using HireNova.Data_Connection;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;

namespace HireNova.Data_Services.Repositories
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AdminLoginRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<AdminLoginResult?> GetAdminByEmailAsync(string email)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<AdminLoginResult>(
                "USP_AdminLogin",
                new { Email = email },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

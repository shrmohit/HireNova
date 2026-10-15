using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HireNova.Data_Connection;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;

namespace HireNova.Data_Services.Repositories
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AdminUserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<AdminUserDTO>> GetUsersAsync(string? search)
        {
            using var connection = _connectionFactory.CreateConnection();

            var users = await connection.QueryAsync<AdminUserDTO>(
                "dbo.USP_Admin_GetUsers",
                new { Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim() },
                commandType: CommandType.StoredProcedure
            );

            return users.ToList();
        }
    }
}

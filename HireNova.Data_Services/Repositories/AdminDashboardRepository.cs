using System.Data;
using System.Threading.Tasks;
using Dapper;
using HireNova.Data_Connection;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;

namespace HireNova.Data_Services.Repositories
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AdminDashboardRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<AdminDashboardDTO> GetSummaryAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<AdminDashboardDTO>(
                "dbo.USP_AdminDashboardSummary",
                commandType: CommandType.StoredProcedure
            );

            return result ?? new AdminDashboardDTO();
        }
    }
}

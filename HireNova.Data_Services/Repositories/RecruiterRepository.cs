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
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RecruiterRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<RecruiterDTO>> GetRecruitersAsync(string? search, int statusFilter = -1)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new
            {
                Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                StatusFilter = statusFilter
            };

            var recruiters = await connection.QueryAsync<RecruiterDTO>(
                "dbo.USP_Admin_GetRecruiters",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return recruiters.ToList();
        }
    }
}

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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CandidateRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CandidateDTO>> GetCandidatesAsync(string? search, int statusFilter = -1)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new
            {
                Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                StatusFilter = statusFilter
            };

            var result = await connection.QueryAsync<CandidateDTO>(
                "dbo.USP_Admin_GetCandidates",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public async Task<bool> UpdateCandidateStatusAsync(int userId, bool status)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new
            {
                UserId = userId,
                Status = status
            };

            var rowsAffected = await connection.ExecuteScalarAsync<int>(
                "dbo.USP_Admin_UpdateCandidateStatus",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return rowsAffected > 0;
        }

        public async Task<CandidateDTO?> GetCandidateByIdAsync(int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<CandidateDTO>(
                "dbo.USP_Admin_GetCandidateById",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<CandidateEducationDTO>> GetCandidateEducationAsync(int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<CandidateEducationDTO>(
                "dbo.USP_Admin_GetCandidateEducation",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }
}

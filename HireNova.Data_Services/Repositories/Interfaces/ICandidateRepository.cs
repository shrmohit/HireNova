using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        Task<List<CandidateDTO>> GetCandidatesAsync(string? search, int statusFilter = -1);
        Task<bool> UpdateCandidateStatusAsync(int userId, bool status);
        Task<CandidateDTO?> GetCandidateByIdAsync(int userId);
        Task<List<CandidateEducationDTO>> GetCandidateEducationAsync(int userId);
    }
}

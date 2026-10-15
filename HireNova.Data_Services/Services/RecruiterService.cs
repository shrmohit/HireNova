using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository _recruiterRepository;

        public RecruiterService(IRecruiterRepository recruiterRepository)
        {
            _recruiterRepository = recruiterRepository;
        }

        public async Task<List<RecruiterDTO>> GetRecruitersAsync(
            string? search,
            int statusFilter = -1)
        {
            return await _recruiterRepository.GetRecruitersAsync(search, statusFilter);
        }
    }
}

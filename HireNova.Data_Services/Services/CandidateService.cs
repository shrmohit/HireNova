using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // Get candidates with Search and Status Filter
        public async Task<List<CandidateDTO>> GetCandidatesAsync(
            string? search,
            int statusFilter = -1)
        {
            return await _candidateRepository.GetCandidatesAsync(search, statusFilter);
        }

        // Activate or Deactivate candidate
        public async Task<bool> UpdateCandidateStatusAsync(
            int userId,
            bool status)
        {
            if (userId <= 0)
            {
                return false;
            }

            return await _candidateRepository.UpdateCandidateStatusAsync(userId, status);
        }

        // Get candidate details by ID
        public async Task<CandidateDTO?> GetCandidateByIdAsync(int userId)
        {
            if (userId <= 0)
            {
                return null;
            }

            return await _candidateRepository.GetCandidateByIdAsync(userId);
        }

        // Get candidate education records
        public async Task<List<CandidateEducationDTO>> GetCandidateEducationAsync(
            int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException(
                    "Invalid candidate UserId.",
                    nameof(userId));
            }

            return await _candidateRepository.GetCandidateEducationAsync(userId);
        }
    }
}

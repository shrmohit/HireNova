using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Services.Interfaces
{
    public interface IRecruiterService
    {
        Task<List<RecruiterDTO>> GetRecruitersAsync(string? search, int statusFilter = -1);
    }
}

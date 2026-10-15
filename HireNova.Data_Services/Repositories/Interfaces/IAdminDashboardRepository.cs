using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Repositories.Interfaces
{
    public interface IAdminDashboardRepository
    {
        Task<AdminDashboardDTO> GetSummaryAsync();
    }
}

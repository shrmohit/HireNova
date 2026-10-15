using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Services.Interfaces
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardDTO> GetSummaryAsync();
    }
}

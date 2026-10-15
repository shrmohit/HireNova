using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _dashboardRepository;

        public AdminDashboardService(IAdminDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<AdminDashboardDTO> GetSummaryAsync()
        {
            return await _dashboardRepository.GetSummaryAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _adminUserRepository;

        public AdminUserService(IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public async Task<List<AdminUserDTO>> GetUsersAsync(string? search)
        {
            return await _adminUserRepository.GetUsersAsync(search);
        }
    }
}

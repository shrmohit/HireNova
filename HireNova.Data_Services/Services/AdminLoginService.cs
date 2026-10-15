using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

namespace HireNova.Data_Services
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminLoginRepository _adminLoginRepository;

        public AdminLoginService(IAdminLoginRepository adminLoginRepository)
        {
            _adminLoginRepository = adminLoginRepository;
        }

        public async Task<AdminLoginResult?> GetAdminByEmailAsync(string email)
        {
            return await _adminLoginRepository.GetAdminByEmailAsync(email);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

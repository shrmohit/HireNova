using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Services.Interfaces
{
    public interface IAdminLoginService
    {
        Task<AdminLoginResult?> GetAdminByEmailAsync(string email);
        bool VerifyPassword(string password, string passwordHash);
        string HashPassword(string password);
    }
}

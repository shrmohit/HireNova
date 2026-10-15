using System.Collections.Generic;
using System.Threading.Tasks;
using HireNova.Data_Model.DTOs;

namespace HireNova.Data_Services.Repositories.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<List<AdminUserDTO>> GetUsersAsync(string? search);
    }
}

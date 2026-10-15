using System.Threading.Tasks;

namespace HireNova.Data_Services.Services.Interfaces
{
    public interface IDatabaseTestService
    {
        Task<bool> TestConnectionAsync();
    }
}

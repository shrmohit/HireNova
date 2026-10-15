using Microsoft.Data.SqlClient;

namespace HireNova.Data_Connection
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

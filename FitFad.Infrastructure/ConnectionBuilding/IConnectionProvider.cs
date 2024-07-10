using System.Data.SqlClient;

namespace FitFad.Infrastructure.ConnectionBuilding
{
    public interface IConnectionProvider
    {
        Task<SqlConnection> GetConnectionAsync();
    }
}

using System.Data.SqlClient;
using System.Security;

namespace FitFad.Infrastructure.ConnectionBuilding
{
    public class ConnectionProvider(
        AuthenticationType authenticationType = AuthenticationType.SQLPassword,
        string? serverName = null,
        string? databaseName = null,
        string? login = null,
        SecureString? password = null,
        bool isEncrypted = true,
        bool isServerCertificateTrusted = false) : IConnectionProvider
    {
        private readonly AuthenticationType AuthenticationType = authenticationType;
        private readonly string? ServerName = serverName;
        private readonly string? DatabaseName = databaseName;
        private readonly string? Login = login;
        private readonly bool IsEncrypted = isEncrypted;
        private readonly bool IsServerCertificateTrusted = isServerCertificateTrusted;

        public Task<SqlConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection
            {
                ConnectionString = GetConnectionString()
            };

            return AuthenticateAsync(connection);
        }

        private string GetConnectionString()
        {
            if (string.IsNullOrEmpty(ServerName))
            {
                throw new InvalidOperationException("Server name is required for database engine server type.");
            }
            if (string.IsNullOrEmpty(DatabaseName))
            {
                throw new InvalidOperationException("Database name is required for database engine server type.");
            }

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ServerName,
                InitialCatalog = DatabaseName,
                Encrypt = IsEncrypted,
                TrustServerCertificate = IsServerCertificateTrusted
            };

            return builder.ConnectionString;
        }

        private async Task<SqlConnection> AuthenticateAsync(SqlConnection connection)
        {
            switch (AuthenticationType)
            {
                case AuthenticationType.SQLPassword:
                    return await Task.Run(() => AuthenticateByPassword(connection));
                default:
                    throw new InvalidOperationException("Authentication type not supported.");
            }
        }

        private SqlConnection AuthenticateByPassword(SqlConnection connection)
        {
            if (string.IsNullOrEmpty(Login))
            {
                throw new InvalidOperationException("Login is required for SQL password authentication.");
            }
            if (password is null || password.Length == 0)
            {
                throw new InvalidOperationException("Password is required for SQL password authentication.");
            }
            var credential =
                new SQLPasswordAuthentication(Login, password)
                .GetCredential();

            connection.Credential = credential;
            return connection;
        }
    }
}

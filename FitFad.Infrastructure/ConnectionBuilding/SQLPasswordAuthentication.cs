using System.Data.SqlClient;
using System.Security;

namespace FitFad.Infrastructure.ConnectionBuilding
{
    internal class SQLPasswordAuthentication
    {
        public readonly string Login;
        private readonly SecureString _password;

        public SQLPasswordAuthentication(string login, SecureString password)
        {
            if (login is null || login.Length == 0)
            {
                throw new InvalidOperationException("Login is required for SQL password authentication.");
            }
            Login = login;
            if (password is null || password.Length == 0)
            {
                throw new InvalidOperationException("Password is required for SQL password authentication.");
            }
            _password = password;
        }

        public SqlCredential GetCredential()
        {
            return new SqlCredential(Login, _password);
        }
    }
}

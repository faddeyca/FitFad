using CredentialManagement;
using FitFad.Infrastructure;
using FitFad.Infrastructure.ConnectionBuilding;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Security;

namespace FitFad.Application
{
    public class ApplicationContext
    {
        private static ApplicationContext? _instance;
        public static ApplicationContext Instance => _instance ??= new ApplicationContext();

        public event Action<string>? NewProgressStage;

        public string? Username { get; private set; }
        private SecureString? Password;
        public bool HasCredentials => Username is not null && Password is not null;
        private SqlConnection? _connection;

        public readonly IConfiguration Configuration = GetConfiguration();

        private ApplicationContext()
        {
            TryToLoadCredentials();
        }

        private void OnNewProgressStage(string stage)
        {
            NewProgressStage?.Invoke(stage);
        }

        public async Task Login(bool remember = false)
        {
            await SetUpConnection();

            if (!remember)
            {
                DeleteCredentials();
            }
        }

        public async Task Login(string username, SecureString password, bool remember = false)
        {
            Username = username;
            Password = password;

            if (remember)
            {
                SaveCredentials();
            }
            else
            {
                DeleteCredentials();
            }

            OnNewProgressStage("Setting up connection...");
            await SetUpConnection();

            OnNewProgressStage("Connecting to database...");
            Context context;
            await Task.Run(() => context = new Context(_connection!));
        }

        private async Task SetUpConnection()
        {
            var connectionProvider = new ConnectionProvider(
                Enum.Parse<AuthenticationType>(Configuration["ConnectionSettings:AuthenticationType"]!),
                Configuration["ConnectionSettings:Server"]!,
                Configuration["ConnectionSettings:Database"]!,
                Username,
                Password,
                bool.Parse(Configuration["ConnectionSettings:IsEncrypted"]!),
                bool.Parse(Configuration["ConnectionSettings:IsServerCertificateTrusted"]!));

            _connection = await connectionProvider.GetConnectionAsync();
        }

        public void DeleteCredentials()
        {
            using var cred = new Credential { Target = "FitFad" };
            cred.Delete();
        }

        private void TryToLoadCredentials()
        {
            using var cred = new Credential { Target = "FitFad" };
            if (cred.Load())
            {
                Username = cred.Username;
                Password = new SecureString();
                foreach (var c in cred.Password)
                {
                    Password.AppendChar(c);
                }
            }
        }

        private void SaveCredentials()
        {
            var passwordString = new NetworkCredential(string.Empty, Password).Password;

            using var cred = new Credential
            {
                Target = "FitFad",
                Username = Username,
                Password = passwordString,
                PersistanceType = PersistanceType.LocalComputer
            };
            cred.Save();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}

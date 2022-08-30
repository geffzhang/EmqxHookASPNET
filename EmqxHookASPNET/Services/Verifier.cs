using Emqx.Exhook.V2;

namespace EmqxHookASPNET.Services
{
    public class Verifier
    {
        private readonly ILogger<Verifier> _logger;

        public Verifier(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<Verifier>();
        }

        public bool Verify(ClientInfo clientinfo)
        {
            string clientId = clientinfo.Clientid;
            string username = clientinfo.Username;
            string password = clientinfo.Password;
            if (!string.IsNullOrEmpty(clientId) || !string.IsNullOrEmpty(username)
                    || !string.IsNullOrEmpty(password))
            {
                return false;
            }
            return SignByDoge(clientId, username, password);
        }

        private bool SignByDoge(string clientId, string username, string password)
        {
            _logger.LogInformation($"{clientId}: {username} : {password}");
            return true;
        }

    }
}

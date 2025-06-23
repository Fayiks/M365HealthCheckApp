using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Web;
using Microsoft.Kiota.Abstractions.Authentication;

namespace M365HealthCheckApp.Services
{
    public class GraphService
    {
        private readonly GraphServiceClient _graphClient;

        public GraphService(ITokenAcquisition tokenAcquisition)
        {
            var tokenProvider = new MsalTokenProvider(tokenAcquisition);
            var authProvider = new BaseBearerTokenAuthenticationProvider(tokenProvider);
            _graphClient = new GraphServiceClient(authProvider);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _graphClient.Users.GetAsync(requestConfig =>
            {
                requestConfig.QueryParameters.Select = new[] { "id", "displayName", "mail" };
            });

            return users?.Value?.ToList() ?? new List<User>();
        }

        public async Task<List<string>> CheckUserHealthAsync()
        {
            return await Task.FromResult(new List<string>
            {
                "User object validation not implemented."
            });
        }
    }
}

using Microsoft.Identity.Web;
using Microsoft.Kiota.Abstractions.Authentication;

namespace M365HealthCheckApp.Services
{
    public class MsalTokenProvider : IAccessTokenProvider
    {
        private readonly ITokenAcquisition _tokenAcquisition;

        public MsalTokenProvider(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
            AllowedHostsValidator = new AllowedHostsValidator();
        }

        public async Task<string> GetAuthorizationTokenAsync(
            Uri uri,
            Dictionary<string, object>? additionalAuthenticationContext = null,
            CancellationToken cancellationToken = default)
        {
            return await _tokenAcquisition.GetAccessTokenForUserAsync(
                new[] { "https://graph.microsoft.com/.default" });
        }

        public AllowedHostsValidator AllowedHostsValidator { get; }
    }
}

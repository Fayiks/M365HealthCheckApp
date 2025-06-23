
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.Graph.Models;
using System.Net.Http.Headers;
using Azure.Identity;

//public class GraphService
//{
//    private readonly ITokenAcquisition _tokenAcquisition;

//    public GraphService(ITokenAcquisition tokenAcquisition) => _tokenAcquisition = tokenAcquisition;

//    public async Task<List<User>> GetUsersAsync()
//    {
//        var token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "User.Read.All" });
//        var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(request =>
//        {
//            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
//            return Task.CompletedTask;
//        }));

//        var users = await graphClient.Users.Request().Select("id,displayName,mail").GetAsync();
//        return users.CurrentPage.ToList();
//    }

//    public async Task<List<string>> CheckUserHealthAsync()
//    {
//        return new List<string> { "User object validation not implemented." };
//    }
//}

namespace M365HealthCheckApp.Services
{

    public class GraphService
    {
        //private readonly GraphServiceClient _graphClient;

        //public GraphService(ITokenAcquisition tokenAcquisition)
        //{
        //    var credential = new TokenAcquisitionTokenCredential(tokenAcquisition, new[] { "https://graph.microsoft.com/.default" });
        //    _graphClient = new GraphServiceClient(credential);
        //}

        private readonly GraphServiceClient _graphClient;

        public GraphService(ITokenAcquisition tokenAcquisition)
        {
            _graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async requestMessage =>
            {
                var token = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { "https://graph.microsoft.com/.default" });
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }));

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
            // Placeholder for user validation logic
            return new List<string> { "User object validation not implemented." };
        }
    }

}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using M365HealthCheckApp.Services;

[Authorize]
public class DirectoryController : Controller
{
    private readonly GraphService _graphService;
    public DirectoryController(GraphService graphService) => _graphService = graphService;

    public async Task<IActionResult> Index()
    {
        var users = await _graphService.GetUsersAsync();
        return View(users);
    }
}

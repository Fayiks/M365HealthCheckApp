

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using M365HealthCheckApp.Services;

[Authorize]
public class HealthCheckController : Controller
{
    private readonly GraphService _graphService;
    private readonly PowerShellService _psService;

    public HealthCheckController(GraphService graphService, PowerShellService psService)
    {
        _graphService = graphService;
        _psService = psService;
    }

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> RunHealthCheck()
    {
        var graphIssues = await _graphService.CheckUserHealthAsync();
        var mailboxIssues = _psService.CheckMailboxSizes();
        var result = new { GraphIssues = graphIssues, MailboxIssues = mailboxIssues };
        return View("Results", result);
    }
}

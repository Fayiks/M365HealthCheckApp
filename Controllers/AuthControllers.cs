
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

[Authorize]
public class AuthController : Controller
{
    public IActionResult SignIn() =>
    Challenge(new AuthenticationProperties { RedirectUri = "/" }, "OpenIdConnect");

    public IActionResult SignOut() =>
    SignOut(new AuthenticationProperties { RedirectUri = "/" }, "Cookies", "OpenIdConnect");
}


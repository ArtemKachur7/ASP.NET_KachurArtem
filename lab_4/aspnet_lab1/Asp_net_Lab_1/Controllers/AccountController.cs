using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        var redirectUri = Url.Action("Index", "Home");
        return Challenge(new AuthenticationProperties { RedirectUri = redirectUri }, "Auth0");
    }

    public IActionResult Logout()
    {
        var redirectUri = Url.Action("Index", "Home");
        return SignOut(new AuthenticationProperties { RedirectUri = redirectUri }, "Auth0", "Cookies");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}


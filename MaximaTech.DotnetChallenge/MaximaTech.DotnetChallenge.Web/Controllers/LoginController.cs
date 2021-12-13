using MaximaTech.DotnetChallenge.Web.Mocks;
using MaximaTech.DotnetChallenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.DotnetChallenge.Web.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            LoginState.Authenticated = true;
            return RedirectToAction("Index", "Home");
        }
    }
}

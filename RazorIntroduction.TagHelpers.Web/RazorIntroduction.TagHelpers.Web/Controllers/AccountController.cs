using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorIntroduction.TagHelpers.Web.DatabaseContexts;
using System.Security.Claims;
using RazorIntroduction.TagHelpers.Web.Models;

namespace RazorIntroduction.TagHelpers.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserDatabaseContext _context;
        public AccountController(UserDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>() {
                   new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                   new Claim(ClaimTypes.Name, user.Username),
                   new Claim(ClaimTypes.Surname, user.Lastname),
                   new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
            
            return RedirectToAction(nameof(HomeController.Custom), nameof(HomeController).Replace("Controller",""));
        }
    }
}

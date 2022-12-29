using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using RazorIntroduction.TagHelpers.Web.DatabaseContexts;
using RazorIntroduction.TagHelpers.Web.Models;
using System.Diagnostics;

namespace RazorIntroduction.TagHelpers.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserDatabaseContext _context;

        public HomeController(ILogger<HomeController> logger,UserDatabaseContext context )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Custom()
        {
            var userList = await _context.Users.ToListAsync();
            return View(userList);
        }
        public IActionResult Extended()
        {
            return View(new User());
        }
        public async Task<IActionResult> AttributeBased()
        {
            var userList = await _context.Users.ToListAsync();
            return View(userList);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
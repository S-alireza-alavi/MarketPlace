using App.Domain.Core.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> SeedData()
        {
            await _userManager.CreateAsync(new ApplicationUser
            {
                
            });

            return Ok();
        }

        public IActionResult Index()
        {
            ViewData["UserId"] = _userManager.GetUserId(this.User);
            return View();
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
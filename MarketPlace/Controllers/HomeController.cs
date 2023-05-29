using App.Domain.Core.Entities;
using MarketPlace.Database;
using MarketPlace.Entities;
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
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, AppDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> SeedData()
        {
            //var secondSeller = new ApplicationUser()
            //{
            //    Email = "secondSeller@gmail.com",
            //    UserName = "SecondSeller",
            //    EmailConfirmed = true,
            //    PhoneNumber = "09121221212",
            //    PhoneNumberConfirmed = true
            //};

            //await _userManager.CreateAsync(secondSeller, "123@");
            //await _userManager.AddToRoleAsync(secondSeller, "Seller");

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
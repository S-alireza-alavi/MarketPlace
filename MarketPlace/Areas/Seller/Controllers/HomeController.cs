using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.Configs;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class HomeController : Controller
    {
        private readonly AppConfigs _appConfigs;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICalculateTotalSalePricesForSellerService _calculateTotalSalePricesForSeller;

        public HomeController(AppConfigs appConfigs, UserManager<ApplicationUser> userManager, ICalculateTotalSalePricesForSellerService calculateTotalSalePricesForSeller)
        {
            _appConfigs = appConfigs;
            _userManager = userManager;
            _calculateTotalSalePricesForSeller = calculateTotalSalePricesForSeller;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);

            var totalSalePrice = await _calculateTotalSalePricesForSeller.CalculateTotalSalePricesForSeller(user.Id, cancellationToken);

            return View();
        }
    }
}

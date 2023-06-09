using App.Domain.Core.AppServices.Sellers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ProductsController : Controller
    {
        private readonly IGetStoreProductsService _storeProductsService;

        public ProductsController(IGetStoreProductsService storeProductsService)
        {
            _storeProductsService = storeProductsService;
        }

        public async Task<IActionResult> StoreProducts(int storeId, CancellationToken cancellationToken)
        {
            var products = await _storeProductsService.GetStoreProducts(storeId, cancellationToken);

            ViewBag.StoreId = storeId;

            return View(products);
        }
    }
}

using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.AppServices.Sellers;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGetProductsByCategoriesService _getProductsByCategoriesService;
        private readonly IStoreProductsService _storeProductsService;
        private readonly ICalculateTotalSalePricesForSellerService _calculateTotalSalePricesForSellerService;
        private readonly IUpdateProductPriceInAuctionService _updateProductPriceInAuctionService;
        private readonly IGetSellerIdByStoreIdService _getSellerIdByStoreIdService;
        private readonly IGetCategoryByCategoryIdService _getCategoryByCategoryIdService;

        public CategoryController(IGetProductsByCategoriesService getProductsByCategoriesService, IStoreProductsService storeProductsService, IUpdateProductPriceInAuctionService updateProductPriceInAuctionService, ICalculateTotalSalePricesForSellerService calculateTotalSalePricesForSellerService, IGetSellerIdByStoreIdService getSellerIdByStoreIdService, IGetCategoryByCategoryIdService getCategoryByCategoryIdService)
        {
            _getProductsByCategoriesService = getProductsByCategoriesService;
            _storeProductsService = storeProductsService;
            _updateProductPriceInAuctionService = updateProductPriceInAuctionService;
            _calculateTotalSalePricesForSellerService = calculateTotalSalePricesForSellerService;
            _getSellerIdByStoreIdService = getSellerIdByStoreIdService;
            _getCategoryByCategoryIdService = getCategoryByCategoryIdService;
        }

        public async Task<IActionResult> ProductsByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _getCategoryByCategoryIdService.GetCategoryByCategoryId(categoryId, cancellationToken);

            if (category == null)
            {
                return NotFound();
            }

            var products = await _getProductsByCategoriesService.GetProductsByCategories(categoryId, cancellationToken);

            ViewBag.CategoryName = category.Name;
            ViewBag.CategoryId = category.Id;

            return View(products);
        }

        public async Task<IActionResult> StoreProducts(int storeId, CancellationToken cancellationToken)
        {
            var products = await _storeProductsService.GetStoreProducts(storeId, cancellationToken);

            var sellerId = await _getSellerIdByStoreIdService.GetSellerIdByStoreId(storeId, cancellationToken);

            int totalSalePrice = await _calculateTotalSalePricesForSellerService.CalculateTotalSalePricesForSeller(sellerId, cancellationToken);

            return View(products);
        }
    }
}

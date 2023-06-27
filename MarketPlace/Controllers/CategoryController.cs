using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.AppServices.Sellers;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGetStoresByCategoriesService _getStoresByCategoriesService;
        private readonly IStoreProductsService _storeProductsService;
        private readonly ICalculateTotalSalePricesForSellerService _calculateTotalSalePricesForSellerService;
        private readonly IUpdateProductPriceInAuctionService _updateProductPriceInAuctionService;
        private readonly IGetSellerIdByStoreIdService _getSellerIdByStoreIdService;

        public CategoryController(IGetStoresByCategoriesService getStoresByCategoriesService, IStoreProductsService storeProductsService, IUpdateProductPriceInAuctionService updateProductPriceInAuctionService, ICalculateTotalSalePricesForSellerService calculateTotalSalePricesForSellerService, IGetSellerIdByStoreIdService getSellerIdByStoreIdService)
        {
            _getStoresByCategoriesService = getStoresByCategoriesService;
            _storeProductsService = storeProductsService;
            _updateProductPriceInAuctionService = updateProductPriceInAuctionService;
            _calculateTotalSalePricesForSellerService = calculateTotalSalePricesForSellerService;
            _getSellerIdByStoreIdService = getSellerIdByStoreIdService;
        }

        public async Task<IActionResult> StoresByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var stores = await _getStoresByCategoriesService.GetStoresByCategories(categoryId, cancellationToken);

            return View(stores);
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

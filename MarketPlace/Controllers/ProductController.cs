using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Sellers;
using MarketPlace.Database;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IUpdateProductPriceInAuctionService _updateProductPriceInAuctionService;
        private readonly IGetAuctionWithBidsService _getAuctionWithBidsService;

        public ProductController(IProductDetailService productDetailService, IUpdateProductPriceInAuctionService updateProductPriceInAuctionService, IGetAuctionWithBidsService getAuctionWithBidsService)
        {
            _productDetailService = productDetailService;
            _updateProductPriceInAuctionService = updateProductPriceInAuctionService;
            _getAuctionWithBidsService = getAuctionWithBidsService;
        }

        public async Task<IActionResult> Details(int productId, CancellationToken cancellationToken)
        {
            var product = await _productDetailService.GetProductDetail(productId, cancellationToken);

            var auction = product.Auctions.FirstOrDefault(a => a.StartTime < DateTime.Now && a.EndTime > DateTime.Now);

            if (auction != null)
            {
                var auctionDto = await _getAuctionWithBidsService.GetAuctionWithBids(auction.Id, cancellationToken);

                if (auctionDto != null)
                {
                    await _updateProductPriceInAuctionService.UpdateProductPriceInAuction(auctionDto.Id, cancellationToken);
                }
            }

            product = await _productDetailService.GetProductDetail(productId, cancellationToken);

            return View(product);
        }
    }
}

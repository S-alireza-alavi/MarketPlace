using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IGetInAuctionProductsService _getInAuctionProductsService;
        private readonly IUpdateProductPriceInAuctionService _updateProductPriceInAuctionService;


        public AuctionController(IAuctionService auctionService, IGetInAuctionProductsService getInAuctionProductsService, IUpdateProductPriceInAuctionService updateProductPriceInAuctionService)
        {
            _auctionService = auctionService;
            _getInAuctionProductsService = getInAuctionProductsService;
            _updateProductPriceInAuctionService = updateProductPriceInAuctionService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            await _auctionService.CheckAndUpdateIsRunning(null, cancellationToken);

            await _auctionService.AssignWinningBidsToAuctions(cancellationToken);

            var products = await _getInAuctionProductsService.GetInAuctionProducts(cancellationToken);

            return View(products);
        }
    }
}

using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IGetInAuctionProductsService _getInAuctionProductsService;


        public AuctionController(IAuctionService auctionService, IGetInAuctionProductsService getInAuctionProductsService)
        {
            _auctionService = auctionService;
            _getInAuctionProductsService = getInAuctionProductsService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            await _auctionService.CheckAndUpdateIsRunning(null, cancellationToken);

            var products = await _getInAuctionProductsService.GetInAuctionProducts(cancellationToken);

            return View(products);
        }
    }
}

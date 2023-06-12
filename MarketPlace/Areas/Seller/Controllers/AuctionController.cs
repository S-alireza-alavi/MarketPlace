using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DtoModels.Auctions;
using App.Domain.Core.Entities;
using MarketPlace.Areas.Seller.Models.Auction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class AuctionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICreateAuctionService _createAuctionService;
        private readonly IGetStoreAuctionsService _getStoreAuctionsService;
        private readonly IAuctionService _auctionService;

        public AuctionController(UserManager<ApplicationUser> userManager, ICreateAuctionService createAuctionService, IGetStoreAuctionsService getStoreAuctionsService, IAuctionService auctionService)
        {
            _userManager = userManager;
            _createAuctionService = createAuctionService;
            _getStoreAuctionsService = getStoreAuctionsService;
            _auctionService = auctionService;
        }

        public async Task<IActionResult> Index(int storeId, CancellationToken cancellationToken)
        {
            ViewBag.StoreId = storeId;

            var auctions = await _getStoreAuctionsService.GetStoreAuctions(storeId, cancellationToken);

            await _auctionService.CheckAndUpdateIsRunning(storeId, cancellationToken);

            return View(auctions);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAuction(int storeId, int productId, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);

            var viewModel = new CreateAuctionViewModel
            {
                StoreId = storeId,
                ProductId = productId,
                SellerId = user.Id
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(CreateAuctionViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _createAuctionService.CreateAuctionAsync(new AddAuctionInputDto
                {
                    StoreId = model.StoreId,
                    SellerId = model.SellerId,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    MinimumPrice = model.MinimumPrice,
                    IsRunning = false,
                    ProductId = model.ProductId
                }, cancellationToken);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

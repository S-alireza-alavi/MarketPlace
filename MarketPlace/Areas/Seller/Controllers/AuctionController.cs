using App.Domain.Core.AppServices.Sellers.Commands;
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

        public AuctionController(UserManager<ApplicationUser> userManager, ICreateAuctionService createAuctionService)
        {
            _userManager = userManager;
            _createAuctionService = createAuctionService;
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

                //todo: این عوض شه بعدا
                return Ok();
            }

            return View(model);
        }
    }
}

using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Sellers;
using App.Domain.Core.DtoModels.Bids;
using App.Domain.Core.DtoModels.Commisions;
using App.Domain.Core.DtoModels.OrderItems;
using App.Domain.Core.DtoModels.Orders;
using App.Domain.Core.Entities;
using MarketPlace.Database;
using MarketPlace.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IUpdateProductPriceInAuctionService _updateProductPriceInAuctionService;
        private readonly ICalculateCommissionAmountService _calculateCommissionAmountService;
        private readonly IGetAuctionWithBidsService _getAuctionWithBidsService;
        private readonly IProductService _productService;
        private readonly IBidService _bidService;
        private readonly IOrderService _orderService;
        private readonly ICommissionService _commissionService;
        private readonly IFilterProductsSearchService _filterProductsSearchService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductDetailService productDetailService, IUpdateProductPriceInAuctionService updateProductPriceInAuctionService, IGetAuctionWithBidsService getAuctionWithBidsService, IProductService productService, IBidService bidService, UserManager<ApplicationUser> userManager, IOrderService orderService, ICalculateCommissionAmountService calculateCommissionAmountService, ICommissionService commissionService, IFilterProductsSearchService filterProductsSearchService)
        {
            _productDetailService = productDetailService;
            _updateProductPriceInAuctionService = updateProductPriceInAuctionService;
            _getAuctionWithBidsService = getAuctionWithBidsService;
            _productService = productService;
            _bidService = bidService;
            _userManager = userManager;
            _orderService = orderService;
            _calculateCommissionAmountService = calculateCommissionAmountService;
            _commissionService = commissionService;
            _filterProductsSearchService = filterProductsSearchService;
        }

        public async Task<IActionResult> Details(int productId, CancellationToken cancellationToken)
        {
            string successMessage = TempData["SuccessMessage"] as string;

            ViewBag.SuccessMessage = successMessage;

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

            if (auction != null)
            {
                var remainingTime = auction.EndTime - DateTime.Now;
                ViewBag.RemainingTime = remainingTime;
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterBid(int productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductBy(productId, cancellationToken);

            var viewModel = new BidRegistrationViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductPrice = product.Price
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterBid(BidRegistrationViewModel model, CancellationToken cancellationToken)
        {
            TempData["SuccessMessage"] = "پیشنهاد شما با موفقیت ثبت شد";

            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductBy(model.ProductId, cancellationToken);

                if (product.Auctions.Any(a => a.IsRunning))
                {
                    var currentUser = await _userManager.GetUserAsync(User);

                    var bid = new AddBidInputDto
                    {
                        AuctionId = product.Auctions.FirstOrDefault(a => a.IsRunning).Id,
                        BuyerId = currentUser.Id,
                        BidAmount = model.BidAmount,
                        BidTime = DateTime.Now
                    };

                    await _bidService.CreateBid(bid, cancellationToken);

                    return RedirectToAction("Details", "Product", new { productId = product.Id });
                }
            }
            else
            {
                //todo: create this NoAuction
                return RedirectToAction("NoAuction", "Product");
            }

            return View(model);
        }

        public async Task<IActionResult> Search(string searchPhrase,CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var filteredProducts = await _filterProductsSearchService.FilterProductsSearch(searchPhrase, cancellationToken);

                if (filteredProducts.Count == 0)
                {
                    ViewBag.Message = "نتیجه‌ای برای جستجوی شما یافت نشد.";
                    return View("NoResults");
                }

                return View(filteredProducts);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}

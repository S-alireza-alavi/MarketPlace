using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.StoreAddresses;
using App.Domain.Core.DtoModels.Stores;
using App.Domain.Core.Entities;
using MarketPlace.Areas.Seller.Models;
using MarketPlace.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class StoreController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAddNewStoreService _addNewStoreService;
        private readonly IGetAllStoresBySellerId _getAllStoresBySellerId;
        private readonly IAddNewStoreAddressService _addNewStoreAddressService;

        public StoreController(UserManager<ApplicationUser> userManager, IAddNewStoreService addNewStoreService, IGetAllStoresBySellerId getAllStoresBySellerId, IAddNewStoreAddressService addNewStoreAddressService)
        {
            _userManager = userManager;
            _addNewStoreService = addNewStoreService;
            _getAllStoresBySellerId = getAllStoresBySellerId;
            _addNewStoreAddressService = addNewStoreAddressService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddStoreWithStoreAddressViewModel inputDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var result = await _addNewStoreService.AddNewStore(new AddStoreInputDto
            {
                Name = inputDto.Name,
                SellerId = userId,
                Description = inputDto.Description
            }, cancellationToken);

            await _addNewStoreAddressService.CreateStoreAddress(new AddStoreAddressInputDto
            {
                StoreId = result,
                FullAddress = inputDto.FullAddress
            }, cancellationToken);

            return View(inputDto);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

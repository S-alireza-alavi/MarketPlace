using App.Domain.AppService;
using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Sellers.Commands;
using App.Domain.Core.AppServices.Sellers.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.ProductPhotos;
using App.Domain.Core.DtoModels.Products;
using App.Domain.Core.DtoModels.StoreAddresses;
using App.Domain.Core.DtoModels.Stores;
using App.Domain.Core.Entities;
using MarketPlace.Areas.Seller.Models;
using MarketPlace.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBrandsService _brandsService;
        private readonly IModelService _modelService;
        private readonly IAddNewProductService _addNewProductService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAddProductPhotoService _addNewProductPhotoService;

        public StoreController(UserManager<ApplicationUser> userManager, IAddNewStoreService addNewStoreService, IGetAllStoresBySellerId getAllStoresBySellerId, IAddNewStoreAddressService addNewStoreAddressService, IProductCategoryService productCategoryService, IBrandsService brandsService, IModelService modelService, IAddNewProductService addNewProductService, IWebHostEnvironment webHostEnvironment, IAddProductPhotoService addNewProductPhotoService)
        {
            _userManager = userManager;
            _addNewStoreService = addNewStoreService;
            _getAllStoresBySellerId = getAllStoresBySellerId;
            _addNewStoreAddressService = addNewStoreAddressService;
            _productCategoryService = productCategoryService;
            _brandsService = brandsService;
            _modelService = modelService;
            _addNewProductService = addNewProductService;
            _webHostEnvironment = webHostEnvironment;
            _addNewProductPhotoService = addNewProductPhotoService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddStoreWithStoreAddressViewModel inputDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
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
            }

            return View(inputDto);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StoresList(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var stores = await _getAllStoresBySellerId.GetAllStoresBySellerId(userId, cancellationToken);
            return View(stores);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct(int storeId, CancellationToken cancellationToken)
        {
            ViewBag.StoreId = storeId;

            var categories = await _productCategoryService.GetAllProductCategories();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var brands = await _brandsService.GetAllBrands();
            ViewBag.Brands = brands
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                });

            var models = await _modelService.GetAllModels();
            ViewBag.Models = models
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(int storeId, AddProductViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _addNewProductService.AddNewProduct(new AddProductInputDto
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    BrandId = model.BrandId,
                    StoreId = storeId,
                    Weight = model.Weight,
                    Description = model.Description,
                    ModelId = model.ModelId,
                    Price = model.Price
                }, cancellationToken);

                if (model.ProductPhotoFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProductPhotoFile.FileName);
                    var filePath = Path.Combine("product-photos", fileName);

                    using (var fileStream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, filePath), FileMode.Create))
                    {
                        await model.ProductPhotoFile.CopyToAsync(fileStream);
                    }

                    await _addNewProductPhotoService.AddProductPhoto(new AddProductPhotoInputDto
                    {
                        ProductId = result,
                        FileName = fileName,
                        FilePath = filePath
                    }, cancellationToken);
                }
            }

            return View(model);
        }
    }
}

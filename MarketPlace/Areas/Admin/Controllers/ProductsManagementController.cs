using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Products;
using MarketPlace.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Printing;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsManagementController : Controller
    {
        private readonly IProductsServiceAppService _productsServiceAppService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBrandsService _brandsService;
        private readonly IStoreAppService _storeAppService;
        private readonly IModelService _modelService;

        public ProductsManagementController(IProductsServiceAppService productsServiceAppService, IProductCategoryService productCategoryService, IBrandsService brandsService, IModelService modelService, IStoreAppService storeAppService)
        {
            _productsServiceAppService = productsServiceAppService;
            _productCategoryService = productCategoryService;
            _brandsService = brandsService;
            _modelService = modelService;
            _storeAppService = storeAppService;
        }

        public async Task<IActionResult> Index(string? search, CancellationToken cancellationToken)
        {
            ViewBag.Search = search;

            var products = await _productsServiceAppService.GetAllProducts(search, cancellationToken);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _productCategoryService.GetAllProductCategories();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var brands = await _brandsService.GetAllBrands();
            ViewBag.Brands = brands
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var stores = await _storeAppService.GetAllStores();
            ViewBag.Stores = stores
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelService.GetAllModels();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductInputDto product, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = new Product
                    {
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        BrandId = product.BrandId,
                        StoreId = product.StoreId,
                        Weight = product.Weight,
                        Description = product.Description,
                        Count = product.Count,
                        ModelId = product.ModelId,
                        Price = product.Price,
                        IsActive = product.IsActive
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception("Something went wrong", ex.InnerException);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var categories = await _productCategoryService.GetAllProductCategories();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var brands = await _brandsService.GetAllBrands();
            ViewBag.Brands = brands
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var stores = await _storeAppService.GetAllStores();
            ViewBag.Stores = stores
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelService.GetAllModels();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var dto = await _productsServiceAppService.GetProductBy(id, cancellationToken);
            var viewProduct = new ProductOutputDto
            {
                Id = dto.Id,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId,
                StoreId = dto.StoreId,
                Weight = dto.Weight,
                Description = dto.Description,
                Count = dto.Count,
                ModelId = dto.ModelId,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            return View(viewProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductInputDto product, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            var dto = new EditProductInputDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                StoreId = product.StoreId,
                Weight = product.Weight,
                Description = product.Description,
                Count = product.Count,
                ModelId = product.ModelId,
                Price = product.Price,
                IsActive = product.IsActive
            };

            await _productsServiceAppService.UpdateProduct(dto, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int productId, CancellationToken cancellationToken)
        {
            await _productsServiceAppService.DeleteProduct(productId, cancellationToken);

            return RedirectToAction("Index");
        }
    }
}

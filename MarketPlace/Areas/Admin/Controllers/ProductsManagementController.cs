using App.Domain.Core.AppServices;
using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Products;
using Azure.Identity;
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
        private readonly IConfirmSellersProductServiceAppService _confirmSellersProductServiceAppService;

        public ProductsManagementController(IProductsServiceAppService productsServiceAppService, IProductCategoryService productCategoryService, IBrandsService brandsService, IModelService modelService, IStoreAppService storeAppService, IConfirmSellersProductServiceAppService confirmSellersProductServiceAppService)
        {
            _productsServiceAppService = productsServiceAppService;
            _productCategoryService = productCategoryService;
            _brandsService = brandsService;
            _modelService = modelService;
            _storeAppService = storeAppService;
            _confirmSellersProductServiceAppService = confirmSellersProductServiceAppService;
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
        public async Task<IActionResult> Create(AddProductInputDto input, List<IFormFile> photos, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = new Product
                    {
                        Name = input.Name,
                        CategoryId = input.CategoryId,
                        BrandId = input.BrandId,
                        StoreId = input.StoreId,
                        Weight = input.Weight,
                        Description = input.Description,
                        ModelId = input.ModelId,
                        Price = input.Price,
                        ProductPhotos = new List<ProductPhoto>(),
                        IsActive = input.IsActive
                    };

                    foreach (var photo in photos)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "product-photos", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(stream);
                        }

                        product.ProductPhotos.Add(new ProductPhoto
                        {
                            FileName = fileName,
                            FilePath = filePath
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Something went wrong", ex.InnerException);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(input);
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
                ModelId = dto.ModelId,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            return View(viewProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductInputDto product, CancellationToken cancellationToken)
        {
            //if (ModelState.IsValid)
            //{
            //    return View(product);
            //}

            var dto = new EditProductInputDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                StoreId = product.StoreId,
                Weight = product.Weight,
                Description = product.Description,
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

        [HttpGet]
        public async Task<IActionResult> InActiveIndex(CancellationToken cancellationToken)
        {
            var inActiveproducts = await _confirmSellersProductServiceAppService.GetAllInActiveProducts(cancellationToken);
            return View(inActiveproducts);
        }

        //todo: fix this
        [HttpGet]
        public async Task<IActionResult> ActivateProduct(int productId, CancellationToken cancellationToken)
        {
            await _confirmSellersProductServiceAppService.ConfirmSellersProductAsync(productId, cancellationToken);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> ActivateProduct(CancellationToken cancellationToken)
        //{
        //    await _confirmSellersProductServiceAppService.ConfirmSellersProductAsync(productId, cancellationToken);
        //    return RedirectToAction("InActiveIndex");
        //}
    }
}

using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsManagementController : Controller
    {
        private readonly IProductsServiceAppService _productsServiceAppService;

        public ProductsManagementController(IProductsServiceAppService productsServiceAppService)
        {
            _productsServiceAppService = productsServiceAppService;
        }

        public async Task<IActionResult> Index(string? search, CancellationToken cancellationToken)
        {
            ViewBag.Search = search;

            var products = await _productsServiceAppService.GetAllProducts(search, cancellationToken);

            return View(products);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var product = await _productsServiceAppService.GetProductBy(id, cancellationToken);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductInputDto product, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            await _productsServiceAppService.UpdateProduct(product, cancellationToken);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int productId, CancellationToken cancellationToken)
        {
            await _productsServiceAppService.DeleteProduct(productId, cancellationToken);

            return RedirectToAction("Index");
        }
    }
}

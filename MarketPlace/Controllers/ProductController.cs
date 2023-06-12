using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IActionResult> Details(int productId, CancellationToken cancellationToken)
        {
            var product = await _productDetailService.GetProductDetail(productId, cancellationToken);

            return View(product);
        }
    }
}

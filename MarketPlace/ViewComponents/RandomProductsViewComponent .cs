using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.ViewComponents
{
    public class RandomProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public RandomProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var randomProducts = await _productService.GetRandomProducts(cancellationToken);
            return View(randomProducts);
        }
    }
}

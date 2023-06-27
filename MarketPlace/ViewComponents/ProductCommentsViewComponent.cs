using App.Domain.Core.AppServices.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.ViewComponents
{
    public class ProductCommentsViewComponent : ViewComponent
    {
        private readonly IProductCommentService _productCommentService;

        public ProductCommentsViewComponent(IProductCommentService productCommentService)
        {
            _productCommentService = productCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId, CancellationToken cancellationToken)
        {
            var comments = await _productCommentService.GetConfirmedCommentsForProduct(productId, cancellationToken);
            return View(comments);
        }
    }
}

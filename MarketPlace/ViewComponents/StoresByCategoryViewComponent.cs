using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.ViewComponents
{
    public class StoresByCategoryViewComponent : ViewComponent
    {
        private readonly IGetStoresByCagetoryIdService _getStoresByCagetoryIdService;

        public StoresByCategoryViewComponent(IGetStoresByCagetoryIdService getStoresByCagetoryIdService)
        {
            _getStoresByCagetoryIdService = getStoresByCagetoryIdService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, CancellationToken cancellationToken)
        {
            var stores = await _getStoresByCagetoryIdService.GetStoresByCagetoryId(categoryId, cancellationToken);
            return View(stores);
        }
    }
}

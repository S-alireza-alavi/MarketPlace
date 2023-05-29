using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StoresManagementController : Controller
    {
        private readonly IStoresServiceAppService _storesAppService;

        public StoresManagementController(IStoresServiceAppService storesServiceAppService)
        {
            _storesAppService = storesServiceAppService;
        }

        public async Task<IActionResult> Index(string? search, CancellationToken cancellationToken)
        {
            ViewBag.Search = search;

            var stores = await _storesAppService.GetAllStores(search, cancellationToken);

            return View(stores);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var store = await _storesAppService.GetStoreBy(id, cancellationToken);
            return View(store);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditStoreInputDto store, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                return View(store);
            }

            await _storesAppService.UpdateStore(store, cancellationToken);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int storeId,CancellationToken cancellationToken)
        {
            await _storesAppService.DeleteStore(storeId, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}

using App.Domain.Core.AppServices.Admins.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommissionsManagementController : Controller
    {
        private readonly ICommissionsServiceAppService _commissionsServiceAppService;

        public CommissionsManagementController(ICommissionsServiceAppService commissionsServiceAppService)
        {
            _commissionsServiceAppService = commissionsServiceAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var commissions = await _commissionsServiceAppService.GetCommissions(cancellationToken);
            return View(commissions);
        }
    }
}

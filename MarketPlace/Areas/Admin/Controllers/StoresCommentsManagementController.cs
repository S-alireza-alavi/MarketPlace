using App.Domain.Core.AppServices.Admins.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StoresCommentsManagementController : Controller
    {
        private readonly IConfirmCustomersCommentServiceAppService _confirmCustomersCommentServiceAppService;

        public StoresCommentsManagementController(IConfirmCustomersCommentServiceAppService confirmCustomersCommentServiceAppService)
        {
            _confirmCustomersCommentServiceAppService = confirmCustomersCommentServiceAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var storeComments = await _confirmCustomersCommentServiceAppService.GetAllUnConfirmedStoreComments(cancellationToken);
            return View(storeComments);
        }

        public async Task<IActionResult> ConfirmComment(int commentId, CancellationToken cancellationToken)
        {
            await _confirmCustomersCommentServiceAppService.ConfirmCustomersStoreComment(commentId, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}

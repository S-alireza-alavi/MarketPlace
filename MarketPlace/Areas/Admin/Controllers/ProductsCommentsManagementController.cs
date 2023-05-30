using App.Domain.Core.AppServices.Admins.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsCommentsManagementController : Controller
    {
        private readonly IConfirmCustomersCommentServiceAppService _confirmCustomersCommentServiceAppService;

        public ProductsCommentsManagementController(IConfirmCustomersCommentServiceAppService confirmCustomersCommentServiceAppService)
        {
            _confirmCustomersCommentServiceAppService = confirmCustomersCommentServiceAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var productComments = await _confirmCustomersCommentServiceAppService.GetAllUnConfirmedProductComments(cancellationToken);
            return View(productComments);
        }

        public async Task<IActionResult> ConfirmComment(int commentId, CancellationToken cancellationToken)
        {
            await _confirmCustomersCommentServiceAppService.ConfirmCustomersProductComment(commentId, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}

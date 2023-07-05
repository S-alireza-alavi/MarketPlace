using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.DtoModels.OrderComment;
using App.Domain.Core.DtoModels.ProductComments;
using App.Domain.Core.DtoModels.StoreComments;
using App.Domain.Core.Entities;
using MarketPlace.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILeaveCommentForProductService _leaveCommentForProductService;
        private readonly IGetOrderByIdService _getOrderByIdService;
        private readonly IAddOrderCommentService _addOrderCommentService;

        public CommentController(ILeaveCommentForProductService leaveCommentForProductService, UserManager<ApplicationUser> userManager, IAddOrderCommentService addOrderCommentService)
        {
            _leaveCommentForProductService = leaveCommentForProductService;
            _userManager = userManager;
            _addOrderCommentService = addOrderCommentService;
        }

        [HttpPost]
        public async Task<IActionResult> LeaveComment(CommentViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var comment = new AddProductCommentInputDto
                {
                    Title = model.Title,
                    CommentBody = model.CommentBody,
                    UserId = model.UserId ?? 0,
                    ProductId = model.ProductId,
                    IsConfirmedByAdmin = false,
                    ParentCommentId = null,
                    Rate = null,
                    LikeCount = null,
                    DislikeCount = null
                };

                await _leaveCommentForProductService.LeaveCommentForProduct(comment, cancellationToken);

                return RedirectToAction("Index", "Home");
            }

            return View("Comment", model);
        }

        [HttpGet]
        public async Task<IActionResult> OrderComment(int orderId)
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new AddOrderCommentInputDto 
            {
                OrderId = orderId,
                UserId = user.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrderComment(AddOrderCommentInputDto orderComment, CancellationToken cancellationToken)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            await _addOrderCommentService.AddOrderComment(orderComment, cancellationToken);

            return RedirectToAction("Index", "Home");
        }
    }
}

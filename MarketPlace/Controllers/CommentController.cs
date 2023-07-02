using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.ProductComments;
using App.Domain.Core.DtoModels.StoreComments;
using MarketPlace.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILeaveCommentForProductService _leaveCommentForProductService;

        public CommentController(ILeaveCommentForProductService leaveCommentForProductService)
        {
            _leaveCommentForProductService = leaveCommentForProductService;
        }

        [HttpGet]
        public IActionResult Comment(int productId, int userId)
        {
            var commentViewModel = new CommentViewModel
            {
                ProductId = productId,
                UserId = userId,
                Title = "",
                CommentBody = ""
            };

            return View(commentViewModel);
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
                    UserId = model.UserId,
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
    }
}

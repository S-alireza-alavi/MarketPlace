using App.Domain.Core.AppServices.Customers.Commands;
using App.Domain.Core.DtoModels.StoreComments;
using MarketPlace.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILeaveCommentForStoreService _leaveCommentForStoreService;

        public CommentController(ILeaveCommentForStoreService leaveCommentForStoreService)
        {
            _leaveCommentForStoreService = leaveCommentForStoreService;
        }

        [HttpGet]
        public IActionResult Comment(int storeId, int userId)
        {
            var commentViewModel = new CommentViewModel
            {
                StoreId = storeId,
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
                var comment = new AddStoreCommentInputDto
                {
                    Title = model.Title,
                    CommentBody = model.CommentBody,
                    UserId = model.UserId,
                    StoreId = model.StoreId,
                    IsConfirmedByAdmin = false,
                    ParentCommentId = null,
                    Rate = null,
                    LikeCount = null,
                    DislikeCount = null
                };

                await _leaveCommentForStoreService.LeaveCommentForStore(comment, cancellationToken);

                TempData["SuccessMessage"] = "با تشکر از انتخاب شما";

                return RedirectToAction("Index", "Home");
            }

            return View("Comment", model);
        }
    }
}

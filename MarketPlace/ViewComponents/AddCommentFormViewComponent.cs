using App.Domain.Core.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlace.ViewComponents
{
    public class AddCommentFormViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddCommentFormViewComponent(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var userId = user?.Id;

                var model = new CommentViewModel
                {
                    ProductId = productId,
                    UserId = user.Id
                };

                return View("", model);
            }

            // User is not authenticated, handle this case accordingly
            return Content(""); // or return a different view/component if needed
        }
    }
}

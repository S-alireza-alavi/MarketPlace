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
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userId = user.Id;

            var model = new CommentViewModel
            {
                ProductId = productId,
                UserId = userId
            };

            return View("", model);
        }
    }
}

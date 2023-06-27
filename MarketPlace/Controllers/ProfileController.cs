using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetOrdersByUserIdService _getOrdersByUserIdService;

        public ProfileController(UserManager<ApplicationUser> userManager, IGetOrdersByUserIdService getOrdersByUserIdService)
        {
            _userManager = userManager;
            _getOrdersByUserIdService = getOrdersByUserIdService;
        }

        public IActionResult Index()
        {
            string successMessage = TempData["SuccessMessage"] as string;

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            var profileViewModel = new ProfileViewModel
            {
                CustomerId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "پروفایل شما با موفقیت ویرایش شد.";
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    //display error.
                }
            }

            return View("EditProfile", model);
        }

        public async Task<IActionResult> OrderHistory(CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userOrders = await _getOrdersByUserIdService.GetOrdersByUserId(currentUser.Id, cancellationToken);

            return View(userOrders);
        }
    }
}

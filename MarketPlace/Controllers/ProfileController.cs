using App.Domain.Core.AppServices.Customers.Queries;
using App.Domain.Core.Entities;
using MarketPlace.Entities;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            string successMessage = TempData["SuccessMessage"] as string;

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserInformationViewModel
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.Users
                .Include(u => u.CustomerAddresses)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            var profileViewModel = new ProfileViewModel
            {
                CustomerId = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.CustomerAddresses.FirstOrDefault()?.FullAddress
            };

            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users
                .Include(u => u.CustomerAddresses)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                user.FullName = model.FullName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var address = user.CustomerAddresses.FirstOrDefault();

                if (address == null)
                {
                    address = new CustomerAddress
                    {
                        CustomerId = user.Id,
                        FullAddress = model.Address
                    };
                    user.CustomerAddresses.Add(address);
                }
                else
                {
                    address.FullAddress = model.Address;
                }

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

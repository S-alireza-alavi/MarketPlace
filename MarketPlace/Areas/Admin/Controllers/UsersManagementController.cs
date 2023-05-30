using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DtoModels.Users;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersManagementController : Controller
    {
        //todo: جدا کردن query و commandهای سرویس‌
        private readonly IUsersAppService _usersAppService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UsersManagementController(IUsersAppService usersAppService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _usersAppService = usersAppService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int id, string? search, CancellationToken cancellationToken)
        {
            ViewBag.Search = search;

            var users = await _usersAppService.GetAllUsers(id, search, cancellationToken);
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var roles = await _usersAppService.GetAllRoles(cancellationToken);
            var user = await _usersAppService.GetUser(id);

            ViewBag.Roles = roles.Where(r => !user.Roles.Contains(r.Name)).Select(r => new SelectListItem()
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserInputDto user, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userManager.Users.FirstAsync(x => x.Id == user.Id);

            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.UserName = user.UserName;
                userToUpdate.PhoneNumber = user.PhoneNumber;

                await _userManager.UpdateAsync(userToUpdate);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstAsync(x => x.Id == userId);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}

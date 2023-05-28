using App.Domain.Core.AppServices.Admins.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPlace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersManagementController : Controller
    {
        private readonly IUsersAppService _usersAppService;

        public UsersManagementController(IUsersAppService usersAppService)
        {
            _usersAppService = usersAppService;
        }

        public async Task<IActionResult> Index(int id, string? search, CancellationToken cancellationToken)
        {
            ViewBag.Search = search;

            var users = await _usersAppService.GetAllUsers(id, search, cancellationToken);
            return View(users);
        }

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
        public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
        {
            await _usersAppService.Delete(userId, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}

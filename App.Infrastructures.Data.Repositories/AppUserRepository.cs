using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.AppUser;
using App.Domain.Core.Entities;
using MarketPlace.Database;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructures.Data.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AppUserRepository(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(AppUserInputDto appUser, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser();

            if (appUser.Role == "Customer")
            {
                user = new ApplicationUser()
                {
                    UserName = appUser.UserName,
                    Email = appUser.Email
                };
            }

            if (appUser.Role == "Seller")
            {
                user = new ApplicationUser()
                {
                    UserName = appUser.UserName,
                    Email = appUser.Email
                };
            }

            var result = await _userManager.CreateAsync(user, appUser.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, appUser.Role);
            }

            return result;
        }

        public async Task<SignInResult> Login(AppUserInputDto appUser, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.Email, appUser.Password, true, false);

            return result;
        }
    }
}

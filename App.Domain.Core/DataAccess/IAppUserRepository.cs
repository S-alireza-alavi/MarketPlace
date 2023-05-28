using App.Domain.Core.DtoModels.AppUser;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.DataAccess
{
    public interface IAppUserRepository
    {
        Task<IdentityResult> CreateUser(AppUserInputDto appUser, CancellationToken cancellationToken);
        Task<SignInResult> Login(AppUserInputDto appUser, CancellationToken cancellationToken);
    }
}

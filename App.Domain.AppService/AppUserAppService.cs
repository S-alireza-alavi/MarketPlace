using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AppServices;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.AppUser;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.AppService
{
    public class AppUserAppService : IAppUserAppService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserAppService(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> Register(AppUserInputDto appUser, CancellationToken cancellationToken)
        {
            var result = await _userRepository.CreateUser(appUser, cancellationToken);

            return result;
        }

        public async Task<SignInResult> Login(AppUserInputDto appUser, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Login(appUser, cancellationToken);

            return result;
        }
    }
}

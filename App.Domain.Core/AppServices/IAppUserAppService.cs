﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.DtoModels.AppUser;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.AppServices
{
    public interface IAppUserAppService
    {
        Task<IdentityResult> Register(AppUserInputDto appUser, CancellationToken cancellationToken);
        Task<SignInResult> Login(AppUserInputDto appUser, CancellationToken cancellationToken);
    }
}

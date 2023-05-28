using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins.Commands
{
    public class UsersControlServiceAppService : IUsersControlServiceAppService
    {
        public Task DeleteUser(int userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> EditUser(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUser(int userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

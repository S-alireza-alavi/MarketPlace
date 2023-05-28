using App.Domain.Core.AppServices.Admins.Commands;
using App.Domain.Core.Entities;

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

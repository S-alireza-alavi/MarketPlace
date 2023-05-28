using App.Domain.Core.Entities;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IUsersControlServiceAppService
    {
        Task<ApplicationUser> GetUser(int userId, CancellationToken cancellationToken);
        Task<ApplicationUser> EditUser(ApplicationUser user, CancellationToken cancellationToken);
        Task DeleteUser(int userId, CancellationToken cancellationToken);
    }
}

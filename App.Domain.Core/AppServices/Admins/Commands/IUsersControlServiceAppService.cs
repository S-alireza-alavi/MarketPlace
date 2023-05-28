using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Commands
{
    public interface IUsersControlServiceAppService
    {
        Task<ApplicationUser> GetUser(int userId, CancellationToken cancellationToken);
        Task<ApplicationUser> EditUser(ApplicationUser user, CancellationToken cancellationToken);
        Task DeleteUser(int userId, CancellationToken cancellationToken);
    }
}

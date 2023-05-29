using App.Domain.Core.DtoModels.Roles;
using App.Domain.Core.DtoModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admins.Queries
{
    public interface IUsersAppService
    {
        Task<List<UsersOutputDto>> GetAllUsers(int id, string? search, CancellationToken cancellationToken);
        Task<UsersOutputDto> GetUser(int id);
        Task Update(EditUserInputDto user, string oldPassword, string newPassword, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<RoleOutputDto>> GetAllRoles(CancellationToken cancellationToken);
    }
}

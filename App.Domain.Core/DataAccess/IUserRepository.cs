using App.Domain.Core.DtoModels.Roles;
using App.Domain.Core.DtoModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IUserRepository
    {
        Task<List<UsersOutputDto>> GetAllUsers(int id, string? search, CancellationToken cancellationToken);
        Task<UsersOutputDto> GetUserBy(int id);
        Task DeleteUser(int id, CancellationToken cancellationToken);
        Task<List<RoleOutputDto>> GetAllRoles(CancellationToken cancellationToken);
    }
}

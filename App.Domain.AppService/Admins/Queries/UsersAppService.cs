using App.Domain.Core.AppServices.Admins.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Roles;
using App.Domain.Core.DtoModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins.Queries
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUserRepository _userRepository;

        public UsersAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UsersOutputDto>> GetAllUsers(int id, string? search, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers(id, search, cancellationToken);
            return users;
        }

        public async Task<UsersOutputDto> GetUser(int id)
        {
            var user = await _userRepository.GetUserBy(id);
            return user;
        }

        public async Task Update(EditUserInputDto user, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUser(user, oldPassword, newPassword);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(id, cancellationToken);
        }

        public async Task<List<RoleOutputDto>> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _userRepository.GetAllRoles(cancellationToken);
            return roles;
        }
    }
}

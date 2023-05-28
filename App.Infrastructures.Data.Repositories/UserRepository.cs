using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Roles;
using App.Domain.Core.DtoModels.Users;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<UsersOutputDto>> GetAllUsers(int id, string? search, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Select(u => new UsersOutputDto
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName
            }).ToListAsync(cancellationToken);

            foreach (var item in users)
            {
                var user = await _userManager.FindByIdAsync(item.Id.ToString());
                var roles = await _userManager.GetRolesAsync(user);
                item.Roles = roles.ToList();
            }

            if (string.IsNullOrEmpty(search))
            {
                if (id == 1)
                {
                    users = users.Where(x => x.Roles.Count == 1).ToList();
                }
                if (id == 2)
                {
                    users = users.Where(x => x.Roles.Count == 2).ToList();
                }

                return users;
            }
            else
            {
                users = users
                    .Where(x => x.UserName.Contains(search) || x.Email.Contains(search))
                    .ToList();

                return users;
            }
        }

        public async Task<UsersOutputDto> GetUserBy(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            UsersOutputDto userDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            var roles = await _userManager.GetRolesAsync(user);
            userDto.Roles = roles.ToList();

            return userDto;
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                await _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex.InnerException);
            }
        }

        public async Task<List<RoleOutputDto>> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync(cancellationToken);

            var roleDtos = roles.Select(r => new RoleOutputDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return roleDtos;
        }

    }
}

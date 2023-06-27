using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Roles;
using App.Domain.Core.DtoModels.Users;
using App.Domain.Core.Entities;
using MarketPlace.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly AppDbContext _context;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<List<UsersOutputDto>> GetAllUsers(int id, string? search, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Select(u => new UsersOutputDto
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber
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
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };

            var roles = await _userManager.GetRolesAsync(user);
            userDto.Roles = roles.ToList();

            var medal = await _context.Medals.FirstOrDefaultAsync(m => m.SellerId == id);
            if (medal != null)
            {
                userDto.Medal = new Medal
                {
                    Id = medal.Id,
                    SellerId = medal.SellerId,
                };
            }

            return userDto;
        }

        public async Task UpdateUser(EditUserInputDto user, string oldPassword, string newPassword)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.Id.ToString());

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                var result = await _userManager.CheckPasswordAsync(userToUpdate, oldPassword);

                if (result)
                {
                    await _userManager.ChangePasswordAsync(userToUpdate, oldPassword, newPassword);
                }

                userToUpdate.Email = user.Email;
                userToUpdate.UserName = user.UserName;
                userToUpdate.PhoneNumber = user.PhoneNumber;
                userToUpdate.CustomerAddresses = user.CustomerAddresses.ToList();

                var roles = await _userManager.GetRolesAsync(userToUpdate);
                await _userManager.RemoveFromRolesAsync(userToUpdate, roles);
                await _userManager.AddToRolesAsync(userToUpdate, user.Roles);
                await _userManager.UpdateAsync(userToUpdate);
            }
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

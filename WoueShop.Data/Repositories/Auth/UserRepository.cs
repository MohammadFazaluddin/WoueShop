﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.ReturnModels;
using WouShop.Database;

namespace WoueShop.Data.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(DatabaseContext database, UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AssignRoleToUser(Guid userId, string role)
        {
            ApplicationUser user = await GetUserById(userId);

            var result = await _userManager.AddToRoleAsync(user, role);

            return result;
        }

        public Task<IdentityResult?> CreateUser(UserInfoModel user)
        {
            var result = _userManager.CreateAsync(new()
                        {
                            Id = user.UserId,
                            Email = user.Email,
                            UserName = user.Email,
                            FullName = user.Name,
                        }, user.Password);

            return result;
        }

        public Task<IdentityResult> DeleteUserById(Guid userid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserById(Guid userid)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueEmail(string email)
        {
            var result = _database.Users.Any(e => e.Email.ToLower().Equals(email));

            return result;
        }

        public Task<IdentityResult> Update(Guid userId, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}

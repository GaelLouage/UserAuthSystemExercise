using Microsoft.AspNetCore.Identity;
using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Data.Interfaces;
using UserAuthenticationSystem.Extensions;
using UserAuthenticationSystem.Helpers;
using UserAuthenticationSystem.Models;
using UserAuthenticationSystem.Services.Interfaces;

namespace UserAuthenticationSystem.Services.Classes
{
    public class SimpleAuthenticator : IUserAuthenticator
    {
        private readonly IUserService _userService;

        public SimpleAuthenticator(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> AuthenticateAsync(UserData user)
        {
            var users = await _userService.GetAsync();
            var userExists = users.UserCredentialsExists(user);
            if (userExists)
            {
                return true;
            }
            return false;
        }
        public async Task RegisterAsync(UserData dummyUser)
        {
            string salt = HashSaltHelper.GenerateSalt();
            // Hash the password with the salt
            string passwordHash = HashSaltHelper.HashPassword(dummyUser.Password, salt);
            var users = await _userService.GetAsync();
            var userExists = users.UserExists(dummyUser);
            if (userExists is false) 
            {
                // Create a new user entity
                var userEntity = new UserDbEntity
                {
                    UserName = dummyUser.UserName,
                    PasswordHash = passwordHash,
                    Salt = salt
                };
                await _userService.WriteAsync(userEntity);
            }
        }
    }
}

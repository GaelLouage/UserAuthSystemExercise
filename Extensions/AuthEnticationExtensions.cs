using Microsoft.AspNetCore.OutputCaching;
using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Helpers;
using UserAuthenticationSystem.Models;

namespace UserAuthenticationSystem.Extensions
{
    public static class AuthEnticationExtensions
    {
        public static bool UserExists(this List<UserDbEntity> users, UserDbEntity user )
        {

            return users
                .Exists(x => x.UserName == user.UserName);
        }

        public static bool UserExists(this List<UserDbEntity> users,  UserData dummyUser)
        {
            return users
                     .Exists(x => x.UserName == dummyUser.UserName);
        }

        public static bool UserCredentialsExists(this List<UserDbEntity> users, UserData user)
        {
            var userToFind = users.FirstOrDefault(x => x.UserName == user.UserName);
            if (userToFind == null)
            {
                return false;
            }

            // Hash the input password using the stored salt
            string inputHashedPassword = HashSaltHelper.HashPassword(user.Password, userToFind.Salt);

            // Compare the hashed input password with the stored hashed password
            bool isPasswordCorrect = inputHashedPassword.Equals(userToFind.PasswordHash);

            return isPasswordCorrect;
        }
    }
}

using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Models;
using UserAuthenticationSystem.Services.Interfaces;

namespace UserAuthenticationSystem.Manager
{
    public class UserManager
    {
        public async Task RegisterUserAsync(IUserAuthenticator userAuthenticator, UserData user)
        {
           await userAuthenticator.RegisterAsync(user);
        }

        public async Task<bool> LoginUserAsync(IUserAuthenticator userAuthenticator, UserData user)
        {
            var authIsSucces = await userAuthenticator.AuthenticateAsync(user);
            if (authIsSucces)
            {
                return true;
            }
            return false;
        }
    }
}

using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Models;

namespace UserAuthenticationSystem.Services.Interfaces
{
    public interface IUserAuthenticator
    {
        Task<bool> AuthenticateAsync(UserData user);
        Task RegisterAsync(UserData dummyUser);
    }
}
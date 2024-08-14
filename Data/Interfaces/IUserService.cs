using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Models;

namespace UserAuthenticationSystem.Data.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDbEntity>> GetAsync();
        Task WriteAsync(UserDbEntity userEntity);
    }
}
using Newtonsoft.Json;
using System.Text;
using UserAuthenticationSystem.Data.Interfaces;
using UserAuthenticationSystem.Helpers;
using UserAuthenticationSystem.Models;

namespace UserAuthenticationSystem.Data.Classes
{
    public class UserService : IUserService
    {
        private const string USERS_FILE = "Users.json";
        private string _filePath => Path.Combine(Environment.CurrentDirectory, USERS_FILE);

        private List<UserDbEntity> _users;
        public UserService()
        {
            if (File.Exists(
               _filePath) is false && _users is null)
            {
                var fs = File.Create(_filePath);
                fs.Close();
            }
        }
        public async Task WriteAsync(UserDbEntity userEntity)
        {
            _users = await GetAsync();
            var userExist = _users.Exists(x => x.UserName == userEntity.UserName);
            if (userExist is false)
            {
                _users.Add(userEntity);
                await WriteUserAsync();
            }
        }
        public async Task<List<UserDbEntity>> GetAsync()
        {
            var fileData = await File.ReadAllTextAsync(_filePath);
            _users = JsonConvert.DeserializeObject<List<UserDbEntity>>(fileData) ?? new List<UserDbEntity>();
            return _users;
        }


        private async Task WriteUserAsync()
        {
            var users = JsonConvert.SerializeObject(_users, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, users);
        }


        private void WriteUser()
        {
            var users = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(_filePath, users);
        }
    }
}

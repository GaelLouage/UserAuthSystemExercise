namespace UserAuthenticationSystem.Models
{
    public class UserDbEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}

namespace UserAuthenticationSystem.Data.Classes
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public static List<UserData> Users { get; set; } = new List<UserData>()
   {
       new UserData { Password = "Gael123", UserName = "Gael" },
       new UserData { Password = "David123", UserName = "David" },
       new UserData { Password = "Estelle123", UserName = "Estelle" },
       new UserData { Password = "Quinten123", UserName = "Quinten" },
   };
    }
}

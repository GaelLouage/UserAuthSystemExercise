using System.Text;
using UserAuthenticationSystem.Data.Classes;
using UserAuthenticationSystem.Data.Interfaces;
using UserAuthenticationSystem.Manager;
using UserAuthenticationSystem.Services.Classes;
using UserAuthenticationSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserAuthenticator, SimpleAuthenticator>();
var app = builder.Build();

app.MapGet("/", async (IUserService userService) =>
{
 

    var registerTest = new UserManager();
    var loginIsSucces = await registerTest.LoginUserAsync(new SimpleAuthenticator(userService), new UserData()
    {
        Password = "Bart123",
        UserName = "Bart"
    });


    var users = await userService.GetAsync();

  var usersText = new StringBuilder();

    foreach (var user in users)
    {
        usersText.AppendLine($"{nameof(user.UserName)}: {user.UserName}")
                 .AppendLine($"{nameof(user.PasswordHash)}: {user.PasswordHash}")
                 .AppendLine($"{nameof(user.Salt)}: {user.Salt}")
                 .AppendLine();
    }
    var loginSuccess = loginIsSucces is true ? "Logged in." : "Access denied.";
    usersText.AppendLine(loginSuccess);
    return usersText.ToString();
});

app.Run();

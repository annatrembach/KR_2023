using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.Users;
using System.Security.Cryptography;
using KR_1.UI.Base;

namespace KR_1.UI;

public class AddUserUI : IUserInterface
{
    IUserService userService;
    public AddUserUI(DbContext context)
    {
        userService = new UserService(context);
    }
    public string Action()
    {
        //username
        string userName;
        Console.WriteLine("Enter User Name:");
        userName = Console.ReadLine();
        //login
        string login;
        do
        {
            Console.WriteLine("Enter User Login");
            login = Console.ReadLine();
        }
        while (userService.ReadAccountbyLogin(login) != null);
        //password
        string password;
        Console.WriteLine("Enter User Password");
        password = Console.ReadLine();

        User userEntity = new User(userName, login, password);

        try
        {
            var result = userService.UserRegistration(userEntity);
            return "User added";
        }
        catch (Exception e)
        {
            return $"Can`t add user. {e.Message}";
        }
    }
    public string Show()
    {
        return "Add User.";
    }
}

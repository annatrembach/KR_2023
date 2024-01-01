using KR_1.Database.Entity;
using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.UI.Base;

namespace KR_1.UI;

public class UserInfoByIdUI : IUserInterface
{
    IUserService userService;
    UserEntity userEntity = new UserEntity();
    public UserInfoByIdUI(DbContext context)
    {
        userService = new UserService(context);
    }
    public string Action()
    {
        Console.WriteLine("Enter User id:");
        int userid;
        var validId = int.TryParse(Console.ReadLine(), out userid);
        if (!validId)
            return "Can`t find user. Invalid ID.";
        var user = userService.ReadAccountbyId(userid); ;
        string result = "";
        result += user.GetInfo();
        return result;
    }
    public string Show()
    {
        return $"Show User info by Id";
    }
}

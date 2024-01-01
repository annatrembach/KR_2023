using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.UI.Base;

namespace KR_1.UI;

public class UsersInfoUI : IUserInterface
{
    IUserService userService;
    public UsersInfoUI(DbContext context)
    {
        userService = new UserService(context);
    }
    public string Action()
    {
        var users = userService.ReadAccounts();
        string result = "";
        foreach (var userEntity in users)
        {
            result += userEntity.GetInfo() + "\n";
        }
        return result;
    }
    public string Show()
    {
        return "Show all users";
    }
}

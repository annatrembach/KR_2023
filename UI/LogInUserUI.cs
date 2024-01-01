using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.UI.Base;
using KR_1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR_1.Database.Entity;

namespace KR_1.UI
{
    public class LogInUserUI : IUserInterface
    {
        IUserService userService;
        public LogInUserUI(DbContext context)
        {
            userService = new UserService(context);
        }
        public string Action()
        {
            //login
            string login;
            do
            {
                Console.WriteLine("Enter User Login");
                login = Console.ReadLine();
            }
            while (userService.ReadAccountbyLogin(login) == null);
            User.CurrentUser = userService.ReadAccountbyLogin(login);
            //password
            string password;
            do
            {
                Console.WriteLine("Enter User Password");
                password = Console.ReadLine();
            }
            while (User.CurrentUser.Password != password);
            return "User Log In successfully";
        }
        public string Show()
        {
            return "Log In User.";
        }
    }
}

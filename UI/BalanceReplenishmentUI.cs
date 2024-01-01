using KR_1.Database;
using KR_1.Database.Entity;
using KR_1.Database.Service;
using KR_1.Database.Service.Base;
using KR_1.UI.Base;
using KR_1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_1.UI
{
    public class BalanceReplenishmentUI : IUserInterface
    {
        IUserService userService;
        public BalanceReplenishmentUI(DbContext context)
        { 
            userService = new UserService(context);
        }
        public string Action()
        {
            int changing;
            Console.WriteLine("Enter the amount by which you want to replenish the balance");
            var validchanging = int.TryParse(Console.ReadLine(), out changing);
            if (!validchanging)
                return "Invalid Sum";
            User.CurrentUser.Balance = User.CurrentUser.Balance + changing;
            userService.UpdateUser(User.CurrentUser);
            return "Successfull Balance replenishment";
        }
        public string Show()
        {
            return "Balance Replenishment";
        }
        
        
    }
}

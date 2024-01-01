using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR_1.UI.Base;
using KR_1.Users;

namespace KR_1.UI
{
    public class PurchaseInfoUI : IUserInterface
    {
        IPurchaseService purchaseService;
        int userId = User.CurrentUser.UserId;
        public PurchaseInfoUI(DbContext context)
        {
            purchaseService = new PurchaseService(context);
        }
        public string Action()
        {
            var purchases = purchaseService.ReadPurchasesByUserId(userId);
            string result = "";
            foreach (var purchase in purchases)
            {
                result += purchase.GetInfo() + "\n";
            }
            return result;
        }
        public string Show()
        {
            return "Show all User Purchases";
        }
    }
}

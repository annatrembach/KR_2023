using KR_1.Database;
using KR_1.Database.Entity;
using KR_1.Database.Service;
using KR_1.Database.Service.Base;
using KR_1.Purchases;
using KR_1.UI.Base;
using KR_1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_1.UI
{
    public class MakePurchaseUI : IUserInterface
    {
        IPurchaseService purchaseService;
        IProductService productService;
        IUserService userService;
        public MakePurchaseUI(DbContext context)
        {
            userService = new UserService(context);
            purchaseService = new PurchaseService(context);
            productService = new ProductService(context);
        }
        public string Action()
        {
            int productId;
            do
            {
                Console.WriteLine("Enter Product Id");
                var validId = int.TryParse(Console.ReadLine(), out productId);
                if (!validId)
                    return "Can`t find Product. Invalid ID.";
            } while (productService.ReadProductbyId(productId) == null);

            User user = User.CurrentUser;
            var product = productService.ReadProductbyId(productId);

            int countOfProducts;
            Console.WriteLine("Enter Count of Products");
            var validCountId = int.TryParse(Console.ReadLine(), out countOfProducts);
            if(!validCountId)
                return "Invalid Count.";
            if(User.CurrentUser.Balance < product.Cost * countOfProducts)
            {
                return $"Can`t make purchase. Fill up Balance, please";
            }
            Purchase purchase = new Purchase(user, product, countOfProducts);
            try
            {
                var result = purchaseService.CreatePurchase(purchase);
                User.CurrentUser.Balance = User.CurrentUser.Balance - product.Cost * countOfProducts;
                userService.UpdateUser(User.CurrentUser);
                return "Purchase made.";
            }
            catch (Exception e)
            {
                return $"Can`t make purchase. {e.Message}";
            }
        }
        public string Show()
        {
            return "Make Purchase";
        }
    }
}

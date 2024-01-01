using KR_1.Database;
using KR_1.UI;
using KR_1.UI.Base;
using KR_1.Users;

namespace KR_1;

public class Main
{
    public List<IUserInterface> LoginRegistration(DbContext context)
    {
        return new List<IUserInterface>
        {
                new LogInUserUI(context),
                new AddUserUI(context)
                
        };
    }
    public List<IUserInterface> Setup(DbContext context)
    {
        return new List<IUserInterface>
        {
                new MakePurchaseUI(context),
                new PurchaseInfoUI(context),
                new UsersInfoUI(context),
                new UserInfoByIdUI(context),
                new AddProductUI(context),
                new ProductsInfoUI(context),
                new ProductInfoByIdUI(context),
                new BalanceReplenishmentUI(context)
        };
    }
}
public class Program
{
    static void Main()
    {
        DbContext context = new DbContext();
        var uis = new Main().LoginRegistration(context);
        while (true)
        {
            if(User.CurrentUser == null)
            {
                uis = new Main().LoginRegistration(context);
            }
            else
            {
                uis = new Main().Setup(context);
            }
            Console.WriteLine("Choose task for start");
            for (int i = 0; i < uis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {uis[i].Show()}");
            }
            var key = Console.ReadLine();

            if (key == "q")
                return;
            int actionIndex;
            var isInt = int.TryParse(key, out actionIndex);
            if (isInt == true && actionIndex <= uis.Count && actionIndex > 0)
                Console.WriteLine(uis[actionIndex - 1].Action());
            else
                Console.WriteLine($"Invalid value. Can`t parse {key}. Values must be in range [1:{uis.Count}].");
        }

    }
}
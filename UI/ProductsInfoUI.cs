using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.UI.Base;

namespace KR_1.UI;

public class ProductsInfoUI : IUserInterface
{
    IProductService productService;
    public ProductsInfoUI(DbContext context)
    {
        productService = new ProductService(context);
    }
    public string Action()
    {
        var products = productService.ReadProducts();
        string result = "";
        foreach (var productEntity in products)
        {
            result += productEntity.GetInfo() + "\n";
        }
        return result;
    }
    public string Show()
    {
        return "Show all products";
    }
}

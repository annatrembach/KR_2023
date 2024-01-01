using KR_1.Database.Entity;
using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.UI.Base;

namespace KR_1.UI;

public class ProductInfoByIdUI : IUserInterface
{
    IProductService productService;
    ProductEntity productEntity = new ProductEntity();
    public ProductInfoByIdUI(DbContext context)
    {
        productService = new ProductService(context);
    }
    public string Action()
    {
        Console.WriteLine("Enter Product id:");
        int productid;
        var validId = int.TryParse(Console.ReadLine(), out productid);
        if (!validId)
            return "Can`t find product. Invalid ID.";
        var product = productService.ReadProductbyId(productid); ;
        string result = "";
        result += product.GetInfo();
        return result;
    }
    public string Show()
    {
        return $"Show Product info by Id";
    }
}

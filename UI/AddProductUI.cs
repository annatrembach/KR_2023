using KR_1.Database.Service.Base;
using KR_1.Database.Service;
using KR_1.Database;
using KR_1.Products;
using KR_1.UI.Base;

namespace KR_1.UI;

public class AddProductUI : IUserInterface
{
    IProductService productService;
    public AddProductUI(DbContext context)
    {
        productService = new ProductService(context);
    }
    public string Action()
    {
        //name
        string productName;
        Console.WriteLine("Enter Product Name:");
        productName = Console.ReadLine();

        //cost
        int productCost;
        Console.WriteLine("Enter Product Cost:");
        var validCost = int.TryParse(Console.ReadLine(), out productCost);
        if (!validCost)
            return "Can`t create user. Invalid Cost.";

        StandartProduct productEntity = new StandartProduct(productName, productCost);

        try
        {
            var result = productService.CreateProduct(productEntity);
            return "Product added";
        }
        catch (Exception e)
        {
            return $"Can`t add product. {e.Message}";
        }
    }
    public string Show()
    {
        return "Add Product.";
    }
}
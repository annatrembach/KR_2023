using KR_1.Products;

namespace KR_1.Database.Service.Base;

public interface IProductService
{
    public bool CreateProduct(StandartProduct product);
    public List<StandartProduct> ReadProducts();
    public StandartProduct ReadProductbyId(int searchId);
}

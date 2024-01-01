using KR_1.Database.Entity;
using KR_1.Database.Repository.Base;

namespace KR_1.Database.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DbContext dbcontext;
    public ProductRepository(DbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }
    public void Create(ProductEntity product)
    {
        dbcontext.Products.Add(product);
    }

    public void Delete(int Id)
    {

        dbcontext.Products.Remove(ReadProductbyId(Id));
    }

    public ProductEntity ReadProductbyId(int searchId)
    {
        foreach (ProductEntity product in Read())
        {
            if (product.Id == searchId)
            {
                return product;
            }
        }
        return null;
    }

    public IEnumerable<ProductEntity> Read()
    {
        return dbcontext.Products;
    }

    public void Update(ProductEntity product)
    {
        dbcontext.Products.Remove(ReadProductbyId(product.Id));
        dbcontext.Products.Add(product);
    }
}

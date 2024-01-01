using KR_1.Database.Entity;
using KR_1.Database.Repository.Base;
using KR_1.Database.Repository;
using KR_1.Database.Service.Base;
using KR_1.Products;

namespace KR_1.Database.Service;

public class ProductService : IProductService
{
    private IProductRepository productRepository;

    public ProductService(DbContext dbcontext)
    {
        productRepository = new ProductRepository(dbcontext);
    }

    private StandartProduct Map(ProductEntity product)
    {
        return new StandartProduct(product.Id, product.Name, product.Cost);
    }

    public bool CreateProduct(StandartProduct product)
    {
        productRepository.Create(
        new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost
        }
        );
        return true;
    }

    public List<StandartProduct> ReadProducts()
    {
        List<StandartProduct> products = new List<StandartProduct>();
        foreach (ProductEntity product in productRepository.Read())
        {
            products.Add(Map(product));
        }
        return products;
    }

    public StandartProduct ReadProductbyId(int searchId)
    {
        return Map(productRepository.ReadProductbyId(searchId));
    }
}

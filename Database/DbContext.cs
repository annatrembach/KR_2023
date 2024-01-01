using KR_1.Database.Entity;

namespace KR_1.Database;

public class DbContext
{
    public List<UserEntity> Users { get; set; }
    public List<ProductEntity> Products { get; set; }
    public List<PurchaseEntity> Purchases { get; set; }
    public DbContext()
    { 
        Users = new List<UserEntity>
        {
            new UserEntity {Id = 1, UserName = "Anna", Login = "anna", Password = "qwerty"},
            new UserEntity {Id = 2, UserName = "Anastasiia", Login = "anastasiia", Password = "qwerty"},
            new UserEntity {Id = 3, UserName = "Diana", Login = "diana", Password = "qwerty"}
        };
        Products = new List<ProductEntity>
        {
            new ProductEntity {Id = 1, Name = "Book1", Cost = 300},
            new ProductEntity {Id = 2, Name = "Book2", Cost = 400},
            new ProductEntity {Id = 3, Name = "Book3", Cost = 500},
            new ProductEntity {Id = 4, Name = "Book4", Cost = 600},
            new ProductEntity {Id = 5, Name = "Book5", Cost = 700},
            new ProductEntity {Id = 6, Name = "Book6", Cost = 800}
        };
        Purchases = new List<PurchaseEntity>();
    }
}

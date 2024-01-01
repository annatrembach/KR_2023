using KR_1.Database.Repository.Base;
using KR_1.Database.Repository;
using KR_1.Database.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR_1.Database.Entity;
using KR_1.Users;
using KR_1.Purchases;
using KR_1.Products;

namespace KR_1.Database.Service
{
    public class PurchaseService : IPurchaseService
    {
        private IUserService userService;
        private IPurchaseRepository purchaseRepository;
        private IProductService productService;

        public PurchaseService(DbContext dbcontext)
        {
            userService = new UserService(dbcontext);
            purchaseRepository = new PurchaseRepository(dbcontext);
            productService = new ProductService(dbcontext);
        }

        private Purchase Map(PurchaseEntity purchase)
        {
            if (purchase == null)
            {
                return null;
            }
            var user = userService.ReadAccountbyId(purchase.UserId);
            var product = productService.ReadProductbyId(purchase.ProductId);
            return new Purchase(purchase.Id, user, product, purchase.CountOfProducts);

        }
        public bool CreatePurchase(Purchase purchase)
        {
            purchaseRepository.Create(
            new PurchaseEntity
            {
                Id = purchase.Id,
                UserId = purchase.User.UserId,
                ProductId = purchase.Product.Id,
                CountOfProducts = purchase.CountOfProducts
            }
            );
            return true;
        }
        public List<Purchase> ReadPurchasesByUserId(int searchId)
        {
            List<Purchase> purchases = new List<Purchase>();
            foreach(PurchaseEntity purchase in purchaseRepository.ReadPurchesesByUserId(searchId))
            {
                purchases.Add(Map(purchase));
            }
            return purchases;
        }

        public List<Purchase> ReadPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            foreach (PurchaseEntity purchase in purchaseRepository.Read())
            {
                purchases.Add(Map(purchase));
            }
            return purchases;
        }
        public Purchase ReadPurchasebyId(int searchId)
        {
            return Map(purchaseRepository.ReadPurchasebyId(searchId));
        }
    }
}

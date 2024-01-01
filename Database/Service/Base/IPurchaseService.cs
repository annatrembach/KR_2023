using KR_1.Products;
using KR_1.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_1.Database.Service.Base
{
    public interface IPurchaseService
    {
        public bool CreatePurchase(Purchase purchase);
        public List<Purchase> ReadPurchases();
        public List<Purchase> ReadPurchasesByUserId(int searchId);
        public Purchase ReadPurchasebyId(int searchId);
    }
}

using KR_1.Database.Entity;
using KR_1.Database.Repository.Base;
using KR_1.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_1.Database.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DbContext dbcontext;
        public PurchaseRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Create(PurchaseEntity purchase)
        {
            dbcontext.Purchases.Add(purchase);
        }

        public void Delete(int Id)
        {

            dbcontext.Purchases.Remove(ReadPurchasebyId(Id));
        }

        public PurchaseEntity ReadPurchasebyId(int searchId)
        {
            foreach (PurchaseEntity purchase in Read())
            {
                if (purchase.Id == searchId)
                {
                    return purchase;
                }
            }
            return null;
        }

        public IEnumerable<PurchaseEntity> ReadPurchesesByUserId(int searchId) 
        {
            List<PurchaseEntity> purchases = new List<PurchaseEntity>();
            foreach (PurchaseEntity purchase in Read())
            {
                if (purchase.UserId == searchId)
                {
                    purchases.Add(purchase);
                }
            }
            return purchases;
        }

        public IEnumerable<PurchaseEntity> Read()
        {
            return dbcontext.Purchases;
        }

        public void Update(PurchaseEntity purchase)
        {
            dbcontext.Purchases.Remove(ReadPurchasebyId(purchase.Id));
            dbcontext.Purchases.Add(purchase);
        }
    }
}

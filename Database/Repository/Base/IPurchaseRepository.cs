using KR_1.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_1.Database.Repository.Base
{
    public interface IPurchaseRepository
    {
        public void Create(PurchaseEntity purchase);
        public IEnumerable<PurchaseEntity> Read();
        public void Update(PurchaseEntity purchase);
        public void Delete(int Id);
        public IEnumerable<PurchaseEntity> ReadPurchesesByUserId(int searchId);
        public PurchaseEntity ReadPurchasebyId(int searchId);

    }
}

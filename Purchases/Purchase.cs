using KR_1.Products;
using KR_1.UI;
using KR_1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KR_1.Purchases
{
    public class Purchase
    {
        public Purchase(int id, User user, StandartProduct product, int countOfProducts)
        {
            Id = id;
            User = user;
            Product = product;
            CountOfProducts = countOfProducts;
        }
        public Purchase(User user, StandartProduct product, int countOfProducts) 
        {
            Id = LastId + 1;
            User = user;
            Product = product;
            CountOfProducts = countOfProducts;
            LastId = Id;
        }
        public int Id { get; set; } 
        static public int LastId { get; set; }
        public User User { get; set; }
        public StandartProduct Product { get; set; }
        public int CountOfProducts { get; set; }
        public string GetInfo()
        {
            return $"{Id}, {User.UserName}, {Product.Name}, {CountOfProducts}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreMvcApplicationFirstWeek.Models;

namespace NetCoreMvcApplicationFirstWeek.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private static List<Product> products;

        public ProductRepository()
        {
            if (products == null)
            {
                products = new List<Product>()
                                {
                                    new Product() { Id = 1, Name = "Test1", Price= 1, Stock = 12},
                                    new Product() { Id = 2, Name = "Test2", Price= 2, Stock = 15},
                                    new Product() { Id = 3, Name = "Test3", Price= 3, Stock = 20},
                                };
            }
        }

        public void Create(Product p)
        {
            products.Add(p);
        }

        public IEnumerable<Product> GetAll()
        {
            return products.ToList();
        }

        public Product GetById(int Id)
        {
            return products.SingleOrDefault(p => p.Id == Id);
        }
    }
}

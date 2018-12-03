using NetCoreMvcApplicationFirstWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcApplicationFirstWeek.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int Id);
        void Create(Product p);
    }
}

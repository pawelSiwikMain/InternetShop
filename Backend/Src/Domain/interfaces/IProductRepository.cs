using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(string category);
        Product Get(int id);
        Product Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}

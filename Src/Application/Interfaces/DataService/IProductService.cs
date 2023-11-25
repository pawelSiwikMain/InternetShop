using Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IProductService 
    {
        ProductDto AddProduct(CreateProductDto product);
        ProductDto GetByIdProduct(string id);
        IEnumerable<ProductDto> GetAllProducts();
        void UpdateProduct(ProductDto product);
        void DeleteProduct(string id);
    }
}

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
        ProductDto GetByIdProduct(int id);
        IEnumerable<ProductDto> GetByIdCategory(string category);
        IEnumerable<ProductDto> GetAllProducts();
        void UpdateProduct(UpdateProductDto product);
        void DeleteProduct(int id);
    }
}

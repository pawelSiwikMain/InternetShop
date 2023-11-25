using Application.Dtos.ProductDtos;
using Application.Interfaces.DataService;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public ProductDto AddProduct(CreateProductDto product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductDto GetByIdProduct(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

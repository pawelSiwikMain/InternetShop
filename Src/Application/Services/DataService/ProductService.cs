using Application.Dtos.ProductDtos;
using Application.Interfaces.DataService;
using AutoMapper;
using Domain.entities;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }

        public ProductDto AddProduct(CreateProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _productRepository.Add(newProduct);
            return _mapper.Map<ProductDto>(newProduct);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetByIdProduct(int id)
        {
            var product = _productRepository.Get(id);
            return _mapper.Map<ProductDto>(product);
        }

        public void UpdateProduct(UpdateProductDto product)
        {
            var existingProduct = _productRepository.Get(product.Id);
            var newProcuct = _mapper.Map(product, existingProduct);
            _productRepository.Update(newProcuct);
        }
    }
}

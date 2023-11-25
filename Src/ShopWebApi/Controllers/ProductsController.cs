using Application.Dtos.ProductDtos;
using Application.Interfaces.DataService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var product = _productService.GetByIdProduct(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create(CreateProductDto product) 
        {
            var resoult = _productService.AddProduct(product);
            return Created($"api/products/{resoult.Id}", resoult);
        }
        [HttpPut]
        public IActionResult Update(UpdateProductDto product) 
        {
            _productService.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}

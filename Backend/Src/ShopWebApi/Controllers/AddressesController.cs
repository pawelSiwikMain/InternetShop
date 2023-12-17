using Application.Dtos.AddressDtos;
using Application.Interfaces.DataService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var address = _addressService.GetByIdAddress(id);
            return Ok(address);
        }

        [HttpGet("userId/{id}")]
        public IActionResult GetByUserId(int id) 
        {
            var address = _addressService.GetByUserId(id);
            return Ok(address);
        }
        [HttpPost]
        public IActionResult Create(CreateAddressDto address)
        {
            var resoult = _addressService.AddAddress(address);
            return Created($"api/addresses/{resoult.Id}", resoult);
        }
        [HttpPut]
        public IActionResult Update(UpdateAddressDto address) 
        {
            _addressService.UpdateAddress(address);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _addressService.DeleteAddress(id);
            return NoContent();
        }
    }
}

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

        [HttpGet]
        public IActionResult Get()
        {
            var addresses = _addressService.GetAllAddresses();
            return Ok(addresses);
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id) 
        {
            var address = _addressService.GetByIdAddress(id);
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
        [HttpDelete]
        public IActionResult Delete(string id) 
        {
            _addressService.DeleteAddress(id);
            return NoContent();
        }

    }
}

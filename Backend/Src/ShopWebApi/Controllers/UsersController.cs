using Application.Interfaces.DataService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}

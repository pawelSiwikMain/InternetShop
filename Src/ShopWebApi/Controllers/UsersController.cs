using Application.Dtos.UserDtos;
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

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetByIdUser(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create(CreateUserDto user)
        {
            var response = _userService.AddUser(user);
            return Created($"api/users/{response.Id}", response);
        }
        [HttpPut]
        public IActionResult Update(UpdateUserDto user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}

using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces;
using Domine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateUser(CreateUser createUser)
        {
            UserResponse user = await _userService.CreateUser(createUser);
            return base.CreatedAtAction(nameof(Application.Dtos.Requests.CreateUser), new { username = user.Username }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            UserResponse user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUser updateUser)
        {
            await _userService.UpdateUser(id, updateUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}

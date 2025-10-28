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

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            List<UserResponse> users = await _userService.Get();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUser createUser)
        {
            UserResponse user = await _userService.CreateUser(createUser);
            return CreatedAtAction(nameof(CreateUser), new { username = user.Username }, user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUser updateUser)
        {
            await _userService.UpdateUser(id, updateUser);
            return NoContent();
        }

        [HttpPatch("change-password/{id}")]
        public async Task<ActionResult> NewPassword(Guid id, ChangePassword changePassword)
        {
            await _userService.NewPassword(id, changePassword);
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

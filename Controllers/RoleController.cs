using Application.Dtos.Requests;
using Application.Interfaces;
using Domine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _roleService.Get());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoleCreate roleCreate)
        {
            Role? role = await _roleService.Create(roleCreate);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            await _roleService.DeleteRole(id);
            return NoContent();
        }

    }
}

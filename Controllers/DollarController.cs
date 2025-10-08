using Application.Interfaces;
using Domine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DollarController : ControllerBase
    {
        private readonly IDollarApiService _dollarApiService;
        public DollarController(IDollarApiService dollarApiService)
        {
            _dollarApiService = dollarApiService;
        }

        [HttpGet]
        public async Task<ActionResult<DollarRate>> GetDollarRate()
        {
            var rate = await _dollarApiService.GetDollarRateAsync();
            return Ok(rate);
        }
    }
}

using Application.Dtos;
using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Services;
using Domine.Entities;
using Domine.Enums;
using Domine.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace e_commerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AuthenticationController(IConfiguration configuration, IUserService userService, IClientRepository clientRepository, IEmployeeRepository employeeRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
        }   

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] CredentialsRequest request)
        {
            User? user = await _userService.Login(request);

            Client? client = await _clientRepository.GetClientByUserIdAsync(user.Id);

            Employee? employee = await _employeeRepository.GetByUserIdAsync(user.Id);

            var saltEncrypted = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signature = new SigningCredentials(saltEncrypted, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("username", user.Username),
                new Claim("email", user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name.ToString())
            };

            bool isBoss = user.Role.Name == RoleType.Boss;
            claims.Add(new Claim("isBoss", isBoss.ToString().ToLower()));

            if (employee is not null)
            {
                claims.Add(new Claim("isEmployee", "true"));
                claims.Add(new Claim("employeeId", employee.Id.ToString()));
            }
            else
            {
                claims.Add(new Claim("isEmployee", "false"));
            }

            if (client is not null)
            {
                claims.Add(new Claim("isClient", "true"));
                claims.Add(new Claim("clientId", client.Id.ToString()));

                if (client.RetailClient is not null)
                {
                    claims.Add(new Claim("clientType", "RetailClient"));

                    if (client.RetailClient.Membership is not null)
                    {
                        claims.Add(new Claim("membership", client.RetailClient.Membership.MembershipType?.ToString() ?? "Null"));
                        claims.Add(new Claim("membershipDiscount", client.RetailClient.Membership.DiscountRate?.ToString() ?? "0"));
                    }
                }

                if (client.WholesaleClient is not null)
                {
                    claims.Add(new Claim("clientType", "WholesaleClient"));
                    claims.Add(new Claim("tierWholesale", client.WholesaleClient.TierWholesale.ToString()));
                    claims.Add(new Claim("creditLimit", client.WholesaleClient.CreditLimit.ToString()));
                }
            }
            else
            {
                claims.Add(new Claim("isClient", "false"));
            }

            var jwtSecurityToken = new JwtSecurityToken(
                  _configuration["Authentication:Issuer"],
                  _configuration["Authentication:Audience"],
                  claims: claims,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddHours(1),
                  signature
            );

            string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(new { accessToken = tokenToReturn });
        }
    }
}

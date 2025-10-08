//using Application.Dtos;
//using Application.Interfaces;
//using Application.Services;
//using Domine.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace e_commerceAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticationController : ControllerBase
//    {
//        public IConfiguration _configuration;
//        private readonly IUserService _userService;
//        public AuthenticationController(IConfiguration configuration, IUserService userService)
//        {
//            _configuration = configuration;
//            _userService = userService;
//        }

//        [HttpPost]
//        public IActionResult Authenticate([FromBody] CredentialsRequest request)
//        {
//            // 1- Validamos credenciales.
//            if (string.IsNullOrEmpty(request.Username) || (string.IsNullOrEmpty(request.Password)))
//            {
//                return BadRequest("Credenciales incorrectas, intentelo de nuevo");
//            }

//            User? user = _userService.LoginUser(request);

//            // 2- Crear el token.
//            if (user is not null)
//            {
//                //El secret de la API va a estar encriptado por esta dos lineas.

//                //Secret de la API
//                var saltEncrypted = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                
//                //Como se firma el token, clave de la API, con el algoritmo de hasheo del token.
//                var signature = new SigningCredentials(saltEncrypted, SecurityAlgorithms.HmacSha256);

//                var claimsForToken = new List<Claim>()
//                {
//                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
//                    new Claim("username", user.Username),

//                    new Claim(ClaimTypes.Role, user.Role.ToString()),

//                    new Claim("clientId", user.Client.Id.ToString()),

//                    new Claim("retailMembership", user.Client?.Membership?.MembershipType.ToString() ?? "None"),
//                    new Claim("wholesaleTier", user.Client?.WholesaleClient?.TierWholesale.ToString() ?? "None")
//                };
                

//                var jwtSecurityToken = new JwtSecurityToken(
//                  _configuration["Authentication:Issuer"],
//                  _configuration["Authentication:Audience"],
//                  claimsForToken,
//                  DateTime.UtcNow,
//                  DateTime.UtcNow.AddHours(1),
//                  signature);

//                string tokenToReturn = new JwtSecurityTokenHandler()
//                    .WriteToken(jwtSecurityToken);

//                return Ok(tokenToReturn);
//            }
//            return Unauthorized();
//        }
//    }
//}

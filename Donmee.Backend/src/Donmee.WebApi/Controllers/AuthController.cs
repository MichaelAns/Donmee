using Donmee.Persistence.Models;
using Donmee.WebApi.Configurations;
using Donmee.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Donmee.WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        private readonly UserManager<Persistence.Models.User> _userManager;
        private readonly IConfiguration _configuration;

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Domain.User requestUser)
        {
            // Validate the incoming request
            if (ModelState.IsValid)
            {
                // Check the email existing
                var userExist = await _userManager.FindByEmailAsync(requestUser.Email);

                if (userExist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exists"
                        }
                    });
                }

                // Create a user
                string passwordHash = HashCode(requestUser.Password);                

                var newUser = new Persistence.Models.User()
                {
                    UserName = requestUser.Name,
                    SecondName = requestUser.SecondName,
                    Email = requestUser.Email,
                    PhoneNumber = requestUser.Phone,
                    PasswordHash = passwordHash
                };

                var isCreated = await _userManager.CreateAsync(newUser, passwordHash);

                if (isCreated.Succeeded)
                {
                    // Generate the token
                    var token = GenerateJwtToken(newUser);

                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                        {
                            "Server error"
                        }
                });
            }

            return BadRequest();
        }

        private string HashCode(string source)
        {
            using (var sha256 = SHA256.Create())
            {                
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder stringBuilder = new();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}


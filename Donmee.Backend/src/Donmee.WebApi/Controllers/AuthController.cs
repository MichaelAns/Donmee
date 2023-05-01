using Donmee.Persistence.Models;
using Donmee.WebApi.Configurations;
using Donmee.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Donmee.WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(
            UserManager<User> userManager)
        {
            _userManager = userManager;
            //_jwtConfig = jwtConfig;
        }
        private readonly UserManager<Persistence.Models.User> _userManager;
        //private readonly JwtConfig _jwtConfig;

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
                string passwordHash = "password";

                using (var hmac = new HMACSHA512())
                {
                    // TODO: encrypt
                }

                var newUser = new Persistence.Models.User()
                {
                    UserName = requestUser.Name,
                    SecondName = requestUser.SecondName,
                    Email = requestUser.Email,
                    PhoneNumber = requestUser.Phone,
                    PasswordHash = passwordHash
                };

                var isCreated = await _userManager.CreateAsync(newUser, requestUser.Password);

                if (isCreated.Succeeded)
                {
                    // Generate the token
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

        //
    }
}

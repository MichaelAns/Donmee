﻿using Donmee.Persistence.Models;
using Donmee.WebApi.Models;
using Donmee.WebApi.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Donmee.WebApi.Controllers
{
    /// <summary>
    /// Вход и регистрация пользователя
    /// </summary>
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

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="requestUser">Пользователь</param>
        /// <returns>True, если пользователь успешно зарегистрировался, false - иначе</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto requestUser)
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
                    return Ok(new AuthResult()
                    {
                        Result = true,
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

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="loginRequest">Почта и пароль</param>
        /// <returns>Jwt-токен и ID пользователя, если вход выполнен успешно</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginRequest)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(loginRequest.Email);

                if(existingUser == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid payload"
                        },
                        Result = false
                    });
                }

                var passwordHash = HashCode(loginRequest.Password);
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, passwordHash);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        },
                        Result = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);

                return Ok(new AuthResult()
                {
                    Token = jwtToken,
                    Result = true,
                    UserId = existingUser.Id
                });
            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                    {
                        "Invalid creditionals"
                    },
                Result = false
            });
        }

        /// <summary>
        /// Хэширование с помощью SHA-256
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <returns>Хэщ-код исходной строки</returns>
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

        /// <summary>
        /// Генерация JWT-токена для запрашиваемого пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>JWT-токен</returns>
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

                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}


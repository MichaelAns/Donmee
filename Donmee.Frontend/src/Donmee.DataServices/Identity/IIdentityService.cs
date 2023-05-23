using Donmee.Domain.DTOs;
using Donmee.Domain.RequestResults;

namespace Donmee.DataServices.Identity
{
    /// <summary>
    /// Регистрация и вход пользователя
    /// </summary>
    public interface IIdentityService
    {
        public Task<AuthResult> Identity(UserLoginDto user);
        public Task<AuthResult> SignUp(UserRegistrationDto user);
        public Task<AuthResult> Validate(string token);
    }
}

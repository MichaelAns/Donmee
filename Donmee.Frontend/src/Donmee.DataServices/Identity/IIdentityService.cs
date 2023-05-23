using Donmee.Domain.DTOs;
using Donmee.Domain.RequestResults;

namespace Donmee.DataServices.Identity
{
    public interface IIdentityService
    {
        public Task<AuthResult> Identity(UserLoginDto user);
        public Task<AuthResult> SignUp(UserRegistrationDto user);
    }
}

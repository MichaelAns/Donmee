namespace Donmee.DataServices.Identity
{
    public interface IIdentityService
    {
        public Task<string> Identity(string email, string password);
        public Task<Donmee.Domain.User> SignUp(Donmee.Domain.User user);
    }
}

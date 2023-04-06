namespace Donmee.DataServices.Identity
{
    public interface IIdentityService
    {
        public Task<string> Identity(string email, string password);
    }
}

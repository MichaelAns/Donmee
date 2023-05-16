namespace Donmee.DataServices.Identity
{
    public class IdentityDatabaseService : IIdentityService
    {
        public Task<string> Identity(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.User> SignUp(Domain.User user)
        {
            throw new NotImplementedException();
        }
    }
}

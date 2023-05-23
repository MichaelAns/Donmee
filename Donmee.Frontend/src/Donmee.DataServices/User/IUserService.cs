namespace Donmee.DataServices.User
{
    public interface IUserService
    {
        public Task<Donmee.Domain.User> GetUser(string userId);
    }
}

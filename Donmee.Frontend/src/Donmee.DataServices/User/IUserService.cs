namespace Donmee.DataServices.User
{
    public interface IUserService
    {
        public Task<Frontend.Persistance.Models.User> GetUser(Guid userId);
    }
}

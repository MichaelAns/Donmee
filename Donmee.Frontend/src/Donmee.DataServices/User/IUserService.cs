namespace Donmee.DataServices.User
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public interface IUserService
    {
        public Task<Donmee.Domain.User> GetUser(string userId, string token);
    }
}

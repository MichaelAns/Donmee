namespace Donmee.Application.Mappings
{
    public static class UserMapper
    {
        public static Donmee.Domain.User ToDomain(this Persistence.Models.User user)
        {
            return new Domain.User
            {
                Id = user.Id,
                Name = user.Name,
                SecondName = user.SecondName,
                Email = user.Email,
                Balance = user.Balance,
                Password = user.Password,
                Phone = user.Phone
            };
        }
    }
}

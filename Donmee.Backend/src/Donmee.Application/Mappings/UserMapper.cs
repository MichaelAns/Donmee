namespace Donmee.Application.Mappings
{
    public static class UserMapper
    {
        public static Donmee.Domain.User ToDomain(this Persistence.Models.User user)
        {
            return new Domain.User
            {
                Id = Guid.Parse(user.Id),
                Name = user.UserName,
                SecondName = user.SecondName,
                Email = user.Email,
                Balance = user.Balance,
                Password = String.Empty,
                Phone = user.PhoneNumber
            };
        }
    }
}

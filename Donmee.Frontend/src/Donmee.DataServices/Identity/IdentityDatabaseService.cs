using Frontend.Persistance.Models;

namespace Donmee.DataServices.Identity
{
    public class IdentityDatabaseService : IIdentityService
    {
        private string[] _args;

        public IdentityDatabaseService(string[] args)
        {
            _args = args;
        }

        public async Task<string> Identity(string email, string password)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(_args))
            {
                return dbContext.User.FirstOrDefaultAsync(user =>
                    user.Email == email.ToLower() &&
                    user.Password == password).Result.Id.ToString();
            }
        }

        public async Task<User> SignUp(User user)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(_args))
                {
                if (await dbContext.User.FirstOrDefaultAsync(u => u.Phone == user.Phone || u.Email == user.Email) != null)
                {
                    return null;
                }
                var createdUser = await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return createdUser.Entity;
            }
        }
    }
}

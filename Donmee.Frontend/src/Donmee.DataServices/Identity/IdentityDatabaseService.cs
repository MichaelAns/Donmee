namespace Donmee.DataServices.Identity
{
    public class IdentityDatabaseService : IIdentityService
    {
        public async Task<string> Identity(string email, string password)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext())
            {
                return dbContext.User.FirstOrDefaultAsync(user =>
                    user.Email == email &&
                    user.Password == password).Result.Id.ToString();
            }
        }
    }
}

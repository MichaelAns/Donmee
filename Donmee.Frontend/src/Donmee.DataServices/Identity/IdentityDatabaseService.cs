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
    }
}

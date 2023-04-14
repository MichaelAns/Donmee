namespace Donmee.DataServices.User
{
    public class UserDatabaseService : IUserService
    {
        public UserDatabaseService(string[] args)
        {
            Args = args;
        }
        private string[] Args;


        public async Task<Frontend.Persistance.Models.User> GetUser(Guid userId)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(Args))
            {                
                var result = dbContext.User.FirstOrDefault(user => user.Id == userId);
                return result;
            }
        }
    }
}

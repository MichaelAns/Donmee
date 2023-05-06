namespace Donmee.Application.Mappings
{
    public static class WishMapper
    {
        public static Domain.Wish ToDomain(this Persistence.Models.Wish wish)
        {
            return new Domain.Wish
            {
                Id = wish.Id,
                Name = wish.Name,
                Description = wish.Description,
                ImagePath = wish.ImagePath,
                CurrentAmount = wish.CurrentAmount,
                EndDate = wish.EndDate,
                Goal = wish.Goal,
                WishType = wish.WishType
            };
        }
    }
}

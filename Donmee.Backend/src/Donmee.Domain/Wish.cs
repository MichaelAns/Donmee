using Donmee.Persistence.Models.Enums;

namespace Donmee.Domain
{
    public class Wish
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int Goal { get; set; }
        public int CurrentAmount { get; set; }
        public DateTime EndDate { get; set; }
        public WishType WishType { get; set; }
    }
}

namespace Frontend.Persistance.Models
{
    public class Wish
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; }
        public int CurrentAmount { get; set; }
        public DateTime EndDate { get; set; }

    }
}

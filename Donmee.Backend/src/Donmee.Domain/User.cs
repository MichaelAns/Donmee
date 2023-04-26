namespace Donmee.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
    }
}

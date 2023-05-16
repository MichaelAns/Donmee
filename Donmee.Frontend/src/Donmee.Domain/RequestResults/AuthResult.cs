namespace Donmee.Domain.RequestResults
{
    public class AuthResult
    {
        public string Token { get; set; }

        public string UserId { get; set; }

        public bool Result { get; set; }

        public List<string> Errors { get; set; }
    }
}
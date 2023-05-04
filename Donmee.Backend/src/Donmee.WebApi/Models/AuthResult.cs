namespace Donmee.WebApi.Models
{
    /// <summary>
    /// Результат входа / регистрации
    /// </summary>
    public class AuthResult
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}

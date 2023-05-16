namespace Donmee.WebApi.Configurations
{
    /// <summary>
    /// Кофигурация JWT-токена
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Секретный ключ для токена
        /// </summary>
        public string Secret { get; set; }
    }
}

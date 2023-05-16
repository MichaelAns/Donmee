namespace Donmee.WebApi.Models
{
    /// <summary>
    /// Результат входа / регистрации
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        /// JWT-токен
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Результат операции <br/>
        /// true - если операция прошла успешно, false - иначе
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; set; }
    }
}

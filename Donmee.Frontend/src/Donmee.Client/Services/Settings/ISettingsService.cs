namespace Donmee.Client.Services.Settings
{
    /// <summary>
    /// Основные параметры приложения
    /// </summary>
    public interface ISettingsService
    {
        public string AuthAccessToken { get; set; }
        public string UserId { get; set; }
    }
}

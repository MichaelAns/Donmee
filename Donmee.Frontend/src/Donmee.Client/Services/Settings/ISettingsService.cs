namespace Donmee.Client.Services.Settings
{
    public interface ISettingsService
    {
        public string AuthAccessToken { get; set; }
        public string UserId { get; set; }
    }
}

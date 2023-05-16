namespace Donmee.Client.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string Id = "user_id";
        private const string AccessToken = "access_token";
        private readonly string _authAccessToken = String.Empty;
        private readonly string _userId = String.Empty;

        public string AuthAccessToken 
        { 
            get => Preferences.Get(AccessToken, _authAccessToken); 
            set => Preferences.Set(AccessToken, value);
        }

        public string UserId
        {
            get => Preferences.Get(Id, _userId);
            set => Preferences.Set(Id, value);
        }
    }
}

using System.Diagnostics;
using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Identity;

namespace Donmee.Client.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IIdentityService identityService) : base(navigationService, settingsService)
        {
            IdentityService = IdentityService;
        }

        [RelayCommand]
        private async Task SignInAsync()
        {
            try
            {
                // TODO : Auth
            }
            catch (Exception exc)
            {
                Debug.WriteLine($"[SignIn] Error signing in: {exc}");
            }
            await NavigationService.NavigateToAsync("//Main/Wishes/CommonWishes");
        }

        public IIdentityService IdentityService { get; private set; }

        
    }
}

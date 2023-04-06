using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using System.Diagnostics;

namespace Donmee.Client.ViewModels
{
    public partial class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService) : base(navigationService, settingsService)
        {
        }

        [RelayCommand]
        private async Task SignUpAsync()
        {
            try
            {
                //TODO: SignUp
            }
            catch (Exception exc)
            {
                Debug.WriteLine($"[SignIn] Error signing in: {exc}");
            }
            await NavigationService.NavigateToAsync("//Login");
        }
    }
}

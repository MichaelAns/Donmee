using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels.Base;
using System.Diagnostics;

namespace Donmee.Client.ViewModels
{
    public partial class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel(INavigationService navigationService) : base(navigationService)
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

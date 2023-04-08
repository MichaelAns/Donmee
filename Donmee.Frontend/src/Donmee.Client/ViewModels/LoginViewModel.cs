using System.Diagnostics;
using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.Validation;
using Donmee.Client.Validation.Rules;
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
            IdentityService = identityService;
            AddValidation();

            SignInCommand = new AsyncRelayCommand(SignInAsync, () => IsValid);
        }

        public IIdentityService IdentityService { get; private set; }

        public IAsyncRelayCommand SignInCommand { get; private set; }

        [ObservableProperty]
        private bool _isSignInError = false;
        private async Task SignInAsync()
        {
            try
            {
                var response = await IdentityService.Identity(Email.Value, Password.Value);
                //var guid = Guid.Parse(response);
                SettingsService.UserId = response;
                IsSignInError = false;
                await NavigationService.NavigateToAsync("//Main/Wishes/CommonWishes");
            }   
            catch (NullReferenceException exc)
            {
                IsSignInError = true;
            }
            catch (Exception exc)
            {
                Debug.WriteLine($"[SignIn] Error signing in: {exc}");
            }            
        }

        

        [ObservableProperty]
        private ValidatableObject<string> _email = new();
        [ObservableProperty]
        private ValidatableObject<string> _password = new();

        private void AddValidation()
        {
            Email.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "An email is required."
            });
            Email.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "Must be an email."
            });

            Password.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "A password is required."
            });
        }

        [ObservableProperty]
        private bool _isValid;

        [RelayCommand]
        private void Validate()
        {
            IsValid = Email.Validate() && Password.Validate();
            SignInCommand.NotifyCanExecuteChanged();
        }    
    }
}

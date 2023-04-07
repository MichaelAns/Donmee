using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.Validation;
using Donmee.Client.Validation.Rules;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Identity;
using Microsoft.Extensions.Options;

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

        public IAsyncRelayCommand SignInCommand { get; private set; }
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

using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.Validation;
using Donmee.Client.Validation.Rules;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Identity;
using Frontend.Persistance.Models;
using System.Diagnostics;

namespace Donmee.Client.ViewModels
{
    public partial class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IIdentityService identityService) : base(navigationService, settingsService)
        {
            IdentityService = identityService;
            SignUpCommand = new AsyncRelayCommand(SignUpAsync, () => IsValid);
            AddValidation();
        }

        public IIdentityService IdentityService { get; private set; }

        public IAsyncRelayCommand SignUpCommand { get; private set; }
        private async Task SignUpAsync()
        {
            try
            {
                if (Password.Value != RepeatPassword.Value)
                {
                    ErrorLabel = "Passwords don't match";   
                    IsError = true;
                    return;
                }
                IsError = false;
                User user = new User
                {
                    Name = Name.Value,
                    SecondName = SecondName.Value,
                    Password = Password.Value,
                    Email = this.Email.Value,
                    Phone = Phone.Value
                };

                var createdUser = IdentityService.SignUp(user);

                await NavigationService.NavigateToAsync("//Login");
            }

            catch (Exception exc)
            {
                Debug.WriteLine($"[SignIn] Error signing in: {exc}");
            }
            
        }

        // Fields

        [ObservableProperty]
        private ValidatableObject<string> _email = new();

        [ObservableProperty]
        private ValidatableObject<string> _password = new();

        [ObservableProperty]
        private ValidatableObject<string> _repeatPassword = new();

        [ObservableProperty]
        private ValidatableObject<string> _phone = new();

        [ObservableProperty]
        private ValidatableObject<string> _name = new();

        [ObservableProperty]
        private ValidatableObject<string> _secondName = new();

        // Validation
        private void AddValidation()
        {
            Email.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });
            Email.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "Must be an email"
            });

            Password.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });

            RepeatPassword.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });

            Phone.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });

            Name.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });

            SecondName.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private bool _isValid;

        [RelayCommand]
        private void Validate()
        {
            IsValid = Email.Validate() && 
                Password.Validate() &&
                RepeatPassword.Validate() &&
                Phone.Validate() &&
                Name.Validate() &&
                SecondName.Validate();

            SignUpCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private bool _isError = false;

        [ObservableProperty]
        private string _errorLabel;
    }
}

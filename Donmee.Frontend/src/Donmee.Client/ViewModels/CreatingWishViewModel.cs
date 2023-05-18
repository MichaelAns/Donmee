using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.Validation;
using Donmee.Client.Validation.Rules;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Transaction;

namespace Donmee.Client.ViewModels
{
    public partial class CreatingWishViewModel : ViewModelBase
    {
        public CreatingWishViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            ITransactionService transactionService) : base(navigationService, settingsService)
        {
            TransactionService = transactionService;

            CreateCommand = new AsyncRelayCommand(CreateExecuteAsync, CreateCanExecute);

            AddValidation();
        }

        public ITransactionService TransactionService { get; set; }

        //Create
        public IAsyncRelayCommand CreateCommand { get; private set; }
        private async Task CreateExecuteAsync() 
        {
            try
            {
                var wish = new Wish
                {
                    Name = this.Name.Value,
                    Description = this.Description.Value,
                    Goal = this.Goal.Value,
                    WishType = this.SelectedWishType,
                    ImagePath = this.SelectedImagePath
                };

                await TransactionService.CreatingTransaction(
                    Guid.Parse(SettingsService.UserId),
                    wish);

                IsError = false;

                await NavigationService.NavigateToAsync("//Main/Wishes/CommonWishes");
            }
            catch (Exception exc)
            {
                ErrorLabel = exc.ToString();
                IsError = true;
            }
        }
        private bool CreateCanExecute() => IsValid;


        // Fields

        [ObservableProperty]
        private ValidatableObject<string> _name = new();

        [ObservableProperty]
        private ValidatableObject<string> _description = new();

        [ObservableProperty]
        private ValidatableObject<int> _goal = new();

        [ObservableProperty]
        private List<WishType> _wishTypes = new List<WishType>()
        {
            {
                WishType.Common
            },
            {
                WishType.Blitz 
            }
        };

        [ObservableProperty]
        private WishType _selectedWishType = WishType.Common;

        [ObservableProperty]
        private string _selectedImagePath = ImagePaths.Ball;

        [ObservableProperty]
        private List<string> _images = new List<string>()
        {
            ImagePaths.Ball,
            ImagePaths.Balloons,
            ImagePaths.Pc,
            ImagePaths.Pizza,
            ImagePaths.Smartphone
        };


        // Validation
        private void AddValidation()
        {
            Name.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });
            Description.Validations.Add(new IsNullOrEmptyRule<string>
            {
                ValidationMessage = "Cannot be empty."
            });
            Goal.Validations.Add(new IsIntOrEmptyRule<int>
            {
                ValidationMessage = "Must be a number."
            });
        }

        [ObservableProperty]
        private bool _isValid;

        [RelayCommand]
        private void Validate()
        {
            IsValid = Name.Validate() &&
                Description.Validate() &&
                Goal.Validate();
            CreateCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private bool _isError = false;

        [ObservableProperty]
        private string _errorLabel;
    }
}

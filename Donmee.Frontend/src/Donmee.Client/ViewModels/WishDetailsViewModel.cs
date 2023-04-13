using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Transaction;
using Frontend.Persistance.Models;

namespace Donmee.Client.ViewModels
{
    [QueryProperty(nameof(Wish), "WishDetails")]
    public partial class WishDetailsViewModel : ViewModelBase
    {
        public WishDetailsViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            ITransactionService transactionService) : base(navigationService, settingsService)
        {
            TransactionService = transactionService;
            DonateCommand = new AsyncRelayCommand(DonateExecuteAsync, DonateCanExecute);
        }       

        public ITransactionService TransactionService { get; private set; }

        [ObservableProperty]
        private Wish _wish;

        // Donate
        [ObservableProperty]
        private int _money = 0;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isError = false;

        [RelayCommand]
        private void Validate() => DonateCommand.NotifyCanExecuteChanged();

        public IAsyncRelayCommand DonateCommand { get; set; }
        private bool DonateCanExecute() => _money > 0;
        private async Task DonateExecuteAsync()
        {
            try
            {
                await TransactionService.DonateTransaction(
                    Guid.Parse(SettingsService.UserId),
                    this.Wish,
                    Money);
                IsError = false;
                await NavigationService.NavigateToAsync("//Main/Wishes/CommonWishes");
            }
            catch (Exception exc)
            {
                ErrorMessage = exc.Message;
                IsError = true;
            }
        }
    }
}

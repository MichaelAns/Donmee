using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Transaction;
using Donmee.DataServices.User;

namespace Donmee.Client.ViewModels
{
    public partial class ProfileViewModel : ViewModelBase
    {
        public ProfileViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            ITransactionService transactionService,
            IUserService userService) : base(navigationService, settingsService)
        {
            TransactionService = transactionService;
            UserService = userService;
            ReplenishmentCommand = new AsyncRelayCommand(ReplenishExecute, ReplenishCanExecute);
            // Load();
        }

        public IUserService UserService { get; private set; }
        public ITransactionService TransactionService { get; private set; }

        private void Load()
        {
            /*UserService.GetUser(Guid.Parse(SettingsService.UserId)).ContinueWith(
                task =>
                {
                    User = task.Result;
                });*/
        }


        // Fields

        [ObservableProperty]
        private User _user;
                
        [ObservableProperty]
        private int _replenish = 0;

        // Replenish
        public IAsyncRelayCommand ReplenishmentCommand { get; private set; }
        private bool ReplenishCanExecute() => Replenish > 0;
        private async Task ReplenishExecute()
        {
            /*try
            {
                await TransactionService.ReplenishmentTransaction(
                    Guid.Parse(SettingsService.UserId),
                    Replenish);
                Replenish = 0;

                Load();
            }
            catch (Exception)
            {

            }*/
        }
                
        [RelayCommand]
        private void Validate()
        {
            ReplenishmentCommand.NotifyCanExecuteChanged();
        }

        // Refresh
        [RelayCommand]
        private void Refresh() => Load();

    }
}

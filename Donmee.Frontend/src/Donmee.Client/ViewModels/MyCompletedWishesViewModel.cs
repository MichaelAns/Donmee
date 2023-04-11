using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
using Frontend.Persistance.Models;
using Frontend.Persistance.Models.Enums;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class MyCompletedWishesViewModel : ViewModelBase
    {
        public MyCompletedWishesViewModel(
            INavigationService navigationService,
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
            GetWishes();
        }

        public IWishService WishService { get; private set; }

        private void GetWishes()
        {
            try
            {
                WishService.GetWishesAsync(
                    Guid.Parse(SettingsService.UserId),
                    WishStatus.Active)
                    .ContinueWith(task =>
                    {
                        _wishes = new(task.Result);
                    });
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;

        [ObservableProperty]
        private Wish _selectedWish;
    }
}

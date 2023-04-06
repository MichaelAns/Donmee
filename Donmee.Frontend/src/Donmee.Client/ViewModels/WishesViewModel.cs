using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
using Frontend.Persistance.Models;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class WishesViewModel : ViewModelBase
    {

        public WishesViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
        }
        private void GetWishes()
        {
            WishService.GetWishesAsync(Guid.Parse(SettingsService.UserId)).ContinueWith(
                task =>
                {
                    _wishes = new(task.Result);
                });
        }

        
        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;

        [ObservableProperty]
        private Wish _selectedWish;

        public IWishService WishService { get; private set; }

        [RelayCommand]
        private async Task SelectWishAsync()
        {
            await NavigationService.NavigateToAsync(
                    "/WishDetails",
                    new Dictionary<string, object> 
                    {
                        {
                                "WishDetails",
                                SelectedWish
                        } 
                    }); 
        }

    }
}

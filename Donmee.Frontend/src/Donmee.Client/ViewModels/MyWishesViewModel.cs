using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels.Base;
using Frontend.Persistance.Models;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class MyWishesViewModel : ViewModelBase
    {
        public MyWishesViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetWishes();
        }
        private void GetWishes()
        {
            WishesInit().ContinueWith(task
                => _wishes = task.Result);
        }

        private async Task<ObservableCollection<Wish>> WishesInit()
        {
            return new ObservableCollection<Wish>()
            {
                new Wish
                {
                    Name = "Телефон",
                    Description = "Новый телефон",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                },
                new Wish
                {
                    Name = "Ноутбук",
                    Description = "Новый ноутбук",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                }
            };
        }
        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;

        [ObservableProperty]
        private Wish _selectedWish;

        [RelayCommand]
        private async Task SelectWishAsync()
        { }
    }
}

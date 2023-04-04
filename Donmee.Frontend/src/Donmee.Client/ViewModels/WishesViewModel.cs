using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels.Base;
using Frontend.Persistance;
using Frontend.Persistance.Models;
using Frontend.Repository;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class WishesViewModel : ViewModelBase
    {
        public WishesViewModel(INavigationService navigationService) : base(navigationService)
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
            Guid UserId_1 = Guid.NewGuid();
            Guid UserId_2 = Guid.NewGuid();
            Guid UserId_3 = Guid.NewGuid();

            Guid Transaction_1 = Guid.NewGuid();
            Guid Transaction_2 = Guid.NewGuid();
            Guid Transaction_3 = Guid.NewGuid();

            Guid Wish_1 = Guid.NewGuid();
            Guid Wish_2 = Guid.NewGuid();
            Guid Wish_3 = Guid.NewGuid();

            return new ObservableCollection<Wish>()
            {
                new Wish
                {
                    Id = Wish_1,
                    Name = "Телефон",
                    Description = "Новый телефон",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                },
                new Wish
                {
                    Id = Wish_2,
                    Name = "Ноутбук",
                    Description = "Новый ноутбук",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                }
                /*new Wish
                {
                    Id = Wish_3,
                    Name = "Энергетик Black Monster",
                    CurrentAmount = 50,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                    Goal = 100
                }*/
            };
        }
        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;

        [ObservableProperty]
        private Wish _selectedWish;

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

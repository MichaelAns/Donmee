using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels.Base;
using Frontend.Persistance.Models;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class BlitzWishesViewModel : ViewModelBase
    {
        public BlitzWishesViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetWishes();
        }

        private async Task<ObservableCollection<Wish>> WishesInit()
        {
            return new ObservableCollection<Wish>()
            {
                new Wish
                {
                    Name = "Энергетик Black Monster",
                    CurrentAmount = 50,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                    Goal = 100
                },
                new Wish
                {
                    Name = "Шаурма",
                    CurrentAmount = 10,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                    Goal = 100
                },
                new Wish
                {
                    Name = "Пицца",
                    CurrentAmount = 50,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                    Goal = 100
                }
            };
        }

        private void GetWishes()
        {
            WishesInit().ContinueWith(task
                => _wishes = task.Result);
        }

        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;
        
        [RelayCommand]
        private async Task DonateAsync()
        {
            
        }
    }
}

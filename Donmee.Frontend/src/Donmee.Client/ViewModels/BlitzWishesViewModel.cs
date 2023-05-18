using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class BlitzWishesViewModel : ViewModelBase
    {
        public BlitzWishesViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
            //GetWishes();
        }


        private void GetWishes()
        {
            WishService.GetWishesAsync(
                Guid.Parse(SettingsService.UserId),
                WishType.Blitz)
                .ContinueWith(
                task =>
                {
                    _wishes = new(task.Result);
                });
        }

        private ObservableCollection<Wish> _wishes = new ObservableCollection<Wish>()
        {
            new Wish()
            {
                Id = new Guid(),
                Description = "Очень большое описание этого желание. Много написано, очень написано. Интересно, что получится из этого",
                Name = "Пицца Spar",
                Goal = 100,
                CurrentAmount = 0,
                ImagePath = ImagePaths.Pizza,
                EndDate = new(23, 06, 29),
                WishType = WishType.Common
            },
            new Wish()
            {
                Id = new Guid(),
                Name = "Компьютер",
                Goal = 100,
                CurrentAmount = 0,
                ImagePath = ImagePaths.Pc,
                EndDate = new(23, 06, 29),
                WishType = WishType.Common
            },
            new Wish()
            {
                Id = new Guid(),
                Name = "Гиря",
                Goal = 100,
                CurrentAmount = 0,
                ImagePath = ImagePaths.Ball,
                EndDate = new(23, 06, 29),
                WishType = WishType.Common
            },
            new Wish()
            {
                Id = new Guid(),
                Name = "Билет на Мейби Бейби",
                Goal = 100,
                CurrentAmount = 0,
                ImagePath = ImagePaths.Balloons,
                EndDate = new(23, 06, 29),
                WishType = WishType.Common
            },
            new Wish()
            {
                Id = new Guid(),
                Name = "IPhone 12",
                Goal = 100,
                CurrentAmount = 0,
                ImagePath = ImagePaths.Smartphone,
                EndDate = new(23, 06, 29),
                WishType = WishType.Common
            }
        };

        public IWishService WishService { get; private set; }

        public IReadOnlyList<Wish> Wishes => _wishes;
        
        [RelayCommand]
        private async Task DonateAsync()
        {
            
        }
    }
}

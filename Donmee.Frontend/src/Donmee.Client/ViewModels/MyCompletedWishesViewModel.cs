using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
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
            //GetWishes();
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

        [ObservableProperty]
        private ObservableCollection<Wish> _wishes = new ObservableCollection<Wish>()
        {
            new Wish()
            {
                Id = new Guid(),
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


        [ObservableProperty]
        private Wish _selectedWish;
    }
}

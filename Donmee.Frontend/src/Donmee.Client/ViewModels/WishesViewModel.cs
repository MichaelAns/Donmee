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
            _repository.GetAll().ContinueWith(task
                => _wishes = new(task.Result));
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

        private DonmeeRepository<Wish> _repository = new(new DonmeeDbContextFactory().CreateDbContext());
    }
}

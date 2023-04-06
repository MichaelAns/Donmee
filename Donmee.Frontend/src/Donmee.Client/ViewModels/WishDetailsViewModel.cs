using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Frontend.Persistance.Models;

namespace Donmee.Client.ViewModels
{
    [QueryProperty(nameof(Wish), "WishDetails")]
    public partial class WishDetailsViewModel : ViewModelBase
    {
        public WishDetailsViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService) : base(navigationService, settingsService)
        {
        }       

        [ObservableProperty]
        private Wish _wish;


        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);

            if (query.ValueAsBool("WishDetails"))
            {
                Wish = (Wish)query["WishDetails"];
            }
        }
    }
}

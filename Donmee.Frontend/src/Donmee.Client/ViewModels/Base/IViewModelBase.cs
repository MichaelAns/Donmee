using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;

namespace Donmee.Client.ViewModels.Base
{
    public interface IViewModelBase
    {
        public INavigationService NavigationService { get; }
        public ISettingsService SettingsService { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; set; }

        Task InitializeAsync();
    }
}

using Donmee.Client.Services.Navigation;

namespace Donmee.Client.ViewModels.Base
{
    public interface IViewModelBase
    {
        public INavigationService NavigationService { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; set; }

        Task InitializeAsync();
    }
}

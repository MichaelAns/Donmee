namespace Donmee.Client.Services.Navigation
{
    public interface INavigationService
    {
        public Task InitializeAsync();
        public Task NavigateToAsync(string route,
            IDictionary<string, object> routeParameters = null);
        public Task PopAsync();
    }
}

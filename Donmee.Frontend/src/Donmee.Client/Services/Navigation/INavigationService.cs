namespace Donmee.Client.Services.Navigation
{
    /// <summary>
    /// Навигация по оболочке
    /// </summary>
    public interface INavigationService
    {
        public Task InitializeAsync();
        public Task NavigateToAsync(string route,
            IDictionary<string, object> routeParameters = null);
        public Task PopAsync();
    }
}

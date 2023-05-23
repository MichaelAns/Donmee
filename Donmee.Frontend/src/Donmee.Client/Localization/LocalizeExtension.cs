using Donmee.Client.Resources.Strings;
using Microsoft.Extensions.Localization;

namespace Donmee.Client.Localization
{
    /// <summary>
    /// Локализация приложения
    /// </summary>
    [ContentProperty(nameof(Key))]
    internal class LocalizeExtension : IMarkupExtension
    {
        public LocalizeExtension()
        {
            _localizer = ServiceHelper.GetService<IStringLocalizer<AppStrings>>();
        }

        IStringLocalizer<AppStrings> _localizer;

        public string Key { get; set; } = string.Empty;


        public object ProvideValue(IServiceProvider serviceProvider)
        {
            string localizedText = _localizer[Key];
            return localizedText;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}

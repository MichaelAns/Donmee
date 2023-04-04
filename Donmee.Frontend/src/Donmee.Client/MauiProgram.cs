using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels;
using Donmee.Client.Views;
using Frontend.Persistance;
using Frontend.Persistance.Models;
using Frontend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Donmee.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterViewModels()
			.RegisterViews();

		// Register dependencies to the container
		builder.Services
			.AddSingleton<INavigationService, MauiNavigationService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddTransient<LoginView>();
		mauiAppBuilder.Services.AddTransient<RegisterView>();

        mauiAppBuilder.Services.AddTransient<WishesView>();
        mauiAppBuilder.Services.AddTransient<BlitzWishesView>();
        mauiAppBuilder.Services.AddTransient<MyWishesView>();

        mauiAppBuilder.Services.AddTransient<WishDetailsView>();
        mauiAppBuilder.Services.AddTransient<MyWishDetailsView>();

        mauiAppBuilder.Services.AddTransient<SettingsView>();
        mauiAppBuilder.Services.AddTransient<ProfileView>();

		return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
        mauiAppBuilder.Services.AddSingleton<RegisterViewModel>();
        mauiAppBuilder.Services.AddSingleton<WishesViewModel>();

        return mauiAppBuilder;
    }

	
}

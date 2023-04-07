using CommunityToolkit.Maui;
using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels;
using Donmee.Client.Views;
using Donmee.DataServices.Identity;
using Donmee.DataServices.Wish;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
			.UseMauiCommunityToolkit()
			.RegisterViewModels()
			.RegisterViews()
			.RegisterServices();
			//.RegisterDatabaseServices();

		// Register dependencies to the container
		

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

        mauiAppBuilder.Services.AddTransient<ProfileView>();

		return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
        mauiAppBuilder.Services.AddSingleton<RegisterViewModel>();
        mauiAppBuilder.Services.AddTransient<WishesViewModel>();
        mauiAppBuilder.Services.AddTransient<WishDetailsViewModel>();
		mauiAppBuilder.Services.AddTransient<BlitzWishesViewModel>();
        mauiAppBuilder.Services.AddTransient<MyWishesViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
		mauiAppBuilder.Services.AddSingleton<string[]>(services => new string[] { FileSystem.AppDataDirectory });
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddSingleton<IIdentityService, IdentityDatabaseService>();
        mauiAppBuilder.Services.AddSingleton<IWishService, WishDatabaseService>();

        return mauiAppBuilder;
    }

	public static MauiAppBuilder RegisterDatabaseServices(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddSingleton<IdentityDatabaseService>(serv => new IdentityDatabaseService(new string[] { FileSystem.AppDataDirectory }));
        mauiAppBuilder.Services.AddSingleton<WishDatabaseService>(serv => new WishDatabaseService(new string[] { FileSystem.AppDataDirectory }));

		return mauiAppBuilder;
    }


}

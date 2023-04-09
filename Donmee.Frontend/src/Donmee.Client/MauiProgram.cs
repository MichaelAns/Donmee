using CommunityToolkit.Maui;
using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels;
using Donmee.Client.Views;
using Donmee.DataServices.Identity;
using Donmee.DataServices.Transaction;
using Donmee.DataServices.User;
using Donmee.DataServices.Wish;
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
        mauiAppBuilder.Services.AddTransient<ProfileViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
		mauiAppBuilder.Services.AddSingleton<string[]>(services => new string[] { FileSystem.AppDataDirectory });
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddSingleton<IIdentityService, IdentityDatabaseService>();
        mauiAppBuilder.Services.AddSingleton<IWishService, WishDatabaseService>();
        mauiAppBuilder.Services.AddSingleton<ITransactionService, TransactionDatabaseService>();
        mauiAppBuilder.Services.AddSingleton<IUserService, UserDatabaseService>();

        return mauiAppBuilder;
    }
}

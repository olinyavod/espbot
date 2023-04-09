using System.Reflection;
using CommunityToolkit.Maui.Views;
using espbot.ui.Pages;
using espbot.ui.Servuces;
using espbot.ui.ViewModules;

namespace espbot.ui.IoCModules;

static class PagesModule
{
	public class PopupInfo<TViewModel>
	{
		public Type PopupType { get; }

		public PopupInfo(Type popupType)
		{
			PopupType = popupType;
		}
	}

	public static IServiceCollection RegisterPages(this IServiceCollection services)
	{
		services.AddTransient<HomePage>();
		services.AddTransient<HomeViewModel>();
		services.AddSingleton<ShellViewModel>();
		services.AddSingleton<AppShell>();

		services.RegisterPopup<SearchBotPopup, SearchBotViewModel>();

		return services;
	}

	private static void RegisterPopup<TPopup, TViewModel>(this IServiceCollection services)
		where TPopup : Popup
		where TViewModel : class
	{
		services.AddTransient<TViewModel>();
		services.AddTransient<TPopup>();
		services.AddSingleton(new PopupInfo<TViewModel>(typeof(TPopup)));

	}

	private static void RegisterRoute<TPage, TViewModel>(this IServiceCollection services)
		where TPage : Page
		where TViewModel : class
	{
		services.AddTransient<TPage>();
		services.AddTransient<TViewModel>();

		Routing.RegisterRoute(typeof(TViewModel).FullName, new PageFactory<TPage>());
	}
}
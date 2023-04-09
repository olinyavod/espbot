using espbot.ui.Pages;
using espbot.ui.ViewModules;

namespace espbot.ui.IoCModules;

static class PagesModule
{
	public static IServiceCollection RegisterPages(this IServiceCollection services)
	{
		services.AddTransient<HomePage>();
		services.AddTransient<HomeViewModel>();
		services.AddSingleton<ShellViewModel>();
		services.AddSingleton<AppShell>();

		return services;
	}
}
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using espbot.ui.IoCModules;

namespace espbot.ui.Servuces;

class ShellNavigationService : INavigationService
{
	private readonly AppShell _shell;

	public ShellNavigationService(AppShell shell)
	{
		_shell = shell;
	}

	public Task GoToAsync<TViewModel>(Dictionary<string, object>? parameters = null)
	{
		return _shell.GoToAsync(typeof(TViewModel).FullName, parameters);
	}

	public Task GoToAsync(string route, Dictionary<string, object>? parameters = null) => _shell.GoToAsync(route, parameters);

	public Task ShowPopupAsync<TViewModel>()
	{
		var ioc = Ioc.Default;
		var info = ioc.GetRequiredService<PagesModule.PopupInfo<TViewModel>>();
		var popup = (Popup) ioc.GetRequiredService(info.PopupType);
		return _shell.CurrentPage.ShowPopupAsync(popup);
	}
}
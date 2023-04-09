namespace espbot.ui.Servuces;

public interface INavigationService
{
	Task GoToAsync<TViewModel>(Dictionary<string, object>? parameters = null);

	Task GoToAsync(string route, Dictionary<string, object>? parameters = null);

	Task ShowPopupAsync<TViewModel>();
}
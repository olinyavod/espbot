using CommunityToolkit.Maui.Core;
using espbot.ui.Extensions;
using espbot.ui.ViewModules;

namespace espbot.ui.Pages;

public partial class SearchBotPopup
{
	private readonly SearchBotViewModel _dataContext;

	public SearchBotPopup(SearchBotViewModel dataContext)
	{
		InitializeComponent();

		BindingContext = _dataContext = dataContext;
	}

	private void SearchBotPopupOnClosed(object? sender, PopupClosedEventArgs e)
	{
		_dataContext.StopScanCommand.TryExecute(e.Result);
	}

	private void CloseOnClicked(object? sender, EventArgs e)
	{
		Close();
	}
}
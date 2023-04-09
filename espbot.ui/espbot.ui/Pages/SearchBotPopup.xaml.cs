using espbot.ui.ViewModules;

namespace espbot.ui.Pages;

public partial class SearchBotPopup
{
	public SearchBotPopup(SearchBotViewModel dataContext)
	{
		InitializeComponent();

		BindingContext = dataContext;
	}
}
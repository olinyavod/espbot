using espbot.ui.ViewModules;

namespace espbot.ui.Pages;

public partial class HomePage
{
	public HomePage(HomeViewModel dataContext)
	{
		InitializeComponent();

		BindingContext = dataContext;
	}
}


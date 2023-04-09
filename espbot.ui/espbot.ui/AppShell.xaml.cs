using espbot.ui.ViewModules;

namespace espbot.ui;

public partial class AppShell
{
	public AppShell(ShellViewModel dataContext)
	{
		if (dataContext == null) throw new ArgumentNullException(nameof(dataContext));

		InitializeComponent();
		BindingContext = dataContext;
	}
}

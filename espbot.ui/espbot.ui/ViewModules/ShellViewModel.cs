using CommunityToolkit.Mvvm.ComponentModel;

namespace espbot.ui.ViewModules;

[ObservableObject]
public partial class ShellViewModel
{
	[ObservableProperty]
	private bool _flyoutIsPresented;

	public ShellViewModel()
	{
	}
}
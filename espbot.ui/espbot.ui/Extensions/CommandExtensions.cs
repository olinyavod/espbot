using ABI.System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace espbot.ui.Extensions;

static class CommandExtensions
{
	public static bool TryExecute(this IAsyncRelayCommand? command, object? parameter = null)
	{
		if(command?.CanExecute(parameter) is not true)
			return false;

		command.Execute(parameter);
		return true;
	}

	public static bool TryExecute(this ICommand? command, object? parameter = null)
	{
		if(command?.CanExecute(parameter) is not true)
			return false;

		command.Execute(parameter);
		return true;
	}
}
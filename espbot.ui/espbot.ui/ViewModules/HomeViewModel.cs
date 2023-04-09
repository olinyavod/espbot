using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using espbot.ui.Servuces;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace espbot.ui.ViewModules;

[ObservableObject]
public partial class HomeViewModel
{
	private readonly IBluetoothLE _bluetooth;
	private readonly INavigationService _navigationService;

	[ObservableProperty]
	private int _count;

	[ObservableProperty]
	private bool _isBluetoothEnabled;

	[ObservableProperty]
	private bool _bluetoothAvailable;

	[ObservableProperty]
	private string? _counterTitle = "Click me";

	public HomeViewModel
	(
		IBluetoothLE bluetooth,
		INavigationService navigationService
	)
	{
		_bluetooth = bluetooth ?? throw new ArgumentNullException(nameof(bluetooth));
		_navigationService = navigationService;

		_bluetooth.StateChanged += BluetoothOnStateChanged;

		_bluetoothAvailable = bluetooth.IsAvailable;
	}

	private void BluetoothOnStateChanged(object sender, BluetoothStateChangedArgs e)
	{
		IsBluetoothEnabled = e.NewState == BluetoothState.On;
	}

	private bool OnCanScanClicked() => BluetoothAvailable;

	[RelayCommand(CanExecute = nameof(OnCanScanClicked), AllowConcurrentExecutions = false)]
	private Task OnScanClicked()
	{
		return _navigationService.ShowPopupAsync<SearchBotViewModel>();
	}
}
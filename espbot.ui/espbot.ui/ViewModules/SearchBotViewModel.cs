using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using espbot.ui.Extensions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace espbot.ui.ViewModules;

[ObservableObject]
public partial class SearchBotViewModel
{
	private readonly IBluetoothLE _bluetooth;
	private readonly HashSet<Guid> _devices = new();


	public ObservableCollection<BLEDeviceItemViewModel> DevicesSource { get; } = new();

	public SearchBotViewModel(IBluetoothLE bluetooth)
	{
		_bluetooth = bluetooth ?? throw new ArgumentNullException(nameof(bluetooth));

		_bluetooth.Adapter.DeviceAdvertised += AdapterOnDeviceAdvertised;

		StartScanCommand.TryExecute();
	}

	private void AdapterOnDeviceAdvertised(object? sender, DeviceEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			if(!_devices.Add(e.Device.Id))
				return;

			DevicesSource.Add(new BLEDeviceItemViewModel
			{
				Id = e.Device.Id,
				Name = e.Device.Name
			});
		});
	}

	[RelayCommand(AllowConcurrentExecutions = false)]
	private Task StartScan()
	{
		_devices.Clear();
		DevicesSource.Clear();

		return _bluetooth.Adapter.StartScanningForDevicesAsync();
	}

	private bool CanStopScan() => _bluetooth.Adapter.IsScanning;

	[RelayCommand(AllowConcurrentExecutions = true, CanExecute = nameof(CanStopScan))]
	private Task StopScan() => _bluetooth.Adapter.StopScanningForDevicesAsync();
}

[ObservableObject]
public partial class BLEDeviceItemViewModel
{
	public Guid Id { get; set; }

	public string? Name { get; set; }
}
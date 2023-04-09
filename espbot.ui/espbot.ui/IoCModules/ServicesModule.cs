using Plugin.BLE;

namespace espbot.ui.IoCModules;

static class ServicesModule
{
	public static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.AddSingleton(CrossBluetoothLE.Current);

		return services;
	}
}
using CommunityToolkit.Mvvm.DependencyInjection;
using espbot.ui.IoCModules;

namespace espbot.ui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		var ioc = Ioc.Default;
		ioc.ConfigureServices(ConfigureServices());

		MainPage = ioc.GetRequiredService<AppShell>();
	}

	private static IServiceProvider ConfigureServices() => new ServiceCollection()
		.RegisterPages()
		.RegisterServices()
		.BuildServiceProvider();

}

using CommunityToolkit.Mvvm.DependencyInjection;

namespace espbot.ui.Servuces;

class PageFactory<TPage> : RouteFactory
	where TPage : Page
{
	public override Element GetOrCreate()
	{
		return Ioc.Default.GetRequiredService<TPage>();
	}

	public override Element GetOrCreate(IServiceProvider services) => GetOrCreate();
}
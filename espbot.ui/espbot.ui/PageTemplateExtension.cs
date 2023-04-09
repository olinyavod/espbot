using CommunityToolkit.Mvvm.DependencyInjection;

namespace espbot.ui;

[ContentProperty(nameof(PageType))]
class PageTemplateExtension: IMarkupExtension
{
	public Type PageType { get; set; }

	public object ProvideValue(IServiceProvider serviceProvider)
	{
		return new DataTemplate(() => Ioc.Default.GetRequiredService(PageType));
	}
}
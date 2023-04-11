namespace ResourcesStore
{
	[Logo("photo.jpg")]
	public class Class1
	{

	}

	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	public sealed class LogoAttribute : Attribute
	{
		public string ImageName { get; }

		// See the attribute guidelines at 
		//  http://go.microsoft.com/fwlink/?LinkId=85236
		public LogoAttribute(string imageName)
		{
			ImageName = imageName;
		}
	}
}
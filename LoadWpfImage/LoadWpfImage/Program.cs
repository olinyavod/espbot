
using System.Reflection;
using System.Resources;
using System.Windows.Media.Imaging;
using ResourcesStore;

var testClass = typeof(Class1);

var logo= testClass.GetCustomAttribute<LogoAttribute>();

using var img = testClass.Assembly.GetManifestResourceStream($"{testClass.Namespace}.{logo.ImageName}");

var bmp = new BitmapImage();

bmp.BeginInit();
bmp.StreamSource = img;
bmp.EndInit();

var w = bmp.PixelWidth;
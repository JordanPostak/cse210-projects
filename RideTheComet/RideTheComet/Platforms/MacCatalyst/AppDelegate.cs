using Foundation;
using Microsoft.Maui.Hosting;

namespace RideTheComet;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
}
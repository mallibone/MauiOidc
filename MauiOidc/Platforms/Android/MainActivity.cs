using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MauiOidc;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnResume()
	{
		base.OnResume();

		Microsoft.Maui.ApplicationModel.Platform.OnResume(this);
	}
}


using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MauiOidc;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(
		new[] { Microsoft.Maui.ApplicationModel.Platform.Intent.ActionAppAction },
		Categories = new[] { Intent.CategoryDefault })]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? bundle)
    {
        base.OnCreate(bundle);

		Microsoft.Maui.ApplicationModel.Platform.Init(this, bundle);
    }

    protected override void OnResume()
	{
		base.OnResume();

		Microsoft.Maui.ApplicationModel.Platform.OnResume(this);
	}
	protected override void OnNewIntent(Intent intent)
	{
		base.OnNewIntent(intent);

		Microsoft.Maui.ApplicationModel.Platform.OnNewIntent(intent);
	}
}


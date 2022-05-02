using Android.App;
using Android.Content;
using Android.Content.PM;

namespace MauiOidc;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(
        new[] {Intent.ActionView},
		Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
		DataScheme = App.CallbackUri)]
public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
}


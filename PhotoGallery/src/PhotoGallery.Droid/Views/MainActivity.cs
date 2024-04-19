using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Transformations;
using MvvmCross.Forms.Platforms.Android.Views;
using PhotoGallery.Core.ViewModels;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;
using Rg.Plugins.Popup;
using Xamarin.Essentials;
using XamEffects.Droid;

namespace PhotoGallery.Droid.Views
{
    [Activity(LaunchMode = LaunchMode.SingleTop, Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            CrossCurrentActivity.Current.Init(this, bundle);
            CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CachedImageRenderer.Init(false);
            CachedImageRenderer.InitImageViewHandler();
            Popup.Init(this);

            //Avoid linker error
            var ignore = new CircleTransformation();

            UserDialogs.Init(this);
            Effects.Init();

            Platform.Init(this, bundle);

            base.OnCreate(bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
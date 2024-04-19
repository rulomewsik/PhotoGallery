using FFImageLoading.Forms.Platform;
using FFImageLoading.Transformations;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Core;
using PhotoGallery.Core;
using Rg.Plugins.Popup;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfCarousel.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using Syncfusion.XForms.iOS.TabView;
using UIKit;

namespace PhotoGallery.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, App, UI.App>
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            MvxIosSetupSingleton.EnsureSingletonAvailable(this, Window)
                .EnsureInitialized();

            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            XamEffects.iOS.Effects.Init();
            Popup.Init();
            SfTabViewRenderer.Init(); 
            SfCarouselRenderer.Init();
            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init();
            SfPullToRefreshRenderer.Init();
            
            //Avoid linker error
            var ignore = new CircleTransformation();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
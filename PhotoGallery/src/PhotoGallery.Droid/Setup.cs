#nullable enable
using Android.App;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Plugin;
using PhotoGallery.Core;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace PhotoGallery.Droid
{
    public class Setup : MvxFormsAndroidSetup<App, UI.App>
    {
        protected override ILoggerProvider? CreateLogProvider()
        {
            return null;
        }

        protected override ILoggerFactory? CreateLogFactory()
        {
            return null;
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Messenger.Plugin>();
        }
    }
}
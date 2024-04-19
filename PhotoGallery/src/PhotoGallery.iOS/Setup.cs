using PhotoGallery.Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Plugin;

namespace PhotoGallery.iOS
{
    public class Setup : MvxFormsIosSetup<App, UI.App>
    {
        protected override ILoggerProvider CreateLogProvider()
        {
            return null;
        }

        protected override ILoggerFactory CreateLogFactory()
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
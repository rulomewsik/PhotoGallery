using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace PhotoGallery.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class RootPage
    {
        public RootPage()
        {
            InitializeComponent();
        }
    }
}
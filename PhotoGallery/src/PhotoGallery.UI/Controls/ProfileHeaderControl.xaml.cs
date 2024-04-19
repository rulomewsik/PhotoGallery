using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace PhotoGallery.UI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileHeaderControl : MvxContentView
    {
        public ProfileHeaderControl()
        {
            InitializeComponent();
        }
    }
}
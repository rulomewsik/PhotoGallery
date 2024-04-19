using System;
using Syncfusion.ListView.XForms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace PhotoGallery.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosView
    {
        public PhotosView()
        {
            InitializeComponent();
        }

        private void SfListView_OnItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action == DragAction.Start || e.Action == DragAction.Drop)
            {
                HapticFeedback.Perform(HapticFeedbackType.LongPress);
            }
        }

        private void SfListView_OnSwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            HapticFeedback.Perform(HapticFeedbackType.LongPress);
        }

        private void SfPullToRefresh_OnRefreshing(object sender, EventArgs e)
        {
            HapticFeedback.Perform(HapticFeedbackType.LongPress);
        }

        private void SfPullToRefresh_OnRefreshed(object sender, EventArgs e)
        {
            HapticFeedback.Perform();
        }
    }
}
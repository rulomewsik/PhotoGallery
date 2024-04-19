using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PhotoGallery.Core.Models.Photos;
using PhotoGallery.Core.Utilities;

namespace PhotoGallery.Core.Models.Service.Response
{
    public class GetAllPhotosResponse : BindableBase
    {
        private ObservableCollection<PhotoItem> _jobHistory;

        [JsonProperty("jobHistory")]
        public ObservableCollection<PhotoItem> JobHistory
        {
            get => _jobHistory;
            set => SetProperty(ref _jobHistory, value);
        }
    }
}
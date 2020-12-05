using Billbort.Presenter;
using DAL.Repositories.Implementations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class AdvertisementPage : Page
    {
        private AdvertisementService _advertisementService;
        public AdvertisementPage()
        {
            InitializeComponent();
            var createNewVideoRepository = new CreateNewVideoRepository();
            _advertisementService = new AdvertisementService(createNewVideoRepository);
            var videos = createNewVideoRepository.GetAll();
            var userVideos = videos.Where(c => c.OwnerId == AuthorizationPage.UserId);
            advertisementGrid.ItemsSource = userVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_Click_LoadVideo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadAdvertisementPage());
        }
        public void Button_Click_DeleteVideo(object sender, RoutedEventArgs e)
        {
            _advertisementService.DeleteVideo(sender);
            this.NavigationService.Navigate(new AdvertisementPage());
        }
    }
}

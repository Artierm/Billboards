using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class AdvertisementPage : Page
    {
        private readonly AdvertisementService _advertisementService;
        public AdvertisementPage()
        {
            InitializeComponent();
            var createNewVideoRepository = new CreateNewVideoRepository();
            var createNewLogRepository = new CreateNewLogRepository();
            var createNewUserRepository = new CreateNewUserRepository();
            _advertisementService = new AdvertisementService(createNewVideoRepository, createNewLogRepository, createNewUserRepository);
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

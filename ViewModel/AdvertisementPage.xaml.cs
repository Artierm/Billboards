using BillboardProject.Service;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class AdvertisementPage : Page
    {
        private readonly AdvertisementService _advertisementService;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public AdvertisementPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _advertisementService = new AdvertisementService(_createNewVideoRepository, _createNewLogRepository, _createNewUserRepository);
            var videos = createNewVideoRepository.GetAll();
            var userVideos = videos.Where(c => c.OwnerId == AuthorizationPage.UserId);
            advertisementGrid.ItemsSource = userVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        public void Button_Click_LoadVideo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadAdvertisementPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
        public void Button_Click_DeleteVideo(object sender, RoutedEventArgs e)
        {
            _advertisementService.DeleteVideo(sender);
            this.NavigationService.Navigate(new AdvertisementPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}

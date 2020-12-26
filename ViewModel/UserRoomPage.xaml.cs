using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class UserRoomPage : Page
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public UserRoomPage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
        }

        private void Button_Click_Billboards(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
        private void Button_Click_Advertisement(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdvertisementPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class AdminRoomPage : Page
    {
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public AdminRoomPage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
        }

        private void Button_Click_Billboards (object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CrudUserPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        public void Button_Click_Logs(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LogsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}

using BillboardProject.View;
using System.Windows;
using System.Windows.Controls;
using BillboardsProject.View;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class SchedulePage : Page
    {

        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        private readonly CreateScheduleService _createScheduleService;
        public SchedulePage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            schedulesAndVideosGrid.ItemsSource = _createNewScheduleRepository.GetAll();
            _createScheduleService = new CreateScheduleService(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository);

        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        public void Button_Click_CreateSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateSchedulePage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        public void Button_Click_Delete_Schedule(object sender, RoutedEventArgs e)
        {
            _createScheduleService.DeleteSchedule(sender);
            this.NavigationService.Navigate(new SchedulePage(_createNewBillboardRepository,  _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

        public void Button_Click_View_Schedule(object sender, RoutedEventArgs e)
        {
             ViewUserSchedulePage.ScheduleAndVideos = _createScheduleService.ViewSchedule(sender);
            this.NavigationService.Navigate(new ViewUserSchedulePage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

    }
}

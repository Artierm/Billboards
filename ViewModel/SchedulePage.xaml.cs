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
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;

        private readonly CreateScheduleService _createScheduleService;
        public SchedulePage(ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewVideoRepository createNewVideoRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            schedulesAndVideosGrid.ItemsSource = _createNewScheduleRepository.GetAll();
            _createScheduleService = new CreateScheduleService(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository);

        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_Click_CreateSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateSchedulePage());
        }

        public void Button_Click_Delete_Schedule(object sender, RoutedEventArgs e)
        {
            _createScheduleService.DeleteSchedule(sender);
            this.NavigationService.Navigate(new SchedulePage(_createNewScheduleRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository));
        }

        public void Button_Click_View_Schedule(object sender, RoutedEventArgs e)
        {
             ViewUserSchedulePage.ScheduleAndVideos = _createScheduleService.ViewSchedule(sender);
            this.NavigationService.Navigate(new ViewUserSchedulePage());
        }

    }
}

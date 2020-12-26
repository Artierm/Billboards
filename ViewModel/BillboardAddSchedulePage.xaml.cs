using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BillboardProject;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.View
{
    public partial class BillboardAddSchedulePage : Page
    {
        private readonly CreateScheduleService _createScheduleService;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        public static Billboard Billboard { get; set; }

        public BillboardAddSchedulePage(ICreateNewLogRepository createNewLogRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewScheduleRepository createNewScheduleRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            var schedules =  _createNewScheduleRepository.GetAll();
            var workSchedules = schedules.Where(c => c.User == user);
            schedulesGrid.ItemsSource = schedules;
            _createScheduleService = new CreateScheduleService(_createNewBillboardRepository,_createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository);
        }

        private void Button_Click_Choose_Schedule(object sender, RoutedEventArgs e)
        {
            _createScheduleService.ChooseSchedule(sender);
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }
    }
}

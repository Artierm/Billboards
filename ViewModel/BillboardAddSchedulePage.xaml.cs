using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BillboardProject;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.View
{
    /// <summary>
    /// Interaction logic for BillboardAddSchedulePage.xaml
    /// </summary>
    public partial class BillboardAddSchedulePage : Page
    {
        private readonly CreateScheduleService _createScheduleService;
        private  readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;

        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        public static Billboard Billboard { get; set; }

        public BillboardAddSchedulePage(ICreateNewScheduleRepository сreateNewScheduleRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewVideoRepository createNewVideoRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = сreateNewScheduleRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            var user = _createNewUserRepository.GetById(AuthorizationPage.UserId);
            var schedules =  _createNewScheduleRepository.GetAll();
            var workSchedules = schedules.Where(c => c.User == user);
            schedulesGrid.ItemsSource = schedules;
            _createScheduleService = new CreateScheduleService(_createNewBillboardRepository,_createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository);
        }

        private void Button_Click_Choose_Schedule(object sender, RoutedEventArgs e)
        {
            _createScheduleService.ChooseSchedule(sender);
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository));
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository));
        }
    }
}

using BillboardProject.Service;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BillboardsProject.View;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class UserBillboardsPage : Page
    {
        private readonly UserViewBillboardService _userViewBillboardService;

        private readonly CreateScheduleService _createScheduleService;

        private  readonly  ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;

        public UserBillboardsPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            var billboards = _createNewBillboardRepository.GetAll();
            var newBillboards = billboards.Where(c => c.Owner != string.Empty);
            billsGrid.ItemsSource = newBillboards;
            _userViewBillboardService = new UserViewBillboardService();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createScheduleService = new CreateScheduleService(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository);
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            _userViewBillboardService.ViewBillboard(sender, out int id, out string address, out string owner);
            UserViewBillboardPage.BillboardAddress = address;
            UserViewBillboardPage.BillboardId = id;
            UserViewBillboardPage.BillboardOwner = owner;
            this.NavigationService.Navigate(new UserViewBillboardPage(_createNewVideoRepository,_createNewScheduleAndVideoRepository, _createNewBillboardRepository,_createNewScheduleRepository));
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        private void Button_Click_Add_Schedule (object sender, RoutedEventArgs e)
        {
            _createScheduleService.AddBillboardToSchedule(sender, out Billboard billboard);
            BillboardAddSchedulePage.Billboard = billboard;
            this.NavigationService.Navigate(new BillboardAddSchedulePage(_createNewScheduleRepository, _createNewUserRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository));
        }

        private void Button_Click_View_Registration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterBillboardPage( _createNewScheduleRepository, _createNewUserRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewVideoRepository));
        }

    }
}

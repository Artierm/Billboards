using BillboardProject.Service;
using DAL.Models;
using DAL.Repositories.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class AdminViewBillboardPage : Page
    {
        private readonly AdminViewBillboardService _adminViewBillboardService;

        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public AdminViewBillboardPage(ICreateNewBillboardRepository createNewBillboardRepository,
            ICreateNewScheduleRepository createNewScheduleRepository,
            ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository,
            ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository,
            ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewScheduleRepository = createNewScheduleRepository;
            _adminViewBillboardService = new AdminViewBillboardService(_createNewBillboardRepository, _createNewLogRepository);
            string address = UserViewBillboardPage.BillboardAddress;
            var billboards = _createNewBillboardRepository.GetAll();
            var billboard = billboards.FirstOrDefault(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();
            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }

        public void Button_Click_DeleteBillboard(object sender, RoutedEventArgs e)
        {
            _adminViewBillboardService.DeleteBillboard(sender);
            this.NavigationService.Navigate(new AdminBillboardsPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }
    }
}

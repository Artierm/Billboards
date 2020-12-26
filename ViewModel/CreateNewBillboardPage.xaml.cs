using BillboardProject.Model;
using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class CreateNewBillboardPage : Page, IRegistration
    {
        private readonly CreateNewBillboardService _createNewBillboardService;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public string BillboardCreateAddress { get => billboard_address.Text.Trim(); set => billboard_address.Text = value.Trim(); }
        public CreateNewBillboardPage(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleRepository createNewScheduleRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository, ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewScheduleRepository = createNewScheduleRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewVideoRepository = createNewVideoRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewBillboardService = new CreateNewBillboardService(_createNewBillboardRepository, _createNewLogRepository);
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }
        public void Button_Click_AddBillboard(object sender, RoutedEventArgs e)
        {
            _createNewBillboardService.AddBillboard(BillboardCreateAddress);
            this.NavigationService.Navigate(new AdminBillboardsPage(_createNewLogRepository, _createNewUserRepository, _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository, _createNewScheduleRepository));
        }
    }
}

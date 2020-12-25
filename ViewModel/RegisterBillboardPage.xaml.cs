using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class RegisterBillboardPage : Page
    { 
        private readonly RegisterBillboardService _registerBillboardService;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
 
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        public RegisterBillboardPage(ICreateNewScheduleRepository сreateNewScheduleRepository, ICreateNewUserRepository createNewUserRepository, ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository, ICreateNewVideoRepository createNewVideoRepository)
        {
            InitializeComponent();
            
            _createNewScheduleRepository = сreateNewScheduleRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewScheduleAndVideoRepository = createNewScheduleAndVideoRepository;
            _createNewVideoRepository = createNewVideoRepository;

            _registerBillboardService = new RegisterBillboardService(_createNewBillboardRepository, new CreateNewUserRepository(), new CreateNewLogRepository());
            var billboards = createNewBillboardRepository.GetAll();
            var newBillboards = billboards.Where(c => c.Owner == string.Empty);
            billsGrid.ItemsSource = newBillboards;
        }
        public void Button_Click_Register_Billboard(object sender, RoutedEventArgs e)
        {
            _registerBillboardService.RegisterBillboard(sender);
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository,_createNewUserRepository, _createNewVideoRepository));
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository));
        }       
    }
}

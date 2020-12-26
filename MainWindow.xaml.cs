using BillboardProject.Service;
using System.Windows;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class MainWindow : Window
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public MainWindow()
        {

            Loaded += MyWindow_Loaded;
            InitializeComponent();
            _createNewVideoRepository = new CreateNewVideoRepository();
            _createNewLogRepository = new CreateNewLogRepository();
            _createNewScheduleAndVideoRepository = new CreateNewScheduleAndVideoRepository();
            _createNewScheduleRepository = new CreateNewScheduleRepository();
            _createNewUserRepository = new CreateNewUserRepository();
            _createNewBillboardRepository = new CreateNewBillboardRepository();
            
        }

        public void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new AuthorizationPage(_createNewBillboardRepository, _createNewScheduleRepository, _createNewScheduleAndVideoRepository, _createNewUserRepository, _createNewVideoRepository, _createNewLogRepository));
        }

    }
}

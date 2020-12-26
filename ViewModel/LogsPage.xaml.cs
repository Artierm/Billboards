using System;
using System.Windows;
using System.Windows.Controls;
using BillboardsProject.Model.Services;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardProject
{
    public partial class LogsPage : Page
    {

        private LogService logService;

        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewScheduleRepository _createNewScheduleRepository;
        private readonly ICreateNewScheduleAndVideoRepository _createNewScheduleAndVideoRepository;
        private readonly ICreateNewUserRepository _createNewUserRepository;
        private readonly ICreateNewVideoRepository _createNewVideoRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public LogsPage(ICreateNewBillboardRepository createNewBillboardRepository,
            ICreateNewScheduleRepository createNewScheduleRepository,
            ICreateNewScheduleAndVideoRepository createNewScheduleAndVideoRepository,
            ICreateNewUserRepository createNewUserRepository, ICreateNewVideoRepository createNewVideoRepository,
            ICreateNewLogRepository createNewLogRepository)
        {
            InitializeComponent();
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewLogRepository = createNewLogRepository;
            _createNewUserRepository = createNewUserRepository;
            _createNewLogRepository = createNewLogRepository;

            var logs = createNewLogRepository.GetAll();
            logService = new LogService(createNewLogRepository);
            logsGrid.ItemsSource = logs;
        }

        public void Button_click_Create_Logs(object sender, RoutedEventArgs e)
        {
            logService.CreateFileLogs();
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage(_createNewLogRepository, _createNewUserRepository,
                _createNewVideoRepository, _createNewBillboardRepository, _createNewScheduleAndVideoRepository,
                _createNewScheduleRepository));
        }
    }
}

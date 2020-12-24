using System;
using System.Windows;
using System.Windows.Controls;
using BillboardsProject.Model.Services;
using DAL.Repositories.Implementations;

namespace BillboardProject
{
    public partial class LogsPage : Page
    {

        private LogService logService;
        public LogsPage()
        {
            InitializeComponent();
            var createNewLogRepository = new CreateNewLogRepository();
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
            this.NavigationService.Navigate(new AdminRoomPage());
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Implementations;

namespace BillboardProject
{
    public partial class LogsPage : Page
    {

        public LogsPage()
        {
            InitializeComponent();
            var createNewLogRepository = new CreateNewLogRepository();
            var logs = createNewLogRepository.GetAll();
            logsGrid.ItemsSource = logs;

        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage());
        }
    }
}

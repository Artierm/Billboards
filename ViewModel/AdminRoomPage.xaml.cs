using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class AdminRoomPage : Page
    {
        public AdminRoomPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Billboards (object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CrudUserPage());
        }

        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage());
        }

        public void Button_Click_Logs(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LogsPage());
        }
    }
}

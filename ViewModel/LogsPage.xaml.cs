using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            InitializeComponent();
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage());
        }
    }
}

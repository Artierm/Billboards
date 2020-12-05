using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class UserRoomPage : Page
    {
        public UserRoomPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Billboards(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }
        private void Button_Click_Advertisement(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdvertisementPage());
        }
        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

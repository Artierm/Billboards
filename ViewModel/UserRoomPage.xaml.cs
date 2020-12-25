using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Implementations;

namespace BillboardProject
{
    public partial class UserRoomPage : Page
    {
        public UserRoomPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Billboards(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage(new CreateNewBillboardRepository(), new CreateNewScheduleRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewUserRepository(), new CreateNewVideoRepository()));
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage( new CreateNewScheduleRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewVideoRepository()));
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

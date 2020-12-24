using BillboardProject.View;
using System.Windows;
using System.Windows.Controls;
using DAL.Repositories.Implementations;

namespace BillboardProject
{
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_Click_CreateSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateSchedulePage());
        }

    }
}

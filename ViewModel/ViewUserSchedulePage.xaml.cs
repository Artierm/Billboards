using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BillboardProject;
using DAL.Models;
using DAL.Repositories.Implementations;

namespace BillboardsProject.View
{
    /// <summary>
    /// Interaction logic for ViewUserSchedulePage.xaml
    /// </summary>
    public partial class ViewUserSchedulePage : Page
    {
        public static List<Video> ScheduleAndVideos;
        public ViewUserSchedulePage()
        {
            InitializeComponent();
            videosGrid.ItemsSource = ScheduleAndVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage(new CreateNewScheduleRepository(), new CreateNewBillboardRepository(), new CreateNewScheduleAndVideoRepository(), new CreateNewVideoRepository()));
        }
    }
}

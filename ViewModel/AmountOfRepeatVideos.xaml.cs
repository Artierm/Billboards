using DAL.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Billbort.View
{
    /// <summary>
    /// Interaction logic for AmountOfRepeatVideos.xaml
    /// </summary>
    public partial class AmountOfRepeatVideos : Page
    {
       private List<Video> Videos { get; set; }
        public AmountOfRepeatVideos(List<Video> videos)
        {
            InitializeComponent();
            Videos = videos;
            videosGrid.ItemsSource = videos;
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new CreateSchedulePage());
        }

        public void Button_Click_Save_and_Continue(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }
    }
}

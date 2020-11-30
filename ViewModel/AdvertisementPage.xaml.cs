using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdvertisementPage : Page
    {
        private DatabaseContext database;

        public AdvertisementPage()
        {
            InitializeComponent();
            database = new DatabaseContext();

            List<Video> videos = database.Videos.ToList();
            var userVideos = videos.Where(c => c.OwnerId == AuthorizationPage.UserId);
            advertisementGrid.ItemsSource = userVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadAdvertisementPage());
        }
    }
}

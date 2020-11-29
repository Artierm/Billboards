using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class Advertisement : Page
    {
        public event EventHandler backEvent;
        private ApplicationContext database;

        public Advertisement()
        {
            InitializeComponent();
            database = new ApplicationContext();
            List<Video> videos = database.Videos.ToList();
            var userVideos = videos.Where(c => c.IdOwner == Authorization.IdUser);
            advertisementGrid.ItemsSource = userVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserRoom());
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new LoadAdvertisement());
        }
    }
}

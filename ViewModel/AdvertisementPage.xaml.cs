using BillboardsProject.Presenter;
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
        private AdvertisementPresenter _advertisementPresenter;

        public AdvertisementPage()
        {
            InitializeComponent();
            database = new DatabaseContext();
            _advertisementPresenter = new AdvertisementPresenter();
            List<Video> videos = database.Videos.ToList();
            var userVideos = videos.Where(c => c.OwnerId == AuthorizationPage.UserId);
            advertisementGrid.ItemsSource = userVideos;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_Click_LoadVideo(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadAdvertisementPage());
        }
        public void Button_Click_DeleteVideo(object sender, RoutedEventArgs e)
        {
            _advertisementPresenter.DeleteVideo(sender);
            this.NavigationService.Navigate(new AdvertisementPage());
        }
    }
}

using Billbort.Presents;
using Billbort.ViewModel;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class LoadAdvertisementPage : Page, ILoadAdvertisement
    {
        private LoadAdvertisementService _loadAdvertisementService;
        public string LoadAdvertisementNameVideo { get => name_video.Text.Trim(); set => name_video.Text = value.Trim(); }
        public int LoadAdvertisementTimeVideo { get => Convert.ToInt32(time_video.Text.Trim()); set => time_video.Text = value.ToString().Trim(); }
        public LoadAdvertisementPage()
        {
            InitializeComponent();
            _loadAdvertisementService = new LoadAdvertisementService(new CreateNewVideoRepository());
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdvertisementPage());
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
           _loadAdvertisementService.LoadVideo(LoadAdvertisementNameVideo, LoadAdvertisementTimeVideo);
            this.NavigationService.Navigate(new AdvertisementPage());
        }
    }
}

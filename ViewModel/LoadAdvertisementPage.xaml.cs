using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillboardsProject
{
    public partial class LoadAdvertisementPage : Page, ILoadAdvertisement
    {
        private LoadAdvertisementPresenter _loadAdvertisementPresenter;
        public string LoadAdvertisementNameVideo { get => name_video.Text.Trim(); set => name_video.Text = value.Trim(); }
        public int LoadAdvertisementTimeVideo { get => Convert.ToInt32(time_video.Text.Trim()); set => time_video.Text = value.ToString().Trim(); }
        public LoadAdvertisementPage()
        {
            InitializeComponent();
            _loadAdvertisementPresenter = new LoadAdvertisementPresenter();
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdvertisementPage());
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
           _loadAdvertisementPresenter.LoadVideo(LoadAdvertisementNameVideo, LoadAdvertisementTimeVideo);
            this.NavigationService.Navigate(new AdvertisementPage());
        }
    }
}

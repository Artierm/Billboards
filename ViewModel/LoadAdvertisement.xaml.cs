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
    /// <summary>
    /// Логика взаимодействия для LoadAdvertisement.xaml
    /// </summary>
    public partial class LoadAdvertisement : Page, ILoadAdvertisement
    {
        public delegate void AddAdvertisementDelegate(object sender, EventArgs e, string nameVideo, int timeVideo);
        public event AddAdvertisementDelegate addBillboardEvent;
        public string LoadAdvertisementNameVideo { get => name_video.Text.Trim(); set => name_video.Text = value.Trim(); }
        public int LoadAdvertisementTimeVideo { get => Convert.ToInt32(time_video.Text.Trim()); set => time_video.Text = value.ToString().Trim(); }
        public LoadAdvertisement()
        {
            InitializeComponent();
            LoadAdvertisementPresent loadAdvertisementPresent = new LoadAdvertisementPresent(this);
        }
        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            // backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Advertisement());
        }

        public void Button_LoadVideo(object sender, RoutedEventArgs e)
        {
            addBillboardEvent.Invoke(sender, e, LoadAdvertisementNameVideo, LoadAdvertisementTimeVideo);
            // backEvent.Invoke(sender, e);
            //this.NavigationService.Navigate(new Advertisement());
        }
    }
}

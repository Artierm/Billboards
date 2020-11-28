using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class Advertisement : Page
    {
        public event EventHandler backEvent;

        public Advertisement()
        {
            InitializeComponent();
            List<Video> advertisementList = new List<Video>
            {
                new Video {NameVideo="Shedule1",  TimeVideo= 80},
                new Video {NameVideo="Shedule2",  TimeVideo= 45},
                new Video {NameVideo="Shedule3",  TimeVideo = 65}
            };
            advertisementGrid.ItemsSource = advertisementList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserRoom());
        }

    }
}

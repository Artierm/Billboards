using System;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserRoom : Page
    {
        public event EventHandler billboardsEvent;
        public event EventHandler sheduleEvent;
        public event EventHandler advertismentEvent;
        public event EventHandler authorizationEvent;
        public UserRoom()
        {
            InitializeComponent();
        }

        private void Button_Click_Billboards(object sender, RoutedEventArgs e)
        {
            //billboardsEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            //sheduleEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Schedule());
        }
        private void Button_Click_Advertisement(object sender, RoutedEventArgs e)
        {
            //advertismentEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Advertisement());
        }
        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            //authorizationEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Authorization());
        }
    }
}

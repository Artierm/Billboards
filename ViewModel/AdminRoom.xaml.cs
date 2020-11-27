using System;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminRoom : Page
    {
        public event EventHandler billboardsEvent;
        public event EventHandler usersEvent;
        public event EventHandler authorizationEvent;
        public event EventHandler logsEvent;

        public AdminRoom()
        {
            InitializeComponent();
        }

        private void Button_Click_Billboards (object sender, RoutedEventArgs e)
        {
            //billboardsEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminBillboards());
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            //usersEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new CrudUser());
        }

        private void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            //authorizationEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Authorization());
        }

        public void Button_Click_Logs(object sender, RoutedEventArgs e)
        {
           // logsEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new Logs());
        }
    }
}

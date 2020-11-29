using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserBillboards : Page
    {
        public event EventHandler billboardEvent;
        public event EventHandler backEvent;
        private ApplicationContext database;
        public UserBillboards()
        {
            InitializeComponent();
            database = new ApplicationContext();
            List<Billboard> billboards = database.Billboards.ToList();
            //List<User> users = database.Users.ToList();
            //var owner = users.Find(c => c.Id == Authorization.IdUser);
            var newBillboards = billboards.Where(c => c.Owner != string.Empty);
            billsGrid.ItemsSource = newBillboards;
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            //billboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserViewBillboard());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserRoom());
        }

        private void Button_Click_View_Registration(object sender, RoutedEventArgs e)
        {
            //billboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new RegisterBillboard());
        }

    }
}

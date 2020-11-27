using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserBillboards : Page
    {
        public event EventHandler billboardEvent;
        public event EventHandler backEvent;
        public UserBillboards()
        {
            InitializeComponent();
            //List<Billboard> billsList = new List<Billboard>
            //{
            //    new Billboard {Id=1, Owner="Artyom Yermak", Address="Fedotova 5", View ="View"},
            //    new Billboard {Id=2, Owner="Maks Stankevich", Address="Kurchatova 17",View ="View"},
            //    new Billboard {Id=3, Owner="Sasha Bibikov", Address="Lenina 6",View ="View"},
            //    new Billboard {Id = 4 , Owner = string.Empty, Address=string.Empty,View = "Register"}

            //};
            //billsGrid.ItemsSource = billsList;
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            //billboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserViewBillboard());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            backEvent.Invoke(sender, e);
            //this.NavigationService.Navigate(new UserRoom());
        }
    }
}

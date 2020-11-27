using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserViewBillboard : Page
    {
        public event EventHandler backEvent;
        public UserViewBillboard()
        {
            InitializeComponent();

            //List<Billboard> billsList = new List<Billboard>
            //{
            //    new Billboard {Id=1, Owner="Artyom Yermak", Address="Fedotova 5",  NameVideo = "Apple presentation"}
            //};
            //billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
        }

    }
}

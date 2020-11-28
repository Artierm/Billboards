using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminViewBillboard : Page
    {
        public event EventHandler billboardsEvent;


        public AdminViewBillboard()
        {
            InitializeComponent();
            List<Billboard> billsList = new List<Billboard>
            {
                new Billboard {Id=1, Owner="Artyom Yermak", Address="Fedotova 5"}
            };
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //billboardsEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminBillboards());
        }

    }
}

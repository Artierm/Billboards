using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminBillboards : Page
    {
        public event EventHandler viewBillboardEvent;
        public event EventHandler backEvent;
        public event EventHandler createNewBillboardEvent;
        private ApplicationContext database;
        public AdminBillboards()
        {
            InitializeComponent();
            //{
            //    new Billboard {Id = 1, Owner="Artyom Yermak", Address="Fedotova 5"},
            //    new Billboard {Id = 2, Owner="Maks Stankevich", Address="Kurchatova 17" },
            //    new Billboard {Id = 3, Owner="Sasha Bibikov", Address="Lenina 6"},
            //    new Billboard {Id = 4 , Owner = string.Empty, Address=string.Empty}
            //};
            database = new ApplicationContext();
            List<Billboard> billboards = database.Billboards.ToList();
            billsGrid.ItemsSource = billboards;
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
           // viewBillboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminViewBillboard());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminRoom());
        }

        private void Button_CreateNewBillboard(object sender, RoutedEventArgs e)
        {
             //createNewBillboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new CreateNewBillboard());
        }
    }
}

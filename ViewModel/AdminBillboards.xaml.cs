using BillboardsProject.Presents;
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
        public delegate void ViewBillboardDelegate(object sender, EventArgs e, out int id, out string address, out string owner);
        public event ViewBillboardDelegate ViewBillboardEvent;
        private ApplicationContext database;
        public AdminBillboards()
        {
            InitializeComponent();
            database = new ApplicationContext();
            List<Billboard> billboards = database.Billboards.ToList();
           // var newBillboards = billboards.Where(c => c.Owner != string.Empty);
            billsGrid.ItemsSource = billboards;
            AdminBillboardsPresent userViewBillboardPresent = new AdminBillboardsPresent(this);
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            ViewBillboardEvent.Invoke(sender, e, out int id, out string address, out string owner);
            UserViewBillboard.AddressBillboard = address;
            UserViewBillboard.IdBillboard = id;
            UserViewBillboard.OwnerBillboard = owner;
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

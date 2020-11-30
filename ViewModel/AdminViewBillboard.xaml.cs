using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminViewBillboard : Page
    {
        public event EventHandler billboardsEvent;
        private ApplicationContext database;


        public AdminViewBillboard()
        {
            InitializeComponent();
            int id = UserViewBillboard.IdBillboard;
            string owner = UserViewBillboard.OwnerBillboard;
            string address = UserViewBillboard.AddressBillboard;
            database = new ApplicationContext();
            List<Billboard> billboards = database.Billboards.ToList();
            var billboard = billboards.Find(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();
            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //billboardsEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminBillboards());
        }

    }
}

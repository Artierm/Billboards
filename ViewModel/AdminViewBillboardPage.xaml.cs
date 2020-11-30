using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminViewBillboardPage : Page
    {
        private DatabaseContext database;

        public AdminViewBillboardPage()
        {
            InitializeComponent();
            database = new DatabaseContext();

            string address = UserViewBillboardPage.BillboardAddress;
            List<Billboard> billboards = database.Billboards.ToList();
            var billboard = billboards.Find(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();
            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }

    }
}

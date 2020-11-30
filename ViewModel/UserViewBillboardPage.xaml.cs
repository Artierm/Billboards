using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserViewBillboardPage : Page
    {
        public event EventHandler ViewBillboardEvent;
        //private UserViewBillboardPage userViewBillboard;

        private DatabaseContext database;
        public static int BillboardId { get; set; }
        public static string BillboardOwner { get; set; }
        public static string BillboardAddress { get; set; }

        public UserViewBillboardPage()
        {
            InitializeComponent();
            string address = UserViewBillboardPage.BillboardAddress;
            database = new DatabaseContext();
            List<Billboard> billboards = database.Billboards.ToList();
            var billboard = billboards.Find(c => c.Address == address);
            List<Billboard> billsList = new List<Billboard>();
            billsList.Add(billboard);
            billsGrid.ItemsSource = billsList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }

        public void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            ViewBillboardEvent.Invoke(sender, e);
        }

    }
}

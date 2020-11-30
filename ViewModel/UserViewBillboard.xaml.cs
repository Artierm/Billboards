using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserViewBillboard : Page
    {
        public event EventHandler backEvent;
        public event EventHandler ViewBillboardEvent;
        public UserViewBillboard userViewBillboard;
        private ApplicationContext database;
        public static int IdBillboard { get; set; }
        public static string OwnerBillboard { get; set; }
        public static string AddressBillboard { get; set; }




        public UserViewBillboard()
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
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
        }

        public void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            ViewBillboardEvent.Invoke(sender, e);
            //backEvent.Invoke(sender, e);
            //this.NavigationService.Navigate(new UserBillboards());
        }

    }
}

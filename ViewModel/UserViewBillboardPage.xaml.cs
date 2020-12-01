using BillboardsProject.Presents;
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

        private DatabaseContext database;
        private UserBillboardsPresenter _userBillboardsPresenter;
        public static int BillboardId { get; set; }
        public static string BillboardOwner { get; set; }
        public static string BillboardAddress { get; set; }

        public UserViewBillboardPage()
        {
            InitializeComponent();
            _userBillboardsPresenter = new UserBillboardsPresenter();
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
            _userBillboardsPresenter.ViewBillboard(sender, out int id, out string address, out string owner);
        }

    }
}

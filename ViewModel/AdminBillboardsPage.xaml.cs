using BillboardsProject.Presents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AdminBillboardsPage : Page
    {
        private DatabaseContext database;
        private AdminBillboardsPresenter _adminBillboardsPresenter;
        public AdminBillboardsPage()
        {
            InitializeComponent();
            _adminBillboardsPresenter = new AdminBillboardsPresenter();
            database = new DatabaseContext();
            List<Billboard> billboards = database.Billboards.ToList();
            billsGrid.ItemsSource = billboards;
    
        }

        private void Button_Click_ViewBillboard(object sender, RoutedEventArgs e)
        {
            _adminBillboardsPresenter.ViewBillboard(sender, out int id, out string address, out string owner);
            UserViewBillboardPage.BillboardAddress = address;
            UserViewBillboardPage.BillboardId = id;
            UserViewBillboardPage.BillboardOwner = owner;
            this.NavigationService.Navigate(new AdminViewBillboardPage());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage());
        }

        private void Button_Click_CreateNewBillboard(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewBillboardPage());
        }
    }
}

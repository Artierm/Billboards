using BillboardsProject.Presents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class UserBillboardsPage : Page
    {
        private DatabaseContext _database;
        private UserBillboardsPresenter _userViewBillboardPresenter;
        public UserBillboardsPage()
        {
            InitializeComponent();
            _database = new DatabaseContext();
            List<Billboard> billboards = _database.Billboards.ToList();
            var newBillboards = billboards.Where(c => c.Owner != string.Empty);
            billsGrid.ItemsSource = newBillboards;
            _userViewBillboardPresenter = new UserBillboardsPresenter();
        }

        private void Button_Click_View_Billboard(object sender, RoutedEventArgs e)
        {
            _userViewBillboardPresenter.ViewBillboard(sender, out int id, out string address, out string owner);
            UserViewBillboardPage.BillboardAddress = address;
            UserViewBillboardPage.BillboardId = id;
            UserViewBillboardPage.BillboardOwner = owner;
            this.NavigationService.Navigate(new UserViewBillboardPage());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        private void Button_Click_View_Registration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterBillboardPage());
        }

    }
}

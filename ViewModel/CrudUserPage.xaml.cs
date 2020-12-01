using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class CrudUserPage : Page
    {
        private DatabaseContext _database;
        private CrudUserPresenter _crudUserPresenter;
        public CrudUserPage()
        {
            InitializeComponent();
            _database = new DatabaseContext();

            _crudUserPresenter = new CrudUserPresenter();
            List<User> users = _database.Users.ToList();
            var realUsers = users.Where(c => c.Id != 1);
            usersGrid.ItemsSource = realUsers;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new AdminRoomPage());
        }

        public void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            _crudUserPresenter.RemoveUser(sender);
            this.NavigationService.Navigate(new CrudUserPage());
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewUserPage());
        }

    }
}

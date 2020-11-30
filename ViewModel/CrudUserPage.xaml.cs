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

        public event EventHandler DeleteUserEvent;
        private DatabaseContext database;

        public CrudUserPage()
        {
            InitializeComponent();
            database = new DatabaseContext();

            CrudUserPresenter crudUserPresenter = new CrudUserPresenter(this);
            List<User> users = database.Users.ToList();
            var realUsers = users.Where(c => c.Id != 1);
            usersGrid.ItemsSource = realUsers;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new AdminRoomPage());
        }

        public void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            DeleteUserEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new CrudUserPage());
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewUserPage());
        }

    }
}

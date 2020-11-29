using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class CrudUser : Page
    {

        public event EventHandler backEvent;
        public event EventHandler DeleteUserEvent;
        public event EventHandler AddNewUserEvent;
        private ApplicationContext database;

     
        public CrudUser()
        {
            InitializeComponent();
            CrudUserPresent crudUserPresent = new CrudUserPresent(this);
            database = new ApplicationContext();
            List<User> users = database.Users.ToList();
            var realUsers = users.Where(c => c.Id != 1);
            usersGrid.ItemsSource = realUsers;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           // backEvent.Invoke(sender, e);
           this.NavigationService.Navigate(new AdminRoom());
        }

        public void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            DeleteUserEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminRoom());
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            //AddNewUserEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new CreateNewUser());
        }

    }
}

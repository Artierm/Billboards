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
            //List<Owner> usersList = new List<Owner>
            //{
            //    new Owner {Name="Artyom Yermak",  IdBillboards = "1 2 5", AmountOfBillboards = 3},
            //    new Owner {Name="Maks Stankevich",  IdBillboards = "3 6", AmountOfBillboards = 2},
            //    new Owner {Name="Sasha Bibilov",  IdBillboards = "4", AmountOfBillboards = 1}
            //};
            CrudUserPresent crudUserPresent = new CrudUserPresent(this);
            database = new ApplicationContext();
            List<User> users = database.Users.ToList();
            usersGrid.ItemsSource = users;
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

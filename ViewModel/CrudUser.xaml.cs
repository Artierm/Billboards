using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class CrudUser : Page
    {
        public event EventHandler backEvent;
        public CrudUser()
        {
            InitializeComponent();
            //List<Owner> usersList = new List<Owner>
            //{
            //    new Owner {Name="Artyom Yermak",  IdBillboards = "1 2 5", AmountOfBillboards = 3},
            //    new Owner {Name="Maks Stankevich",  IdBillboards = "3 6", AmountOfBillboards = 2},
            //    new Owner {Name="Sasha Bibilov",  IdBillboards = "4", AmountOfBillboards = 1}
            //};
            //usersGrid.ItemsSource = usersList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           // backEvent.Invoke(sender, e);
           this.NavigationService.Navigate(new AdminRoom());
        }

    }
}

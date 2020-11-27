using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using BillboardsProject.Components;
using System;

namespace BillboardsProject
{
    public partial class Logs : Page
    {
        public event EventHandler backEvent;
        public Logs()
        {
            InitializeComponent();
            //List<Log> usersList = new List<Log>
            //{
            //    new Log {LogTime = new DateTime(2020, 07, 05), LogInformation = "Admin add new user"},
            //    new Log {LogTime = new DateTime(2020, 07, 06), LogInformation = "Admin add new billboard"},
            //    new Log {LogTime = new DateTime(2020, 07, 08), LogInformation = "Admin add new user"},

            //};
            //logsGrid.ItemsSource = usersList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new AdminRoom());
        }
    }
}

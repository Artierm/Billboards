using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using BillboardsProject.Components;
using System;

namespace BillboardsProject
{
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            InitializeComponent();
            List<Log> usersList = new List<Log>
            {
                new Log {LogTime = new DateTime(2020, 07, 05), LogInformation = "Admin add new user"},
                new Log {LogTime = new DateTime(2020, 07, 06), LogInformation = "Admin add new billboard"},
                new Log {LogTime = new DateTime(2020, 07, 08), LogInformation = "Admin add new user"},
            };
            logsGrid.ItemsSource = usersList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoomPage());
        }
    }
}

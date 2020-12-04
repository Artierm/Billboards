using BillboardsProject.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
            //List<Owner> sheduleList = new List<Owner>
            //{
            //    new Owner {Name="Shedule1", IdBillboards="1 2 5", AmountOfBillboards= 3},
            //    new Owner {Name="Shedule2", IdBillboards="3 6", AmountOfBillboards= 2},
            //    new Owner {Name="Shedule3", IdBillboards="4", AmountOfBillboards= 1}
            //};
            //shedulesGrid.ItemsSource = sheduleList;
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserRoomPage());
        }

        public void Button_Click_CreateSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateSchedulePage());
        }

    }
}

using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    /// <summary>
    /// Логика взаимодействия для Create_NewBillboard.xaml
    /// </summary>
    public partial class CreateNewBillboard : Page, IRegistration
    {
        public IRegistration ibillboardCreate;
        public delegate void AddBillboardDelegate(object sender, EventArgs e, string address);
        public event AddBillboardDelegate addBillboardEvent;
        public string BillboardCreateAddress { get => billboard_address.Text.Trim(); set => billboard_address.Text = value.Trim(); }
        public CreateNewBillboard()
        {
            InitializeComponent();
            CreateNewBillboardPresent createNewBillboardPresent = new CreateNewBillboardPresent(this);
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new AdminBillboards());
        }
        public void Button_AddBillboard(object sender, RoutedEventArgs e)
        {
            addBillboardEvent.Invoke(sender, e, BillboardCreateAddress);
            this.NavigationService.Navigate(new AdminBillboards());
        }
    }
}

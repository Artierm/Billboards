using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class CreateNewBillboardPage : Page, IRegistration
    {
        private IRegistration ibillboardCreate;

        public delegate void AddBillboardDelegate(object sender, EventArgs e, string address);
        public event AddBillboardDelegate AddBillboardEvent;
        public string BillboardCreateAddress { get => billboard_address.Text.Trim(); set => billboard_address.Text = value.Trim(); }
        public CreateNewBillboardPage()
        {
            InitializeComponent();
            CreateNewBillboardPresenter createNewBillboardPresenter = new CreateNewBillboardPresenter(this);
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
        public void Button_Click_AddBillboard(object sender, RoutedEventArgs e)
        {
            AddBillboardEvent.Invoke(sender, e, BillboardCreateAddress);
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
    }
}

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
        private CreateNewBillboardPresenter _createNewBillboardPresenter;
        public string BillboardCreateAddress { get => billboard_address.Text.Trim(); set => billboard_address.Text = value.Trim(); }
        public CreateNewBillboardPage()
        {
            InitializeComponent();
            _createNewBillboardPresenter = new CreateNewBillboardPresenter();
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
        public void Button_Click_AddBillboard(object sender, RoutedEventArgs e)
        {
            _createNewBillboardPresenter.AddBillboard(BillboardCreateAddress);
            this.NavigationService.Navigate(new AdminBillboardsPage());
        }
    }
}

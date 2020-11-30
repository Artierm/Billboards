using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillboardsProject
{
    public partial class RegisterBillboardPage : Page
    { 
        public event RoutedEventHandler RegisterBillboardEvent;
        private DatabaseContext database;

        public RegisterBillboardPage()
        {
            InitializeComponent();
            database = new DatabaseContext();

            List<Billboard> billboards = database.Billboards.ToList();
            var newBillboards = billboards.Where(c => c.Owner == string.Empty);
            billsGrid.ItemsSource = newBillboards;
            RegisterBillboardPresenter registerBillboardPresenter = new RegisterBillboardPresenter(this);
        }

        public void Button_Click_Register_Billboard(object sender, RoutedEventArgs e)
        {
            RegisterBillboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboardsPage());
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserBillboardsPage());
        }       
    }
}

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
    /// <summary>
    /// Логика взаимодействия для RegisterBillboard.xaml
    /// </summary>
    public partial class RegisterBillboard : Page
    { 
        //IRegistrationBillboard
    
        public event RoutedEventHandler RegisterBillboardEvent;
        public event EventHandler BackEvent;
        private ApplicationContext database;

       //public string IdRegistrationBillboard { get => ; set => id_billboard.Text = value.Trim(); }
       // public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        public RegisterBillboard()
        {
            InitializeComponent();
            database = new ApplicationContext();
            List<Billboard> billboards = database.Billboards.ToList();
            var newBillboards = billboards.Where(c => c.Owner == string.Empty);
            billsGrid.ItemsSource = newBillboards;
            RegisterBillboardPresent registerBillboardPresent = new RegisterBillboardPresent(this);
        }

        public void Button_Click_Register_Billboard(object sender, RoutedEventArgs e)
        {
            RegisterBillboardEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
            //string address = string.Empty;
            //List<Billboard> billboards = database.Billboards.ToList();
            //List<User> users = database.Users.ToList();
            //Button btnSender = (Button)sender;
            //var dataContextFromBtn = (Billboard)btnSender.DataContext;     
            //MessageBox.Show(dataContextFromBtn.Address);
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
        }       
    }
}

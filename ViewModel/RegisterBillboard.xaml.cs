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
        public event RoutedEventHandler RegisterBillboardEvent;
        public event EventHandler BackEvent;
        private ApplicationContext database;

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
            List<Billboard> users = database.Billboards.ToList();
            var billboards = users.Where(c => c.Address == string.Empty);
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.OriginalSource).DataContext;
                int idBillboard = Convert.ToInt32(dataRowView[1].ToString());
                string address = dataRowView[3].ToString();
                var billboardCheck = billboards.ToList().Find(c => c.Id == idBillboard);
                var owner = database.Users.ToList().Find(c => c.Id == Authorization.IdUser);
                billboardCheck.Owner = owner.Login;
                database.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           // RegisterBillboardEvent.Invoke(sender, e);
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //backEvent.Invoke(sender, e);
            this.NavigationService.Navigate(new UserBillboards());
        }
    }
}

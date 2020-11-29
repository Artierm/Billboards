using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : Page, ICreateUsers
    {
        private ICreateUsers icreateUsers;
        public delegate void AddNewUserDelegate(object sender, EventArgs e, string login, string password, string passordRepeat);
        public event AddNewUserDelegate AddNewUserEvent;
        
        public string UserLogin { get => user_login.Text.Trim(); set => user_login.Text = value.Trim(); }
        public string UserPassword { get => user_password.Password.Trim(); set => user_password.Password = value.Trim(); }

        public string UserPasswordRepeat { get => user_password_repeat.Password.Trim(); set => user_password_repeat.Password = value.Trim(); }
        public CreateNewUser()
        {          
            InitializeComponent();
            CreateNewUserPresent createNewUserPresent = new CreateNewUserPresent(this);
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            AddNewUserEvent.Invoke(sender, e, UserLogin, UserPassword, UserPasswordRepeat);
            this.NavigationService.Navigate(new CrudUser());
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new CrudUser());
        }
    }
}

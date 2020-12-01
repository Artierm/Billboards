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
    public partial class CreateNewUserPage : Page, ICreateUsers
    {
        private CreateNewUserPresenter _createNewUserPresenter;
        public string UserLogin { get => user_login.Text.Trim(); set => user_login.Text = value.Trim(); }
        public string UserPassword { get => user_password.Password.Trim(); set => user_password.Password = value.Trim(); }

        public string UserPasswordRepeat { get => user_password_repeat.Password.Trim(); set => user_password_repeat.Password = value.Trim(); }
        public CreateNewUserPage()
        {          
            InitializeComponent();
            _createNewUserPresenter = new CreateNewUserPresenter();
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
             _createNewUserPresenter.CreateUser(UserLogin, UserPassword, UserPasswordRepeat);
            this.NavigationService.Navigate(new CrudUserPage());
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CrudUserPage());
        }
    }
}

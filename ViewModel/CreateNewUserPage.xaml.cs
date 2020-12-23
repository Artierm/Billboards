using BillboardProject.Model;
using BillboardProject.Service;
using DAL.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;

namespace BillboardProject
{
    public partial class CreateNewUserPage : Page, ICreateUsers
    {
        private readonly CreateNewUserService _createNewUserService;
        public string UserLogin { get => user_login.Text.Trim(); set => user_login.Text = value.Trim(); }
        public string UserPassword { get => user_password.Password.Trim(); set => user_password.Password = value.Trim(); }

        public string UserPasswordRepeat { get => user_password_repeat.Password.Trim(); set => user_password_repeat.Password = value.Trim(); }
        public CreateNewUserPage()
        {          
            InitializeComponent();
            _createNewUserService = new CreateNewUserService(new CreateNewUserRepository(), new CreateNewLogRepository());
        }

        public void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
             _createNewUserService.CreateUser(UserLogin, UserPassword, UserPasswordRepeat);
            this.NavigationService.Navigate(new CrudUserPage());
        }

        public void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CrudUserPage());
        }
    }
}

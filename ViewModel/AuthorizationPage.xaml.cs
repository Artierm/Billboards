using Billbort.Presenter;
using Billbort.ViewModel;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Billbort
{
    public partial class AuthorizationPage : Page, IAuthorization
    {
        private AuthorizationService _authorizationService;
        public static int UserId { get; set; }

        public string AuthorizationLogin { get => authorization_login.Text.Trim(); set => authorization_login.Text = value.Trim(); }
        public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        public AuthorizationPage()
        {
            InitializeComponent();
            _authorizationService = new AuthorizationService(new CreateNewUserRepository());
        }

        public void Button_Click_Log_In(object sender, RoutedEventArgs e)
        {
            if (_authorizationService.CheckUser(AuthorizationLogin, AuthorizationPassword, out bool admin, out int userId))
            {
                if (admin)
                {
                    this.NavigationService.Navigate(new AdminRoomPage());
                }
                else
                {
                    this.NavigationService.Navigate(new UserRoomPage());
                }
                UserId = userId;
            }
            else
            {
                string errorMessage = FormattableString.Invariant($"Password or login is incorrect");
                MessageBox.Show(errorMessage);
            }
        }

        public void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new RegistrationPage());
        }

    }
}

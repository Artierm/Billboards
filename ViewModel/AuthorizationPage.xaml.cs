using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class AuthorizationPage : Page, IAuthorization
    {
        public static int UserId { get; set; }

        private ICreateBillboard registrationView;
       // private IAuthorizationService _authorizationService;// подсказад Шпак
        public delegate bool AuthorizationHandler(object sender, EventArgs e, string login, string password, out bool admin, out int idUser);

        public event AuthorizationHandler UserEvent;
        public event EventHandler RegistrationEvent;


        public string AuthorizationLogin { get => authorization_login.Text.Trim(); set => authorization_login.Text = value.Trim(); }
        public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        public AuthorizationPage()
        {
            InitializeComponent();
            AuthorizationPresenter authorizationPresenter = new AuthorizationPresenter(this);
            //_authorizationService = new AuthorizationService();// подсказал Шпак
        }

        public void Button_Click_Log_In(object sender, RoutedEventArgs e)
        {
            //if(_authorizationService.UserEvent(AuthorizationLogin, AuthorizationPassword, out bool admin, out int userId))
            //{

            //}

            if(UserEvent.Invoke(sender, e, AuthorizationLogin, AuthorizationPassword, out bool admin, out int userId))
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
           this.NavigationService.Navigate(new RegistrationPage(registrationView));
        }

    }
}

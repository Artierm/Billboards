using BillboardsProject.Presents;
using BillboardsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BillboardsProject
{
    public partial class Authorization : Page, IAuthorization
    {
        public IRegistration registrationView;
        public delegate bool AuthorizationHandler(object sender, EventArgs e, string login, string password);
        public event EventHandler AdminEvent;
        public event AuthorizationHandler UserEvent;
        public event EventHandler RegistrationEvent;

        public string AuthorizationLogin { get => authorization_login.Text.Trim(); set => authorization_login.Text = value.Trim(); }
        public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        // private ApplicationContext _context;
        public Authorization()
        {
            //_context = new ApplicationContext();
            //List<User> users = _context.Users.ToList();
            InitializeComponent();
            AuthorizationPresent authorizationPresent = new AuthorizationPresent(this);
        }

        public void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminRoom());

        }

        public void Button_Click_User(object sender, RoutedEventArgs e)
        {
            if(UserEvent.Invoke(sender, e, AuthorizationLogin, AuthorizationPassword))
            {
                this.NavigationService.Navigate(new UserRoom());
            }
            else
            {
                string errorMessage = FormattableString.Invariant($"Password or login is incorrect");
                MessageBox.Show(errorMessage);
            }
        }

        public void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new Registration(registrationView));
        }

    }
}

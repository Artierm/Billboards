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
        public delegate void AuthorizationHandler();
        public event EventHandler AdminEvent;
        public event EventHandler UserEvent;
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
            this.NavigationService.Navigate(new UserRoom());
        }

        public void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new Registration(registrationView));
        }

    }
}

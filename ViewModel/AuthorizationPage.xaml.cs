using BillboardsProject.Model.Interfaces;
using BillboardProject.Presenter;
using BillboardProject.ViewModel;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BillboardProject
{
    public partial class AuthorizationPage : Page, IAuthorization, ITime
    {
        private readonly AuthorizationService _authorizationService;
        public string Time { get => time.Text; set => time.Text = value.ToString(); }
        public static int UserId { get; set; }

        public string AuthorizationLogin { get => authorization_login.Text.Trim(); set => authorization_login.Text = value.Trim(); }
        public string AuthorizationPassword { get => authorization_password.Password.Trim(); set => authorization_password.Password = value.Trim(); }
        public AuthorizationPage()
        {
           // StartClock();
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

        public void StartClock()
        {
            DispatcherTimer dispstcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            dispstcherTimer.Tick += TickEvent;
            dispstcherTimer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToString();
        }
    }
}

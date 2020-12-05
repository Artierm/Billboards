using Billbort.Presents;
using Billbort.ViewModel;
using DAL.Repositories.Implementations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Billbort
{
    public partial class RegistrationPage : Page, ICreateBillboard
    {
        private RegistrationService _registrationService;
        public string RegistrationLogin { get => textBoxLogin.Text.Trim(); set => textBoxLogin.Text = value.Trim(); }
        public string RegistrationPassword { get => pass_box.Password.Trim(); set => pass_box.Password = value.Trim(); }
        public string RegistrationPasswordRepeat { get => pass_box2.Password.Trim(); set => pass_box2.Password = value.Trim(); }

        public RegistrationPage()
        {
            InitializeComponent();
            _registrationService = new RegistrationService(new CreateNewUserRepository());
        }

        public   void Button_Click_Authorization(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage());
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                if (_registrationService.AddNewUser(RegistrationLogin, RegistrationPassword, RegistrationPasswordRepeat, out bool admin))
                {
                    if (admin)
                    {
                        this.NavigationService.Navigate(new AdminRoomPage());
                    }
                    else
                    {
                        this.NavigationService.Navigate(new UserRoomPage());
                    }
                }
            }
       
        }

        public bool Validation()
        {
            bool validationParametr = true;
            RegistrationLogin = textBoxLogin.Text;
            RegistrationPassword = pass_box.Password;
            RegistrationPasswordRepeat = pass_box2.Password;
            string login = RegistrationLogin;
            string password = RegistrationPassword;
            string passwordRepeat = RegistrationPasswordRepeat;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Некорректный логин";
                textBoxLogin.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else if (password.Length < 7)
            {
                pass_box.ToolTip = "Некорректный пароль";
                pass_box.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else if (password != passwordRepeat)
            {
                pass_box2.ToolTip = "Некорректный пароль";
                pass_box2.Background = Brushes.IndianRed;
                validationParametr = false;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                pass_box.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                pass_box2.ToolTip = "";
                textBoxLogin.Background = Brushes.White;
                validationParametr = true;
            }
            return validationParametr;
        }
    }
}
